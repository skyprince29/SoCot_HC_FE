using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SoCot_HC_FE.Models;

namespace SoCot_HC_FE.Controllers
{
    public class PersonsController : Controller
    {
        [HttpGet]
        public ActionResult List()
        {
            //SAMPLE DATA
            var personList = new List<Person>
            {
                new Person
                {
                    PersonId = Guid.NewGuid(),
                    Firstname = "John",
                    Middlename = "A.",
                    Lastname = "Doe",
                    Birthdate = "1990-01-01"
                },
                new Person
                {
                    PersonId = Guid.NewGuid(),
                    Firstname = "Jane",
                    Middlename = "B.",
                    Lastname = "Smith",
                    Birthdate = "1985-07-15"
                }
            };

            return View(personList);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

    }
}