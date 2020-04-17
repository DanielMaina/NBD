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

namespace NBD_ClientManagementGood.Controllers
{
    [Authorize(Roles = "Admin,Assistant,Supervisor")]
    public class BidStageReportsController : Controller
    {
        private readonly NBD_ClientManagementGoodContext _context;

        public BidStageReportsController(NBD_ClientManagementGoodContext context)
        {
            _context = context;
        }

        // GET: BidStageReports
        public async Task<IActionResult> Index()
        {
            var nBD_ClientManagementGoodContext = _context.BidStageReports.Include(b => b.Project);
            return View(await nBD_ClientManagementGoodContext.ToListAsync());
        }

        // GET: BidStageReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidStageReport = await _context.BidStageReports
                .Include(b => b.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bidStageReport == null)
            {
                return NotFound();
            }

            return View(bidStageReport);
        }

        // GET: BidStageReports/Create
        public IActionResult Create()
        {
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name");
            return View();
        }

        // POST: BidStageReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EstBID,Hours,EstHours,Costs,EstCost,HoursRemaining,CostsRemaining,ProjectID")] BidStageReport bidStageReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bidStageReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", bidStageReport.ProjectID);
            return View(bidStageReport);
        }

        // GET: BidStageReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidStageReport = await _context.BidStageReports.FindAsync(id);
            if (bidStageReport == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", bidStageReport.ProjectID);
            return View(bidStageReport);
        }

        // POST: BidStageReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EstBID,Hours,EstHours,Costs,EstCost,HoursRemaining,CostsRemaining,ProjectID")] BidStageReport bidStageReport)
        {
            if (id != bidStageReport.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bidStageReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidStageReportExists(bidStageReport.ID))
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
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", bidStageReport.ProjectID);
            return View(bidStageReport);
        }

        // GET: BidStageReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bidStageReport = await _context.BidStageReports
                .Include(b => b.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bidStageReport == null)
            {
                return NotFound();
            }

            return View(bidStageReport);
        }

        // POST: BidStageReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bidStageReport = await _context.BidStageReports.FindAsync(id);
            _context.BidStageReports.Remove(bidStageReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BidStageReportExists(int id)
        {
            return _context.BidStageReports.Any(e => e.ID == id);
        }
    }
}
