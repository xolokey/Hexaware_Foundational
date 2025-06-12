using System;
using System.Collections.Generic;

namespace AssertManagementMVC.Models;

public partial class AssetAuditLog
{
    public int LogId { get; set; }

    public int? AuditRequestId { get; set; }

    public string? Status { get; set; }

    public int? VerifiedBy { get; set; }

    public DateTime? VerifiedDate { get; set; }

    public virtual AuditRequest? AuditRequest { get; set; }

    public virtual User? VerifiedByNavigation { get; set; }
}
