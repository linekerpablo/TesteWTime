using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteWTime.Domain.Utilities
{
    public static class Utilities
    {
        public static string GenerateRandomUrl() => new Random(DateTime.Now.Millisecond).Next().ToString();

        public static string ShortUrl => !string.IsNullOrEmpty(ConfigurationManager.AppSettings["ShortUrl"]) ? ConfigurationManager.AppSettings["ShortUrl"] : string.Empty;
    }
}
