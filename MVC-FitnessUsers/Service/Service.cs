using EAAA_fitness_lib.Model;
using EAAA_fitness_lib.Storage;
using MVC_FitnessUsers.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_FitnessUsers.Service
{
    public class Service
    {
        //readonly elementer er knyttet på Class objektet og derfor kun en instans af hver
        private static readonly Service _instance = new Service();
        private FitnessContext db;

        private Service()
        {
        db = new FitnessContext();
        }

        public static Service Instance
        {
            get
            {
                return _instance;
            }
        }
        //Returner fuld FitnessViewModel i stedet for List<FitnessClass>
        public List<FitnessClass> GetAllFitnessClasses()
        {
            var classes = db.Classes.ToList();
            return classes;
        }

        public FitnessViewModel LoadFitnessViewModel()
        {
            var model = new FitnessViewModel();
            model.Classes = db.Classes.ToList();
            model.Disciplines = db.Disciplines.ToList();
            model.Instructors = db.Instructors.ToList();
            model.SelectedDate = null;
            model.User = null;
            return model;
        }

        public List<FitnessClass> FilterFitnessClasses(int disId, int insId, DateTime? selectedDate)
        {
            List<FitnessClass> result = new List<FitnessClass>();
            var allClasses = db.Classes;
            result = allClasses.Where(
                c => disId==0 || c.Discipline.Id == disId 
                && insId==0 || c.Instructor.InstructorId == insId && 
                selectedDate==null || c.Start == selectedDate) //check på måned og dag istedet..
                .ToList();
            return result;
        }

        //throw exception hvis userid not valid..
        public User FindUser(string userid)
        {
            User result = db.Users.Find(userid);
            return result;
        }

        public User UnsubscribeUserFromClass(string userId, int classId)
        {
            var user = db.Users.Find(userId);
            if(user != null)
            {
                var tobedeleted = user.Classes.First(c => c.Id == classId);
                if(tobedeleted != null)
                {
                    user.Classes.Remove(tobedeleted);
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return user;
        }

        public User SubscribeUserToClass(string userId, int classId)
        {
            var user = db.Users.Find(userId);
            if(user != null)
            {
                var tobeadded = db.Classes.Find(classId);
                if(tobeadded != null)
                {
                    user.Classes.Add(tobeadded);
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return FindUser("aa");
        }
    }
}