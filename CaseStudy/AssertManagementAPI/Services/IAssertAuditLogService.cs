namespace AssertManagementAPI.Services
{
    public interface IAuditLogService
    {
        Task<bool> LogAuditAsync(int auditRequestId, string status, int verifiedBy);
    }
}
