namespace MedicalApp.Domain.MedicalApp.Models
{
    public class Patient
    {
        public string Identification { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string City { get; set; }

        public IEnumerable<string> DiseasesAllergies { get; set; }   

        public string PhoneNumber { get; set; }

        public string Rh { get; set; }
    }
}
