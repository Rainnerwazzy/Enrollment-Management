using JWTAuthorization.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthorization.Api.Business.AuthService.Interfaces
{
    public interface IAuthService
    {
        public Task<string> Login(User login);
    }
}
