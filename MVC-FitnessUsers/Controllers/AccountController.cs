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
        public AccountController()
        {
            service = Service.Service.Instance;
        }

        // GET: Account
        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult UserProfile(string userId)
        {
            if(userId == null || userId.Length== 0)
            {
                return RedirectToAction("LogIn");
            }
            var user = service.FindUser(userId);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult UserProfile(FormCollection col)
        {
            string userid = col["UserId"];
            if (userid == null || userid.Length==0)
            {
                ModelState.AddModelError("Error", "UserId is null eller length==0");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);   
            }
            User user = service.FindUser(userid);
            if(user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //string userId, string classId
        //Jeg opgiver.. Browser siger den ikke kan finde ressource Account/UnsubscribeFitnessClass
        [ActionName("UnsubscribeFitnessClass")]
        public ActionResult UserProfile()
        {
            string userId = "aa";
            int cId = 1;
            if(userId == null || userId.Length == 0 || cId == 0) //for int er 0 == null. Brug int? i stedet?
            {
                ModelState.AddModelError("Error", "UserId is null");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("LogIn", "Account");
            }
            User user = service.UnsubscribeUserFromClass(userId, cId);
            //new { id = userId }
            return View(User); //send user i stedet for id?    
        }
    }
}