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
    public class Order1Controller : Controller
    {
        private readonly Commerce2Context _context;

        public Order1Controller(Commerce2Context context)
        {
            _context = context;
        }

        // GET: Order1
        public async Task<IActionResult> Index()
        {
            var commerceContext = _context.Orders.Include(o => o.City).Include(o => o.Country).Include(o => o.State);
            return View(await commerceContext.ToListAsync());
        }

        // GET: Order1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order1 = await _context.Orders
                .Include(o => o.City)
                .Include(o => o.Country)
                .Include(o => o.State)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order1 == null)
            {
                return NotFound();
            }

            return View(order1);
        }

        // GET: Order1/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Set<City>(), "Id", "Id");
            ViewData["CountryId"] = new SelectList(_context.Set<Country>(), "Id", "Id");
            ViewData["StateId"] = new SelectList(_context.Set<State>(), "Id", "Id");
            return View();
        }

        // POST: Order1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerName,Phone,CountryId,StateId,CityId,Address,OrderDate")] Order1 order1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Set<City>(), "Id", "Id", order1.CityId);
            ViewData["CountryId"] = new SelectList(_context.Set<Country>(), "Id", "Id", order1.CountryId);
            ViewData["StateId"] = new SelectList(_context.Set<State>(), "Id", "Id", order1.StateId);
            return View(order1);
        }

        // GET: Order1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order1 = await _context.Orders.FindAsync(id);
            if (order1 == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Set<City>(), "Id", "Id", order1.CityId);
            ViewData["CountryId"] = new SelectList(_context.Set<Country>(), "Id", "Id", order1.CountryId);
            ViewData["StateId"] = new SelectList(_context.Set<State>(), "Id", "Id", order1.StateId);
            return View(order1);
        }

        // POST: Order1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerName,Phone,CountryId,StateId,CityId,Address,OrderDate")] Order1 order1)
        {
            if (id != order1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Order1Exists(order1.Id))
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
            ViewData["CityId"] = new SelectList(_context.Set<City>(), "Id", "Id", order1.CityId);
            ViewData["CountryId"] = new SelectList(_context.Set<Country>(), "Id", "Id", order1.CountryId);
            ViewData["StateId"] = new SelectList(_context.Set<State>(), "Id", "Id", order1.StateId);
            return View(order1);
        }

        // GET: Order1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order1 = await _context.Orders
                .Include(o => o.City)
                .Include(o => o.Country)
                .Include(o => o.State)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order1 == null)
            {
                return NotFound();
            }

            return View(order1);
        }

        // POST: Order1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order1 = await _context.Orders.FindAsync(id);
            if (order1 != null)
            {
                _context.Orders.Remove(order1);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Order1Exists(int id) => _context.Orders.Any(e => e.Id == id);
    }
}
