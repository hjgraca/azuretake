using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Entities;
using DAL.Repositories;

namespace WebRole.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            //var repository = new RestaurantRepository();
            //repository.Insert(new RestaurantEntity
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Name = string.Format("My Name is {0}", Guid.NewGuid()),
            //    Phone = "1234",
            //    PostCode = "SW6 4FR"
            //});

            //return View(repository.GetAll());
            return View(new List<RestaurantEntity>());
        }

        public ActionResult About(string id = "nw6")
        {
            var repository = new RestaurantRepository();

            return View(repository.GetByPostCode(id));
        }

        public ActionResult Contact(string id="NW6")
        {
            ViewBag.Message = "Your contact page.";

            var repo = new SearchRepository();

            return View(repo.Search(id));
        }
    }
}