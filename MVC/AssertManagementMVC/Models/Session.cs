using System;
using System.Collections.Generic;

namespace AssertManagementMVC.Models;

public partial class Session
{
    public int SessionId { get; set; }

    public int? UserId { get; set; }

    public string? Jwttoken { get; set; }

    public DateTime? LoginTime { get; set; }

    public DateTime? LogoutTime { get; set; }

    public bool? IsValid { get; set; }

    public virtual User? User { get; set; }
}
