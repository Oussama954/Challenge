using System.Data.Entity;
using System.Diagnostics;
using Challenge.Model.Migrations;

namespace Challenge.Model
{
    public class ChallengeContext : DbContext
    {
        public ChallengeContext()
            : base("name=ChallengeModel")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChallengeContext, Configuration>());
            Database.Log = s => Debug.WriteLine(s);
        }

        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>()
                .Property(e => e.SerialNumber);

            modelBuilder.Entity<Equipment>()
                .HasOptional(e => e.Picture)
                .WithRequired(e => e.Equipment);

            modelBuilder.Entity<Picture>()
                .Property(e => e.SerialNumber);
        }
    }
}