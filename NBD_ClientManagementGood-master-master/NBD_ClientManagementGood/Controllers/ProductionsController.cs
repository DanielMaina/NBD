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
    [Authorize(Roles = "Assistant,Supervisor")]
    public class ProductionsController : Controller
    {
        private readonly NBD_ClientManagementGoodContext _context;

        public ProductionsController(NBD_ClientManagementGoodContext context)
        {
            _context = context;
        }

        // GET: Productions
        public async Task<IActionResult> Index()
        {
            var productions = from s in _context.Productions
                .Include(s => s.Labour).ThenInclude(s => s.LabourUnit)
                .Include(s => s.Bid)
                              select s;
            return View(await productions.ToListAsync());
        }

        // GET: Productions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var production = await _context.Productions
                .Include(p => p.Bid)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (production == null)
            {
                return NotFound();
            }

            return View(production);
        }

        // GET: Productions/Create
        public IActionResult Create()
        {
            Production production = new Production();
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "BlueprintCode");
            PopulateAssignedUnitData(production);
            return View();
        }

        // POST: Productions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProEstHourly,ProEstMaterialCost,ProBidPercent,BidID")] Production production, string[] selectedOptions)
        {
            try
            {
                UpdateLabourUnits(selectedOptions, production);
                if (ModelState.IsValid)
                {
                    _context.Add(production);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Something went wrong in the database.");
            }
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "BlueprintCode", production.BidID);
            PopulateAssignedUnitData(production);
            return View(production);
        }

        // GET: Productions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var production = await _context.Productions
                .Include(d => d.Labour).ThenInclude(d => d.LabourUnit)
                .Include(d => d.Bid)
                .AsNoTracking()
                .SingleOrDefaultAsync(d => d.ID == id);

            if (production == null)
            {
                return NotFound();
            }
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "BlueprintCode", production.BidID);
            PopulateAssignedUnitData(production);
            return View(production);
        }

        // POST: Productions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,/*, [Bind("ID,ProEstHourly,ProEstMaterialCost,ProEstTotalHours,ProBidPercent,BidID")] */ string[] selectedOptions)
        {

            var productionToUpdate = await _context.Productions
                .Include(d => d.Labour).ThenInclude(d => d.LabourUnit)
                .Include(d => d.Bid)
                .AsNoTracking()
                .SingleOrDefaultAsync(d => d.ID == id);

            if (productionToUpdate == null)
            {
                return NotFound();
            }

            UpdateLabourUnits(selectedOptions, productionToUpdate);

            if (await TryUpdateModelAsync<Production>(productionToUpdate, "", d => d.ProEstHourly, d => d.ProEstMaterialCost, d => d.BidID))
            {
                try
                {
                    _context.Update(productionToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionExists(productionToUpdate.ID))
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
            ViewData["BidID"] = new SelectList(_context.Bids, "ID", "BlueprintCode", productionToUpdate.BidID);
            PopulateAssignedUnitData(productionToUpdate);
            return View(productionToUpdate);
        }

        // GET: Productions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var production = await _context.Productions
                .Include(p => p.Bid)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (production == null)
            {
                return NotFound();
            }

            return View(production);
        }

        // POST: Productions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var production = await _context.Productions.FindAsync(id);
            _context.Productions.Remove(production);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void PopulateAssignedUnitData(Production production)
        {
            var allUnits = _context.LabourUnits;
            var proUnit = new HashSet<int>(production.Labour.Select(b => b.LabourUnitID));
            var selected = new List<OptionVM>();
            var available = new List<OptionVM>();
            foreach (var s in allUnits)
            {
                if (proUnit.Contains(s.ID))
                {
                    selected.Add(new OptionVM
                    {
                        ID = s.ID,
                        DisplayText = s.Description
                    });
                }
                else
                {
                    available.Add(new OptionVM
                    {
                        ID = s.ID,
                        DisplayText = s.Description
                    });
                }
            }

            ViewData["selOpts"] = new MultiSelectList(selected.OrderBy(s => s.DisplayText), "ID", "DisplayText");
            ViewData["availOpts"] = new MultiSelectList(available.OrderBy(s => s.DisplayText), "ID", "DisplayText");
        }
        private void UpdateLabourUnits(string[] selectedOptions, Production unitToUpdate)
        {
            if (selectedOptions == null)
            {
                unitToUpdate.Labour = new List<Labour>();
                return;
            }

            var selectedOptionsHS = new HashSet<string>(selectedOptions);
            var labourStaffs = new HashSet<int>(unitToUpdate.Labour.Select(b => b.LabourUnitID));
            foreach (var s in _context.LabourUnits)
            {
                if (selectedOptionsHS.Contains(s.ID.ToString()))
                {
                    if (!labourStaffs.Contains(s.ID))
                    {
                        unitToUpdate.Labour.Add(new Labour
                        {
                            LabourUnitID = s.ID,
                            ProductionID = unitToUpdate.ID
                        });
                    }
                }
                else
                {
                    if (labourStaffs.Contains(s.ID))
                    {
                        Labour specToRemove = unitToUpdate.Labour.SingleOrDefault(d => d.LabourUnitID == s.ID);
                        _context.Remove(specToRemove);
                    }
                }
            }
        }

        private bool ProductionExists(int id)
        {
            return _context.Productions.Any(e => e.ID == id);
        }
    }
}
