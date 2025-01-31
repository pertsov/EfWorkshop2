namespace EFCodeFirstMigrations.DataAccess.Models
{
    internal class Employee
    {
        public int EmployeeId { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Salary { get; set; }
        
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
