using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChooseYourDevApp.Models;

namespace ChooseYourDevApp.Controllers
{
    public class DevController : Controller
    {
        private readonly DevContext _context;

        public DevController(DevContext context)
        {
            _context = context;
        }

        // GET: Dev
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dev.ToListAsync());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Qui sommes nous ?";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Comment nous contacter ?";

            return View();
        }

        // GET: Dev/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dev = await _context.Dev
                .SingleOrDefaultAsync(m => m.Id == id);
            if (dev == null)
            {
                return NotFound();
            }

            return View(dev);
        }

        // GET: Dev/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dev/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Description,Pokename,Price,Rating")] Dev dev)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dev);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dev);
        }

        // GET: Dev/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dev = await _context.Dev.SingleOrDefaultAsync(m => m.Id == id);
            if (dev == null)
            {
                return NotFound();
            }
            return View(dev);
        }

        // POST: Dev/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Description,Pokename,Price,Rating")] Dev dev)
        {
            if (id != dev.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dev);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevExists(dev.Id))
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
            return View(dev);
        }

        // GET: Dev/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dev = await _context.Dev
                .SingleOrDefaultAsync(m => m.Id == id);
            if (dev == null)
            {
                return NotFound();
            }

            return View(dev);
        }

        // POST: Dev/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dev = await _context.Dev.SingleOrDefaultAsync(m => m.Id == id);
            _context.Dev.Remove(dev);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevExists(int id)
        {
            return _context.Dev.Any(e => e.Id == id);
        }
    }
}
