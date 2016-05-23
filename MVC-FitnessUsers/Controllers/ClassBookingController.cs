using MVC_FitnessUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_FitnessUsers.Controllers
{
    public class ClassBookingController : Controller
    {
        Service.Service _service;
        public ClassBookingController()
        {
            _service = Service.Service.Instance;
        }
        // GET: ClassBooking
        public ActionResult Index()
        {
            var model = _service.LoadClassBookingViewModel();
            model.SelectedDate = new DateTime(2016, 6, 20);
            return View(model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken] //er min form blevet hacket??
        //public ActionResult Index(FormCollection formCollection)
        //{
        //    var disciplin = formCollection["SelectedDiscipline"];
        //    var instructor = formCollection["SelectedInstructor"];
        //    var date = formCollection["SelectedDate"];
        //    //Lav redirect til Index()
        //    return View();
        //}
        [HttpPost]
        //[ValidateAntiForgeryToken] //er min form blevet hacket??
        //de eneste properties fra binding jeg er interesseret i er givet med som parametre i Bind attributten. (Så sendes hele listen af hold ikke igen...)
        public ActionResult FilterClasses([Bind(Include = "SelectedDiscipline, SelectedInstructor, SelectedDate")] ClassBookingViewModel model) 
        {
            //Er property/binding validering gået godt:
            if (!ModelState.IsValid)
            {
                //Hvis input i formen ikke er valid. Giv mere sigende feedback i stedet...
                ModelState.AddModelError(string.Empty, "Det var ikke muligt at filtre i holdene. ModelState not valid.");
                return RedirectToAction("Index");
            }else
            {
                _service.FilterViewModel(model);
            }
            return View();
        }
    }
}