using Task08.Models.DTO;
using Task08.Helpers;
using System;
using Task08.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Task08.Services
{
    public class AccountsDbService : IAccountsDbService
    {
        private  Context context;
        private  IConfiguration configuration;

        public AccountsDbService(Context context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public JwtSecurityToken GetToken()
        {
            Claim[] userClaims = new[]
            {
                new Claim(ClaimTypes.Role, "user"),
                new Claim(ClaimTypes.Role, "client")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "http://localhost",
                audience: "http://localhost",
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return token;
        }
        public async System.Threading.Tasks.Task<LoginHelper> LoginAsync(UserDto dto)
        {
            var wantedUser = await context.User.FirstOrDefaultAsync(e => e.Login == dto.Login);
            if (wantedUser == null)
                return new LoginHelper(DbAnswer.UserNotFound);

            if (wantedUser.Password != SecurityHelper.GetHashedSaltedPassword(dto.Password, wantedUser.Salt))
                return new LoginHelper(DbAnswer.BadPassword);

            var token = GetToken();

            wantedUser.RefreshToken = Guid.NewGuid().ToString();
            wantedUser.RerfreshTokenExpiration = DateTime.Now.AddHours(12);

            await context.SaveChangesAsync();

            return new LoginHelper(DbAnswer.OK, new JwtSecurityTokenHandler().WriteToken(token).ToString(), wantedUser.RefreshToken);
        }

        public async System.Threading.Tasks.Task<DbAnswer> RegisterAsync(UserDto dto)
        {
            //if (dto.Password.Length < 6) return DbAnswer.PasswordLengthIsNotProper;

            var checkUser = await context.User.FirstOrDefaultAsync(e => e.Login == dto.Login);
            if (checkUser != null) return DbAnswer.UserIsAlreadyRegistered;

            var hashedPwdAndSalt = SecurityHelper.GetHashedPasswordAndSalt(dto.Password);
            var user = new User
            {
                Login = dto.Login,
                Password = hashedPwdAndSalt.Item1,
                Salt = hashedPwdAndSalt.Item2,
                RefreshToken = Guid.NewGuid().ToString(),
                RerfreshTokenExpiration = DateTime.Now.AddHours(12)
            };

            await context.User.AddAsync(user);
            await context.SaveChangesAsync();

            return DbAnswer.OK;
        }

        public async System.Threading.Tasks.Task<LoginHelper> UpdateAccessTokenAsync(RefreshTokenDto dto)
        {
            var wantedUser = await context.User.FirstOrDefaultAsync(e => e.RefreshToken == dto.RefreshToken);
            if (wantedUser == null)
                return new LoginHelper(DbAnswer.UserNotFound);

            if (wantedUser.RerfreshTokenExpiration < DateTime.Now)
                return new LoginHelper(DbAnswer.RefreshTokenIsExpired);

            var token = GetToken();

            wantedUser.RefreshToken = Guid.NewGuid().ToString();
            wantedUser.RerfreshTokenExpiration = DateTime.Now.AddHours(12);

            await context.SaveChangesAsync();

            return new LoginHelper(DbAnswer.OK, new JwtSecurityTokenHandler().WriteToken(token).ToString(), wantedUser.RefreshToken);
        }
    }
}
