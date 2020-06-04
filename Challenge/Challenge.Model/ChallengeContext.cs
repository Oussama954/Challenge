namespace Challenge.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ChallengeContext : DbContext
    {
        public ChallengeContext()
            : base("name=ChallengeModel")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChallengeContext, Challenge.Model.Migrations.Configuration>());

        }

        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>()
                .Property(e => e.SerialNumber)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Equipment>()
                .HasOptional(e => e.Picture)
                .WithRequired(e => e.Equipment);

            modelBuilder.Entity<Picture>()
                .Property(e => e.SerialNumber)
                .HasPrecision(18, 0);
        }
    }
}
