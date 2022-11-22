namespace MedicalApp.Domain.MedicalApp.Models
{
    public class Medicine
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> Uses { get; set; }

        public IEnumerable<string> AvailablePlaces { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<string> Presentations { get; set; }
    }
}
