using TesteWTime.Domain.Entities;
using System.Collections.Generic;
using TesteWTime.Domain.Interfaces;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using Newtonsoft.Json.Linq;
using System;
using Newtonsoft.Json;

namespace TesteWTime.Infra.Repositories
{
    public class UrlsRepository : RepositoryBase<Urls>, IUrlsRepository
    {
        #region Methods

        public Urls GetByUrlId(Int64 urlid)
        {
            return Db.Urlss.Where(p => p.UrlId.Equals(urlid)).FirstOrDefault();
        }

        public Urls GetByHits(Byte hits)
        {
            return Db.Urlss.Where(p => p.Hits.Equals(hits)).FirstOrDefault();
        }

        public Urls GetByUrl(String url)
        {
            return Db.Urlss.Where(p => p.Url.Equals(url)).FirstOrDefault();
        }

        public Urls GetByShortUrl(String shorturl)
        {
            return Db.Urlss.Where(p => p.ShortUrl.Equals(shorturl)).FirstOrDefault();
        }

        public bool ValidatedRequiredFields()
        {
            return false;
        }

        public string GetStats()
        {
            //Create the command
            SqlCommand objCmd = new SqlCommand();

            //Open the connection
            StringBuilder commandSql = new StringBuilder(@"select 
                            	sum(hits) as hits,
                            	count(UrlId) as urlCount,
                            	(select top 10 * from Urls 
                            		order by Hits desc
                            		for json auto) as topUrls
                            from urls
                            for json auto");

            objCmd.CommandText = commandSql.ToString();

            objCmd.Connection = new SqlConnection { ConnectionString = Utilities.Utilities.ConnectionString };
            objCmd.Connection.Open();

            SqlDataReader sqlDataReader = objCmd.ExecuteReader();
            
            string json = null;

            while (sqlDataReader.Read())
            {
                json = sqlDataReader.GetValue(0).ToString();
            }

            objCmd.Connection.Close();

            return json;
        }

        #endregion
    }
}


