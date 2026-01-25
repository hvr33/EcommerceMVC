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
    public class ProductimagesController : Controller
    {
        private readonly Commerce2Context _context;

        public ProductimagesController(Commerce2Context context)
        {
            _context = context;
        }

        // GET: Productimages
        public async Task<IActionResult> Index()
        {
            var commerceContext = _context.Productimages.Include(p => p.Product);
            return View(await commerceContext.ToListAsync());
        }

        // GET: Productimages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productimage = await _context.Productimages
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productimage == null)
            {
                return NotFound();
            }

            return View(productimage);
        }

        // GET: Productimages/Create
        public IActionResult Create()
        {
            ViewData["Productid"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: Productimages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Productid,Image")] Productimage productimage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productimage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Productid"] = new SelectList(_context.Products, "Id", "Id", productimage.Productid);
            return View(productimage);
        }

        // GET: Productimages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productimage = await _context.Productimages.FindAsync(id);
            if (productimage == null)
            {
                return NotFound();
            }
            ViewData["Productid"] = new SelectList(_context.Products, "Id", "Id", productimage.Productid);
            return View(productimage);
        }

        // POST: Productimages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Productid,Image")] Productimage productimage)
        {
            if (id != productimage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productimage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductimageExists(productimage.Id))
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
            ViewData["Productid"] = new SelectList(_context.Products, "Id", "Id", productimage.Productid);
            return View(productimage);
        }

        // GET: Productimages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productimage = await _context.Productimages
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productimage == null)
            {
                return NotFound();
            }

            return View(productimage);
        }

        // POST: Productimages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productimage = await _context.Productimages.FindAsync(id);
            if (productimage != null)
            {
                _context.Productimages.Remove(productimage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductimageExists(int id) => _context.Productimages.Any(e => e.Id == id);
    }
}
