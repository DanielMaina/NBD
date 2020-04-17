using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBD_ClientManagementGood.Data;
using NBD_ClientManagementGood.Models;

namespace NBD_ClientManagementGood.Controllers
{
    public class ProDLaboursController : Controller
    {
        private readonly NBD_ClientManagementGoodContext _context;

        public ProDLaboursController(NBD_ClientManagementGoodContext context)
        {
            _context = context;
        }

        // GET: ProDLabours
        public async Task<IActionResult> Index()
        {
            var nBD_ClientManagementGoodContext = _context.ProDLabour.Include(p => p.Project);
            return View(await nBD_ClientManagementGoodContext.ToListAsync());
        }

        // GET: ProDLabours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proDLabour = await _context.ProDLabour
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (proDLabour == null)
            {
                return NotFound();
            }

            return View(proDLabour);
        }

        // GET: ProDLabours/Create
        public IActionResult Create()
        {
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name");
            return View();
        }

        // POST: ProDLabours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Hours,CurrentHours,TaskName,Submitter,SubmissionDate,ProjectID")] ProDLabour proDLabour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proDLabour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", proDLabour.ProjectID);
            return View(proDLabour);
        }

        // GET: ProDLabours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proDLabour = await _context.ProDLabour.FindAsync(id);
            if (proDLabour == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", proDLabour.ProjectID);
            return View(proDLabour);
        }

        // POST: ProDLabours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Hours,CurrentHours,TaskName,Submitter,SubmissionDate,ProjectID")] ProDLabour proDLabour)
        {
            if (id != proDLabour.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proDLabour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProDLabourExists(proDLabour.ID))
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
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", proDLabour.ProjectID);
            return View(proDLabour);
        }

        // GET: ProDLabours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proDLabour = await _context.ProDLabour
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (proDLabour == null)
            {
                return NotFound();
            }

            return View(proDLabour);
        }

        // POST: ProDLabours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proDLabour = await _context.ProDLabour.FindAsync(id);
            _context.ProDLabour.Remove(proDLabour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProDLabourExists(int id)
        {
            return _context.ProDLabour.Any(e => e.ID == id);
        }
    }
}
