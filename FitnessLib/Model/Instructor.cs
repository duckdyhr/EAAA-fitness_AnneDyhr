using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAA_fitness_lib.Model
{
    public class Instructor : Person
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; } //som struct?
        public Instructor()
        {
            Classes = new List<FitnessClass>();
            FitnessDiscipliner = new List<Discipline>();
        }

        public virtual ICollection<FitnessClass> Classes { get; set; }

        public virtual ICollection<Discipline> FitnessDiscipliner { get; set; }
    }
}
