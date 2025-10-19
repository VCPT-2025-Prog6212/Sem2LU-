namespace EmployeeLeaveManagement_G1.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; } //unique identifier for the employee
        public string Name { get; set; }//employee name
        public string Department { get; set; }//employee department

        public string Position { get; set; }//employee position in the org
    }
}
