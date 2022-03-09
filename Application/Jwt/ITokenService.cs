using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Jwt
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        bool ValidateToken(string key, string issuer, string audience, string token);
        string GenerateRefreshToken();
    }
}
