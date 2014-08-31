using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using DAL.Repositories;

namespace DataMigration
{
    class Program
    {
        static void Main(string[] args)
        {
            var index = 0;

            var m = new Model1();
            var restaurants =
                m.Resturantes.
                Where(x => x.Offline == 0
                && x.autoOffline == 0
                && x.jupiterclosed == 0
                && x.status == 0).ToList();

            var total = restaurants.Count();

            Console.WriteLine(total);

            var rep = new RestaurantRepository();
            restaurants.ForEach(f =>
            {
                rep.Insert(new RestaurantEntity
                {
                    RowKey = f.Restaurantname,
                    Id = Guid.NewGuid().ToString(),
                    PartitionKey = f.Zipcode.Trim().ToUpper(),
                    PostCode2 = f.zipcode2.Trim().ToUpper(),
                    City = f.City,
                    Email = f.Email,
                    Address = f.Address,
                    MobilePhone = f.MobilePhone,
                    InvoiceEmail = f.invoicemail,
                    Description = f.LongDescr,
                    ShortDescription = f.ShortDescr,
                    LogoUrl = "http://d30v2pzvrfyzpo.cloudfront.net/uk/images/restaurants/" + f.ID + ".gif",
                    FakeId = Convert.ToString(f.ID),
                    DeliversTo = f.Xtrazip,
                    ContactName = f.AttName,
                    ContactPhone = f.AttPhone,
                    Latitude = Convert.ToString(f.Latitude),
                    Longitude = Convert.ToString(f.Longitude),
                    LegalName = f.LegalName,
                    FoodType = GetCousine(f.CountryID, f.SecondCountryID),
                    Bank = f.banknavn,
                    SaleFee = f.Transfee.HasValue ? f.Transfee.Value : 0,
                    FakeNumVotes = f.numOfRatings.HasValue ? f.numOfRatings.Value : 0,
                    FakeRating = f.RatingStars.HasValue ? decimal.ToDouble(f.RatingStars.Value) : 0
                });

                Debug.WriteLine("Missing: " + (total - index++));
            });

            //var model2 = new Model2();
            //var zipcodes = model2.Zipcodes.Where(x => x.Deleted == 0).ToList();
            //var total = zipcodes.Count();

            //Console.WriteLine(total);

            //var repository = new PostCodeRepository();
            //index = 0;

            //zipcodes.ForEach(z =>
            //{
            //    repository.Insert(new PostCodeEntity
            //    {
            //        PostCode = z.zipcodename,
            //        Name = z.cityname,
            //        Region = GetRegion(z.RegionID)
            //    });

            //    Debug.WriteLine("Missing: " + (total - index++));
            //});

            //var prospects = new Prospect();
            //var people = prospects.Earnmoneys.ToList();


            //## Create SearchIndex
            //var rep = new RestaurantRepository();
            var repMenu = new SearchRepository();

            rep.GetAll().Where(x => x.FakeNumVotes > 20).Take(100).ToList().ForEach(x => repMenu.InsertRestaurant("NW6", x));

            Console.WriteLine("done!");
            Console.ReadLine();
        }

        private static string GetRegion(int regionId)
        {
            var dic = new Dictionary<int, string>
            {
                {0,"N/A"},
                {1,"Midlands"},
                {2,"NE & Yorkshire"},
                {3,"London and the South East"},
                {4,"South West England"},
                {5,"Wales"},
                {6,"Scotland"},
                {7,"Northern Ireland"},
                {8,"North West England"},
                {9,"East Anglia"},
                {10,"South England"}
            };

            return dic[regionId];
        }

        static string GetCousine(int? countryId, int? secCountryId)
        {
            if (!countryId.HasValue)
            {
                return string.Empty;
            }

            #region cousines

            var dic = new Dictionary<int, string>
            {
                {1, "Danish"},
                {22, "American"},
                {23, "Mexican"},
                {24, "French"},
                {25, "Turkish"},
                {26, "Spanish"},
                {27, "Italian"},
                {28, "Greek"},
                {29, "Kurdish"},
                {30, "Thai"},
                {31, "Indian"},
                {32, "Norwegian"},
                {33, "Chinese"},
                {34, "Vietnamese"},
                {2, "English"},
                {35, "Japanese"},
                {37, "Pakistani"},
                {0, "[none]"},
                {38, "Jamaican"},
                {50, "Bangladeshi"},
                {51, "Middle Eastern"},
                {52, "Lebanese"},
                {53, "Syrian"},
                {54, "Korean "},
                {55, "Malaysian "},
                {56, "Brazilian Food"},
                {57, "Nepalese"},
                {58, "Portuguese"},
                {60, "Moroccan"},
                {61, "Russian"},
                {62, "Iranian"},
                {63, "Egyptian"},
                {64, "Afghanistani"},
                {65, "Ghanaian"},
                {66, "Nigerian"},
                {67, "Argentinian"},
                {68, "Sri-lankan"},
                {69, "Polish"},
                {70, "Indonesian"},
                {71, "Filipino"},
                {72, "Cuban"},
                {73, "Australian"},
                {74, "South African"},
                {75, "German"},
                {76, "Caribbean"},
                {77, "West African"},
                {78, "Burgers"},
                {79, "Chicken"},
                {80, "Fish & Chips"},
                {81, "Kebabs"},
                {82, "Pizza"},
                {83, "Sushi"},
                {84, "Desserts"},
                {85, "Curry"},
                {86, "Drinks"},
                {87, "Cakes"},
                {88, "Gourmet"},
                {89, "Healthy"},
                {90, "Sandwiches"},
                {91, "Dim Sum"},
                {92, "Breakfast"},
                {93, "Peri Peri"},
                {94, "Persian"},
                {109, "Arabic"},
                {110, "Subways"},
                {97, "African"},
                {98, "Ethiopian"},
                {99, "North African"},
                {100, "Bulgarian"},
                {101, "Eastern European"},
                {102, "European"},
                {103, "Mediterranean"},
                {104, "Swedish"},
                {105, "Hungarian"},
                {106, "British"},
                {107, "South Indian"},
                {108, "Mongolian"},
                {111, "Wraps"},
                {112, "Milkshakes"},
                {113, "Kosher"},
                {114, "Vegetarian"},
                {115, "Tapas"},
                {116, "Sweets"},
                {117, "Retro Sweets"},
                {118, "Grill"},
                {119, "Seafood"},
                {120, "Pasta"},
                {121, "Singapore"},
                {122, "Ukrainian"},
                {123, "Azerbaijan"},
                {124, "Brunch"},
                {125, "Crepes"},
                {126, "Street Food"}
            };

            #endregion

            var cousine1 = dic[countryId.Value];

            if (secCountryId.HasValue)
            {
                var cousine2 = dic[secCountryId.Value];
                return string.Format("{0},{1}", cousine1, cousine2);
            }

            return string.Format("{0}", cousine1);
        }
    }
}
