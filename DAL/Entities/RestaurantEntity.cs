using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace DAL.Entities
{
    public class RestaurantEntity : TableEntity
    {
        public string Phone { get; set; }
        public string MobilePhone { get; set; }

        public string Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsOffline { get; set; }
        public DateTime Joined { get; set; }
        public bool IsBusy { get; set; }

        public string Email { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }

        /// <summary>
        /// days 1 through 7
        /// </summary>
        public string DaysOpen { get; set; }

        public string OpenHours { get; set; }
        public string OfflineMessage { get; set; }

        public string Owner { get; set; }
        public string ContactName { get; set; }

        public string Number { get; set; }

        public string Bank { get; set; }
        public string BankAccount { get; set; }
        public string BankSortCode { get; set; }
        public string BankAccountName { get; set; }
        public double ConnectionFee { get; set; }
        public string InvoiceEmail { get; set; }
        public string Iban { get; set; }
        public string LegalName { get; set; }

        public double Rating { get; set; }
        public int Votes { get; set; }

        public string FoodType { get; set; }

        public string GeoLocation { get; set; }

        public string FakeId { get; set; }


        public string DeliversTo { get; set; }

        public string ContactPhone { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int SaleFee { get; set; }

        public int FakeNumVotes { get; set; }

        public double FakeRating { get; set; }

        public string PostCode2 { get; set; }
    }
}
