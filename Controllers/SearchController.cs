using Foodilizer_Group35.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
           
            if (searchtype == "Restaurant")
            {
                //searchString = "Palm";
                var location = _context.Restaurants.Select(x => x.Rdistrict).Distinct().ToList();

                var rest = _context.Restaurants.Include(e=>e.RestaurantImage);
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
                        rest = _context.Restaurants.Where(s => s.Rname.Contains(searchString)).Include(e=>e.RestaurantImage);
                    }
                    else
                    {
                        rest = rest.Where(s => s.Rname.Contains(searchString) && s.Rdistrict == district).Include(e => e.RestaurantImage);
                    }

                }

                return View(rest.ToList());

            }
            else if (searchtype == null)
            {
                searchtype = "Restaurant";
                //return View(RestaurantSearchResults(searchString, district, searchtype));
                return RedirectToAction("RestaurantSearchResults", "Search",new {searchString,district,searchtype});

            }
            else
            {
                searchtype = "Food";
                //return View(FoodSearchResults(searchString, district, searchtype));
                return RedirectToAction("FoodSearchResults", "Search", new { searchString, district, searchtype });
            }

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
            if (searchtype == "Food")
            {
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
                        food = food.Where(s => s.FoodName.Contains(searchString));
                }

                return View(food.ToList());
            }
            else if (searchtype == null)
            {
                searchtype = "Food";
                return RedirectToAction("FoodSearchResults", "Search", new { searchString, district, searchtype });

            }
            else
            {
                searchtype = "Restaurant";
                return RedirectToAction("RestaurantSearchResults", "Search", new { searchString, district, searchtype });
            }
        }
        public IActionResult redirectstore(int id)
        {
            //Response.WriteAsync(id.ToString());
            var resttype = _context.Restaurants.Where(x => x.RestId==id).FirstOrDefault();
            if (resttype.RestType == "bronze")
            {
                return RedirectToAction("bronze_home", "store_front",new {id});
            }
            else if (resttype.RestType == "silver")
            {
                return RedirectToAction("silver_home", "store_front", new {id});
            }
            else if (resttype.RestType == "gold")
            {
                return RedirectToAction("gold_home", "store_front", new {id});
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }

        //// GET: SearchController/Details/5
        //public IActionResult FoodDetails(int id)
        //{
        //    using (foodilizerContext dbmodel = new foodilizerContext())
        //        return View(dbmodel.Foods.Where(x => x.FoodId == id).FirstOrDefault());
        //}


    }
}
