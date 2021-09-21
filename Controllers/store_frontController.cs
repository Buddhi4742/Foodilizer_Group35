using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodilizer_Group35.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.Graph;

namespace Foodilizer_Group35.Controllers
{
    public class Store_frontController : Controller
    {
        private readonly foodilizerContext _context;

        public Store_frontController(foodilizerContext context)
        {
            _context = context;
        }

        public IActionResult bronze_home(int id)
        {
            
            var sessionid=HttpContext.Session.GetInt32("user_id");
            ViewBag.sessionid = sessionid;
            var sessionuser = HttpContext.Session.GetString("user_type");
            ViewBag.sessionuser = sessionuser;
            HttpContext.Session.SetInt32("rest_id", id);
            
            ViewBag.currentrestid = id;
            var query = _context.Menus.Where(e => e.RestId == id).Include(e => e.Foods).ToList();
            ViewBag.fooddet = query;
            var query2 = _context.Restaurants.Where(e => e.RestId == id).Include(e => e.Reviews).ThenInclude(e=>e.Customer).ToList();
            ViewBag.review = query2;
            var query3 = _context.Restaurants.Include(e => e.Reviews).ToList();
            
            
            int c = query3.Count();
            int count = 0;
            double[,] array = new double[c, 2];
            int i = 0;
            int j = 0;

            

            foreach (var item2 in query3)
            {
                if (item2.RestId != 0)
                {
                    int rid = item2.RestId;
                
                    var rate = _context.Reviews.Where(e => e.RestId == rid).ToList();
                    double avg = System.Convert.ToDouble((from x in rate select x.Rating).Average());
                    array[i, 0] = item2.RestId;
                    array[i, 1] = avg;
                    i++;
                    count++;
                }

            }

            for (i = 0; i < count; i++)
            {
                for (j = 0; j < count -1- i; j++)
                {
                    if (array[j, 1] < array[j + 1, 1]) // column 1 entry comparison
                    {
                        double temp1 = array[j, 0];              // swap both column 0 and column 1
                        double temp2 = array[j, 1];

                        array[j, 0] = array[j + 1, 0];
                        array[j, 1] = array[j + 1, 1];

                        array[j + 1, 0] = temp1;
                        array[j + 1, 1] = temp2;
                    }
                }
            }
            var query4 = _context.Restaurants.Where(e => e.RestId == array[0,0]).Include(e => e.Reviews).ToList();
            ViewBag.rating1 = query4;
            var query5 = _context.Restaurants.Where(e => e.RestId == array[1, 0]).Include(e => e.Reviews).ToList();
            ViewBag.rating2 = query5;
            var query6 = _context.Restaurants.Where(e => e.RestId == array[2, 0]).Include(e => e.Reviews).ToList();
            ViewBag.rating3 = query6;
            var query7 = _context.Restaurants.Where(e => e.RestId == array[3, 0]).Include(e => e.Reviews).ToList();
            ViewBag.rating4 = query7;




            using (foodilizerContext context = new foodilizerContext())
            {
                return View(_context.Restaurants.Where(x => x.RestId == id).Include(e => e.Menus).ThenInclude(e => e.Foods).FirstOrDefault());
            }


        }

