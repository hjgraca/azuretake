namespace DataMigration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Resturante")]
    public partial class Resturante
    {
        public int ID { get; set; }

        public int? Offline { get; set; }

        public DateTime? Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Restaurantname { get; set; }

        [Required]
        [StringLength(50)]
        public string Owner { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(3000)]
        public string Xtrazip { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string MobilePhone { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string Zoomfax { get; set; }

        [StringLength(50)]
        public string AttName { get; set; }

        [StringLength(50)]
        public string AttPhone { get; set; }

        public int? Cat1 { get; set; }

        public int? Cat2 { get; set; }

        public int? Cat3 { get; set; }

        public int? Cat4 { get; set; }

        public int? Cat5 { get; set; }

        public int? Cat6 { get; set; }

        public int? CountryID { get; set; }

        [StringLength(255)]
        public string ShortDescr { get; set; }

        [Column(TypeName = "text")]
        public string LongDescr { get; set; }

        [StringLength(50)]
        public string Pic { get; set; }

        [StringLength(50)]
        public string Logofile { get; set; }

        public int? Employees { get; set; }

        public DateTime? StartDate { get; set; }

        public short? SecondCountryID { get; set; }

        public DateTime? day1open { get; set; }

        public DateTime? day2open { get; set; }

        public DateTime? day3open { get; set; }

        public DateTime? day4open { get; set; }

        public DateTime? day5open { get; set; }

        public DateTime? day6open { get; set; }

        public DateTime? day7open { get; set; }

        public DateTime? day1close { get; set; }

        public DateTime? day2close { get; set; }

        public DateTime? day3close { get; set; }

        public DateTime? day4close { get; set; }

        public DateTime? day5close { get; set; }

        public DateTime? day6close { get; set; }

        public DateTime? day7close { get; set; }

        public bool day1closed { get; set; }

        public bool day2closed { get; set; }

        public bool day3closed { get; set; }

        public bool day4closed { get; set; }

        public bool day5closed { get; set; }

        public bool day6closed { get; set; }

        public bool day7closed { get; set; }

        public short deliveryTimeExpandMinutes { get; set; }

        public short? logowid { get; set; }

        public short? logolen { get; set; }

        public short? picwid { get; set; }

        public short? piclen { get; set; }

        [StringLength(50)]
        public string CVR { get; set; }

        public int status { get; set; }

        [StringLength(50)]
        public string extraPic { get; set; }

        public int? streetnumber { get; set; }

        [StringLength(50)]
        public string enteredBy { get; set; }

        [StringLength(50)]
        public string updatedBy { get; set; }

        [Column(TypeName = "text")]
        public string comment { get; set; }

        public int? SoldById { get; set; }

        [StringLength(100)]
        public string banknavn { get; set; }

        [StringLength(25)]
        public string kontonummer { get; set; }

        [StringLength(10)]
        public string registreringsnummer { get; set; }

        public int? headno { get; set; }

        public int? Transfee { get; set; }

        public decimal? Connectionfee { get; set; }

        public DateTime? lastConnectionFeeDate { get; set; }

        public short Misc { get; set; }

        public short? NumConnFees { get; set; }

        public int? jdRest { get; set; }

        public int? jupiterRest { get; set; }

        public int? tempOffline { get; set; }

        public int? tempAutoOffline { get; set; }

        [StringLength(35)]
        public string tempOfflineText { get; set; }

        [StringLength(50)]
        public string jdPrinter { get; set; }

        public int? kunDK { get; set; }

        public int? KunDKLocked { get; set; }

        public int? administrationid { get; set; }

        [StringLength(250)]
        public string actiontext { get; set; }

        public DateTime? actiondate { get; set; }

        public DateTime? activitydate { get; set; }

        public decimal? RatingStars { get; set; }

        public int? jdReciepts { get; set; }

        public int? sortingorder { get; set; }

        public int? showsmiley { get; set; }

        public int? autoOffline { get; set; }

        public int? onlinePaymentNotOk { get; set; }

        public int? showRating { get; set; }

        public int? numOfRatings { get; set; }

        public int? isOwnerHappy { get; set; }

        public int? connType { get; set; }

        public int? connStatus { get; set; }

        public int? isMenucardAquired { get; set; }

        public bool? closed2012 { get; set; }

        public bool? closed2112 { get; set; }

        public bool? closed2212 { get; set; }

        public bool? closed2312 { get; set; }

        public bool? closed2412 { get; set; }

        public bool? closed2512 { get; set; }

        public bool? closed2612 { get; set; }

        public bool? closed2712 { get; set; }

        public bool? closed2812 { get; set; }

        public bool? closed2912 { get; set; }

        public bool? closed3012 { get; set; }

        public bool? closed3112 { get; set; }

        public bool? closed0101 { get; set; }

        public bool? preorder { get; set; }

        public bool? paypreorder { get; set; }

        public bool? stylesheet { get; set; }

        [StringLength(250)]
        public string welcometext { get; set; }

        public int? lead { get; set; }

        public DateTime? visit1 { get; set; }

        public DateTime? visit2 { get; set; }

        public DateTime? visit3 { get; set; }

        public DateTime? call1 { get; set; }

        public DateTime? call2 { get; set; }

        public DateTime? call3 { get; set; }

        public bool? callback { get; set; }

        [StringLength(50)]
        public string jdBoxID { get; set; }

        public DateTime? QSRVisitSchemeLastPrinted { get; set; }

        public int? pincode { get; set; }

        public bool? phoneAnswerWhenBusy { get; set; }

        public bool? staffHasClothing { get; set; }

        public bool? photosTaken { get; set; }

        public int? pizzaCasesAmount { get; set; }

        public int? JEMenucardAmount { get; set; }

        public int? PizzabagsAmount { get; set; }

        public int? PostersAmount { get; set; }

        public int? StreamerBigStamp { get; set; }

        public int? StreamerSmallStamp { get; set; }

        public int? StreamerDoorSticker { get; set; }

        public int? StreamerBigURL { get; set; }

        [StringLength(50)]
        public string attEmail { get; set; }

        public int? bbr { get; set; }

        public bool? hasDebitorService { get; set; }

        public bool? isDrawPermitActive { get; set; }

        public int? avoidinvoicefee { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? gprsfee { get; set; }

        public int? sendSpecification { get; set; }

        public int? jupiterclosed { get; set; }

        public DateTime? BusyUntil { get; set; }

        public int? SalesGuaranteeAmount { get; set; }

        public DateTime? SalesGuaranteeStart { get; set; }

        public DateTime? SalesGuaranteeEnd { get; set; }

        [StringLength(50)]
        public string MultiLineCustNumber { get; set; }

        public int? underclosure { get; set; }

        public int? SendInvoiceToDevice { get; set; }

        public int? restauranttype { get; set; }

        public int? vipstatus { get; set; }

        public int? createntlogin { get; set; }

        public DateTime? SendDayReportAt { get; set; }

        public int? SendDayReportDayback { get; set; }

        [StringLength(50)]
        public string invoicemail { get; set; }

        [StringLength(10)]
        public string zipcode2 { get; set; }

        public int? HqParentid { get; set; }

        public int? Headquarter { get; set; }

        public int? KickbackProcent { get; set; }

        [Column(TypeName = "money")]
        public decimal? creditcardfeeUser { get; set; }

        public bool? deliveryTimeBusy { get; set; }

        public DateTime? openeddate { get; set; }

        public int? Rank { get; set; }

        [StringLength(50)]
        public string CustomTxtOnOrder { get; set; }

        public int? SendOrderToHQFirst { get; set; }

        public DateTime? MarkUpUntil { get; set; }

        public int? TempOfflineType { get; set; }

        public bool? HalalStatus { get; set; }

        public DateTime? OpeningDate { get; set; }

        public bool? IsAddJEdeleiveryprice { get; set; }

        public DateTime? TempofflineSetDate { get; set; }

        [StringLength(50)]
        public string Zipcode { get; set; }

        [StringLength(100)]
        public string BankAccountNumber { get; set; }

        [StringLength(100)]
        public string BankSortCode { get; set; }

        [StringLength(200)]
        public string BusinessWebsite { get; set; }

        [StringLength(200)]
        public string JustEatWebsite { get; set; }

        public bool? GooglePlacesClaimed { get; set; }

        public bool? BusinessSiteLinkedToJustEat { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        [StringLength(100)]
        public string IBAN { get; set; }

        [StringLength(100)]
        public string BIC { get; set; }

        [StringLength(4000)]
        public string LegalName { get; set; }
    }
}
