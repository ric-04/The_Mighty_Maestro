namespace Mighty_Maestro.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Mighty_Maestro.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Mighty_Maestro.Data.ApplicationDbContext context)
        {
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
            context.Venues.AddOrUpdate(
                p => p.Name,
            new Venue { VenueId = 3, Name = "Grandparents' Garage", Stage = 1, PointsRequired = 0 },
            new Venue { VenueId = 4, Name = "School Dance", Stage = 2, PointsRequired = 500 },
            new Venue { VenueId = 5, Name = "County Fair", Stage = 3, PointsRequired = 1500 },
            new Venue { VenueId = 6, Name = "Local News", Stage = 4, PointsRequired = 2000 },
            new Venue { VenueId = 7, Name = "On Tour", Stage = 5, PointsRequired = 3000 }
            );

            context.Instructors.AddOrUpdate(
                p => p.Name,
            new Instructor { InstructorId = 1, Name = "Dr.Jam" });
        }
    }
}
