using Newtonsoft.Json;
using SoCot_HC_FE.Configurations.Api.Endpoints;
using SoCot_HC_FE.Handler;
using SoCot_HC_FE.Models;
using SoCot_HC_FE.TestData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Ast.Selectors;

namespace SoCot_HC_FE.Controllers
{

    public class FacilityController : Controller
    {

        private FacilityData FacilityData = new FacilityData();
        private readonly HttpClient _httpClient;
        private readonly FacilityApi _facilityApi;


        public FacilityController()
        {
            _httpClient = new HttpClient();
            _facilityApi = new FacilityApi();
        }
        // GET: Facility
        public ActionResult List()
        {
            return View();
        }

        public async Task<ActionResult> LoadTable(int pageNo, int limit, string keyword)
        {
      
            try
            {
                string completeRoute = _facilityApi.GetPagedFacilities(pageNo, limit, keyword);
                HttpResponseMessage response = await _httpClient.GetAsync(completeRoute);

                if (!response.IsSuccessStatusCode)
                {
                    return Json(new { success = false, message = "Failed to load data from API." }, JsonRequestBehavior.AllowGet);
                }

                string responseData = await response.Content.ReadAsStringAsync();
                var paginatedResult = JsonConvert.DeserializeObject<PaginationHandler<Facility>>(responseData);

                return PartialView("~/Views/Facility/_facilityTableData.cshtml", paginatedResult);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Add(long facilityId)
        {
            Facility facility = new Facility();
            bool isForTesting = bool.TryParse(ConfigurationManager.AppSettings["IsForTesting"], out bool result) && result;
            if (isForTesting)
            {
                facility.Address = new Address();
                ViewBag.ProvincesList = new List<SelectListItem>
                    {
                        new SelectListItem { Text = "South Cotabato", Value = "1" },
                        new SelectListItem { Text = "Sultan Kudarat", Value = "2" },
                        new SelectListItem { Text = "North Cotabato", Value = "3" },
                        new SelectListItem { Text = "Quezon Province", Value = "4" }
                    };
            }
            else
            {
                if (facilityId > 0)
                {
                    try
                    {
                        string BaseRoute = ConfigurationManager.AppSettings["BaseRoute"];
                        string SaveUpdateFacility = ConfigurationManager.AppSettings["SaveUpdateFacility"];
                        string completeRoute = BaseRoute + SaveUpdateFacility;

                        HttpResponseMessage getResponse = await _httpClient.GetAsync($"{completeRoute}/{facilityId}");

                        if (getResponse.IsSuccessStatusCode)
                        {
                            var jsonResponse = await getResponse.Content.ReadAsStringAsync();
                            facility = JsonConvert.DeserializeObject<Facility>(jsonResponse);
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
                else
                {
                    facility.Address = new Address();
                    string BaseRoute = ConfigurationManager.AppSettings["BaseRoute"];
                    string AddressBaseRoute = ConfigurationManager.AppSettings["AddressBaseRoute"];
                    string GetProvinces = ConfigurationManager.AppSettings["GetProvince"];

                    string completeRoute = BaseRoute + AddressBaseRoute + GetProvinces;
                    HttpResponseMessage getResponse = await _httpClient.GetAsync($"{completeRoute}");
                    if (getResponse.IsSuccessStatusCode)
                    {
                        var jsonResponse = await getResponse.Content.ReadAsStringAsync();
                        List<Province> provinces = JsonConvert.DeserializeObject<List<Province>>(jsonResponse);
                        ViewBag.ProvincesList = provinces.Select(p => new SelectListItem
                        {
                            Text = p.ProvinceName,
                            Value = p.ProvinceId.ToString()
                        }).ToList();
                    }
                    else
                    {
                        return Json(new { success = false, message = "Unable to find the selected vital sign." });
                    }
                }
            }


            return PartialView("~/Views/Facility/_addFacilityForm.cshtml", facility);
        }

        [HttpGet]
        public async Task<ActionResult> LoadMunicipalities(int provinceId)
        {
            string BaseRoute = ConfigurationManager.AppSettings["BaseRoute"];
            string AddressBaseRoute = ConfigurationManager.AppSettings["AddressBaseRoute"];
            string GetMunicipality = ConfigurationManager.AppSettings["GetMunicipality"];

            string fullUrl = $"{BaseRoute}{AddressBaseRoute}{GetMunicipality}?ProvinceId={provinceId}";

            HttpResponseMessage response = await _httpClient.GetAsync(fullUrl);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var municipalities = JsonConvert.DeserializeObject<List<Municipality>>(json);
                return Json(new { success = true, data = municipalities }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, message = "Failed to load municipalities." }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public async Task<ActionResult> LoadBarangays(int cityMunicipalId)
        {
            string BaseRoute = ConfigurationManager.AppSettings["BaseRoute"];
            string AddressBaseRoute = ConfigurationManager.AppSettings["AddressBaseRoute"];
            string GetBarangay = ConfigurationManager.AppSettings["GetBarangay"];

            string fullUrl = $"{BaseRoute}{AddressBaseRoute}{GetBarangay}?CityMunicipalId={cityMunicipalId}";

            HttpResponseMessage response = await _httpClient.GetAsync(fullUrl);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var barangays = JsonConvert.DeserializeObject<List<Barangay>>(json);

                return Json(new { success = true, data = barangays }, JsonRequestBehavior.AllowGet); // <-- wrap in success:true
            }

            return Json(new { success = false, message = "Failed to load barangays." }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public async Task<ActionResult> SaveFacility(Facility facility)
        {
            if (facility == null)
            {
                return Json(new { success = false, message = "Invalid Vital Sign data." });
            }

            try
            {
                var jsonContent = JsonConvert.SerializeObject(facility);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                string BaseRoute = ConfigurationManager.AppSettings["BaseRoute"];
                string SaveUpdateFacility = ConfigurationManager.AppSettings["SaveUpdateFacility"];
                string completeRoute = BaseRoute + SaveUpdateFacility;

                HttpResponseMessage response = await _httpClient.PostAsync(completeRoute, content);
                var errorResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = "Facility saved successfully via API." });
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
                Console.WriteLine($"[ERROR] Saving facility: {ex.Message}");
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }


    }
}