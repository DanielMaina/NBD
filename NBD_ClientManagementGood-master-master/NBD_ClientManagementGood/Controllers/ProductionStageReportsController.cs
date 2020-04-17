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
    public class ProductionStageReportsController : Controller
    {
        private readonly NBD_ClientManagementGoodContext _context;

        public ProductionStageReportsController(NBD_ClientManagementGoodContext context)
        {
            _context = context;
        }

        // GET: ProductionStageReports
        public async Task<IActionResult> Index()
        {
            var nBD_ClientManagementGoodContext = _context.ProductionStageReports.Include(p => p.Project);
            return View(await nBD_ClientManagementGoodContext.ToListAsync());
        }

        // GET: ProductionStageReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionStageReport = await _context.ProductionStageReports
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productionStageReport == null)
            {
                return NotFound();
            }

            return View(productionStageReport);
        }

        // GET: ProductionStageReports/Create
        public IActionResult Create()
        {
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name");
            return View();
        }

        // POST: ProductionStageReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Cost,EstCost,TotalCost,Mtl,EstMtl,LabourProdCost,EstLabourProdCost,DesignCost,EstDesignCost,ProjectID")] ProductionStageReport productionStageReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productionStageReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", productionStageReport.ProjectID);
            return View(productionStageReport);
        }

        // GET: ProductionStageReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionStageReport = await _context.ProductionStageReports.FindAsync(id);
            if (productionStageReport == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", productionStageReport.ProjectID);
            return View(productionStageReport);
        }

        // POST: ProductionStageReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Cost,EstCost,TotalCost,Mtl,EstMtl,LabourProdCost,EstLabourProdCost,DesignCost,EstDesignCost,ProjectID")] ProductionStageReport productionStageReport)
        {
            if (id != productionStageReport.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productionStageReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionStageReportExists(productionStageReport.ID))
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
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", productionStageReport.ProjectID);
            return View(productionStageReport);
        }

        // GET: ProductionStageReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionStageReport = await _context.ProductionStageReports
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (productionStageReport == null)
            {
                return NotFound();
            }

            return View(productionStageReport);
        }

        // POST: ProductionStageReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productionStageReport = await _context.ProductionStageReports.FindAsync(id);
            _context.ProductionStageReports.Remove(productionStageReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionStageReportExists(int id)
        {
            return _context.ProductionStageReports.Any(e => e.ID == id);
        }
    }
}
