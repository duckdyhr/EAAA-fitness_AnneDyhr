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
            gyms.ForEach(x => context.Gyms.AddOrUpdate(g => new { g.Location }, x));

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
            
            discipliner.ForEach(x => context.Disciplines.AddOrUpdate(d => new { d.Name}, x));

            var users = new List<User>
            {
                new User { UserId="ad", Name="Anne Dyhr"},
                new User { UserId="jd", Name="John Doe"},
                new User { UserId="jw", Name="Jane Wilson" },
                new User { UserId="bh", Name="Bent Hansen" }, 
                new User { UserId="aa", Name="Anne Andersen" },
                new User { UserId="lg", Name="Lene Godte" },
                new User { UserId="mr", Name="Mette Rosen" },
                new User { UserId="ml", Name="Maria Lade" },
                new User { UserId="ab", Name="Anna Banana" }
            };

            users.ForEach(x => context.Users.AddOrUpdate(u => u.UserId, x));

            var instructors = new List<Instructor>
            {
                new Instructor { Name="Louise", Age=59, Adress="Summmer street 2, 1000"},
                new Instructor { Name="Benny", Age=25, Adress="Fall street 42, 1000" },
                new Instructor { Name="Irene", Age=32, Adress="Spring street 12, 1000" },
                new Instructor { Name="Linda", Age=20, Adress="Winter street 1, 1000" },
                new Instructor { Name="Inger", Age=21, Adress="Winter street 3, 1000" }
            };

            instructors.ForEach(x => context.Instructors.AddOrUpdate(i => new { Name = i.Name, Adress = i.Adress }, x));

            //Indsætter relationer:









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
