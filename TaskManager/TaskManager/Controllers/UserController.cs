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
    public class UserController : Controller
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Users;
            return View(await dataContext.ToListAsync());
        }

        // GET: User/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new User());
            else
                return View(_context.Users.Find(id));
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(User user)
        {
            if (ModelState.IsValid)
            {
               if(user.Id == 0)
                _context.Add(user);
               else
                _context.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Delete/Id
        public async Task<IActionResult> Delete(int? id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
