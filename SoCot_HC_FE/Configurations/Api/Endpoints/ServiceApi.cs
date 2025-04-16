using SoCot_HC_FE.Configurations.Api.Base;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace SoCot_HC_FE.Configurations.Api.Endpoints
{
    public class ServiceApi : BaseApiConfig
    {
        private readonly string _serviceEndpoint;

        public ServiceApi()
        {
            _serviceEndpoint = ConfigurationManager.AppSettings["Service"];  // Gets "api/v1/Service"
        }

        public string GetPagedServicesUrl(int pageNo, int limit, string keyword = null)
        {
            var queryParams = new Dictionary<string, object>();
        
            // Only add parameters that have values
            queryParams.Add("pageNo", pageNo);
            queryParams.Add("limit", limit);
            if (!string.IsNullOrEmpty(keyword))
            {
                queryParams.Add("keyword", keyword);
            }

            return BuildUrl($"{_serviceEndpoint}/GetPagedServices", queryParams);
        }

        public string GetServiceUrl(Guid id)
        {
            return BuildUrl($"{_serviceEndpoint}/GetService/{id}");
        }

        public string SaveServiceUrl()
        {
            return BuildUrl($"{_serviceEndpoint}/SaveService");
        }
    }
}
