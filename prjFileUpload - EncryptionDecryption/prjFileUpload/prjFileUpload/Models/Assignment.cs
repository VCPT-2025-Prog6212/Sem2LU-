namespace prjFileUpload.Models
{
    public class Assignment
    {
        public int id {  get; set; }

        public string fileName { get; set; }

        public string uploaderName { get; set; }    

        public DateTime uploadDate { get; set; }
    }
}
