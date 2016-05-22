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
            context.Disciplines.Add(new Discipline { Name="Yoga"});
            context.Disciplines.Add(new Discipline { Name = "Spinning" });
            context.Disciplines.Add(new Discipline { Name = "Kickboxing" });

            context.SaveChanges();

            context.Disciplines.ToList()
                .ForEach(d => Console.WriteLine(
                    d.Id + " " + d.Name));

            Console.Read();
        }
    }
}