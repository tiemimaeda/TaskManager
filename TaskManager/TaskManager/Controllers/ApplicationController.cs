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
    public class ApplicationController : Controller
    {
        private readonly DataContext _context;

        public ApplicationController(DataContext context)
        {
            _context = context;
        }

        // GET: Application
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Applications;
            return View(await dataContext.ToListAsync());
        }
        
        // GET: Application/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Application());
            else
                return View(_context.Applications.Find(id));
        }

        // POST: Application/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(Application application)
        {
            if (ModelState.IsValid)
            {
                if (application.Id == 0)
                    _context.Add(application);
                else
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
            }
            return View(application);
        }

        // GET: Application/Delete/Id
        public async Task<IActionResult> Delete(int? id)
        {
            var application = await _context.Applications.FindAsync(id);
            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
