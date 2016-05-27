using EAAA_fitness_lib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC_FitnessUsers.Models
{
    public class FitnessClassesViewModel
    {
        [DisplayName("Hold")]
        public List<FitnessClass> Classes { get; set; }
        [DisplayName("Bruger")]
        public User User { get; set; }
    }
}