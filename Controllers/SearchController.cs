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
        public IActionResult RestaurantSearchResults(string searchString, string district, string searchtype)
        {
            //if (searchtype == "Restaurant")
            //{
                //searchString = "Palm";
                var location = _context.Restaurants.Select(x => x.Rdistrict).Distinct().ToList();

                var rest = from r in _context.Restaurants
                           select r;
                //DONT DELETE THIS
                //var location = _context.Restaurants.ToList();
                //use this to check queries
                //Response.WriteAsync("This is debug text");
                //for (int i = 0; i < 4; i++)
                //{
                //    Response.WriteAsync(location.ElementAt(i));
                //}

                ViewBag.restlocation = location;
                if (!String.IsNullOrEmpty(searchString))
                {
                    if (district == "All Locations")
                    {
                        rest = rest.Where(s => s.Rname.Contains(searchString));
                    }
                    else
                    {
                        rest = rest.Where(s => s.Rname.Contains(searchString) && s.Rdistrict == district);
                    }

                }

                return View(rest.ToList());

            //}
            //else
            //{
            //    return RedirectToAction(nameof(FoodSearchResults));
            //}

        }
        //// GET: SearchController/Details/5
        //public IActionResult RestaurantDetails(int id)
        //{
        //    using (foodilizerContext dbmodel = new foodilizerContext())
        //        return View(dbmodel.Restaurants.Where(x => x.RestId == id).FirstOrDefault());
        //}
        //// GET: SearchController


        public IActionResult FoodSearchResults(string searchString, string district, string searchtype)
        {
            //if (searchtype == "Food")
            //{
                var location = _context.Restaurants.Select(x => x.Rdistrict).Distinct().ToList();

                var food = from f in _context.Foods
                           select f;

                //var dist = from d in _context.Restaurants
                //           select d;

                //DONT DELETE THIS
                //var location = _context.Restaurants.ToList();
                //use this to check queries
                //Response.WriteAsync("This is debug text");
                //for (int i = 0; i < 4; i++)
                //{
                //    Response.WriteAsync(location.ElementAt(i));
                //}


                ViewBag.restlocation = location;
                if (!String.IsNullOrEmpty(searchString))
                {
                    if (district == "All Locations")
                    {
                        food = food.Where(s => s.FoodName.Contains(searchString));
                    }
                    else
                    {
                        food = food.Where(s => s.FoodName.Contains(searchString) /*&& ( x.Rdistrict == district)*/);
                    }

                }

                return View(food.ToList());
            //}
            //else
            //{
            //    return RedirectToAction(nameof(RestaurantSearchResults));
            //}
        }

        //// GET: SearchController/Details/5
        //public IActionResult FoodDetails(int id)
        //{
        //    using (foodilizerContext dbmodel = new foodilizerContext())
        //        return View(dbmodel.Foods.Where(x => x.FoodId == id).FirstOrDefault());
        //}


    }
}
