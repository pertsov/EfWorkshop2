using System.Collections.Generic;

namespace EFCodeFirstMigrations.DataAccess.Models
{
    internal class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public List<Employee> Employees { get; set; }
    }
}
