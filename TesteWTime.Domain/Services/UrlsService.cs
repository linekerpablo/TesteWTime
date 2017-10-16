using TesteWTime.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System;
using TesteWTime.Domain.Interfaces;
using TesteWTime.Domain.Interfaces.Services;

namespace TesteWTime.Domain.Services
{
    public class UrlsService : ServiceBase<Urls>, IUrlsService
    {
        private readonly IUrlsRepository _urlsRepository;

        public UrlsService(IUrlsRepository urlsRepository)
         : base(urlsRepository)
        {
            _urlsRepository = urlsRepository;
        }

        #region Methods

        public Urls GetByUrlId(Int64 urlid)
        {
            return _urlsRepository.GetByUrlId(urlid);
        }

        public Urls GetByHits(Byte hits)
        {
            return _urlsRepository.GetByHits(hits);
        }

        public Urls GetByUrl(String url)
        {
            return _urlsRepository.GetByUrl(url);
        }

        public Urls GetByShortUrl(String shorturl)
        {
            return _urlsRepository.GetByShortUrl(shorturl);
        }

        public bool ValidatedRequiredFields()
        {
            return false;
        }

        public string GetStats()
        {
            return _urlsRepository.GetStats();
        }

        #endregion

        #region Custom methods

        #endregion
    }
}


