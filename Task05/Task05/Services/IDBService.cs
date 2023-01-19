using System.Threading.Tasks;
using Task05.Models;

namespace Task05.Services
{
    public interface IDBService
    {
        Task<int> AddProductToWarehouseAsync(ProductWarehouse productWarehouse);
    }
}
