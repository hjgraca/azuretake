namespace MigrationDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PostCodeModel : DbContext
    {
        public PostCodeModel()
            : base("name=PostCodeModel")
        {
        }

        public virtual DbSet<region> regions { get; set; }
        public virtual DbSet<Zipcode> Zipcodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<region>()
                .Property(e => e.regionname)
                .IsUnicode(false);

            modelBuilder.Entity<region>()
                .Property(e => e.regionnameAbbr)
                .IsUnicode(false);

            modelBuilder.Entity<region>()
                .Property(e => e.FinanceDebitorVatPriceGroup)
                .IsUnicode(false);

            modelBuilder.Entity<Zipcode>()
                .Property(e => e.cityname)
                .IsUnicode(false);

            modelBuilder.Entity<Zipcode>()
                .Property(e => e.CitynameSearch)
                .IsUnicode(false);

            modelBuilder.Entity<Zipcode>()
                .Property(e => e.zipcodename)
                .IsUnicode(false);

            modelBuilder.Entity<Zipcode>()
                .Property(e => e.timezoneId)
                .IsUnicode(false);
        }
    }
}
