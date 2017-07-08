using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ziv.Models;
using Ziv.Models;

namespace Ziv.Controllers
{
    public class SharkController : Controller
    {
        private readonly ZivContext _context;

        public SharkController(ZivContext context)
        {
            _context = context;    
        }

        // GET: Sharks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shark.ToListAsync());
        }

        // GET: Sharks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shark = await _context.Shark
                .SingleOrDefaultAsync(m => m.ID == id);
            if (shark == null)
            {
                return NotFound();
            }

            return View(shark);
        }

        // GET: Sharks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sharks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AmountOfTeeth,NeedSaltWater,SkinColor,Name,Gender,DateOfBirth,Weight")] Shark shark)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shark);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(shark);
        }

        // GET: Sharks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shark = await _context.Shark.SingleOrDefaultAsync(m => m.ID == id);
            if (shark == null)
            {
                return NotFound();
            }
            return View(shark);
        }

        // POST: Sharks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AmountOfTeeth,NeedSaltWater,SkinColor,Name,Gender,DateOfBirth,Weight")] Shark shark)
        {
            if (id != shark.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SharkExists(shark.ID))
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
            return View(shark);
        }

        // GET: Sharks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shark = await _context.Shark
                .SingleOrDefaultAsync(m => m.ID == id);
            if (shark == null)
            {
                return NotFound();
            }

            return View(shark);
        }

        // POST: Sharks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shark = await _context.Shark.SingleOrDefaultAsync(m => m.ID == id);
            _context.Shark.Remove(shark);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SharkExists(int id)
        {
            return _context.Shark.Any(e => e.ID == id);
        }
    }
}
