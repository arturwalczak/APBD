using Microsoft.IdentityModel.Logging;
using System.Threading.Tasks;
using Task08.Models.DTO;
using Task08.Helpers;

namespace Task08.Services
{
    public interface IAccountsDbService
    {
        public Task<DbAnswer> RegisterAsync(UserDto dto);
        public Task<LoginHelper> LoginAsync(UserDto dto);
        public Task<LoginHelper> UpdateAccessTokenAsync(RefreshTokenDto dto);
    }
}
