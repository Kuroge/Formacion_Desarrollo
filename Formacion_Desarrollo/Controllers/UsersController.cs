using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Formacion_Desarrollo.Data;
using Formacion_Desarrollo.Models;
using Formacion_Desarrollo.ViewModels;

namespace Formacion_Desarrollo.Controllers
{
    public class UsersController : Controller
    {
        private readonly Formacion_DesarrolloContext _context;

        public UsersController(Formacion_DesarrolloContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var query = from u in _context.User
                        join d in _context.Department on u.DepartmentId equals d.Id
                        select new VMUserList()
                        {
                            User = u,
                            Department = d.Name
                        };

            return View(await query.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var user = await _context.User
            //    .SingleOrDefaultAsync(m => m.Id == id);
            var query = from u in _context.User
                        join d in _context.Department on u.DepartmentId equals d.Id
                        where u.Id == id
                        select new VMUserList()
                        {
                            User = u,
                            Department = d.Name
                        };
            if (query == null)
            {
                return NotFound();
            }

            return View(await query.FirstOrDefaultAsync());
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            var query = from d in _context.Department
                        select new SelectListItem()
                        {
                            Value = d.Id.ToString(),
                            Text = d.Name,
                        };
            return View(new VMUser() { User = new Models.User(), Departments = query.ToList() } );
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LastName,Phone,PostalCode,DepartmentId,Id,Name")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.SingleOrDefaultAsync(m => m.Id == id);
            var query = from d in _context.Department
                        select new SelectListItem()
                        {
                            Value = d.Id.ToString(),
                            Text = d.Name
                        };
            if (user == null)
            {
                return NotFound();
            }
            return View(new VMUser() { User = user, Departments = query.ToList()} );
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("LastName,Phone,PostalCode,DepartmentId,Id,Name")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .SingleOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var user = await _context.User.SingleOrDefaultAsync(m => m.Id == id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(long id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
