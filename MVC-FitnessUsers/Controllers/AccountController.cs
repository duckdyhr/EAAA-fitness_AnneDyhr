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

        [HttpPost]
        public ActionResult UserProfile(FormCollection col)
        {
            string userid = col["UserId"];
            if (userid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = service.FindUser(userid);
            if(user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
    }
}