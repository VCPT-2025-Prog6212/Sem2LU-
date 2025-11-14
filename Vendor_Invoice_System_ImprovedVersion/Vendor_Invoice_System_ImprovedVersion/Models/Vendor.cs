using System.ComponentModel.DataAnnotations;  // Required for data validation attributes

namespace Vendor_Invoice_System_ImprovedVersion.Models
{
    // Represents a Vendor entity with properties for vendor details
    public class Vendor
    {
        // Unique identifier for each vendor
        public int VendorId { get; set; }

        // Vendor's name (Required, with a max length of 100 characters)
        [Required]  // Ensures this field is mandatory
        [StringLength(100)]  // Limits the name to a maximum of 100 characters
        public string Name { get; set; }

        // Vendor's email address (Required, with a max length of 200 characters and email format validation)
        [Required]  // Ensures email is required
        [EmailAddress]  // Validates that the input matches the email address format
        [StringLength(200)]  // Limits the email address to a maximum of 200 characters
        public string Email { get; set; }

        // Vendor's company name (Required, with a max length of 100 characters)
        [Required]
        [StringLength(100)]  // Ensures the company name is not too long
        public string CompanyName { get; set; }

        // Vendor's address (Required, with a max length of 200 characters)
        [Required]
        [StringLength(200)]  // Restricts address length to a maximum of 200 characters
        public string Address { get; set; }

        // Vendor's phone number (Required, with a max length of 15 characters, validated as a phone number)
        [Required]
        [Phone]  // Ensures the input matches a valid phone number format
        [StringLength(15)]  // Limits phone number to 15 characters
        public string PhoneNumber { get; set; }

        // Vendor's tax identification number (Required, no length limit specified)
        [Required]  // Ensures the field is mandatory
        public string TaxIdentificationNumber { get; set; }

        // Name of the vendor's bank (Required, with a max length of 50 characters)
        [Required]
        [StringLength(50)]  // Limits bank name length to 50 characters
        public string BankName { get; set; }

        // Vendor's bank account number (Required, with a max length of 20 characters)
        [Required]
        [StringLength(20)]  // Restricts account number to a maximum of 20 characters
        public string BankAccountNumber { get; set; }
    }
}
