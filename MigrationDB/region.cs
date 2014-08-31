namespace MigrationDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("region")]
    public partial class region
    {
        public int regionid { get; set; }

        [StringLength(50)]
        public string regionname { get; set; }

        [StringLength(50)]
        public string regionnameAbbr { get; set; }

        [StringLength(10)]
        public string FinanceDebitorVatPriceGroup { get; set; }
    }
}
