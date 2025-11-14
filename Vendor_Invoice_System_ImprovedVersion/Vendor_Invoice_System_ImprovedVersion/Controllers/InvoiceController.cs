// Required namespaces for ASP.NET Core MVC, Models, and other utilities
using Microsoft.AspNetCore.Mvc;
using Vendor_Invoice_System_ImprovedVersion.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Vendor_Invoice_System_ImprovedVersion.Controllers
{
    // Controller to handle invoice-related operations
    public class InvoiceController : Controller
    {
        // Dependency injection to access hosting environment details (e.g., root paths)
        private readonly IWebHostEnvironment _environment;

        // Simulating a database with static lists for vendors and invoices
        private static List<Vendor> Vendors = new List<Vendor>();
        private static List<Invoice> Invoices = new List<Invoice>();

        // Tracking the latest invoice ID for auto-increment
        private static int _lastInvoiceId = 0;

        // Constructor to inject the hosting environment dependency
        public InvoiceController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        // Action to display the list of all invoices
        public IActionResult Index()
        {
            return View(Invoices); // Returns the 'Index' view with all invoices
        }

        // Action to render the form for submitting a new invoice
        public IActionResult Submit()
        {
            return View(new Invoice()); // Returns an empty invoice model for the view
        }

        // Handles form submission for uploading a new invoice
        [HttpPost] // Specifies this is a POST method
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)] // Limits multipart form size to 200 MB
        [RequestSizeLimit(209715200)] // Limits total request size to 200 MB
        public async Task<IActionResult> Submit(Invoice model, IFormFile file)
        {
            // Check if the model passed validation
            if (ModelState.IsValid)
            {
                // If a file was uploaded
                if (file != null && file.Length > 0)
                {
                    // Define the folder path for storing uploaded files
                    var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");

                    // Ensure the 'uploads' directory exists
                    Directory.CreateDirectory(uploadsFolder);

                    // Generate a unique filename to prevent conflicts
                    var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Save the uploaded file to the specified path
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    // Set invoice properties
                    model.InvoiceId = ++_lastInvoiceId; // Increment and assign ID
                    model.DocumentPath = uniqueFileName; // Save the file path
                    model.IsApproved = false; // Mark as not approved initially
                    model.IsPaid = false; // Mark as unpaid
                    model.SubmissionDate = DateTime.Now; // Set submission date

                    // Add the new invoice to the list
                    Invoices.Add(model);

                    // Set a success message to display in the UI
                    TempData["SuccessMessage"] = $"Invoice submitted successfully. File '{file.FileName}' was uploaded.";

                    // Redirect to the 'InvoiceSubmitted' view after successful upload
                    return RedirectToAction(nameof(InvoiceSubmitted), new { id = model.InvoiceId });
                }
                else
                {
                    // If no file was uploaded, add an error message to the model state
                    ModelState.AddModelError("", "Please upload a document.");
                }
            }

            // Return the same view with the model to show validation errors, if any
            return View(model);
        }

        // Action to show a confirmation message after an invoice is submitted
        public IActionResult InvoiceSubmitted(int id)
        {
            // Find the submitted invoice by ID
            var invoice = Invoices.FirstOrDefault(i => i.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound(); // If not found, return a 404 response
            }
            return View(invoice); // Display the invoice details
        }

        // Action to list all pending invoices that need approval
        public IActionResult Approve()
        {
            // Filter invoices that are not yet approved
            var pendingInvoices = Invoices.Where(i => !i.IsApproved).ToList();
            return View(pendingInvoices); // Return the list of pending invoices
        }

        // Action to approve an invoice by its ID
        [HttpPost] // Specifies this is a POST method
        public IActionResult Approve(int id)
        {
            // Find the invoice by ID
            var invoice = Invoices.FirstOrDefault(i => i.InvoiceId == id);
            if (invoice != null)
            {
                // Mark the invoice as approved and set the approval date
                invoice.IsApproved = true;
                invoice.ApprovedDate = DateTime.Now;

                // Redirect back to the 'Approve' view to update the list
                return RedirectToAction(nameof(Approve));
            }
            return NotFound(); // Return 404 if the invoice was not found
        }

        // Action to display the details of a specific invoice
        public IActionResult Details(int id)
        {
            // Find the invoice by ID
            var invoice = Invoices.FirstOrDefault(i => i.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound(); // Return 404 if not found
            }
            return View(invoice); // Display the details of the invoice
        }

        // Action to display the download options for an invoice's files
        public IActionResult Downloads(int id)
        {
            // Find the invoice by ID
            var invoice = Invoices.FirstOrDefault(i => i.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound(); // Return 404 if not found
            }
            return View(invoice); // Show download options for the invoice
        }

        // Action to download the file associated with an invoice
        public IActionResult DownloadFile(int id)
        {
            // Find the invoice by ID
            var invoice = Invoices.FirstOrDefault(i => i.InvoiceId == id);
            if (invoice == null || string.IsNullOrEmpty(invoice.DocumentPath))
            {
                // Return 404 if the invoice or the file path is missing
                return NotFound("Invoice or file not found.");
            }

            // Construct the full path of the uploaded file
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploadsFolder, invoice.DocumentPath);

            // Check if the file exists on the server
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File does not exist."); // Return 404 if the file is missing
            }

            // Read the file into a byte array
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var fileName = Path.GetFileName(invoice.DocumentPath); // Get the file name

            // Return the file for download with the correct MIME type and name
            return File(fileBytes, "application/octet-stream", fileName);
        }
    }
}
