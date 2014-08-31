namespace DataMigration
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Resturante> Resturantes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resturante>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.Restaurantname)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.Owner)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.Xtrazip)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.MobilePhone)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.Zoomfax)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.AttName)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.AttPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.ShortDescr)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.LongDescr)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.Pic)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.Logofile)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.CVR)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.extraPic)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.enteredBy)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.updatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.banknavn)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.kontonummer)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.registreringsnummer)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.tempOfflineText)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.jdPrinter)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.actiontext)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.welcometext)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.jdBoxID)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.attEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.gprsfee)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.MultiLineCustNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.zipcode2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.creditcardfeeUser)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.CustomTxtOnOrder)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.Zipcode)
                .IsUnicode(false);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.Latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<Resturante>()
                .Property(e => e.Longitude)
                .HasPrecision(9, 6);
        }
    }
}
