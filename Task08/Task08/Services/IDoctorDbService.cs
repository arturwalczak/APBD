using System.Collections.Generic;
using System.Threading.Tasks;
using Task08.Models;
using Task08.Models.DTO;

namespace Task08.Services
{
    public interface IDoctorDbService
    {

        Task<IEnumerable<DoctorDto>> GetDoctorsAsync();
        
        Task<string> AddDoctorAsync(DoctorDto dto);
        Task<string> ChangeDoctorAsync(int id, DoctorDto dto);
        Task<string> DeleteDoctorAsync(int id);
        Task<PrescriptionDto> GetPrescriptionAsync(int id);
    }
}
