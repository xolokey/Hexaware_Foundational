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
    public class AuditRequestsController : Controller
    {
        private readonly AssertManagementMvcContext _context;

        public AuditRequestsController(AssertManagementMvcContext context)
        {
            _context = context;
        }

        // GET: AuditRequests
        public async Task<IActionResult> Index()
        {
            var assertManagementMvcContext = _context.AuditRequests.Include(a => a.Asset).Include(a => a.User);
            return View(await assertManagementMvcContext.ToListAsync());
        }

        // GET: AuditRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditRequest = await _context.AuditRequests
                .Include(a => a.Asset)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AuditRequestId == id);
            if (auditRequest == null)
            {
                return NotFound();
            }

            return View(auditRequest);
        }

        // GET: AuditRequests/Create
        public IActionResult Create()
        {
            ViewData["AssetId"] = new SelectList(_context.Assets, "AssetId", "AssetId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: AuditRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuditRequestId,AssetId,UserId,AuditStatus,AuditDate")] AuditRequest auditRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auditRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetId"] = new SelectList(_context.Assets, "AssetId", "AssetId", auditRequest.AssetId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", auditRequest.UserId);
            return View(auditRequest);
        }

        // GET: AuditRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditRequest = await _context.AuditRequests.FindAsync(id);
            if (auditRequest == null)
            {
                return NotFound();
            }
            ViewData["AssetId"] = new SelectList(_context.Assets, "AssetId", "AssetId", auditRequest.AssetId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", auditRequest.UserId);
            return View(auditRequest);
        }

        // POST: AuditRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuditRequestId,AssetId,UserId,AuditStatus,AuditDate")] AuditRequest auditRequest)
        {
            if (id != auditRequest.AuditRequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auditRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuditRequestExists(auditRequest.AuditRequestId))
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
            ViewData["AssetId"] = new SelectList(_context.Assets, "AssetId", "AssetId", auditRequest.AssetId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", auditRequest.UserId);
            return View(auditRequest);
        }

        // GET: AuditRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditRequest = await _context.AuditRequests
                .Include(a => a.Asset)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AuditRequestId == id);
            if (auditRequest == null)
            {
                return NotFound();
            }

            return View(auditRequest);
        }

        // POST: AuditRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auditRequest = await _context.AuditRequests.FindAsync(id);
            if (auditRequest != null)
            {
                _context.AuditRequests.Remove(auditRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuditRequestExists(int id)
        {
            return _context.AuditRequests.Any(e => e.AuditRequestId == id);
        }
    }
}
