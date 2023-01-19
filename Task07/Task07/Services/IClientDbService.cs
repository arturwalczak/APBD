using System.Threading.Tasks;

namespace Task07.Services
{
    public interface IClientDbService
    {
        Task DeleteClientAsync(int idClient);
    }
}
