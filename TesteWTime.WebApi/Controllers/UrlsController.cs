using TesteWTime.Domain.Entities;
using TesteWTime.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteWTime.Domain.Utilities;
using TesteWTime.WebApi.Models;
using TesteWTime.WebApi.Services;
using System.Web.Http.Results;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TesteWTime.WebApi.Controllers
{
    [RoutePrefix("urls")]
    public class UrlsController : ApiController
    {
        private readonly IUrlsRepository _urlsRepository;

        public UrlsController(IUrlsRepository urlsRepository)
        {
            _urlsRepository = urlsRepository;
        }

        #region Methods
        // GET: api/Urls/ 5
        [HttpGet]
        [Route("stats/{id}")]
        public async Task<Urls> Get(Int64 id)
        {
            Urls objUrls = _urlsRepository.GetById(id);

            return await Task.Run(() =>
            {
                return objUrls;
            });
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<Urls>> GetAll()
        {
            return await Task.Run(() =>
            {
                return _urlsRepository.GetAll();
            });
        }

        [HttpPost]
        [Route("add")]
        public async Task<HttpResponseMessage> Add([FromBody]UrlsModel objUrlsModel)
        {
            HttpRequestMessage request = new HttpRequestMessage();

            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                Urls objUrls = await Task.Run(() =>
                {
                    return _urlsRepository.GetByUrl(objUrlsModel.url);
                });

                if (objUrls == null)
                {
                    objUrls = new Urls();

                    objUrls.Url = objUrlsModel.url;
                    objUrls.ShortUrl = $"{Utilities.ShortUrl}{Utilities.GenerateRandomUrl()}";

                    await Task.Run(() =>
                    {
                        _urlsRepository.Add(objUrls);
                    });
                }
                else
                {
                    objUrls.Hits = objUrls.Hits + 1;

                    await Task.Run(() =>
                    {
                        _urlsRepository.Update(objUrls);
                    });
                }

                string jsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(objUrls);

                return request.CreateResponse(HttpStatusCode.OK, jsonObject, Configuration.Formatters.JsonFormatter);
            }
            catch (Exception ex)
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("delete")]
        public async Task<HttpResponseMessage> Delete([FromBody]Urls objUrls)
        {
            HttpRequestMessage request = new HttpRequestMessage();

            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                await Task.Run(() =>
                {
                    _urlsRepository.Remove(objUrls);
                });

                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("Update")]
        public async Task<HttpResponseMessage> Update([FromBody]Urls objUrls)
        {
            HttpRequestMessage request = new HttpRequestMessage();

            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                await Task.Run(() =>
                {
                    _urlsRepository.Update(objUrls);
                });

                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("stats")]
        public async Task<HttpResponseMessage> GetStats()
        {
            HttpRequestMessage request = new HttpRequestMessage();

            try
            {
                return await Task.Run(() =>
                {
                    return request.CreateResponse(HttpStatusCode.OK, JsonConvert.DeserializeObject(_urlsRepository.GetStats()), Configuration.Formatters.JsonFormatter);
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}


