using Newtonsoft.Json;
using SoCot_HC_FE.Handler;
using SoCot_HC_FE.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace SoCot_HC_FE.Controllers
{
    public class VitalSignController : Controller
    {
        private readonly HttpClient _httpClient;

        public VitalSignController()
        {
            _httpClient = new HttpClient();
        }

        // GET: VitalSign
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Add(long vitalSignId)
        {
            VitalSign vs = new VitalSign();

            if (vitalSignId > 0)
            {
                try
                {
                    string BaseRoute = ConfigurationManager.AppSettings["BaseRoute"];
                    string SaveUpdateVitalSign = ConfigurationManager.AppSettings["SaveUpdateVitalSign"];
                    string completeRoute = BaseRoute + SaveUpdateVitalSign;

                    HttpResponseMessage getResponse = await _httpClient.GetAsync($"{completeRoute}/{vitalSignId}");

                    if (getResponse.IsSuccessStatusCode)
                    {
                        var jsonResponse = await getResponse.Content.ReadAsStringAsync();
                        vs = JsonConvert.DeserializeObject<VitalSign>(jsonResponse);
                    }
                    else
                    {
                        return Json(new { success = false, message = "Unable to find the selected vital sign." });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] Fetching vital sign: {ex.Message}");
                    return Json(new { success = false, message = "An error occurred while fetching data." });
                }
            }

            return PartialView("~/Views/VitalSign/_vitalSignForm.cshtml", vs);
        }

        [HttpPost]
        public async Task<ActionResult> SaveVitalSign(VitalSign vitalSign)
        {
            if (vitalSign == null)
            {
                return Json(new { success = false, message = "Invalid Vital Sign data." });
            }

            try
            {
                var jsonContent = JsonConvert.SerializeObject(vitalSign);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                string BaseRoute = ConfigurationManager.AppSettings["BaseRoute"];
                string SaveUpdateVitalSign = ConfigurationManager.AppSettings["SaveUpdateVitalSign"];
                string completeRoute = BaseRoute + SaveUpdateVitalSign;

                HttpResponseMessage response = await _httpClient.PostAsync(completeRoute, content);
                var errorResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = "Vital Sign saved successfully via API." });
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
                Console.WriteLine($"[ERROR] Saving vital sign: {ex.Message}");
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult> LoadTable(int pageNo , int limit, string keyword)
        {
            try
            {
                string BaseRoute = ConfigurationManager.AppSettings["BaseRoute"];
                string GetVitalSign = ConfigurationManager.AppSettings["GetVitalSign"];
                string completeRoute = $"{BaseRoute}{GetVitalSign}?pageNo={pageNo}&limit={limit}&keyword={keyword}";

                HttpResponseMessage response = await _httpClient.GetAsync(completeRoute);

                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { success = false, message = "Failed to load data from API." }, JsonRequestBehavior.AllowGet);
                }

                string responseData = await response.Content.ReadAsStringAsync();
                var paginatedResult = JsonConvert.DeserializeObject<PaginationHandler<VitalSign>>(responseData);

                return PartialView("~/Views/VitalSign/_vitalSignTableData.cshtml", paginatedResult);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}