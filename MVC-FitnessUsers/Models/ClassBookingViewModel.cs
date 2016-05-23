using EAAA_fitness_lib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_FitnessUsers.Models
{
    public class ClassBookingViewModel
    {
        [DisplayName("Hold")]
        public List<FitnessClass> Classes { get; set; }

        [DisplayName("Disciplin")]
        public List<Discipline> Disciplines { get; set; }
        public Discipline SelectedDiscipline { get; set; }

        [DisplayName("Instruktør")]
        public List<Instructor> Instructors { get; set; }
        public Instructor SelectedInstructor { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Dato")]
        public DateTime? SelectedDate { get; set; }

        public bool IsLoggedIn { get; set; }
        [DisplayName("Bruger")]
        public User User { get; set; }
        public string LblTest { get; set; }
    }
}