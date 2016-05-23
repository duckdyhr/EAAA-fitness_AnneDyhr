using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAA_fitness_lib.Model
{
    public class User : Person
    {
        public string UserId { get; set; }
        public virtual ICollection<FitnessClass> Classes { get; set; }
        public User()
        {
            Classes = new List<FitnessClass>();
        }
    }
}