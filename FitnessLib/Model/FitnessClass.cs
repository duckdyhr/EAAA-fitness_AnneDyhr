using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAA_fitness_lib.Model
{
    public class FitnessClass
    {
        public int Id { get; set; }
        public TimeOfClass Time { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual Discipline Discipline { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }

    public struct TimeOfClass
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        //Overload < > operatorer?
        public static bool Overlapses(TimeOfClass ts1, TimeOfClass ts2)
        {
            return false;
        }
    }
}
