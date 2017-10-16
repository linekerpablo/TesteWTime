using TesteWTime.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System;

namespace TesteWTime.Domain.Interfaces.Services
{
    public interface IUrlsService : IServiceBase<Urls>
    {
        #region Methods

        Urls GetByUrlId(Int64 urlid);

        Urls GetByHits(Byte hits);

        Urls GetByUrl(String url);

        Urls GetByShortUrl(String shorturl);

        bool ValidatedRequiredFields();

        string GetStats();

        #endregion
    }
}


