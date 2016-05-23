using EAAA_fitness_lib.Model;
using EAAA_fitness_lib.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEF
{
    public class Program
    {
        static void Main(string[] args)
        {
            FitnessContext context = new FitnessContext();
            Console.WriteLine("Disciplines;");
            context.Disciplines.ToList()
                .ForEach(d => Console.WriteLine(
                    d.Id + " " + d.Name));
            //Count metoden undermineres af Lazy loading, så 
            Console.WriteLine("\nFitnessClasses");
            context.Classes.ToList().ForEach(fc => Console.WriteLine(fc + "\n\ttime: " + fc.Start.ToString() + "\n\tgym: " + fc.Gym + "\n\tusers: " + fc.Users?.Count));

            Console.WriteLine("\nGyms");
            context.Gyms.ToList().ForEach(g => Console.WriteLine(g.Id + " " + g.Location));

            Console.WriteLine("\nInstructors");
            context.Instructors.ToList().ForEach(i => Console.WriteLine(i.InstructorId + " " + i.Name + " \n\tdiscipliner:" + i.FitnessDiscipliner.Count + " \n\tclasses:" + i.Classes.Count));

            Console.WriteLine("\nUsers");
            context.Users.ToList().ForEach(u => Console.WriteLine(u.UserId + " " + u.Name));

            Console.Read();
        }
    }
}