using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace featherink.Services
{
    public interface IUserService
    {
        Task<string> AuthenticateAsync(string username, string password);
        Task<string> RegistrateAsync(string username, string password);
        IEnumerable<Claim> CreateClaims(string userId);

        string CreateJwtToken(string userId, DateTime expiry,
            string algorithmType = SecurityAlgorithms.HmacSha256Signature);
    }
}
