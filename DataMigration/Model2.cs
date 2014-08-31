namespace DataMigration
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<Zipcode> Zipcodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
