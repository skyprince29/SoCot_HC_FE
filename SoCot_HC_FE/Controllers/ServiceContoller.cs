using Newtonsoft.Json;
using SoCot_HC_FE.Configurations.Api.Endpoints;
using SoCot_HC_FE.Handler;
using SoCot_HC_FE.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SoCot_HC_FE.Controllers
{
    public class ServiceController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ServiceApi _serviceApi;

        public ServiceController()
        {
            _httpClient = new HttpClient();
            _serviceApi = new ServiceApi();
        }

        // Service Main View
        public ActionResult ServiceMain()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> LoadTable(int pageNo , int limit, string keyword)
        {
            try
            {
                string completeRoute = _serviceApi.GetPagedServicesUrl(pageNo, limit, keyword);
                HttpResponseMessage response = await _httpClient.GetAsync(completeRoute);

                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { success = false, message = "Failed to load data from API." }, JsonRequestBehavior.AllowGet);
                }

                string responseData = await response.Content.ReadAsStringAsync();
                var paginatedResult = JsonConvert.DeserializeObject<PaginationHandler<Service>>(responseData);

                return PartialView("~/Views/Service/_ServiceTableData.cshtml", paginatedResult);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Service/ShowServiceForm
        // GET: Service/ShowServiceForm/5
        public async Task<ActionResult> ShowServiceForm(Guid? id)
        {
            try
            {
                Service service = new Service();
                // If id has value, get the service for editing
                if (id.HasValue && id != Guid.Empty)
                {
                    string completeRoute = _serviceApi.GetServiceUrl(id.Value);
                    var response = await _httpClient.GetAsync(completeRoute);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        service = JsonConvert.DeserializeObject<Service>(jsonResponse);
                        return PartialView("~/Views/Service/_ServiceForm.cshtml", service);
                    }
                    
                    return Json(new { success = false, message = "Error retrieving service" });
                }
                else
                {
                    service.IsActive = true;
                }

                // If no id, return empty form for creating new service
                return PartialView("~/Views/Service/_ServiceForm.cshtml", service);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // GET: Service/Get/5
        public async Task<ActionResult> GetService(Guid id)
        {
            try
            {
                string completeRoute = _serviceApi.GetServiceUrl(id);
                var response = await _httpClient.GetAsync(completeRoute);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Service service = JsonConvert.DeserializeObject<Service>(jsonResponse);
                    return Json(service, JsonRequestBehavior.AllowGet);
                }

                return Json(new { success = false, message = "Error retrieving service" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: Service/Save
        [HttpPost]
        public async Task<ActionResult> SaveService(Service model)
        {
            try
            {
                string completeRoute = _serviceApi.SaveServiceUrl();
                var jsonContent = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(completeRoute, content);
                var errorResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = "Service saved successfully via API." });
                }
                else
                {
                    var errorObject = JsonConvert.DeserializeObject<ApiErrorResponse>(errorResponse);
                    if (!errorObject.success)
                    {
                        return Json(new { success = false, message = "Please fill in all required fields", errors = errorObject });
                    }
                    else
                    {
                        return Json(new { success = false, message = "An error occurred, but no detailed errors were provided." });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}