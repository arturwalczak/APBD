using System.Collections.Generic;
using System;
using Task08.Models.DTO;

namespace Task08.Models
{
    public class PrescriptionDto
    {
        public DateTime PrescriptionDate { get; set; }
        public DateTime PrescriptionDueDate { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public DateTime PatientBirthDate { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorEmail { get; set; }
        public IEnumerable<MedicamentDto> Medicaments { get; set; }
    }
}
