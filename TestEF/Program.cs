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

            Console.WriteLine("\nFitnessClasses");
            context.Classes.ToList().ForEach(fc => Console.WriteLine(fc));

            Console.WriteLine("\nGyms");
            context.Gyms.ToList().ForEach(g => Console.WriteLine(g.Location));

            Console.WriteLine("\nInstructors");
            context.Instructors.ToList().ForEach(i => Console.WriteLine(i.Name));

            Console.WriteLine("\nUsers");
            context.Users.ToList().ForEach(u => Console.WriteLine(u.UserId + " " + u.Name));

            Console.Read();
        }
    }
}