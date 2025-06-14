using System;
using System.Collections.Generic;

namespace AssertManagementDB.Models;

public partial class Log
{
    public int LogId { get; set; }

    public string? LogLevel { get; set; }

    public string? Message { get; set; }

    public DateTime? LoggedAt { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
