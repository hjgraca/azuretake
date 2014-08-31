namespace DataMigration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Earnmoney")]
    public partial class Earnmoney
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string firstname { get; set; }

        [Required]
        [StringLength(50)]
        public string surname { get; set; }

        [Required]
        [StringLength(500)]
        public string street { get; set; }

        [Required]
        [StringLength(50)]
        public string housenumber { get; set; }

        [StringLength(50)]
        public string floor { get; set; }

        [Required]
        [StringLength(50)]
        public string zipcode { get; set; }

        [Required]
        [StringLength(50)]
        public string city { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        public int? mobile { get; set; }

        public int? fax { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public decimal? streetnumber { get; set; }

        public int? created { get; set; }

        public DateTime createDate { get; set; }

        public int? referedBy { get; set; }

        public int? datingrecid { get; set; }

        public int wantnews { get; set; }

        public bool? dgoUser { get; set; }

        [Column(TypeName = "money")]
        public decimal? accountstatement { get; set; }

        public bool? hasBounced { get; set; }

        public int? wantnewsTeaser { get; set; }

        public DateTime? dateOfBirth { get; set; }

        public decimal? tippedid { get; set; }

        [StringLength(250)]
        public string affiliated { get; set; }

        public decimal? Companyid { get; set; }

        public bool? CompanyAdministrator { get; set; }

        public int? Companystatus { get; set; }

        public int? wantSms { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? points { get; set; }

        public DateTime? pointsUpdated { get; set; }

        public int? vipstatus { get; set; }

        public DateTime? vipstart { get; set; }

        public DateTime? vipend { get; set; }

        [Column(TypeName = "money")]
        public decimal? vipmoney { get; set; }

        [StringLength(250)]
        public string transact_ticket { get; set; }

        public int? refrestaurantid { get; set; }

        public int? useticket { get; set; }

        public int? AutoRenewVIP { get; set; }

        public int? publisherid { get; set; }

        public int? goodorders { get; set; }

        [StringLength(50)]
        public string ZoomioID { get; set; }

        public DateTime? ProfileUpdated { get; set; }

        public DateTime? ZoomioUpdated { get; set; }

        public int? CanChangeCMS { get; set; }

        [StringLength(50)]
        public string doorcode { get; set; }

        public int? UILanguageId { get; set; }

        public int? TermsAndConditionsId { get; set; }

        [StringLength(100)]
        public string PasswordHash { get; set; }

        public Guid? PasswordSalt { get; set; }
    }
}
