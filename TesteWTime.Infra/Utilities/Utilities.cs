using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteWTime.Infra.Utilities
{
    public static class Utilities
    {
        public static string ConnectionString => !string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings["TesteWTime"].ConnectionString) ? ConfigurationManager.ConnectionStrings["TesteWTime"].ConnectionString : string.Empty;
    }
}
