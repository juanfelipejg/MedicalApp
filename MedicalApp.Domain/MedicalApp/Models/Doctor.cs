using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Domain.MedicalApp.Models
{
    internal class Doctor
    {
        public string Identification { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Specialty { get; set; }

        public string Office { get; set; }

        public string Schedule { get; set; }
    }
}
