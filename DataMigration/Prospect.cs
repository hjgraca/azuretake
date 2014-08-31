namespace DataMigration
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Prospect : DbContext
    {
        public Prospect()
            : base("name=Prospect")
        {
        }

        public virtual DbSet<Earnmoney> Earnmoneys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Earnmoney>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Earnmoney>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<Earnmoney>()
                .Property(e => e.street)
                .IsUnicode(false);

            modelBuilder.Entity<Earnmoney>()
                .Property(e => e.housenumber)
                .IsUnicode(false);

            modelBuilder.Entity<Earnmoney>()
                .Property(e => e.floor)
                .IsUnicode(false);

            modelBuilder.Entity<Earnmoney>()
                .Property(e => e.zipcode)
                .IsUnicode(false);

            modelBuilder.Entity<Earnmoney>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<Earnmoney>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Earnmoney>()
                .Property(e => e.streetnumber)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Earnmoney>()
                .Property(e => e.accountstatement)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Earnmoney>()
                .Property(e => e.tippedid)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Earnmoney>()
                .Property(e => e.Companyid)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Earnmoney>()
                .Property(e => e.points)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Earnmoney>()
                .Property(e => e.vipmoney)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Earnmoney>()
                .Property(e => e.transact_ticket)
                .IsUnicode(false);

            modelBuilder.Entity<Earnmoney>()
                .Property(e => e.ZoomioID)
                .IsUnicode(false);

            modelBuilder.Entity<Earnmoney>()
                .Property(e => e.doorcode)
                .IsUnicode(false);

            modelBuilder.Entity<Earnmoney>()
                .Property(e => e.PasswordHash)
                .IsUnicode(false);
        }
    }
}
