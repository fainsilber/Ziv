using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ziv.Models;

namespace Ziv.Controllers
{
    public class GorillaController : Controller
    {
        private readonly ZivContext _context;

        public GorillaController(ZivContext context)
        {
            _context = context;    
        }

        // GET: Gorillas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gorilla.ToListAsync());
        }

        // GET: Gorillas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gorilla = await _context.Gorilla
                .SingleOrDefaultAsync(m => m.ID == id);
            if (gorilla == null)
            {
                return NotFound();
            }

            return View(gorilla);
        }

        // GET: Gorillas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gorillas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Age,HairColor,Name,Gender,DateOfBirth,Weight")] Gorilla gorilla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gorilla);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gorilla);
        }

        // GET: Gorillas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gorilla = await _context.Gorilla.SingleOrDefaultAsync(m => m.ID == id);
            if (gorilla == null)
            {
                return NotFound();
            }
            return View(gorilla);
        }

        // POST: Gorillas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Age,HairColor,Name,Gender,DateOfBirth,Weight")] Gorilla gorilla)
        {
            if (id != gorilla.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gorilla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GorillaExists(gorilla.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(gorilla);
        }

        // GET: Gorillas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gorilla = await _context.Gorilla
                .SingleOrDefaultAsync(m => m.ID == id);
            if (gorilla == null)
            {
                return NotFound();
            }

            return View(gorilla);
        }

        // POST: Gorillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gorilla = await _context.Gorilla.SingleOrDefaultAsync(m => m.ID == id);
            _context.Gorilla.Remove(gorilla);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool GorillaExists(int id)
        {
            return _context.Gorilla.Any(e => e.ID == id);
        }
    }
}
