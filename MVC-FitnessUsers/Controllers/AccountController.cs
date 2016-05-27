using EAAA_fitness_lib.Model;
using MVC_FitnessUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_FitnessUsers.Controllers
{
    public class AccountController : Controller
    {
        private Service.Service service;
        private User currentUser; //min simple user manager
        public AccountController()
        {
            service = Service.Service.Instance;
        }

        // GET: Account
        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult Index()
        {
            return LogIn();
        }

        public ActionResult UserProfile(string userId)
        {
            var model = service.LoadFitnessViewModel();
            if (userId == null || userId.Length == 0)
            {
                return RedirectToAction("LogIn");
            }
            var user = service.FindUser(userId);
            if (user == null)
            {
                return HttpNotFound();
            }
            model.User = user;
            currentUser = user;
            return View(model);
        }
        //User logges ind
        [HttpPost]
        public ActionResult UserProfile(FormCollection col)
        {
            var model = service.LoadFitnessViewModel();
            string userid = col["UserId"];
            if (userid == null || userid.Length == 0)
            {
                ModelState.AddModelError("Error", "UserId is null eller length==0");
                return RedirectToAction("LogIn");
            }
            User user = service.FindUser(userid);
            if (user == null)
            {
                return RedirectToAction("LogIn");
            }
            model.User = user;
            currentUser = user;
            return View(model);
        }

        //Jeg opgiver.. Browser siger den ikke kan finde ressource Account/UnsubscribeFitnessClass
        [ActionName("UnsubscribeFitnessClass")]
        public ActionResult UserProfile()
        {
            string userId = "aa";
            int cId = 1;
            if (userId == null || userId.Length == 0 || cId == 0)
            {
                ModelState.AddModelError("Error", "UserId is null");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("LogIn", "Account");
            }
            User user = service.UnsubscribeUserFromClass(userId, cId);
            //new { id = userId }
            return View(User); //send user i stedet for id?    
        }

        //Denne metode har jeg desværre også måtte opgive...
        //[ValidateAntiForgeryToken] //er min form blevet hacket??
        //de eneste properties fra binding jeg er interesseret i er givet med som parametre i Bind attributten.
        [HttpPost]
        public ActionResult FilterClasses([Bind(Include = "SelectedDiscipline, SelectedInstructor, SelectedDate")] FitnessViewModel oldModel)
        {
            if (oldModel == null)
            {
                return Content("oldmodel er null");
            }
            if (oldModel.SelectedDiscipline == null)
            {
                return Content("SelectedDiscipline er null");
            }

            int disId = oldModel.SelectedDiscipline.Id;
            int insId = 1; //oldModel.SelectedInstructor.InstructorId;
            DateTime? selectedDate = oldModel.SelectedDate;
            //Er property/binding validering fra brugers side gået godt:
            //if (!ModelState.IsValid)
            //{
            //Hvis input i formen ikke er valid. Giv mere sigende feedback i stedet...
            //ModelState.AddModelError("Error", "Det var ikke muligt at filtre i holdene. ModelState not valid.");
            //return Content("Modelstate not valid ");
            //return RedirectToAction("LogIn");
            //}
            var filtered = service.FilterFitnessClasses(disId, insId, selectedDate);
            var newModel = service.LoadFitnessViewModel();
            newModel.Classes = filtered;

            if (newModel == null)
            {
                return Content("newModel is null");
            }
            else
            {
                return View("UserProfile", newModel);
            }
        }

        //Denne metode driller også, selvom den burde være så simpel - arg!
        [HttpPost]
        public ActionResult SubscribeToClass(int id)
        {
            User modifiedUser = null;
            if (currentUser != null)
            {
                modifiedUser = service.SubscribeUserToClass(currentUser.UserId, id);
            }
            return UserProfile(currentUser.UserId);
            //return View(currentUser);
        }
    }
}