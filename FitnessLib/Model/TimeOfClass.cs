using EAAA_fitness_lib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessLib.Model
{
    //ville gerne have brugt struct, men ak... EF -.-
    [NotMapped]
    public class TimeOfClass
    {
        public int Id { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int hour { get; set; }
        public int duration { get; set; }
        private int quarterMin;
        
        //Property til ære for EF:
        public int FClassId { get; set; }
        [ForeignKey("FClassId")]
        public virtual FitnessClass FClass { get; set; }

        public TimeOfClass()
        {
        }
        public TimeOfClass(int year, int month, int day, int hour, int minute, int duration)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.quarterMin = minute;
            this.duration = duration;
        }

        public int Quarter
        {
            get { return quarterMin; }
            set
            {
                if (value > 0)
                {
                    if (value <= 15)
                        quarterMin = 15;
                    if (value <= 30)
                        quarterMin = 30;
                    if (value <= 45)
                        quarterMin = 45;
                    else
                        quarterMin = 0;
                }
            }
        }
        public override string ToString()
        {
            return day + "-" + month + "-" + year + " " + hour + ":" + quarterMin + " duration:" + duration;
        }
        public DateTime AsDateTime()
        {
            return new DateTime(year, month, day, hour, quarterMin, 0);
        }
        //Overload < > operatorer?
        public static bool Overlapses(TimeOfClass ts1, TimeOfClass ts2)
        {
            return false;
        }
    }
}
