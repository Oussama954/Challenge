using System.Data.Entity.Migrations;

namespace Challenge.Model.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ChallengeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Challenge.Model.ChallengeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
