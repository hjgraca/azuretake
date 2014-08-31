using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.User
{
    public interface IUserData
    {
        int GoodOrders { get; set; }
        int BadOrders { get; set; }
        int TotalOrders { get; set; }
        int TearmsAndConditionsVersion { get; set; }
        DateTime LastLogin { get; set; }
        int Points { get; set; }
        string Referral { get; set; }
        DateTime DateOfBirth { get; set; }
        bool NewsLetter { get; set; }
        DateTime Created { get; set; }
        string MobilePhone { get; set; }
        string Phone { get; set; }
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string AddressLine3 { get; set; }
        string City { get; set; }
        string PostCode { get; set; }
    }
}