        public IActionResult silver_home(int id)
        {
            var sessionid = HttpContext.Session.GetInt32("user_id");
            ViewBag.sessionid = sessionid;
            var sessionuser = HttpContext.Session.GetString("user_type");
            ViewBag.sessionuser = sessionuser;

            HttpContext.Session.SetInt32("rest_id", id);
            var query = _context.Menus.Where(e => e.RestId == id).Include(e => e.Foods).ToList();
            ViewBag.fooddet = query;
            ViewBag.count = 0;
            var query2 = _context.Restaurants.Where(e => e.RestId == id).Include(e => e.Reviews).ThenInclude(e => e.Customer).ToList();
            ViewBag.review = query2;

            foreach (var item in query)
            {

                var recommend = _context.Foods.Where(e => e.MenuId == item.MenuId).ToList();
                var prefscore = recommend.OrderByDescending(c => c.PrefScore).ToList();
                ViewBag.recommendation = prefscore;
            }
            
            
            var query3 = _context.Restaurants.Include(e => e.Reviews).ToList();
            int c = query3.Count();
            int count = 0;
            double[,] array = new double[c, 2];
            int i = 0;
            int j = 0;



            foreach (var item2 in query3)
            {
                if (item2.RestId != 0)
                {
                    int rid = item2.RestId;

                    var rate = _context.Reviews.Where(e => e.RestId == rid).ToList();
                    double avg = System.Convert.ToDouble((from x in rate select x.Rating).Average());
                    array[i, 0] = item2.RestId;
                    array[i, 1] = avg;
                    i++;
                    count++;
                }

            }

            for (i = 0; i < count; i++)
            {
                for (j = 0; j < count - 1 - i; j++)
                {
                    if (array[j, 1] < array[j + 1, 1]) // column 1 entry comparison
                    {
                        double temp1 = array[j, 0];              // swap both column 0 and column 1
                        double temp2 = array[j, 1];

                        array[j, 0] = array[j + 1, 0];
                        array[j, 1] = array[j + 1, 1];

                        array[j + 1, 0] = temp1;
                        array[j + 1, 1] = temp2;
                    }
                }
            }
            var query4 = _context.Restaurants.Where(e => e.RestId == array[0, 0]).Include(e => e.Reviews).ToList();
            ViewBag.rating1 = query4;
            var query5 = _context.Restaurants.Where(e => e.RestId == array[1, 0]).Include(e => e.Reviews).ToList();
            ViewBag.rating2 = query5;
            var query6 = _context.Restaurants.Where(e => e.RestId == array[2, 0]).Include(e => e.Reviews).ToList();
            ViewBag.rating3 = query6;
            var query7 = _context.Restaurants.Where(e => e.RestId == array[3, 0]).Include(e => e.Reviews).ToList();
            ViewBag.rating4 = query7;
            using (foodilizerContext context = new foodilizerContext())
            {
                return View(_context.Restaurants.Where(x => x.RestId == id).Include(e => e.Menus).ThenInclude(e => e.Foods).FirstOrDefault());
            }
        }
        public IActionResult gold_home(int id)
        {
            var sessionid = HttpContext.Session.GetInt32("user_id");
            ViewBag.sessionid = sessionid;
            var sessionuser = HttpContext.Session.GetString("user_type");
            ViewBag.sessionuser = sessionuser;
            //int id = 5;
            HttpContext.Session.SetInt32("rest_id", id);

            ViewBag.currentrestid = id;
            var query = _context.Menus.Where(e => e.RestId == id).Include(e => e.Foods).ToList();
            ViewBag.fooddet = query;
            var query2 = _context.Restaurants.Where(e => e.RestId == id).Include(e => e.Reviews).ThenInclude(e => e.Customer).ToList();
            ViewBag.review = query2;
            ViewBag.count = 0;
            foreach (var item in query)
            {

                var recommend = _context.Foods.Where(e => e.MenuId == item.MenuId).ToList();
                var prefscore = recommend.OrderByDescending(c => c.PrefScore).ToList();
                ViewBag.recommendation = prefscore;
            }
            var query3 = _context.Restaurants.Include(e => e.Reviews).ToList();
            int c = query3.Count();
            int count = 0;
            double[,] array = new double[c, 2];
            int i = 0;
            int j = 0;



            foreach (var item2 in query3)
            {
                if (item2.RestId != 0)
                {
                    int rid = item2.RestId;

                    var rate = _context.Reviews.Where(e => e.RestId == rid).ToList();
                    double avg = System.Convert.ToDouble((from x in rate select x.Rating).Average());
                    array[i, 0] = item2.RestId;
                    array[i, 1] = avg;
                    i++;
                    count++;
                }

            }

            for (i = 0; i < count; i++)
            {
                for (j = 0; j < count - 1 - i; j++)
                {
                    if (array[j, 1] < array[j + 1, 1]) // column 1 entry comparison
                    {
                        double temp1 = array[j, 0];              // swap both column 0 and column 1
                        double temp2 = array[j, 1];

                        array[j, 0] = array[j + 1, 0];
                        array[j, 1] = array[j + 1, 1];

                        array[j + 1, 0] = temp1;
                        array[j + 1, 1] = temp2;
                    }
                }
            }
            var query4 = _context.Restaurants.Where(e => e.RestId == array[0, 0]).Include(e => e.Reviews).ToList();
            ViewBag.rating1 = query4;
            var query5 = _context.Restaurants.Where(e => e.RestId == array[1, 0]).Include(e => e.Reviews).ToList();
            ViewBag.rating2 = query5;
            var query6 = _context.Restaurants.Where(e => e.RestId == array[2, 0]).Include(e => e.Reviews).ToList();
            ViewBag.rating3 = query6;
            var query7 = _context.Restaurants.Where(e => e.RestId == array[3, 0]).Include(e => e.Reviews).ToList();
            ViewBag.rating4 = query7;

            using (foodilizerContext context = new foodilizerContext())
            {
                return View(_context.Restaurants.Where(x => x.RestId == id).Include(e => e.Menus).ThenInclude(e => e.Foods).FirstOrDefault());
            }
        }


