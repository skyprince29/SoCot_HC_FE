using Newtonsoft.Json;
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


        public FacilityController()
        {
            _httpClient = new HttpClient();
        }
        // GET: Facility
        public ActionResult List()
        {
            return View();
        }

        public async Task<ActionResult> LoadTable(int pageNo, int limit, string keyword)
        {
            PaginationHandler<Facility> paginatedResult = null;
            bool isForTesting = bool.TryParse(ConfigurationManager.AppSettings["IsForTesting"], out bool result) && result;
            if (isForTesting)
            {
                paginatedResult = await FacilityData.GetListofFacility(pageNo, limit);
                return PartialView("~/Views/Facility/_facilityTableData.cshtml", paginatedResult);
            }
            return View();
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

        //[HttpGet]
        //public JsonResult GetMunicipalities(int provinceId)
        //{
        //    var list = db.Municipalities
        //                 .Where(m => m.ProvinceId == provinceId)
        //                 .Select(m => new { m.Id, m.Name })
        //                 .ToList();

        //    return Json(list, JsonRequestBehavior.AllowGet);
        //}

        //[HttpGet]
        //public JsonResult GetBarangays(int municipalityId)
        //{
        //    var list = db.Barangays
        //                 .Where(b => b.MunicipalityId == municipalityId)
        //                 .Select(b => new { b.Id, b.Name })
        //                 .ToList();

        //    return Json(list, JsonRequestBehavior.AllowGet);
        //}

    }
}