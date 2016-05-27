using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_FitnessUsers.Models
{
    public class HomeController : Controller
    {
        private Service.Service service;
        public HomeController()
        {
            service = Service.Service.Instance;
        }
        // GET: Home
        public ActionResult Index()
        {
            var classes = service.GetAllFitnessClasses();
            return View(classes);
        }
    }
}