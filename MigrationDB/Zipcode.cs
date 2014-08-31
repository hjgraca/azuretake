namespace MigrationDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zipcode")]
    public partial class Zipcode
    {
        public int ID { get; set; }

        public int Priority { get; set; }

        public int? belongstoid { get; set; }

        public int? rankstatus { get; set; }

        [StringLength(500)]
        public string cityname { get; set; }

        public int RegionID { get; set; }

        [StringLength(50)]
        public string Zipcodenamesearch { get; set; }

        [StringLength(50)]
        public string CitynameSearch { get; set; }

        public int? Deleted { get; set; }

        [StringLength(500)]
        public string Synonyms { get; set; }

        public int? noResult { get; set; }

        [StringLength(50)]
        public string zipcodename { get; set; }

        [StringLength(200)]
        public string timezoneId { get; set; }

        public int timezone { get; set; }
    }
}
