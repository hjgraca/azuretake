using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace DAL.Entities
{
    public class SearchEntity : TableEntity
    {
        public string Category { get; set; }
        public string RestaurantAddress { get; set; }
        public string RestaurantLogo { get; set; }
        public double DeliveryCost { get; set; }

        public double Rating { get; set; }

        public int NumberOfVotes { get; set; }
    }
}
