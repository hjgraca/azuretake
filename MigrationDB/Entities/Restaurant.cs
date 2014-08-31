using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDB.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; }
        public bool IsOffline { get; set; }
        public DateTime Joined { get; set; }
        public bool IsBusy { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<FoodType> FoodTypes { get; set; }
        public virtual Bank Bank { get; set; }

        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }

        public Days DaysOpen { get; set; }

        public string OpenHours { get; set; }
        public string OfflineMessage { get; set; }

        public string Number { get; set; }

        public double Rating { get; set; }
        public int Votes { get; set; }

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

        public string SeoName { get; set; }
        public string PageTitle { get; set; }
        public string PageKeywords { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
        public ICollection<DeliveryArea> DeliveryAreas { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
