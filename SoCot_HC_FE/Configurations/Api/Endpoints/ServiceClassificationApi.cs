using SoCot_HC_FE.Configurations.Api.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Razor.Tokenizer.Symbols;

namespace SoCot_HC_FE.Configurations.Api.Endpoints
{
    public class ServiceClassificationApi : BaseApiConfig
    {
        private readonly string _serviceClassificationEndpoint;

        public ServiceClassificationApi()
        {
            _serviceClassificationEndpoint = ConfigurationManager.AppSettings["ServiceClassfication"];  // Gets "api/v1/Service"
        }

        public string GetServiceClassificationUrl(int id)
        {
            return BuildUrl($"{_serviceClassificationEndpoint}/GetServiceClassification/{id}");
        }

        public string GetServiceClassifications(bool isActiveOnly = true, int? currentId = null)
        {
            var queryParams = new Dictionary<string, object>();

            // Only add parameters that have values
            queryParams.Add("isActiveOnly", isActiveOnly);
            if (currentId.HasValue && currentId.Value > 0)
            {
                queryParams.Add("currentId", currentId);
            }
            return BuildUrl($"{_serviceClassificationEndpoint}/GetServiceClassifications", queryParams);
        }
    }
}