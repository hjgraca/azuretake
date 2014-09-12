using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using AutoMapper;
using MigrationDB.Entities;
using Newtonsoft.Json;

namespace MigrationDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var index = 0;

            //var m = new Model1();
            //var restaurants =
            //    m.Resturantes.
            //    Where(x => x.Offline == 0
            //    && x.autoOffline == 0
            //    && x.jupiterclosed == 0
            //    && x.status == 0).ToList();

            //var total = restaurants.Count();

            //using (var rest = new RestaurantEntity())
            //{
            //    rest.FoodTypes.AddRange(GetFoodTypes());

            //    restaurants.ForEach(f =>
            //    {
            //        var foodT = GetFoodTypes(f.CountryID, f.SecondCountryID);
            //        var cous1 = foodT[0];
            //        var cous2 = foodT[1];

            //        rest.Restaurants.Add(new Restaurant
            //        {

            //            Name = f.Restaurantname,
            //            Addresses = new Collection<Address>
            //            {
            //                new Address
            //                {
            //                    City = f.City,
            //                    Line1 = f.Address,
            //                    PostCode = f.Zipcode.Trim().ToUpper(),
            //                }
            //            },
            //            Contacts = new Collection<Contact>
            //            {
            //                new Contact
            //                {
            //                    ContactName = f.AttName,
            //                    Email = f.Email,
            //                    MobilePhone = f.MobilePhone,
            //                    Owner = f.Owner,
            //                    Phone = f.AttPhone
            //                }
            //            },
            //            PostCode2 = f.zipcode2.Trim().ToUpper(),
            //            Description = f.LongDescr,
            //            ShortDescription = f.ShortDescr,
            //            LogoUrl = "http://d30v2pzvrfyzpo.cloudfront.net/uk/images/restaurants/" + f.ID + ".gif",
            //            FakeId = Convert.ToString(f.ID),
            //            DeliversTo = f.Xtrazip,
            //            ContactPhone = f.AttPhone,
            //            Latitude = Convert.ToString(f.Latitude),
            //            Longitude = Convert.ToString(f.Longitude),
            //            FoodTypes = rest.FoodTypes.Where(x => x.Name == cous1 || x.Name == cous2).ToList(),
            //            Bank = new Bank
            //            {
            //              Name  = f.banknavn,
            //              Account = f.BankAccountNumber,
            //              Iban = f.IBAN,
            //              InvoiceEmail = f.invoicemail,
            //              SortCode = f.BankSortCode,
            //              LegalName = f.LegalName,
            //              ConnectionFee = f.Connectionfee
            //            },
            //            SaleFee = f.Transfee.HasValue ? f.Transfee.Value : 0,
            //            FakeNumVotes = f.numOfRatings.HasValue ? f.numOfRatings.Value : 0,
            //            FakeRating = f.RatingStars.HasValue ? decimal.ToDouble(f.RatingStars.Value) : 0,
            //            Joined = DateTime.Now,
            //            DaysOpen = Days.Mon | Days.Tue | Days.Wed | Days.Thu | Days.Fri | Days.Sat | Days.Sun
            //        });

            //        Debug.WriteLine("Missing: " + (total - index++));
            //    });

            //    rest.SaveChanges();
            //}

            //var m = new PostCodeModel();

            //using (var entity = new RestaurantEntity())
            //{
            //    //entity.Regions.AddRange(m.regions.Select(x => new Region
            //    //{
            //    //    Name = x.regionname
            //    //}));

            //    foreach (var x in m.Zipcodes)
            //    {
            //        var region = entity.Regions.FirstOrDefault(r => r.Id == x.RegionID);

            //        entity.PostCodes.Add(new PostCode
            //        {
            //            CityName = x.cityname,
            //            Name = x.zipcodename,
            //            Synonyms = x.Synonyms,
            //            Region = region
            //        });
            //    }

            //    //var regions = entity.Regions.ToList();
            //    //entity.PostCodes.AddRange(m.Zipcodes.Select(x => new PostCode
            //    //{
            //    //    CityName = x.cityname,
            //    //    Name = x.zipcodename,
            //    //    Synonyms = x.Synonyms,
            //    //    Region = regions.FirstOrDefault(r => r.Id == x.RegionID)
            //    //}));

            //    entity.SaveChanges();
            //}

            //// Web
            //using (var client = new WebClient())
            //{
            //    client.Headers.Add("user-agent", "test");
            //    var json = client.DownloadString("http://localhost/menuapi/MenuJson/13140");
            //    var serializer = new JavaScriptSerializer();
            //    serializer.MaxJsonLength = int.MaxValue;
            //    var model = serializer.Deserialize<MigrationDB.Dummy.Rootobject>(json);
            //}


            //Mapper.CreateMap<MigrationDB.Dummy.Menuitem, Product>();
            //Mapper.CreateMap<MigrationDB.Dummy.Category, Category>();

            //Mapper.CreateMap<MigrationDB.Dummy.Requiredaccessory, Accessory>()
            //    .ForMember(dest => dest.IsRequired, x => x.MapFrom(or => true));
            //Mapper.CreateMap<MigrationDB.Dummy.Requiredaccessory1, Accessory>()
            //    .ForMember(dest => dest.IsRequired, x => x.MapFrom(or => true));

            //Mapper.CreateMap<MigrationDB.Dummy.Optionalaccessory, Accessory>()
            //    .ForMember(dest => dest.IsRequired, x => x.MapFrom(or => false));
            //Mapper.CreateMap<MigrationDB.Dummy.Optionalaccessory1, Accessory>()
            //    .ForMember(dest => dest.IsRequired, x => x.MapFrom(or => false));

            //Mapper.CreateMap<MigrationDB.Dummy.Mealpart, Product>()
            //    .ForMember(dest => dest.Name, x => x.MapFrom(or => or.Synonym + " " + or.Name))
            //    .ForMember(dest => dest.Accessories, x => x.MapFrom(or => or.RequiredAccessories))
            //    .ForMember(dest => dest.Accessories, x => x.MapFrom(or => or.OptionalAccessories));

            //Mapper.CreateMap<MigrationDB.Dummy.Menu, Menu>()
            //    .ForMember(dest => dest.Description, x => x.MapFrom(or => or.MenuDescription))
            //    .ForMember(dest => dest.MenuType, x => x.MapFrom(or => or.IsCollection ? 2 : 1));

            //Mapper.CreateMap<MigrationDB.Dummy.Rootobject, Restaurant>();


            // FileSystem
            //MigrationDB.Dummy.Rootobject parsedData;


            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString))
            {
                con.Open();
                using (var command = new SqlCommand("SELECT FakeId FROM ( SELECT FakeId,FakeNumVotes, FakeRating from [FoodCrave].[dbo].[Restaurants] ) SubQueryAlias order by FakeNumVotes desc, FakeRating desc " +
                                                    "OFFSET 0 ROWS FETCH NEXT 1000 ROWS ONLY;", con))
                using (var reader = command.ExecuteReader())
                {
                    int total = 1000, count = 0;
                    while (reader.Read())
                    {
                        using (var webClient = new System.Net.WebClient())
                        {
                            webClient.Headers.Add("Accept-Language", "en-GB");
                            webClient.Headers.Add("User-Agent", "Fiddler");
                            webClient.Headers.Add("Accept-Charset", "utf-8");
                            try
                            {
                                var json =
                                                        webClient.DownloadString(
                                                            "http://uk-menu-iapi.just-eat.co.uk/restaurant/" + reader.GetString(0) + "/productcategories?type=Delivery");
                                System.IO.File.WriteAllText(
                                    Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\menus\\" + reader.GetString(0) + "-delivery.json",
                                    json);
                            }
                            catch 
                            {
                            }

                            try
                            {
                                var json = webClient.DownloadString(
                                                            "http://uk-menu-iapi.just-eat.co.uk/restaurant/" + reader.GetString(0) + "/productcategories?type=Collection");
                                System.IO.File.WriteAllText(
                                    Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\menus\\" + reader.GetString(0) + "-collection.json",
                                    json);
                            }
                            catch
                            {
                            }
                        }
                        Debug.WriteLine("Missing: " + (total - count++));
                    }
                }
            }

            //var entity = new RestaurantEntity();
            //var count = 0;
            //var total = entity.Restaurants.Count();
            //Debug.WriteLine("Total: " + (total));
            //foreach (var restaurant in entity.Restaurants)
            //{
            //    using (var webClient = new System.Net.WebClient())
            //    {
            //        webClient.Headers.Add("Accept-Language", "en-GB");
            //        webClient.Headers.Add("User-Agent", "Fiddler");
            //        webClient.Headers.Add("Accept-Charset", "utf-8");
            //        //webClient.Headers.Add("x-je-feature", "hack");
            //        //webClient.Headers.Add("x-je-conversation", "hack");
            //        //webClient.Headers.Add("x-je-request", "9e524b31-78e0-4431-acfe-8332d12c27ea");

            //        var json =
            //            webClient.DownloadString(
            //                "http://uk-menu-iapi.just-eat.co.uk/restaurant/"+ restaurant.FakeId +"/productcategories?type=Delivery");
            //        System.IO.File.WriteAllText(
            //            Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\menus\\" + restaurant.FakeId + ".json",
            //            json);
            //    }
            //    Debug.WriteLine("Missing: " + (total - count++));
            //}

            //using (StreamReader re = new StreamReader("13140.json"))
            //{
            //    JsonTextReader reader = new JsonTextReader(re);
            //    JsonSerializer se = new JsonSerializer();
            //    parsedData = se.Deserialize<MigrationDB.Dummy.Rootobject>(reader);
            //}

            //var lstProds = new List<Product>();
            //var lstMenu = new List<Menu>();


            //var entity = new RestaurantEntity();
            //foreach (var menu in parsedData.menus.Take(1))
            //{
            //    foreach (var category in menu.Categories)
            //    {
            //        var cat =entity.Categories.Attach(Mapper.Map<Category>(category));

            //        foreach (var menuitem in category.MenuItems.Take(10))
            //        {
            //            var item = menuitem.Products.First();
                        
            //            ProductType prType = ProductType.None;
            //            item.Tags.Each(x =>
            //            {
            //                switch (x.Value.ToUpper())
            //                {
            //                    case "VEGETARIAN":
            //                        prType = prType | ProductType.Vegetarian;
            //                        break;
            //                    case "SPICY":
            //                        prType = prType | ProductType.Spicy;
            //                        break;
            //                    case "NUTS":
            //                        prType = prType | ProductType.Nuts;
            //                        break;
            //                    default:
            //                        prType = ProductType.None;
            //                        break;
            //                }
            //            });

            //            lstProds.Add(new Product
            //            {
            //                Category = cat,
            //                Name = menuitem.Name,
            //                ProductType = prType,
            //                //Accessories = (ICollection<Accessory>)(from o in item.OptionalAccessories
            //                //                                       select Mapper.Map<Accessory>(o))
            //                //        .Union(from req in item.RequiredAccessories
            //                //               select
            //                //                   Mapper.Map<Accessory>(req)).ToList(),
            //                //Price = item.Price,
            //                //MealParts = Mapper.Map<ICollection<Product>>(item.MealParts),
            //                //Description = item.Description,
            //                //Options = menuitem.Products.Where(x => !string.IsNullOrWhiteSpace(x.Synonym)).Select(x => new Accessory
            //                //{
            //                //    Name = x.Synonym,
            //                //    Price = x.Price
            //                //}).ToList()
            //            });

                        
            //        }
            //    }

            //    lstMenu.Add(new Menu
            //    {
            //        IsCollection = menu.IsCollection,
            //        MenuType = menu.IsCollection ? MenuType.Collection : MenuType.Delivery,
            //        Description = menu.MenuDescription,
            //        Products = lstProds,
            //    });
            //}

            // get and update restaurant

            //var rest = entity.Restaurants.First(x => x.FakeId == "13140");
            //rest.SeoName = parsedData.seoName;
            //rest.PageKeywords = parsedData.keywords;
            //rest.PageTitle = parsedData.title;
            //rest.Menus = lstMenu;

            //entity.SaveChanges();

        }

        static IEnumerable<FoodType> GetFoodTypes()
        {
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

            foreach (var item in dic)
            {
                yield return new FoodType
                {
                    Name = item.Value
                };
            }
        }

        static string[] GetFoodTypes(int? countryId, int? secCountryId)
        {
            return GetCousine(countryId, secCountryId).Trim().Split(',');
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

            return string.Format("{0},", cousine1);
        }
    }
}
