using TesteWTime.Domain.Entities;
using System; 
using System.Collections.Generic;
using TesteWTime.Domain.Interfaces.Repositories;

namespace TesteWTime.Domain.Interfaces
{
    public interface IUrlsRepository : IRepositoryBase<Urls>
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


