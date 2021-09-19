using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
//using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodilizer_Group35.Models;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.Graph;
namespace Foodilizer_Group35.Controllers
{
    public class StoreAdminController : Controller
    {

        private readonly foodilizerContext _context;

        public StoreAdminController(foodilizerContext context)
        {
            _context = context;
        }
        // GET: Store_adminController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Profile()
        {
            int id = 2;
            TempData["ID"] = id;
            //var q = ;
            return View(_context.Restaurants.Where(x => x.RestId == id).FirstOrDefault());
        }

        public async Task<IActionResult> UpdateRestaurant(IFormCollection collection,int id)
        {
                    //await Response.WriteAsync(collection["Remail"].ToString());
                    //var restdetails = await _context.Restaurants.FirstOrDefaultAsync(e => e.Remail == collection["Remail"].ToString() /*&& e.User_status == 1*/);
                    //await Response.WriteAsync(collection["logo"]);
                    
                    var UpdateRestaurant = new Restaurant();
                    UpdateRestaurant.RestId = id;
                    UpdateRestaurant.Rname = collection["Rname"];
                    UpdateRestaurant.OwnerName = collection["OwnerName"];
                    UpdateRestaurant.OwnerContact = collection["OwnerContact"];
                    UpdateRestaurant.Rabout = collection["Rabout"];
                    UpdateRestaurant.RestType = collection["RestType"];
                    UpdateRestaurant.Raddress = collection["Raddress"];
                    UpdateRestaurant.Rdistrict = collection["Rdistrict"];
                    UpdateRestaurant.PriceRange = collection["PriceRange"];
                    UpdateRestaurant.Rdistrict = collection["Rdistrict"];
                    UpdateRestaurant.OpenHour = collection["OpenHour"];
                    UpdateRestaurant.RestContact = collection["RestContact"];
                    UpdateRestaurant.OpenStatus = 1;
                    UpdateRestaurant.WebsiteLink = collection["WebsiteLink"];
                    UpdateRestaurant.MapLink = collection["MapLink"];
                    UpdateRestaurant.MealType = collection["MealType"];
                    UpdateRestaurant.Cuisine = collection["Cuisine"];
                    UpdateRestaurant.Feature = collection["Feature"];
                    UpdateRestaurant.SpecialDiet = collection["SpecialDiet"]; //this is food options on UI
                    _context.Entry(UpdateRestaurant).State = EntityState.Modified;
                    _context.Entry(UpdateRestaurant).Property(x => x.Remail).IsModified = false;
                    _context.Entry(UpdateRestaurant).Property(x => x.RestId).IsModified = false;
                    _context.Entry(UpdateRestaurant).Property(x => x.Rpassword).IsModified = false;
                    _context.Entry(UpdateRestaurant).Property(x => x.Rusername).IsModified = false;
            //_context.Add(customer);
            await _context.SaveChangesAsync();

                    TempData["Message"] = "Updated.";
                    
                    return RedirectToAction("Profile");
        }
        public ActionResult Menu()
        {
            int id = 2;
            var query = _context.Menus.Where(e => e.RestId == id).Include(e => e.Foods).ToList();
            var menuid = _context.Menus.Where(e => e.RestId == id).FirstOrDefault();

            TempData["Menu_id"]=menuid.MenuId;
            ViewBag.fooddet = query;
            return View(_context.Restaurants.Where(x => x.RestId == id).Include(e => e.Menus).ThenInclude(e => e.Foods).FirstOrDefault());

        }

        public ActionResult MenuDetails(int id)
        {

            return View(_context.Foods.Where(x => x.FoodId == id).FirstOrDefault());

        }

        public ActionResult MenuCreate(int id)
        {
            TempData["MenuID"] = id;
            return View();
        }

