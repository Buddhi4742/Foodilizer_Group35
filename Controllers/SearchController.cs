using Foodilizer_Group35.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodilizer_Group35.Controllers
{
    public class SearchController : Controller
    {
        // GET: SearchController
        public IActionResult RestaurantSearchResults()
        {
            using (foodilizerContext dbmodel = new foodilizerContext())
                return View(dbmodel.Restaurants.ToList());
        }

        // GET: SearchController/Details/5
        public IActionResult RestaurantDetails(int id)
        {
            using (foodilizerContext dbmodel = new foodilizerContext())
                return View(dbmodel.Restaurants.Where(x => x.RestId == id).FirstOrDefault());
        }
        // GET: SearchController
        public IActionResult FoodSearchResults()
        {
            using (foodilizerContext dbmodel = new foodilizerContext())
                return View(dbmodel.Foods.ToList());
        }

        // GET: SearchController/Details/5
        public IActionResult FoodDetails(int id)
        {
            using (foodilizerContext dbmodel = new foodilizerContext())
                return View(dbmodel.Foods.Where(x => x.FoodId == id).FirstOrDefault());
        }


    }
}
