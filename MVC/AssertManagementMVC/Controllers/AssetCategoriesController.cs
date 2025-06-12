using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssertManagementMVC.Models;

namespace AssertManagementMVC.Controllers
{
    public class AssetCategoriesController : Controller
    {
        private readonly AssertManagementMvcContext _context;

        public AssetCategoriesController(AssertManagementMvcContext context)
        {
            _context = context;
        }

        // GET: AssetCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.AssetCategories.ToListAsync());
        }

        // GET: AssetCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetCategory = await _context.AssetCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (assetCategory == null)
            {
                return NotFound();
            }

            return View(assetCategory);
        }

        // GET: AssetCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssetCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,Description")] AssetCategory assetCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assetCategory);
        }

        // GET: AssetCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetCategory = await _context.AssetCategories.FindAsync(id);
            if (assetCategory == null)
            {
                return NotFound();
            }
            return View(assetCategory);
        }

        // POST: AssetCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,Description")] AssetCategory assetCategory)
        {
            if (id != assetCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assetCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetCategoryExists(assetCategory.CategoryId))
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
            return View(assetCategory);
        }

        // GET: AssetCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetCategory = await _context.AssetCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (assetCategory == null)
            {
                return NotFound();
            }

            return View(assetCategory);
        }

        // POST: AssetCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assetCategory = await _context.AssetCategories.FindAsync(id);
            if (assetCategory != null)
            {
                _context.AssetCategories.Remove(assetCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetCategoryExists(int id)
        {
            return _context.AssetCategories.Any(e => e.CategoryId == id);
        }
    }
}
