using Domain.CommonModels;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public UserController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Response<IEnumerable<User>> response = new Response<IEnumerable<User>>();

            try
            {
                IEnumerable<User> users = await _repository.User.FindAllAsync();

                response.IsSucceed = true;
                response.Data = users;

                return StatusCode(200, response);
            }
            catch(WebException wex)
            {
                response.Message = wex.Message;

                var webResponse = wex.Response as HttpWebResponse;

                return StatusCode(webResponse == null ? 500 : (int)webResponse.StatusCode, response);

            }
            catch(Exception ex)
            {
                response.Message = ex.Message;

                return StatusCode(500, response);
            }
            
        }

        //[HttpGet("{id}", Name = "GetById"), Authorize]
        [HttpGet, Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery]string id)
        {
            Response<User> response = new Response<User>();

            try
            {
                User user = await _repository.User.FindAsyncById(id);

                response.IsSucceed = true;
                response.Data = user;

                return StatusCode(200, response);
            }
            catch (WebException wex)
            {
                response.Message = wex.Message;

                var webResponse = wex.Response as HttpWebResponse;

                return StatusCode(webResponse == null ? 500 : (int)webResponse.StatusCode, response);

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

                return StatusCode(500, response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User user)
        {
            Response<string> response = new Response<string>();

            try
            {
                _repository.User.Create(user);
                await _repository.SaveAsync();

                response.IsSucceed = true;
                response.Data = user.Id;

                return StatusCode(201, response);
            }
            catch(WebException wex)
            {
                response.Message = wex.Message;

                var webResponse = wex.Response as HttpWebResponse;

                return StatusCode(webResponse == null ? 500 : (int)webResponse.StatusCode, response);
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;

                return StatusCode(500, response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]User user)
        {
            Response<string> response = new Response<string>();

            try
            {
                _repository.User.Update(user);
                await _repository.SaveAsync();

                response.IsSucceed = true;
                response.Data = user.Id;

                return StatusCode(200, response);
            }
            catch (WebException wex)
            {
                response.Message = wex.Message;

                var webResponse = wex.Response as HttpWebResponse;

                return StatusCode(webResponse == null ? 500 : (int)webResponse.StatusCode, response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

                return StatusCode(500, response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            Response<string> response = new Response<string>();

            try
            {
                User user = await _repository.User.FindAsyncById(id);

                if (user == null)
                {
                    response.Message = "Unable to find user data";
                    return StatusCode(404, response);
                }

                _repository.User.Delete(user);
                await _repository.SaveAsync();

                response.IsSucceed = true;
                response.Data = user.Id;

                return StatusCode(200, response);
            }
            catch (WebException wex)
            {
                response.Message = wex.Message;

                var webResponse = wex.Response as HttpWebResponse;

                return StatusCode(webResponse == null ? 500 : (int)webResponse.StatusCode, response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

                return StatusCode(500, response);
            }
        }
    }
}
