using System;
using System.Collections.Generic;
using System.Linq;
using EFWorkshopCodeFirstConfigurations.DataAccess;
using EFWorkshopCodeFirstConfigurations.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EFWorkshopCodeFirstConfigurations
{
    internal class AppRunner
    {
        public void Run()
        {
            SetupDatabase();

            ShowcaseQueryExecutionTypes();
            ShowcaseLoadingStrategies();
        }

        private static void ShowcaseLoadingStrategies()
        {
            var optionsBuilder = new DbContextOptionsBuilder<HrDbContext>();
            using (var context = new HrDbContext(optionsBuilder.Options))
            {
                #region EagerLoading

                // here Department properties are null
                var eagerEmployee1 = context.Employees
                    .Where(em => em.DepartmentId == 2)
                    .ToArray();

                // here Department properties are populated eagerly
                var eagerEmployee2 = context.Employees
                    .Where(em => em.DepartmentId == 2)
                    .Include(em => em.Department)
                    .ToArray();

                #endregion

                #region LazyLoading

                // here Department property is null
                var lazyEmployee = context.Employees.First(em => em.Id == 1);

                if (lazyEmployee.Department != null) // here the Department reference makes EF populate Department property
                {
                    Console.WriteLine("Department was populated lazily");
                }

                #endregion

                #region ExplicitLoading

                // here the Department property is null
                var employee = context.Employees.FirstOrDefault(x => x.Id == 2);

                context.Entry(employee)
                    .Reference(em => em.Department) // reference and load the related department
                    .Load();

                // here the Employees property is null or an empty collection
                var department = context.Departments.FirstOrDefault(x => x.Id == 1);

                context.Entry(department)
                    .Collection(dp => dp.Employees) // reference and load the related employees
                    .Load();

                #endregion
            }
        }

        private static void ShowcaseQueryExecutionTypes()
        {
            var optionsBuilder = new DbContextOptionsBuilder<HrDbContext>();
            using (var context = new HrDbContext(optionsBuilder.Options))
            {
                #region DeferredQueryExecution

                // returns IQueryable<Employee>, no db calls performed
                var logisticsEmployees = context.Employees.Where(em => em.DepartmentId == 2);

                // returns IQueryable<Employee>, no db calls performed
                var highPayingEmployees = logisticsEmployees.Where(em => em.Salary > 200);

                // returns IOrderedQueryable<Employee>, no db calls performed
                var orderedEmployees = highPayingEmployees.OrderByDescending(em => em.Salary);

                // actual db call happens here due to the usage of .ToList(), returns a List<Employee>
                var employees = orderedEmployees.ToList();

                // enumeration is another way to execute deferred queries
                foreach (var employee in orderedEmployees)
                {
                    // logic here
                }

                #endregion

                #region ImmediateQueryExecution

                // actual db call happens here right away due to the usage of .ToList(), returns a List<Employee>
                var resultEmployees = context.Employees
                    .Where(em => em.DepartmentId == 2)
                    .Where(em => em.Salary > 200)
                    .OrderByDescending(em => em.Salary)
                    .ToList();

                #endregion
            }
        }

        private static void SetupDatabase()
        {
            var optionsBuilder = new DbContextOptionsBuilder<HrDbContext>();
            using (var context = new HrDbContext(optionsBuilder.Options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var seedDepartments = GetSeedDepartments();
                context.Departments.AddRange(seedDepartments);

                TrySaveChanges(context);

                var seedEmployees = GetSeedEmployees();
                context.Employees.AddRange(seedEmployees);

                TrySaveChanges(context);
            }
        }

        private static List<Department> GetSeedDepartments()
        {
            return new List<Department>()
            {
                new Department()
                {
                    Name = "Logistics",
                    Description = "Logistics department"
                },
                new Department()
                {
                    Name = "Sales",
                    Description = "Sales department"
                }
            };
        }

        private static List<Employee> GetSeedEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    FirstName = "Caryn",
                    LastName = "Mitchell",
                    Email = "m.f@protonmail.edu",
                    PhoneNumber = "1-683-204-3142",
                    Salary = 100,
                    DepartmentId = 1
                },
                new Employee()
                {
                    FirstName = "Tyler",
                    LastName = "Herring",
                    Email = "el@google.couk",
                    PhoneNumber = "(234) 887-3617",
                    Salary = 200,
                    DepartmentId = 1
                },
                new Employee()
                {
                    FirstName = "Omar",
                    LastName = "Adkins",
                    Email = "d.m@yahoo.net",
                    PhoneNumber = "1-517-314-5525",
                    Salary = 300,
                    DepartmentId = 2
                },
                new Employee()
                {
                    FirstName = "Erich",
                    LastName = "Casey",
                    Email = "sit@yahoo.couk",
                    PhoneNumber = "(283) 850-5763",
                    Salary = 400,
                    DepartmentId = 2
                }
            };
        }

        private static void TrySaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
