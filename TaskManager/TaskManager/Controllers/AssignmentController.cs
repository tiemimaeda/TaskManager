using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManager;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly DataContext _context;

        public AssignmentController(DataContext context)
        {
            _context = context;
        }

        // GET: Assignment
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Assignments.Include(t => t.Application).Include(t => t.User);
            return View(await dataContext.ToListAsync());
        }

        // GET: Assignment/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            ViewData["ApplicationId"] = new SelectList(_context.Applications, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name");
            if (id == 0)
                return View(new Assignment());
            else
                return View(_context.Assignments.Find(id));
        }

        // POST: Assignment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,RequestedDate,UserId,Description,StartDate,EndDate,Complexity,ApplicationId")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                if(assignment.Id == 0)
                    _context.Add(assignment);
                else
                    _context.Update(assignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationId"] = new SelectList(_context.Applications, "Id", "Name", assignment.ApplicationId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", assignment.UserId);
            return View(assignment);
        }

        // GET: Assignment/Delete/
        public async Task<IActionResult> Delete(int? id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
