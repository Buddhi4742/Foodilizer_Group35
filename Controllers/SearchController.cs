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
        private readonly foodilizerContext _context;
        public SearchController(foodilizerContext context)
        {
            _context = context;
        }
        // GET: SearchController
        public IActionResult RestaurantSearchResults(string searchString)
        {

            searchString = "C";
            var locations=_context.Restaurants.Distinct().
                var rest = from r in _context.Restaurants
                             select r;

                if (!String.IsNullOrEmpty(searchString))
                {
                    rest = rest.Where(s => s.Rname.Contains(searchString));
                }

                return View(rest.ToList());
            
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
