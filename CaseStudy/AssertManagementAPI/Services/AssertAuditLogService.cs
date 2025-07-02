using AssertManagementAPI.Context;
using AssertManagementAPI.Model;

namespace AssertManagementAPI.Services
{
        public class AuditLogService : IAuditLogService
        {
            private readonly AppDbContext _context;

            public AuditLogService(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> LogAuditAsync(int auditRequestId, string status, int verifiedBy)
            {
                var auditRequest = await _context.AuditRequests.FindAsync(auditRequestId);
                if (auditRequest == null) return false;

                // Update audit request status
                auditRequest.AuditStatus = status;
                _context.AuditRequests.Update(auditRequest);

                // Create and save audit log
                var log = new AssertAuditLogs
                {
                    AuditRequestId = auditRequestId,
                    Status = status,
                    VerifiedBy = verifiedBy,
                    VerifiedDate = DateTime.UtcNow
                };

                await _context.AssertAuditLogs.AddAsync(log);
                await _context.SaveChangesAsync();

                return true;
            }
        }
}