        public ActionResult MenuNewFooditem(IFormCollection collection, int id)
        {
            var updatefooditem = new Food();
            updatefooditem.MenuId = id;
            updatefooditem.FoodName = collection["FoodName"];
            updatefooditem.Type = collection["Type"];
            updatefooditem.Price = Int64.Parse(collection["Price"]);
            updatefooditem.Ingredient = collection["Ingredient"];
            updatefooditem.ImagePath = collection["ImagePath"];
            updatefooditem.PrefScore = Int32.Parse(collection["PrefScore"]);
            updatefooditem.Featured = collection["Featured"];
            updatefooditem.Category = collection["Category"];
            updatefooditem.SubCategory = collection["SubCategory"];
            updatefooditem.CategoryRating = collection["CategoryRating"];
            updatefooditem.Quantity = Int32.Parse(collection["Quantity"]);
            updatefooditem.Veg = collection["Veg"];
            updatefooditem.Hot = collection["Hot"];
            updatefooditem.SpicyLevel = collection["SpicyLevel"];
            updatefooditem.Organic = collection["Organic"];

            _context.Add(updatefooditem);
            //food.MenuId = id;
            //_context.Foods.Add(food);
            _context.SaveChanges();
            return RedirectToAction(nameof(Menu));
        }
        public ActionResult MenuEdit(int id)
        {

            return View(_context.Foods.Where(x => x.FoodId == id).FirstOrDefault());


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MenuEdit(int id, Food food)
        {
            try
            {

                _context.Entry(food).State = EntityState.Modified;
                _context.SaveChanges();


                return RedirectToAction(nameof(Menu));
            }
            catch
            {
                return View();
            }
        }
        // GET: itemtable/Delete/5
        public ActionResult MenuDelete(int id)
        {
            //Response.WriteAsync(id.ToString());
            TempData["Food_id"] = id;
            //Response.WriteAsync(TempData["Food_id"].ToString());
            return View(_context.Foods.Where(x => x.FoodId == id).FirstOrDefault());
        }

        // POST: itemtable/Delete/5
        public  ActionResult Deletefooditem(int id)
        {
                Food food = _context.Foods.Where(x => x.FoodId == id).FirstOrDefault();
                _context.Foods.Remove(food);
                _context.SaveChanges();
                return RedirectToAction(nameof(Menu));
        }
        public ActionResult Inventory()
        {
            int id = 2;
            var q = _context.Items.Where(x => x.RestId == id).ToList();
            return View(q);

        }
        public ActionResult InventoryDetails(int id)
        {
            
            return View(_context.Items.Where(x => x.ItemId == id).FirstOrDefault());
            
        }

        public ActionResult InventoryCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InventoryCreate(Item item)
        {

            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction(nameof(Inventory));
        }
        public ActionResult InventoryEdit(int id)
        {
            
            return View(_context.Items.Where(x => x.ItemId == id).FirstOrDefault());
            
    
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InventoryEdit(int id, Item item)
        {
            try
            {

                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
                

                return RedirectToAction(nameof(Inventory));
            }
            catch
            {
                return View();
            }
        }
        // GET: itemtable/Delete/5
        public IActionResult InventoryDelete(int id)
        {
            //Response.WriteAsync(id.ToString());
            return View(_context.Items.Where(x => x.ItemId == id).FirstOrDefault());
        }

        // POST: itemtable/Delete/5
        public async Task<IActionResult> InventoryDelete(int id, IFormCollection collection)
        {
            try
            {
                //Response.WriteAsync(id.ToString());
                Item item =  _context.Items.Where(x => x.ItemId == id).FirstOrDefault();
                _context.Items.Remove(item);
               await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Inventory));
            }
            catch
            {
                return View();
            }
        }




        public ActionResult Recomendations()
        {
            return View();
        }
        public ActionResult Banner()
        {
            return View();
        }
        public ActionResult Orders()
        {
            return View();
        }
        public ActionResult OtherUsers()
        {
            return View();
        }
        public ActionResult Reports()
        {
            return View();
        }
        public ActionResult Inspect()
        {
            return View();
        }

    }
}