        public async Task<IActionResult> create_review(IFormCollection collection, List<IFormFile> postedFiles)
        {

            if (ModelState.IsValid)
            {

                try
                {

                    var email = HttpContext.Session.GetString("user_email");
                    var query = _context.Customers.Where(e => e.Cemail == email).ToList();
                    string[] paths = new string[3];
                    int pcount = 0;
                    //Customerid should be removed from here
                    int customerid=-1;
                    foreach (var item2 in query)
                    {
                        if (item2.CustomerId != 0)
                        {
                            customerid = item2.CustomerId;

                        }
                    }
                    var newrev = new Review();
                    var restid= HttpContext.Session.GetInt32("rest_id");
                    newrev.RestId = System.Convert.ToInt32(restid);
                    newrev.CustomerId = customerid;
                    newrev.Feedback = collection["message"];
                    newrev.Title = collection["experience"];
                    newrev.Rating = System.Convert.ToInt32(collection["subject"]);
                    DateTime dateTime = DateTime.UtcNow.Date;
                    newrev.Date = dateTime;
                    

                    // image uploading to the folder
                    string path = "wwwroot/images";

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    List<string> uploadedFiles = new List<string>();
                    foreach (IFormFile postedFile in postedFiles)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        paths[pcount] = fileName;
                        pcount++;
                        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            postedFile.CopyTo(stream);
                            uploadedFiles.Add(fileName);
                            ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                        }
                    }

                    //link uploading to the database
                    string path2 = "~/images";
                    if (pcount >= 3)
                    {
                        newrev.ReviewImage1 = Path.Combine(path2, paths[0]);
                        newrev.ReviewImage2 = Path.Combine(path2, paths[1]);
                        newrev.ReviewImage3 = Path.Combine(path2, paths[2]);
                    }
                    else if (pcount == 2)
                    {
                        newrev.ReviewImage1 = Path.Combine(path2, paths[0]);
                        newrev.ReviewImage2 = Path.Combine(path2, paths[1]);
                    }
                    else if(pcount == 1)
                    {
                        newrev.ReviewImage1 = Path.Combine(path2, paths[0]);
                    }

                    _context.Add(newrev);
                    await _context.SaveChangesAsync();

                    int id = System.Convert.ToInt32(restid);
                    TempData["Message"] = "Review Submitted Successfully";
                    //return RedirectToAction(nameof(Owner_price));
                    string urlAnterior = Request.Headers["Referer"].ToString();

                    if (urlAnterior.Contains("bronze"))
                    {
                        return RedirectToAction("bronze_home", "store_front", new { id });
                    }
                    else if (urlAnterior.Contains("silver"))
                    {
                        return RedirectToAction("silver_home", "store_front", new { id });
                    }
                    else if (urlAnterior.Contains("gold"))
                    {
                        return RedirectToAction("gold_home", "store_front", new { id });
                    }
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.ToString().Contains("Violation of UNIQUE KEY constraint")) ViewBag.Error = "This email is already used. Please use another email address";
                    else ViewBag.Error = "Unable to register this user. Please try agian";
                    return View(/*customer*/);

                }

            }
            ViewBag.Error = "Unable to register this user. Please try agian";
            return View(/*customer*/);

        }
        public IActionResult silver_cart()
        {
            return View();
        }
        public IActionResult gold_cart()
        {
            return View();
        }
        public IActionResult silver_checkout()
        {
            return View();
        }
        public IActionResult gold_checkout()
        {
            return View();
        }
        public IActionResult order_details() 
        { 
            return View();
        }

    }



}
