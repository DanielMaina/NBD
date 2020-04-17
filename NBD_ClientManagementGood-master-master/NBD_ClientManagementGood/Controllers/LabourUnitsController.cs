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
    [Authorize(Roles = "Assistant,Supervisor")]
    public class LabourUnitsController : Controller
    {
        private readonly NBD_ClientManagementGoodContext _context;

        public LabourUnitsController(NBD_ClientManagementGoodContext context)
        {
            _context = context;
        }

        // GET: LabourUnits
        public async Task<IActionResult> Index()
        {
            return View(await _context.LabourUnits.ToListAsync());
        }

        // GET: LabourUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labourUnit = await _context.LabourUnits
                .FirstOrDefaultAsync(m => m.ID == id);
            if (labourUnit == null)
            {
                return NotFound();
            }

            return View(labourUnit);
        }

        // GET: LabourUnits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LabourUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,Hours,Cost,EstCost,TaskName,TaskDescription")] LabourUnit labourUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labourUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labourUnit);
        }

        // GET: LabourUnits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labourUnit = await _context.LabourUnits.FindAsync(id);
            if (labourUnit == null)
            {
                return NotFound();
            }
            return View(labourUnit);
        }

        // POST: LabourUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,Hours,Cost,EstCost,TaskName,TaskDescription")] LabourUnit labourUnit)
        {
            if (id != labourUnit.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labourUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabourUnitExists(labourUnit.ID))
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
            return View(labourUnit);
        }

        // GET: LabourUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labourUnit = await _context.LabourUnits
                .FirstOrDefaultAsync(m => m.ID == id);
            if (labourUnit == null)
            {
                return NotFound();
            }

            return View(labourUnit);
        }

        // POST: LabourUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labourUnit = await _context.LabourUnits.FindAsync(id);
            _context.LabourUnits.Remove(labourUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabourUnitExists(int id)
        {
            return _context.LabourUnits.Any(e => e.ID == id);
        }
    }
}
