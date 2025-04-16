using System.Configuration;
using System.Linq;
using System.Collections.Generic;

namespace SoCot_HC_FE.Configurations.Api.Base
{
    public abstract class BaseApiConfig
    {
        protected readonly string BaseRoute;

        protected BaseApiConfig()
        {
            BaseRoute = ConfigurationManager.AppSettings["BaseRoute"];
        }

        protected string BuildUrl(string endpoint, Dictionary<string, object> queryParams = null)
        {
            var baseUrl = $"{BaseRoute}{endpoint}";
            
            if (queryParams == null || !queryParams.Any())
                return baseUrl;

            var query = string.Join("&", 
                queryParams.Select(p => $"{p.Key}={p.Value}"));

            return $"{baseUrl}?{query}";
        }
    }
}