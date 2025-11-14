using System;  
using System.ComponentModel.DataAnnotations;  // Provides validation attributes

namespace Vendor_Invoice_System_ImprovedVersion.Models
{
    // Represents an Invoice entity with properties and validations
    public class Invoice
    {
        // Unique identifier for each invoice
        public int InvoiceId { get; set; }

        // Vendor ID (Required) - Links the invoice to a specific vendor
        [Required]  // Ensures the field must be provided
        public int VendorId { get; set; }

        // Optional navigation property to reference the related Vendor entity
        public Vendor? Vendor { get; set; }  // Nullable to indicate that it might not always be loaded

        // Invoice amount with validation (must be greater than 0)
        [Required]  // Ensures that the amount field is mandatory
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]  // Range validation to ensure a positive value
        public double Amount { get; set; }

        // Invoice date (Required) - Defaults to the current date
        [Required]  // Field must be provided
        [DataType(DataType.Date)]  // Ensures only the date part is used (no time)
        public DateTime InvoiceDate { get; set; } = DateTime.Now;  // Default value is the current date

        // Due date (Required) - Defaults to the current date
        [Required]  // Field must be provided
        [DataType(DataType.Date)]  // Restricts input to a valid date
        public DateTime DueDate { get; set; } = DateTime.Now;  // Default value is the current date

        // Optional path to the uploaded document associated with the invoice
        public string? DocumentPath { get; set; }  // Nullable if no document is uploaded

        // Indicates if the invoice has been approved (default is false)
        public bool IsApproved { get; set; }  // Tracks the approval status of the invoice

        // Indicates if the invoice has been paid (default is false)
        public bool IsPaid { get; set; }  // Tracks the payment status of the invoice

        // The date when the invoice was approved (nullable)
        public DateTime? ApprovedDate { get; set; }  // Nullable since it may not be approved immediately

        // The submission date of the invoice (mandatory)
        public DateTime SubmissionDate { get; set; }  // Records the exact time the invoice was submitted
    }
}
