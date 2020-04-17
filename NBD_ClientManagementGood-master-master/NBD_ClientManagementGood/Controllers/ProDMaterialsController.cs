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
    public class ProDMaterialsController : Controller
    {
        private readonly NBD_ClientManagementGoodContext _context;

        public ProDMaterialsController(NBD_ClientManagementGoodContext context)
        {
            _context = context;
        }

        // GET: ProDMaterials
        public async Task<IActionResult> Index()
        {
            var nBD_ClientManagementGoodContext = _context.ProDMaterial.Include(p => p.Project);
            return View(await _context.ProDMaterial.ToListAsync());
        }

        // GET: ProDMaterials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proDMaterial = await _context.ProDMaterial
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (proDMaterial == null)
            {
                return NotFound();
            }

            return View(proDMaterial);
        }

        // GET: ProDMaterials/Create
        public IActionResult Create()
        {
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name");
            return View();
        }

        // POST: ProDMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Code,Qty,Net,Submitter,SubmissionDate,ProjectID")] ProDMaterial proDMaterial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proDMaterial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", proDMaterial.ProjectID);
            return View(proDMaterial);
        }

        // GET: ProDMaterials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proDMaterial = await _context.ProDMaterial.FindAsync(id);
            if (proDMaterial == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", proDMaterial.ProjectID);
            return View(proDMaterial);
        }

        // POST: ProDMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Code,Qty,Net,Submitter,SubmissionDate,ProjectID")] ProDMaterial proDMaterial)
        {
            if (id != proDMaterial.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proDMaterial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProDMaterialExists(proDMaterial.ID))
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
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "Name", proDMaterial.ProjectID);
            return View(proDMaterial);
        }

        // GET: ProDMaterials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proDMaterial = await _context.ProDMaterial
                .FirstOrDefaultAsync(m => m.ID == id);
            if (proDMaterial == null)
            {
                return NotFound();
            }

            return View(proDMaterial);
        }

        // POST: ProDMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proDMaterial = await _context.ProDMaterial.FindAsync(id);
            _context.ProDMaterial.Remove(proDMaterial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProDMaterialExists(int id)
        {
            return _context.ProDMaterial.Any(e => e.ID == id);
        }
    }
}
