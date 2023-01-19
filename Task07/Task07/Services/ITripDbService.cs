using System.Collections.Generic;
using System.Threading.Tasks;
using Task07.Models.DTO;

namespace Task07.Services
{
    public interface ITripDbService
    {
        Task<IEnumerable<GetTripsResponseDto>> GetTripsAsync();
        Task AddTripToClientAsync(int idTrip, AddTripToClientRequestDto dto);
    }
}
