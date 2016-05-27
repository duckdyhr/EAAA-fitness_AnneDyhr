namespace FitnessLib.Migrations
{
    using EAAA_fitness_lib.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EAAA_fitness_lib.Storage.FitnessContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EAAA_fitness_lib.Storage.FitnessContext context)
        {
            var gyms = new List<Gym>
            {
                new Gym { Location = "A1", MaxCapacity=10},
                new Gym { Location = "A2", MaxCapacity=10 },
                new Gym { Location = "B1", MaxCapacity=5 }
            };

            var discipliner = new List<Discipline>
            {
                new Discipline { Name = "Zumba", Description="Fun with Zumba" },
                new Discipline { Name = "Kickboxing" },
                new Discipline { Name = "Spinning beginners" },
                new Discipline { Name = "Spinning experienced" },
                new Discipline { Name = "Spinning experts" },
                new Discipline { Name = "Yoga beginners"},
                new Discipline { Name = "Yoga experienced" },
                new Discipline { Name = "Yoga experts" }
            };
            
            var users = new List<User>
            {
                new User { UserId="lg", Name="Lene Godte" },
                new User { UserId="aa", Name="Anne Andersen" },
                new User { UserId="mr", Name="Mette Rosen" },
                new User { UserId="ab", Name="Anna Banana" },
                new User { UserId="ml", Name="Maria Lade" },
                new User { UserId="ad", Name="Anne Dyhr"},
                new User { UserId="jd", Name="John Doe"},
                new User { UserId="jw", Name="Jane Wilson" },
                new User { UserId="bh", Name="Bent Hansen" } 
            };

            var instructors = new List<Instructor>
            {
                new Instructor { Name="Linda", Age=20, Adress="Winter street 1, 1000" },
                new Instructor { Name="Louise", Age=59, Adress="Summmer street 2, 1000"},
                new Instructor { Name="Inger", Age=21, Adress="Winter street 3, 1000" },
                new Instructor { Name="Irene", Age=32, Adress="Spring street 12, 1000" },
                new Instructor { Name="Benny", Age=25, Adress="Fall street 42, 1000" }
            };

            var classes = new List<FitnessClass>
            {
                new FitnessClass { Id= 1, Instructor = instructors[0], Discipline = discipliner[0], Start=new DateTime(2016, 6, 20, 8, 0, 0), Duration=60, Gym = gyms[0] },
                new FitnessClass { Id= 2, Instructor = instructors[0], Discipline = discipliner[0], Start=new DateTime(2016, 6, 20, 9, 30, 0), Duration = 90, Gym = gyms[0] },
                new FitnessClass { Id= 3, Instructor = instructors[0], Discipline = discipliner[1], Start= new DateTime(2016, 6, 20, 13, 0, 0), Duration = 60, Gym = gyms[1] },
                new FitnessClass { Id= 4, Instructor = instructors[0], Discipline = discipliner[2], Start=new DateTime(2016, 6, 20, 15, 45, 0), Duration = 45, Gym=gyms[0] },
                new FitnessClass { Id= 5, Instructor = instructors[2], Discipline = discipliner[2], Start= new DateTime(2016, 6, 20, 8, 0, 0), Duration=60, Gym=gyms[2] },
                new FitnessClass { Id= 6, Instructor = instructors[2], Discipline = discipliner[3], Start= new DateTime(2016, 6, 21, 8, 0, 0), Duration=60, Gym=gyms[0]},
                new FitnessClass { Id= 7, Instructor = instructors[2], Discipline = discipliner[3], Start = new DateTime(2016, 6, 21, 10, 0, 0), Duration=60, Gym=gyms[0] },
                new FitnessClass { Id= 8, Instructor = instructors[2], Discipline = discipliner[3], Start = new DateTime(2016, 6, 21, 12, 0, 0), Duration=60, Gym=gyms[0] },
                new FitnessClass { Id= 9, Instructor = instructors[3], Discipline = discipliner[5], Start = new DateTime(2016, 6, 21, 8, 0, 0), Duration=60, Gym=gyms[1] },
                new FitnessClass { Id= 10, Instructor = instructors[3], Discipline = discipliner[6], Start = new DateTime(2016, 6, 21, 9, 30, 0), Duration=90, Gym=gyms[1] },
                new FitnessClass { Id= 11, Instructor = instructors[3], Discipline = discipliner[7], Start= new DateTime(2016, 6, 21, 13, 0, 0), Duration=45, Gym=gyms[2] }
            };
            //Relationer:

            //Linda
            instructors[0].FitnessDiscipliner.Add(discipliner[0]);
            instructors[0].FitnessDiscipliner.Add(discipliner[1]);
            instructors[0].FitnessDiscipliner.Add(discipliner[2]);
            //Louise
            instructors[1].FitnessDiscipliner.Add(discipliner[0]);
            instructors[1].FitnessDiscipliner.Add(discipliner[1]);
            //Inger
            instructors[2].FitnessDiscipliner.Add(discipliner[2]);
            instructors[2].FitnessDiscipliner.Add(discipliner[3]);
            instructors[2].FitnessDiscipliner.Add(discipliner[4]);
            //Irene
            instructors[3].FitnessDiscipliner.Add(discipliner[5]);
            instructors[3].FitnessDiscipliner.Add(discipliner[6]);
            instructors[3].FitnessDiscipliner.Add(discipliner[7]);
            //Benny
            //...

            classes[0].Users.Add(users[0]);
            classes[0].Users.Add(users[1]);
            classes[0].Users.Add(users[2]);
            classes[0].Users.Add(users[3]);
            classes[0].Users.Add(users[4]);
            classes[0].Users.Add(users[5]);

            classes[1].Users.Add(users[0]);
            classes[1].Users.Add(users[1]);
            classes[1].Users.Add(users[2]);
            classes[1].Users.Add(users[3]);
            classes[1].Users.Add(users[4]);
            classes[1].Users.Add(users[5]);

            classes[2].Users.Add(users[3]);
            classes[2].Users.Add(users[4]);
            classes[2].Users.Add(users[5]);

            classes[0].Users.Add(users[0]);
            classes[0].Users.Add(users[1]);
            classes[0].Users.Add(users[2]);

            gyms.ForEach(x => context.Gyms.AddOrUpdate(g => new { g.Location }, x));
            discipliner.ForEach(x => context.Disciplines.AddOrUpdate(d => new { d.Name }, x));
            instructors.ForEach(x => context.Instructors.AddOrUpdate(i => new { Name = i.Name, Adress = i.Adress }, x));
            users.ForEach(x => context.Users.AddOrUpdate(u => u.UserId, x));
            classes.ForEach(x => context.Classes.AddOrUpdate(fc => fc.Id, x));
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
