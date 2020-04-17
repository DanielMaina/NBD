using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBD_ClientManagementGood.Data;
using NBD_ClientManagementGood.Models;
using NBD_ClientManagementGood.ViewModel;

namespace NBD_ClientManagementGood.Controllers
{
    [Authorize(Roles = "Admin,Supervisor")]
    public class BidsController : Controller
    {
        private readonly NBD_ClientManagementGoodContext _context;

        public BidsController(NBD_ClientManagementGoodContext context)
        {
            _context = context;
        }

        // GET: Bids
        public async Task<IActionResult> Index()
        {
            var bids = from s in _context.Bids
                .Include(s => s.InvBids).ThenInclude(s => s.Item)
                .Include(s => s.Project)
                       select s;
            return View(await bids.ToListAsync());
        }

        // GET: Bids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bids
                .Include(b => b.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        //GET: Bids/Create
        public IActionResult Create()
        {
            Bid bid = new Bid();
            PopulateAssignedItemData(bid);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name");
            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BlueprintCode,EstStart,EstEnd,Amount,Location,ProjectID")] Bid bid, string[] selectedOptions)
        {
            try
            {
                UpdateItems(selectedOptions, bid);
                if (ModelState.IsValid)
                {
                    _context.Add(bid);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Something went wrong in the database.");
            }
            PopulateAssignedItemData(bid);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", bid.ProjectID);
            return View(bid);
        }

        // GET: Bids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bids
                   .Include(d => d.InvBids).ThenInclude(d => d.Item)
                   .Include(d => d.Project)
                   .AsNoTracking()
                   .SingleOrDefaultAsync(d => d.ID == id);

            if (bid == null)
            {
                return NotFound();
            }
            PopulateAssignedItemData(bid);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", bid.ProjectID);
            return View(bid);
        }

        // POST: Bids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id/*, [Bind("ID,BlueprintCode,EstStart,EstEnd,Amount,Location,ProjectID")] Bid bid*/, string[] selectedOptions)
        {

            var bidToUpdate = await _context.Bids
                .Include(d => d.InvBids).ThenInclude(d => d.Item)
                .Include(d => d.Project)
                .SingleOrDefaultAsync(d => d.ID == id);

            if (bidToUpdate == null)
            {
                return NotFound();
            }

            UpdateItems(selectedOptions, bidToUpdate);

            if (await TryUpdateModelAsync<Bid>(bidToUpdate, "", d => d.BlueprintCode, d => d.EstEnd, d => d.EstStart, d => d.Amount, d => d.Location))
            {
                try
                {
                    _context.Update(bidToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidExists(bidToUpdate.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateAssignedItemData(bidToUpdate);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", bidToUpdate.ProjectID);
            return View(bidToUpdate);
        }

        // GET: Bids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bids
                .Include(b => b.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // POST: Bids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bid = await _context.Bids.FindAsync(id);
            _context.Bids.Remove(bid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void PopulateAssignedItemData(Bid bid)
        {
            var allItem = _context.Item;
            var bidItem = new HashSet<int>(bid.InvBids.Select(b => b.ItemID));
            var selected = new List<OptionVM>();
            var available = new List<OptionVM>();
            foreach (var s in allItem)
            {
                if (bidItem.Contains(s.ID))
                {
                    selected.Add(new OptionVM
                    {
                        ID = s.ID,
                        DisplayText = s.Code
                    });
                }
                else
                {
                    available.Add(new OptionVM
                    {
                        ID = s.ID,
                        DisplayText = s.Code
                    });
                }
            }

            ViewData["selOpts"] = new MultiSelectList(selected.OrderBy(s => s.DisplayText), "ID", "DisplayText");
            ViewData["availOpts"] = new MultiSelectList(available.OrderBy(s => s.DisplayText), "ID", "DisplayText");
        }

        private void UpdateItems(string[] selectedOptions, Bid bidToUpdate)
        {
            if (selectedOptions == null)
            {
                bidToUpdate.InvBids = new List<InvBid>();
                return;
            }

            var selectedOptionsHS = new HashSet<string>(selectedOptions);
            var bidItems = new HashSet<int>(bidToUpdate.InvBids.Select(b => b.ItemID));
            foreach (var s in _context.Item)
            {
                if (selectedOptionsHS.Contains(s.ID.ToString()))
                {
                    if (!bidItems.Contains(s.ID))
                    {
                        bidToUpdate.InvBids.Add(new InvBid
                        {
                            ItemID = s.ID,
                            BidID = bidToUpdate.ID
                        });
                    }
                }
                else
                {
                    if (bidItems.Contains(s.ID))
                    {
                        InvBid specToRemove = bidToUpdate.InvBids.SingleOrDefault(d => d.ItemID == s.ID);
                        _context.Remove(specToRemove);
                    }
                }
            }
        }

        private bool BidExists(int id)
        {
            return _context.Bids.Any(e => e.ID == id);
        }
    }
}
