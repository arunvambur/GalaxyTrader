using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyTrader
{
    public class QueryGalaxyException : Exception
    {
        public string Query { get; set; }

        public string Token { get; set; }

        public QueryGalaxyException(string message, string query, Exception innerException) 
            : base(message, innerException)
        {
            Query = query;
        }

        public QueryGalaxyException(string message, string query, string token, Exception innerException) 
            : base(message, innerException)
        {
            Query = query;
            Token = token;
        }
    }
}
