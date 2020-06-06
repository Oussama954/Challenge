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
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
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
