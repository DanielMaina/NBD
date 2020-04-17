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
    public class DesignBudgetsController : Controller
    {
        private readonly NBD_ClientManagementGoodContext _context;

        public DesignBudgetsController(NBD_ClientManagementGoodContext context)
        {
            _context = context;
        }

        // GET: DesignBudgets
        public async Task<IActionResult> Index()
        {
            var nBD_ClientManagementGoodContext = _context.DesignBudget.Include(d => d.Project);
            return View(await nBD_ClientManagementGoodContext.ToListAsync());
        }

        // GET: DesignBudgets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designBudget = await _context.DesignBudget
                .Include(d => d.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (designBudget == null)
            {
                return NotFound();
            }

            return View(designBudget);
        }

        // GET: DesignBudgets/Create
        public IActionResult Create()
        {
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name");
            return View();
        }

        // POST: DesignBudgets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CurrentHours,EstHours,HoursTotal,SubmissionDate,Submitter,ProjectID")] DesignBudget designBudget)
        {
            if (ModelState.IsValid)
            {
                _context.Add(designBudget);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", designBudget.ProjectID);
            return View(designBudget);
        }

        // GET: DesignBudgets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designBudget = await _context.DesignBudget.FindAsync(id);
            if (designBudget == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", designBudget.ProjectID);
            return View(designBudget);
        }

        // POST: DesignBudgets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CurrentHours,EstHours,HoursTotal,SubmissionDate,Submitter,ProjectID")] DesignBudget designBudget)
        {
            if (id != designBudget.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(designBudget);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesignBudgetExists(designBudget.ID))
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
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", designBudget.ProjectID);
            return View(designBudget);
        }

        // GET: DesignBudgets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designBudget = await _context.DesignBudget
                .Include(d => d.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (designBudget == null)
            {
                return NotFound();
            }

            return View(designBudget);
        }

        // POST: DesignBudgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var designBudget = await _context.DesignBudget.FindAsync(id);
            _context.DesignBudget.Remove(designBudget);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesignBudgetExists(int id)
        {
            return _context.DesignBudget.Any(e => e.ID == id);
        }
    }
}
