using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Models.ViewModels;

namespace LeaveManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee>              Employees { get; set; }
        public DbSet<LeaveType>             LeaveTypes { get; set; }
        public DbSet<LeaveAllocation>           LeaveAllocations { get; set; }
        public DbSet<LeaveHistory>          LeaveHistories { get; set; }
        public DbSet<LeaveManagement.Models.ViewModels.LeaveTypeVM> DetailsLeaveTypeVM { get; set; }
    }
}
