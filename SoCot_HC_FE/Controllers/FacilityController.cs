using SoCot_HC_FE.Handler;
using SoCot_HC_FE.Models;
using SoCot_HC_FE.TestData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Ast.Selectors;

namespace SoCot_HC_FE.Controllers
{
    public class FacilityController : Controller
    {
        private FacilityData FacilityData = new FacilityData();
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
    }
}