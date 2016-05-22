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
        private ICollection<Instructor> instructors;

        public virtual ICollection<Instructor> Instructors
        {
            get { return instructors; }
            set { instructors = value; }
        }   
    }
}