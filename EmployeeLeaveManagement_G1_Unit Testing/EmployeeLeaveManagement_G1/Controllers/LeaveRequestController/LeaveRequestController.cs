using EmployeeLeaveManagement_G1.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeaveManagement_G1.Controllers.LeaveRequestController
{
    public class LeaveRequestController : Controller
    {
        //Static in-memory list to store employee data
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee {EmployeeID = 1, Name = "John Doe", Department = "HR", Position = "Manager" },
            new Employee {EmployeeID = 2, Name = "Jane Smith", Department = "IT", Position = "Developer" },
            new Employee {EmployeeID = 3, Name = "Joe Blog", Department = "Finance", Position = "Accountant" },
        };

        //Static in-memory list to store leave request
        //This list will contain all the leave requests made by the employees
        private static List<LeaveRequest> _leaveRequests = new List<LeaveRequest>(); 


        //GET: Display the list of all leave requests
        //This is an action method that will retrieve the list of leave requests to the view
        public IActionResult Index()
        {
            return View(_leaveRequests);//Pass the list of the leave requests to the view
        }

        //GET: Show a dorm for creating a new leave request
        //This method populates the ViewBag with an employee data & returns the "Create"view to show a form
        public IActionResult Create() 
        { 
            ViewBag.Employees = _employees;//Pass along the employee list to the view for displaying in the drop-down selection
            return View();//Return the view with an empty leave request model
        }

        //POST: Handle the leave request submission
        //This method is called when the user submits a new leave request through the form
        [HttpPost]
        public IActionResult Create(LeaveRequest leaveRequest) 
        {
            if (!ModelState.IsValid)//Check if the input data provided is valid 
            {
                ViewBag.Employees = _employees; //repopulates the employee list in case of any validation errors
                return View(leaveRequest);//return the same view
            }

            //Validate that the end date is not earlier than the start date
            if (leaveRequest.EndDate < leaveRequest.StartDate) 
            {
                ModelState.AddModelError("EndDate", "End date cannot be earlier than start date");//custom validation error
                ViewBag.Employees = _employees; //repopulates the employee list in case of any validation errors
                return View(leaveRequest);//return the same view with the error message
            }

            //Generate a new LEaveRequestID & add that leave request to the list
            //If there are existing leave requests, find the maximum ID & increment it by 1, otherwise set the ID to 1
            leaveRequest.LeaveRequestID = _leaveRequests.Any() ? _leaveRequests.Max(lr => lr.LeaveRequestID) + 1 : 1;
            leaveRequest.Status = "Pending"; //Set the initial leave status to Pending
            _leaveRequests.Add(leaveRequest);//Add the new lease request to the in-memory list

            //Redirect to the "Index" view to show the updated list of leave requests
            return RedirectToAction(nameof(Index));
        }

        //GET: Show details of a specific leave request based on the ID
        public IActionResult Details(int id) 
        { var leaveRequest = _leaveRequests.FirstOrDefault(lr => lr.LeaveRequestID == id);
            if (leaveRequest == null) 
            { 
                return NotFound(); //return 404 error if leave request not found
            
            }
            return View("Details",leaveRequest);//pass the leave request to the "Details" view for display
        }

        //GET: Show details of a specific leave request based on the ID
        public IActionResult Edit(int id)
        {
            var leaveRequest = _leaveRequests.FirstOrDefault(lr => lr.LeaveRequestID == id);
            if (leaveRequest == null)
            {
                return NotFound(); //return 404 error if leave request not found

            }
            ViewBag.Employees = _employees;//Pass the employee list to the view to all updating to the employee selection
            return View(leaveRequest);//Pass the leave request to the "Edit"view for editing
        }

        //POST: Handle leave request update
        //This method is called when the user submits the edited leave request
        [HttpPost]
        public IActionResult Edit(int id, LeaveRequest updatedLeaveRequest) 
        { 
            var leaveRequest = _leaveRequests.FirstOrDefault(lr => lr.LeaveRequestID == id); //Find the leave request by ID
            if (leaveRequest == null)
            {
                return NotFound(); //return 404 error if leave request not found

            }
            if (!ModelState.IsValid) //Check if the input is valid 
            { 
                ViewBag.Employees = _employees;
                return View(updatedLeaveRequest); //Return the same view with updated leave request
            }
            //Update the properties of the existing leave request with the data from the form
            leaveRequest.EmployeeID = updatedLeaveRequest.EmployeeID;
            leaveRequest.StartDate = updatedLeaveRequest.StartDate;
            leaveRequest.EndDate = updatedLeaveRequest.EndDate;
            leaveRequest.Reason = updatedLeaveRequest.Reason;

            return RedirectToAction(nameof(Index));

        }

        //POST: Delete a specific leave request
        //This method is called when the user wants to delete a leave request
        [HttpPost]
        public IActionResult Delete(int id) 
        {
            var leaveRequest = _leaveRequests.FirstOrDefault(lr => lr.LeaveRequestID == id); //Find the leave request by ID
            if (leaveRequest == null)
            {
                return NotFound(); //return 404 error if leave request not found
            }
            _leaveRequests.Remove(leaveRequest); //remove the leave request from the list in-memory
            return RedirectToAction(nameof(Index));
        }

        //GET: Approve or Reject a leave request based on its ID & the provided status
        public IActionResult ApproveReject(int id, string status)
        {
            var leaveRequest = _leaveRequests.FirstOrDefault(lr => lr.LeaveRequestID == id); //Find the leave request by ID
            if (leaveRequest == null)
            {
                return NotFound(); //return 404 error if leave request not found
            }

            leaveRequest.Status = status; //Update the status of the leave request (either approve / reject)
            return RedirectToAction(nameof(Index));
        }

    }
}
