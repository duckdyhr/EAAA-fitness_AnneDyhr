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
        //virtual for at opnaa lazy loading
        public virtual DbSet<FitnessClass> Classes { get; set; }
        public virtual  DbSet<Discipline> Disciplines { get; set; }
        public virtual DbSet<Gym> Gyms { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<User> Users { get; set; }

        //Kod fluent api her for at lave enkeltrettet relationer mellem instructor-discipline-fitnessclass, frem for Collections i Disciplin klassen
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
