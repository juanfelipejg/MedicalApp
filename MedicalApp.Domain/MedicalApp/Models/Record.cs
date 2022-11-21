namespace MedicalApp.Domain.MedicalApp.Models
{
    public class Record
    {
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public string Specialty { get; set; }

        public IEnumerable<string> MedicalExams { get; set; }
    }
}
