using SoCot_HC_FE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoCot_HC_FE.Controllers
{
    public class WRAController : Controller
    {
        // GET: WRA
        public ActionResult List()
        {
            return View();
        }

        [ActionName("Add")]
        public ActionResult AddAction(int WRAId = 0)
        {
            var model = new WRA();
            return PartialView("~/Views/WRA/_WRAForm.cshtml", model);
        }
    }
}