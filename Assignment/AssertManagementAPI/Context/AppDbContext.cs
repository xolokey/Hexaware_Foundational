using AssertManagementAPI.Authentication;
using AssertManagementAPI.Model;
using AssertManagementAPI.Model.AssetManagementAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AssertManagementAPI.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set;}
        public DbSet<Assert> Asserts { get; set;}
        public DbSet<AssertAuditLogs> AssertAuditLogs { get; set; }
        public DbSet<AssertCategory> AssetCategories { get; set; }
        public DbSet<AuditRequest> AuditRequests { get; set; }
        public DbSet<EmployeeAssert> EmployeeAsserts { get; set; }
        public virtual DbSet<ServiceRequest> ServiceRequests { get; set; }

    }
}
