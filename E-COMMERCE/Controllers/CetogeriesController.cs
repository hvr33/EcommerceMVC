using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_COMMERCE.Models;

namespace E_COMMERCE.Controllers
{
    public class CetogeriesController : Controller
    {
        private readonly ECO _context;

        public CetogeriesController(ECO context)
        {
            _context = context;
        }

        // GET: Cetogeries
        public async Task<IActionResult> Index() => View(await _context.Cetogeries.ToListAsync());

        // GET: Cetogeries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cetogery = await _context.Cetogeries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cetogery == null)
            {
                return NotFound();
            }

            return View(cetogery);
        }

        // GET: Cetogeries/Create
        public IActionResult Create() => View();

        // POST: Cetogeries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Photos,Description")] Cetogery cetogery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cetogery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cetogery);
        }

        // GET: Cetogeries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cetogery = await _context.Cetogeries.FindAsync(id);
            if (cetogery == null)
            {
                return NotFound();
            }
            return View(cetogery);
        }

        // POST: Cetogeries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Photos,Description")] Cetogery cetogery)
        {
            if (id != cetogery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cetogery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CetogeryExists(cetogery.Id))
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
            return View(cetogery);
        }

        // GET: Cetogeries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cetogery = await _context.Cetogeries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cetogery == null)
            {
                return NotFound();
            }

            return View(cetogery);
        }

        // POST: Cetogeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cetogery = await _context.Cetogeries.FindAsync(id);
            if (cetogery != null)
            {
                _context.Cetogeries.Remove(cetogery);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CetogeryExists(int id) => _context.Cetogeries.Any(e => e.Id == id);
    }
}
