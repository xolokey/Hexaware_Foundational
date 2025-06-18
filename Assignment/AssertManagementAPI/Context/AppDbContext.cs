﻿using AssertManagementAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AssertManagementAPI.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
