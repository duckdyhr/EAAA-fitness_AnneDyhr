using EAAA_fitness_lib.Model;
using EAAA_fitness_lib.Storage;
using MVC_FitnessUsers.Models;
using System;
using System.Collections.Generic;
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

        public List<FitnessClass> GetAllFitnessClasses()
        {
            var classes = db.Classes.ToList();
            return classes;
        }

        public ClassBookingViewModel LoadClassBookingViewModel()
        {
            var model = new ClassBookingViewModel();
            model.Classes = db.Classes.ToList();
            model.Disciplines = db.Disciplines.ToList();
            model.Instructors = db.Instructors.ToList();
            model.SelectedDate = null;
            model.IsLoggedIn = false;
            model.User = null;
            return model;
        }

        public ClassBookingViewModel FilterViewModel(ClassBookingViewModel model)
        {
            var sDisciplin = model.SelectedDiscipline;
            var sInstructor = model.SelectedInstructor;
            var sDate = model.SelectedDate;

            var result = new List<FitnessClass>();
            foreach (var fclass in db.Classes.Where(fc => fc.Id == 1))
            {
                result.Add(fclass);
            }

            model.Classes = result;

            return model;
        }
    }
}