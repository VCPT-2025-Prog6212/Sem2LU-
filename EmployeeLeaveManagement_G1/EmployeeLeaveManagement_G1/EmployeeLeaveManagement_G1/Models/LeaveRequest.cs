namespace EmployeeLeaveManagement_G1.Models
{
    public class LeaveRequest
    {
        public int LeaveRequestID { get; set; } //unique id for the leave request
        public string EmployeeID { get; set; }//employee id for the employee making the request
        public DateTime StartDate { get; set; } //start date for leave
        public DateTime EndDate { get; set; } //end date for leave
        public string Reason { get; set; } //reason for leave
        public string Status { get; set; } = "Pending"; //leave status: Pending, Approved, Rejected
    }
}
