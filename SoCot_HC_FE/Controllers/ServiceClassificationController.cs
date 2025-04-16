using Newtonsoft.Json;
using SoCot_HC_FE.Configurations.Api.Endpoints;
using SoCot_HC_FE.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SoCot_HC_FE.Controllers
{
    public class ServiceClassificationController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ServiceClassificationApi _serviceClassificationApi;

        public ServiceClassificationController()
        {
            _httpClient = new HttpClient();
            _serviceClassificationApi = new ServiceClassificationApi();
        }

        // GET: ServiceClassification/Get/5
        public async Task<ActionResult> GetServiceClassification(int id)
        {
            try
            {
                string completeRoute = _serviceClassificationApi.GetServiceClassificationUrl(id);
                var response = await _httpClient.GetAsync(completeRoute);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    ServiceClassification serviceClassification = JsonConvert.DeserializeObject<ServiceClassification>(jsonResponse);
                    return Json(serviceClassification, JsonRequestBehavior.AllowGet);
                }

                return Json(new { success = false, message = "Error retrieving service classification" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

            // GET: ServiceClassification/GetServiceClassifications
        public async Task<ActionResult> GetServiceClassifications(bool isActiveOnly = true, int? currentId = null)
        {
            try
            {
                string completeRoute = _serviceClassificationApi.GetServiceClassifications(isActiveOnly, currentId.Value);
                var response = await _httpClient.GetAsync(completeRoute);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    List<ServiceClassification> serviceClassifications = JsonConvert.DeserializeObject<List<ServiceClassification>>(jsonResponse);
                    return Json(serviceClassifications, JsonRequestBehavior.AllowGet);
                }

                return Json(new { success = false, message = "Error retrieving service classifications" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
} 