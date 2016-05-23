using FitnessLib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAA_fitness_lib.Model
{
    public class FitnessClass
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Start { get; set; }
        public int Duration { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual Discipline Discipline { get; set; }
        public virtual Gym Gym { get; set; }
        public virtual ICollection<User> Users { get; set; }

        //public int TimeId { get; set; }
        //[ForeignKey("TimeId")]
        //public virtual TimeOfClass Time { get; set; }

        public FitnessClass()
        {
            Users = new List<User>();
        }
        public override string ToString()
        {
            return Id + " " + Instructor.Name;
        }
    }
    
}
