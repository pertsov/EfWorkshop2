using System;
using EFWorkshopCodeFirstConfigurations.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EFWorkshopCodeFirstConfigurations.DataAccess
{
    internal class HrDbContext : DbContext
    {
        private const string ConnectionString = "Server=localhost;Database=HR;Trusted_Connection=True;TrustServerCertificate=True;";

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public HrDbContext(DbContextOptions<HrDbContext> options)
            : base(options) { }

        public HrDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString)
                .UseLazyLoadingProxies() // enables lazy loading
                .LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Employees Fluent API configuration
            modelBuilder.Entity<Employee>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Employee>()
                .Property(m => m.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Employee>()
                .Property(m => m.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Employee>()
                .Property(m => m.Email)
                .HasColumnName("EmailAddress");

            modelBuilder.Entity<Employee>()
                .ToTable("CompanyEmployees");

            modelBuilder.Entity<Employee>()
                .HasOne(m => m.Department);

            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee()
                    {
                        Id = 1, FirstName = "Caryn", LastName = "Mitchell", Email = "m.f@protonmail.edu",
                        PhoneNumber = "1-683-204-3142", Salary = 100, DepartmentId = 1
                    },
                    new Employee()
                    {
                        Id = 2, FirstName = "Tyler", LastName = "Herring", Email = "el@google.couk",
                        PhoneNumber = "(234) 887-3617", Salary = 200, DepartmentId = 1
                    },
                    new Employee()
                    {
                        Id = 3, FirstName = "Omar", LastName = "Adkins", Email = "d.m@yahoo.net",
                        PhoneNumber = "1-517-314-5525", Salary = 300, DepartmentId = 2
                    },
                    new Employee()
                    {
                        Id = 4, FirstName = "Erich", LastName = "Casey", Email = "sit@yahoo.couk",
                        PhoneNumber = "(283) 850-5763", Salary = 400, DepartmentId = 2
                    });

            // Departments Fluent API configuration
            modelBuilder.Entity<Department>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Department>()
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Department>()
                .Ignore(m => m.Location);

            modelBuilder.Entity<Department>()
                .HasMany(m => m.Employees);

            modelBuilder.Entity<Department>()
                .HasData(
                    new Department() { Id = 1, Name = "Logistics", Description = "Logistics department" }, 
                    new Department() { Id = 2, Name = "Sales", Description = "Sales department"});


            // Alternative more technical Fluent API syntax

            //modelBuilder.Entity("EFWorkshopCodeFirstConfigurations.DataAccess.Models.Employee", b =>
            //{
            //    b.Property<int>("Id")
            //        .ValueGeneratedOnAdd()
            //        .HasColumnType("int");

            //    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

            //    b.Property<int>("DepartmentId")
            //        .HasColumnType("int");

            //    b.Property<string>("Email")
            //        .HasColumnType("nvarchar(max)")
            //        .HasColumnName("EmailAddress");

            //    b.Property<string>("FirstName")
            //        .HasColumnType("nvarchar(max)");

            //    b.Property<string>("LastName")
            //        .HasColumnType("nvarchar(max)");

            //    b.Property<string>("PhoneNumber")
            //        .HasColumnType("nvarchar(max)");

            //    b.Property<int>("Salary")
            //        .HasColumnType("int");

            //    b.HasKey("Id");

            //    b.HasIndex("DepartmentId");

            //    b.ToTable("CompanyEmployees");
            //});

            //modelBuilder.Entity("EFWorkshopCodeFirstAfter.DataAccess.Models.Employee", b =>
            //{
            //    b.HasOne("EFWorkshopCodeFirstAfter.DataAccess.Models.Department", "Department")
            //        .WithMany("Employees")
            //        .HasForeignKey("DepartmentId")
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .IsRequired();

            //    b.Navigation("Department");
            //});
        }
    }
}