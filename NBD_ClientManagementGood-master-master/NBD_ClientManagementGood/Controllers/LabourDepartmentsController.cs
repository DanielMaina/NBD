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
    public class LabourDepartmentsController : Controller
    {
        private readonly NBD_ClientManagementGoodContext _context;

        public LabourDepartmentsController(NBD_ClientManagementGoodContext context)
        {
            _context = context;
        }

        // GET: LabourDepartments
        public async Task<IActionResult> Index()
        {
            var staffs = from s in _context.LabourDepartments
                .Include(s => s.LabourStaffs).ThenInclude(s => s.Staff)
                .Include(s => s.Production)
                         select s;
            return View(await staffs.ToListAsync());
        }

        // GET: LabourDepartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labourDepartment = await _context.LabourDepartments
                .Include(p => p.Production)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (labourDepartment == null)
            {
                return NotFound();
            }

            return View(labourDepartment);
        }

        // GET: LabourDepartments/Create
        public IActionResult Create()
        {
            LabourDepartment labourDepartment = new LabourDepartment();
            PopulateAssignedStaffData(labourDepartment);
            ViewData["ProductionID"] = new SelectList(_context.Productions, "ID", "ID");
            return View();
        }

        // POST: LabourDepartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,DepartmentDescription,ProductionID")] LabourDepartment labourDepartment, string[] selectedOptions)
        {
            try
            {
                UpdateLabourStaffs(selectedOptions, labourDepartment);
                if (ModelState.IsValid)
                {
                    _context.Add(labourDepartment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Something went wrong in the database.");
            }
            PopulateAssignedStaffData(labourDepartment);
            ViewData["ProductionID"] = new SelectList(_context.Productions, "ID", "ID", labourDepartment.ProductionID);
            return View(labourDepartment);
        }

        // GET: LabourDepartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labourDepartment = await _context.LabourDepartments
                   .Include(d => d.LabourStaffs).ThenInclude(d => d.Staff)
                   .Include(d => d.Production)
                   .AsNoTracking()
                   .SingleOrDefaultAsync(d => d.ID == id);
            if (labourDepartment == null)
            {
                return NotFound();
            }
            PopulateAssignedStaffData(labourDepartment);
            ViewData["ProductionID"] = new SelectList(_context.Productions, "ID", "ID", labourDepartment.ProductionID);
            return View(labourDepartment);
        }

        // POST: LabourDepartments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,DepartmentDescription,ProductionID")] LabourDepartment labourDepartment, string[] selectedOptions)
        {
            var departmentToUpdate = await _context.LabourDepartments
                .Include(d => d.LabourStaffs).ThenInclude(d => d.Staff)
                .SingleOrDefaultAsync(d => d.ID == id);

            if (departmentToUpdate == null)
            {
                return NotFound();
            }

            UpdateLabourStaffs(selectedOptions, departmentToUpdate);

            if (await TryUpdateModelAsync<LabourDepartment>(departmentToUpdate, "", d => d.Name, d => d.DepartmentDescription))
            {
                try
                {
                    _context.Update(departmentToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabourDepartmentExists(departmentToUpdate.ID))
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
            PopulateAssignedStaffData(departmentToUpdate);
            ViewData["ProductionID"] = new SelectList(_context.Productions, "ID", "ID", labourDepartment.ProductionID);
            return View(departmentToUpdate);
        }

        // GET: LabourDepartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labourDepartment = await _context.LabourDepartments
                .FirstOrDefaultAsync(m => m.ID == id);
            if (labourDepartment == null)
            {
                return NotFound();
            }

            return View(labourDepartment);
        }

        // POST: LabourDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labourDepartment = await _context.LabourDepartments.FindAsync(id);
            _context.LabourDepartments.Remove(labourDepartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void PopulateAssignedStaffData(LabourDepartment department)
        {
            var allStaff = _context.Staffs;
            var depStaff = new HashSet<int>(department.LabourStaffs.Select(b => b.StaffID));
            var selected = new List<OptionVM>();
            var available = new List<OptionVM>();
            foreach (var s in allStaff)
            {
                if (depStaff.Contains(s.ID))
                {
                    selected.Add(new OptionVM
                    {
                        ID = s.ID,
                        DisplayText = s.Name
                    });
                }
                else
                {
                    available.Add(new OptionVM
                    {
                        ID = s.ID,
                        DisplayText = s.Name
                    });
                }
            }

            ViewData["selOpts"] = new MultiSelectList(selected.OrderBy(s => s.DisplayText), "ID", "DisplayText");
            ViewData["availOpts"] = new MultiSelectList(available.OrderBy(s => s.DisplayText), "ID", "DisplayText");
        }
        private void UpdateLabourStaffs(string[] selectedOptions, LabourDepartment departmentToUpdate)
        {
            if (selectedOptions == null)
            {
                departmentToUpdate.LabourStaffs = new List<LabourStaff>();
                return;
            }

            var selectedOptionsHS = new HashSet<string>(selectedOptions);
            var labourStaffs = new HashSet<int>(departmentToUpdate.LabourStaffs.Select(b => b.StaffID));
            foreach (var s in _context.Staffs)
            {
                if (selectedOptionsHS.Contains(s.ID.ToString()))
                {
                    if (!labourStaffs.Contains(s.ID))
                    {
                        departmentToUpdate.LabourStaffs.Add(new LabourStaff
                        {
                            StaffID = s.ID,
                            LabourDeparmentID = departmentToUpdate.ID
                        });
                    }
                }
                else
                {
                    if (labourStaffs.Contains(s.ID))
                    {
                        LabourStaff specToRemove = departmentToUpdate.LabourStaffs.SingleOrDefault(d => d.StaffID == s.ID);
                        _context.Remove(specToRemove);
                    }
                }
            }
        }

        private bool LabourDepartmentExists(int id)
        {
            return _context.LabourDepartments.Any(e => e.ID == id);
        }
    }
}
