using TesteWTime.Domain.Entities;
using TesteWTime.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteWTime.WebApi.Models;
using System.Threading.Tasks;

namespace TesteWTime.WebApi.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        #region Methods
        // GET: api/Users/ 5
        [HttpGet]
        [Route("user/{id}")]
        public async Task<Users> Get(Int64 id)
        {
            Users objUsers = _usersRepository.GetById(id);

            return await Task.Run(() =>
            {
                return objUsers;
            });
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<Users>> GetAll()
        {
            IEnumerable<Users> lstUserss = _usersRepository.GetAll();

            return await Task.Run(() =>
            {
                return lstUserss;
            });
        }
        [HttpPost]
        [Route("add")]
        public async Task<HttpResponseMessage> Add([FromBody]UsersModel objUsersModel)
        {
            HttpRequestMessage request = new HttpRequestMessage();

            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                Users objUsers = new Users { Name = objUsersModel.name };

                _usersRepository.Add(objUsers);

                return await Task.Run(() =>
                {
                    return request.CreateResponse(HttpStatusCode.OK, objUsers, Configuration.Formatters.JsonFormatter);
                });
            }
            catch (Exception ex)
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("delete")]
        public async Task<HttpResponseMessage> Delete([FromBody]Users objUsers)
        {
            HttpRequestMessage request = new HttpRequestMessage();

            try
            {
                _usersRepository.Remove(objUsers);

                return await Task.Run(() =>
                {
                    return request.CreateResponse(HttpStatusCode.OK);
                });
            }
            catch (Exception ex)
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("Update")]
        public async Task<HttpResponseMessage> Update([FromBody]Users objUsers)
        {
            HttpRequestMessage request = new HttpRequestMessage();

            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                _usersRepository.Update(objUsers);

                return await Task.Run(() =>
                {
                    return request.CreateResponse(HttpStatusCode.OK);
                });
            }
            catch (Exception ex)
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        #endregion
    }
}


