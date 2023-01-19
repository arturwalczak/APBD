using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Task08.Models;
using Task08.Models.DTO;

namespace Task08.Services
{
    public class DoctorDbService : IDoctorDbService
    {
        private Context context;

        public DoctorDbService(Context context)
        {
            this.context = context;
        }

        public async Task<string> AddDoctorAsync(DoctorDto dto)
        {
            
                await context.AddAsync(new Doctor
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email
                });
                await context.SaveChangesAsync();
            return("Added");
            
        }

        public async Task<string> ChangeDoctorAsync(int id, DoctorDto dto)
        {
            var changedDoctor = await context.Doctor.FindAsync(id);

            if (changedDoctor == null)
            {
                return "Can not find doctor";
            }                

            changedDoctor.LastName = dto.LastName;
            changedDoctor.FirstName = dto.FirstName;
            changedDoctor.Email = dto.Email;

            await context.SaveChangesAsync();

            return "Changed";
        }

        public async Task<string> DeleteDoctorAsync(int id)
        {
            var deleteDoctor = await context.Doctor.FindAsync(id);

            if (deleteDoctor == null)
            {
                return "Can not doctor";
            }               

            var isHavingPatiets = await context.Prescription.AnyAsync(e => e.IdDoctor == id);

            if (isHavingPatiets)
            {
                return "Cant delete, doctor has patients";
            }                

            context.Remove(deleteDoctor);
            await context.SaveChangesAsync();

            return "Deleted";
        }
        
        public async Task<System.Collections.Generic.IEnumerable<DoctorDto>> GetDoctorsAsync()
        {
            return await context.Doctor.Select(e => new DoctorDto
            {                
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email
            }).ToListAsync();
                
        }
        
        public async Task<PrescriptionDto> GetPrescriptionAsync(int id)
        {
            var prescription = await context.Prescription.FindAsync(id);

            if (prescription == null)
                return null;

            PrescriptionDto prescriptionDto = await context
                .Prescription
                .Where(e => e.IdPrescription == id)
                .Select(e => new PrescriptionDto
                {
                    PrescriptionDate = e.Date,
                    PrescriptionDueDate = e.DueDate,
                    PatientFirstName = e.IdPatientNav.FirstName,
                    PatientLastName = e.IdPatientNav.LastName,
                    PatientBirthDate = e.IdPatientNav.BirthDate,
                    DoctorFirstName = e.IdDoctorNav.FirstName,
                    DoctorLastName = e.IdDoctorNav.LastName,
                    DoctorEmail = e.IdDoctorNav.Email,
                    Medicaments = e.PrescriptionMedicaments.Select(e => new MedicamentDto
                    {
                        Name = e.IdMedicamentNav.Name,
                        Details = e.Details,
                        Dose = e.Dose
                    })
                }).FirstAsync();

            return prescriptionDto;
        }
        
    }
}
