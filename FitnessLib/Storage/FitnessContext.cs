using EAAA_fitness_lib.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAA_fitness_lib.Storage
{
    public class FitnessContext : DbContext
    {
        public FitnessContext() : base("name=FitnessDb")
        {

        }
        public DbSet<FitnessClass> Classes { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
