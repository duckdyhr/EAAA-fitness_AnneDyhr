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
        //alle actions deler den samme model
        ClassBookingViewModel model;
        public ClassBookingController()
        {
            _service = Service.Service.Instance;
            model = _service.LoadClassBookingViewModel();
            model.SelectedDate = new DateTime(2016, 6, 20);
        }
        // GET: ClassBooking
        public ActionResult Index()
        {
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
            //Er property/binding validering fra brugers side gået godt:
            if (!ModelState.IsValid)
            {
                //Hvis input i formen ikke er valid. Giv mere sigende feedback i stedet...
                ModelState.AddModelError("Error", "Det var ikke muligt at filtre i holdene. ModelState not valid.");
                return RedirectToAction("Index");
            }else
            {

                var filtered = _service.FilterFitnessClasses(model.SelectedDiscipline, model.SelectedInstructor, model.SelectedDate);
                this.model.Classes = filtered;
            }
            return RedirectToAction("Index");
        }
    }
}