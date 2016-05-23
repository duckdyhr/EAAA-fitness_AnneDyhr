using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_FitnessUsers.Controllers
{
    public class ClassBookingController : Controller
    {
        Service.Service service = Service.Service.Instance;
        // GET: ClassBooking
        public ActionResult Index()
        {
            var model = service.LoadClassBookingViewModel();
            model.SelectedDate = new DateTime(2016, 6, 20);
            return View(model);
        }

    }
}