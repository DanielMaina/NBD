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
    public class PotteriesController : Controller
    {
        private readonly NBD_ClientManagementGoodContext _context;

        public PotteriesController(NBD_ClientManagementGoodContext context)
        {
            _context = context;
        }

        // GET: Potteries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pottery.ToListAsync());
        }

        // GET: Potteries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pottery = await _context.Pottery
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pottery == null)
            {
                return NotFound();
            }

            return View(pottery);
        }

        // GET: Potteries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Potteries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Features,List,OIS,IS_OB")] Pottery pottery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pottery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pottery);
        }

        // GET: Potteries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pottery = await _context.Pottery.FindAsync(id);
            if (pottery == null)
            {
                return NotFound();
            }
            return View(pottery);
        }

        // POST: Potteries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Features,List,OIS,IS_OB")] Pottery pottery)
        {
            if (id != pottery.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pottery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PotteryExists(pottery.ID))
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
            return View(pottery);
        }

        // GET: Potteries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pottery = await _context.Pottery
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pottery == null)
            {
                return NotFound();
            }

            return View(pottery);
        }

        // POST: Potteries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pottery = await _context.Pottery.FindAsync(id);
            _context.Pottery.Remove(pottery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PotteryExists(int id)
        {
            return _context.Pottery.Any(e => e.ID == id);
        }
    }
}
