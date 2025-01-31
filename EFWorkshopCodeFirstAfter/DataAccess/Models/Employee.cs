using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFWorkshopCodeFirstConfigurations.DataAccess.Models
{
    //[PrimaryKey(nameof(FirstName), nameof(LastName))] - define composite primary key
    [Table("CompanyEmployees")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Column("EmailAddress")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public int Salary { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }

    // Employee model to use lazy loading without Microsoft.EntityFrameworkCore.Proxies

    //public class Employee
    //{
    //    private ILazyLoader LazyLoader { get; set; }
    //    private Department _department;

    //    public Employee() { }

    //    private Employee(ILazyLoader lazyLoader)
    //    {
    //        LazyLoader = lazyLoader;
    //    }

    //    public int EmployeeId { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Email { get; set; }
    //    public string PhoneNumber { get; set; }
    //    public int Salary { get; set; }
    //    public int DepartmentId { get; set; }

    //    public Department Department
    //    {
    //        get => LazyLoader.Load(this, ref _department);
    //        set => _department = value;
    //    }
    //}
}
