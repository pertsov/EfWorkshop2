using System;
using EFCodeFirstMigrations.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstMigrations.DataAccess
{
    internal class HrDbContext : DbContext
    {
        private const string ConnectionString = "Server=localhost;Database=HR;Trusted_Connection=True;TrustServerCertificate=True;";

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public HrDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString)
                .LogTo(Console.WriteLine);         
        }
    }
}
