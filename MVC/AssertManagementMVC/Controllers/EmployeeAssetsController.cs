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
    public class EmployeeAssetsController : Controller
    {
        private readonly AssertManagementMvcContext _context;

        public EmployeeAssetsController(AssertManagementMvcContext context)
        {
            _context = context;
        }

        // GET: EmployeeAssets
        public async Task<IActionResult> Index()
        {
            var assertManagementMvcContext = _context.EmployeeAssets.Include(e => e.Asset).Include(e => e.User);
            return View(await assertManagementMvcContext.ToListAsync());
        }

        // GET: EmployeeAssets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeAsset = await _context.EmployeeAssets
                .Include(e => e.Asset)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.AllocationId == id);
            if (employeeAsset == null)
            {
                return NotFound();
            }

            return View(employeeAsset);
        }

        // GET: EmployeeAssets/Create
        public IActionResult Create()
        {
            ViewData["AssetId"] = new SelectList(_context.Assets, "AssetId", "AssetId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: EmployeeAssets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AllocationId,UserId,AssetId,AllocationDate,ReturnDate,Status")] EmployeeAsset employeeAsset)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeAsset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetId"] = new SelectList(_context.Assets, "AssetId", "AssetId", employeeAsset.AssetId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", employeeAsset.UserId);
            return View(employeeAsset);
        }

        // GET: EmployeeAssets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeAsset = await _context.EmployeeAssets.FindAsync(id);
            if (employeeAsset == null)
            {
                return NotFound();
            }
            ViewData["AssetId"] = new SelectList(_context.Assets, "AssetId", "AssetId", employeeAsset.AssetId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", employeeAsset.UserId);
            return View(employeeAsset);
        }

        // POST: EmployeeAssets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AllocationId,UserId,AssetId,AllocationDate,ReturnDate,Status")] EmployeeAsset employeeAsset)
        {
            if (id != employeeAsset.AllocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeAsset);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeAssetExists(employeeAsset.AllocationId))
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
            ViewData["AssetId"] = new SelectList(_context.Assets, "AssetId", "AssetId", employeeAsset.AssetId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", employeeAsset.UserId);
            return View(employeeAsset);
        }

        // GET: EmployeeAssets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeAsset = await _context.EmployeeAssets
                .Include(e => e.Asset)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.AllocationId == id);
            if (employeeAsset == null)
            {
                return NotFound();
            }

            return View(employeeAsset);
        }

        // POST: EmployeeAssets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeAsset = await _context.EmployeeAssets.FindAsync(id);
            if (employeeAsset != null)
            {
                _context.EmployeeAssets.Remove(employeeAsset);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeAssetExists(int id)
        {
            return _context.EmployeeAssets.Any(e => e.AllocationId == id);
        }
    }
}
