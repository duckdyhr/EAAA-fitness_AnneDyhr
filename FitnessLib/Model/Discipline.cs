using EAAA_fitness_lib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAA_fitness_lib.Model
{
    public class Discipline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<FitnessClass> Classes { get; set; }
    }
}