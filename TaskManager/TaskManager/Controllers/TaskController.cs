﻿using System;
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
    public class TaskController : Controller
    {
        private readonly DataContext _context;

        public TaskController(DataContext context)
        {
            _context = context;
        }

        // GET: Task
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Tasks.Include(t => t.Application).Include(t => t.User);
            return View(await dataContext.ToListAsync());
        }

        // GET: Task/Create
        public IActionResult Create(int id=0)
        {
            ViewData["ApplicationId"] = new SelectList(_context.Applications, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name");
            return View(new Models.Task());
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RequestedDate,UserId,Description,StartDate,EndDate,Complexity,ApplicationId,Status")] Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationId"] = new SelectList(_context.Applications, "Id", "Name", task.ApplicationId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", task.UserId);
            return View(task);
        }

        // GET: Task/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .Include(t => t.Application)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }
    }
}
