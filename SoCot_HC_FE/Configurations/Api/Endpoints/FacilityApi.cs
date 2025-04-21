using SoCot_HC_FE.Configurations.Api.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SoCot_HC_FE.Configurations.Api.Endpoints
{
    public class FacilityApi : BaseApiConfig
    {
        private readonly string _facilityEndpoint;

        public FacilityApi()
        {
            _facilityEndpoint = ConfigurationManager.AppSettings["Facility"];  // Gets "api/v1/Facility"
        }



        public string GetPagedFacilities(int pageNo, int limit, string keyword = null)
        {
            var queryParams = new Dictionary<string, object>();

            // Only add parameters that have values
            queryParams.Add("pageNo", pageNo);
            queryParams.Add("limit", limit);
            if (!string.IsNullOrEmpty(keyword))
            {
                queryParams.Add("keyword", keyword);
            }

            return BuildUrl($"{_facilityEndpoint}/GetPagedFacilities", queryParams);
        }

    }
}