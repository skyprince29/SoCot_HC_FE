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
    public class SchoolAgeProfileController : Controller
    {
        private readonly HttpClient _httpClient;

        // GET: SchoolAgeProfile
        public ActionResult SchoolAgeList()
        {
            return View();
        }

        [ActionName("Add")]
        public ActionResult AddAction(int SchoolAgeId = 0)
        {
            var model = new SchoolAgeProfile();
            return PartialView("~/Views/SchoolAge/_SchoolAgeForm.cshtml", model);
        }
    }
}