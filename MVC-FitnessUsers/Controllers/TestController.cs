using MVC_FitnessUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_FitnessUsers.Controllers
{
    public class TestController : Controller
    {
        Service.Service service = Service.Service.Instance;
        // GET: Test
        public ActionResult Index()
        {
            var model = service.LoadClassBookingViewModel();
            model.Classes = service.GetAllFitnessClasses();
            model.LblTest = "Tekst property fra ClassBookingViewModel";
            return View(model);
        }
    }
}