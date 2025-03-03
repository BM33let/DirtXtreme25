using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BOROMOTORS.Data;
using BOROMOTORS.Models;
using Microsoft.AspNetCore.Authorization;

namespace BOROMOTORS.Controllers
{
    public class DirtBikesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DirtBikesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DirtBikes
        public async Task<IActionResult> Index(string searchQuery)
        {
            var dirtBikes = await _context.DirtBikes.ToListAsync();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                searchQuery = searchQuery.ToLower();

                dirtBikes = await _context.DirtBikes
                    .Where(d => d.Model.ToLower().Contains(searchQuery) || d.Manufacturer.ToLower().Contains(searchQuery))
                    .ToListAsync();
            }

            return View(dirtBikes);
        }

        // GET: DirtBikes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dirtBike = await _context.DirtBikes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dirtBike == null)
            {
                return NotFound();
            }

            return View(dirtBike);
        }

        // GET: DirtBikes/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: DirtBikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,Manufacturer,Price,Stock,Description,ImageUrl,VideoUrl,TopSpeed,Horsepower,Weight")] DirtBike dirtBike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dirtBike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dirtBike);
        }

        // GET: DirtBikes/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dirtBike = await _context.DirtBikes.FindAsync(id);
            if (dirtBike == null)
            {
                return NotFound();
            }
            return View(dirtBike);
        }

        // POST: DirtBikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Model,Manufacturer,Price,Stock,Description,ImageUrl,VideoUrl,TopSpeed,Horsepower,Weight")] DirtBike dirtBike)
        {
            if (id != dirtBike.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dirtBike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirtBikeExists(dirtBike.Id))
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
            return View(dirtBike);
        }

        // GET: DirtBikes/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dirtBike = await _context.DirtBikes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dirtBike == null)
            {
                return NotFound();
            }

            return View(dirtBike);
        }

        // POST: DirtBikes/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var dirtBike = await _context.DirtBikes.FindAsync(id);
            if (dirtBike != null)
            {
                _context.DirtBikes.Remove(dirtBike);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirtBikeExists(int? id)
        {
            return _context.DirtBikes.Any(e => e.Id == id);
        }
    }
}
