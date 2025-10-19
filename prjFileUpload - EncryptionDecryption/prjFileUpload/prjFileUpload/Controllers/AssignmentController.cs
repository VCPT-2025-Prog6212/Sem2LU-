using Microsoft.AspNetCore.Mvc;
using prjFileUpload.Models;

namespace prjFileUpload.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        // used to access wwwroot and file

        public AssignmentController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            // tells the system to look at the wwwroot
        }

        private static List<Assignment> assignments = new List<Assignment>();
        // store list in memory
        public IActionResult Index()
        {
            return View(assignments); // returns the list 
        }

        [HttpPost]

        // action method for handling post requests - file uploads
        public IActionResult Upload(IFormFile file, string uploaderName)
        {
            if (file != null && file.Length > 0)
            {
                // get orginial file name
                var fileName = Path.GetFileName(file.FileName); 

                // create the path to save the file under wwwroot/uploads
                var path = Path.Combine(_webHostEnvironment.WebRootPath,
                    "uploads", fileName);

                using (var stream = new MemoryStream()) // changed from file stream to memory stream
                {
                    file.CopyTo(stream); // copy the uploaded file into the stream
                    var fileBytes = stream.ToArray(); // added this for encrypt
                    var encryptedBytes = EncryptionHelper.Encrypt(fileBytes); // added this for encrypt
                    System.IO.File.WriteAllBytes(path, encryptedBytes); // added this for encrypt
                }
                assignments.Add(new Assignment // add assignment details to the list
                {
                    id = assignments.Count + 1,
                    fileName = fileName,
                    uploaderName = uploaderName,
                    uploadDate = DateTime.Now
                });
            }
            return RedirectToAction("Index"); // show the updated list
        }

        // action method to open / download a file by name

        public ActionResult OpenFile(string fileName)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", fileName);
            var encryptedBytes = System.IO.File.ReadAllBytes(path); // changed variable name here for decrypt
            var decryptedBytes = EncryptionHelper.Decrypt(encryptedBytes); // added this for decrypt

            // return the file to browers as download
            return File(decryptedBytes, "application/octet-stream", fileName); // changed here for decrypt
        }
    }
}
