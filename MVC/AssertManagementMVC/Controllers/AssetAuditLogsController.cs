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
    public class AssetAuditLogsController : Controller
    {
        private readonly AssertManagementMvcContext _context;

        public AssetAuditLogsController(AssertManagementMvcContext context)
        {
            _context = context;
        }

        // GET: AssetAuditLogs
        public async Task<IActionResult> Index()
        {
            var assertManagementMvcContext = _context.AssetAuditLogs.Include(a => a.AuditRequest).Include(a => a.VerifiedByNavigation);
            return View(await assertManagementMvcContext.ToListAsync());
        }

        // GET: AssetAuditLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetAuditLog = await _context.AssetAuditLogs
                .Include(a => a.AuditRequest)
                .Include(a => a.VerifiedByNavigation)
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (assetAuditLog == null)
            {
                return NotFound();
            }

            return View(assetAuditLog);
        }

        // GET: AssetAuditLogs/Create
        public IActionResult Create()
        {
            ViewData["AuditRequestId"] = new SelectList(_context.AuditRequests, "AuditRequestId", "AuditRequestId");
            ViewData["VerifiedBy"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: AssetAuditLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogId,AuditRequestId,Status,VerifiedBy,VerifiedDate")] AssetAuditLog assetAuditLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetAuditLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuditRequestId"] = new SelectList(_context.AuditRequests, "AuditRequestId", "AuditRequestId", assetAuditLog.AuditRequestId);
            ViewData["VerifiedBy"] = new SelectList(_context.Users, "UserId", "UserId", assetAuditLog.VerifiedBy);
            return View(assetAuditLog);
        }

        // GET: AssetAuditLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetAuditLog = await _context.AssetAuditLogs.FindAsync(id);
            if (assetAuditLog == null)
            {
                return NotFound();
            }
            ViewData["AuditRequestId"] = new SelectList(_context.AuditRequests, "AuditRequestId", "AuditRequestId", assetAuditLog.AuditRequestId);
            ViewData["VerifiedBy"] = new SelectList(_context.Users, "UserId", "UserId", assetAuditLog.VerifiedBy);
            return View(assetAuditLog);
        }

        // POST: AssetAuditLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LogId,AuditRequestId,Status,VerifiedBy,VerifiedDate")] AssetAuditLog assetAuditLog)
        {
            if (id != assetAuditLog.LogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assetAuditLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetAuditLogExists(assetAuditLog.LogId))
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
            ViewData["AuditRequestId"] = new SelectList(_context.AuditRequests, "AuditRequestId", "AuditRequestId", assetAuditLog.AuditRequestId);
            ViewData["VerifiedBy"] = new SelectList(_context.Users, "UserId", "UserId", assetAuditLog.VerifiedBy);
            return View(assetAuditLog);
        }

        // GET: AssetAuditLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetAuditLog = await _context.AssetAuditLogs
                .Include(a => a.AuditRequest)
                .Include(a => a.VerifiedByNavigation)
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (assetAuditLog == null)
            {
                return NotFound();
            }

            return View(assetAuditLog);
        }

        // POST: AssetAuditLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assetAuditLog = await _context.AssetAuditLogs.FindAsync(id);
            if (assetAuditLog != null)
            {
                _context.AssetAuditLogs.Remove(assetAuditLog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetAuditLogExists(int id)
        {
            return _context.AssetAuditLogs.Any(e => e.LogId == id);
        }
    }
}
