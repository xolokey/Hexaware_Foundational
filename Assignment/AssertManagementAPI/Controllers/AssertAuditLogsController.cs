
using AssertManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AssertManagementAPI.Controllers
{
    [ApiController]
    [Route("api/audit")]
    public class AuditController : ControllerBase
    {
        private readonly IAuditLogService _auditLogService;

        public AuditController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        [Authorize(Roles = "User")]
        [HttpPost("verify/{auditRequestId}")]
        public async Task<IActionResult> VerifyAudit(int auditRequestId, [FromBody] string status)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var success = await _auditLogService.LogAuditAsync(auditRequestId, status, userId);

            if (!success) return NotFound("Audit Request not found.");

            return Ok("Audit log recorded.");
        }
    }
}
