using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFWorkshopCodeFirstConfigurations.DataAccess.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public string Location { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }

    // Department model to use lazy loading without Microsoft.EntityFrameworkCore.Proxies

    //public class Department
    //{
    //    private ILazyLoader LazyLoader { get; set; }
    //    private ICollection<Employee> _employees;

    //    public Department() { }

    //    public Department(ILazyLoader lazyLoader)
    //    {
    //        LazyLoader = lazyLoader;
    //    }

    //    public int DepartmentId { get; set; }
    //    public string Name { get; set; }
    //    public string Description { get; set; }

    //    public ICollection<Employee> Employees
    //    {
    //        get => LazyLoader.Load(this, ref _employees);
    //        set => _employees = value;
    //    }
    //}
}
