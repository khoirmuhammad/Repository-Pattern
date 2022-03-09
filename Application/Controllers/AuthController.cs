using Application.Jwt;
using Domain.CommonModels;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private ITokenService _token;
        public AuthController(IRepositoryWrapper repository, ITokenService token)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(_repository));
            _token = token ?? throw new ArgumentNullException(nameof(_token));
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login([FromBody]CredentialRequest request)
        {
            CredentialResponse response = new CredentialResponse();

            if (request == null)
            {
                response.Message = "Insert Credential";
                return StatusCode(400, response);
            }

            User user = await _repository.User.FIndAsyncByCredential(request.Email, request.Password);

            if (user != null)
            {
                response.Token = _token.GenerateToken(user);
                response.RefreshToken = _token.GenerateRefreshToken();
                response.UniqueIdentity = user.Email;

                return StatusCode(200, response);
            }
            else
            {
                response.Message = "User unauthorized";
                return StatusCode(200, response);
            }

        }
    }
}
