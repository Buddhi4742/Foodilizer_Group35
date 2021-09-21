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
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.Graph;

namespace Foodilizer_Group35.Controllers
{
    public class Customer_profileController : Controller
    {
        // GET: Customer_ProfileController
        private readonly foodilizerContext _context;

        public Customer_profileController(foodilizerContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult customer_profile_orders(int id)
        {
            int userid = id;
            TempData["Id"] = id;
            var userdetails = _context.Users.Where(x => x.UserId == userid).FirstOrDefault();
            var customerid = _context.Customers.Where(x => x.Cemail == userdetails.Email).FirstOrDefault();
            id = customerid.CustomerId;
            
            var queryOrder = _context.Customers.Where(e => e.CustomerId == id).Include(e => e.RestaurantOrders).ThenInclude(e => e.Rest).Include(e => e.RestaurantOrders).ThenInclude(e => e.OrderIncludesFoods).ThenInclude(e => e.Food).ToList();
            ViewBag.customerOrders = queryOrder;
            var queryReview = _context.Customers.Where(e => e.CustomerId == id).Include(e => e.Reviews).ThenInclude(e => e.Rest).ToList();
            ViewBag.customerReviews = queryReview;
            using (foodilizerContext context = new foodilizerContext())
            {
                return View(_context.Customers.Where(x => x.CustomerId == id).FirstOrDefault());
            }
        }

        public ActionResult customer_profile_reviews(int id)
        {
            //Response.WriteAsync(id.ToString());
            int userid = id;
            TempData["Id"] = id;
            var userdetails = _context.Users.Where(x => x.UserId == userid).FirstOrDefault();
            var customerid = _context.Customers.Where(x => x.Cemail == userdetails.Email).FirstOrDefault();
            id = customerid.CustomerId;
            TempData["Name"] = customerid.Name;

            //int id = 1;
            var queryReview = _context.Customers.Where(e => e.CustomerId == id).Include(e => e.Reviews).ThenInclude(e => e.Rest).ToList();
            ViewBag.customerReviews = queryReview;
            var queryOrder = _context.Customers.Where(e => e.CustomerId == id).Include(e => e.RestaurantOrders).ThenInclude(e => e.Rest).ToList();
            ViewBag.customerOrders = queryOrder;
            using (foodilizerContext context = new foodilizerContext())
            {
                return View(_context.Customers.Where(x => x.CustomerId == id).Include(e => e.Reviews).FirstOrDefault());
            }
        }

        public ActionResult customer_profile_edit(int id)
        {
            int userid = id;
            TempData["Id"] = id;
            var userdetails = _context.Users.Where(x => x.UserId == userid).FirstOrDefault();
            var customerid = _context.Customers.Where(x => x.Cemail == userdetails.Email).FirstOrDefault();
            id = customerid.CustomerId;
            using (foodilizerContext context = new foodilizerContext())
            {
                return View(_context.Customers.Where(x => x.CustomerId == id).FirstOrDefault());
            }
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult customer_profile_edit(int id,Customer customer, IFormFile postedFile)
        {
            int userid = id;
            TempData["Id"] = id;
            var userdetails = _context.Users.Where(x => x.UserId == userid).FirstOrDefault();
            var customerid = _context.Customers.Where(x => x.Cemail == userdetails.Email).FirstOrDefault();
            id = customerid.CustomerId;
            try
            {
                string path = "wwwroot/images";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string uploadedFile = "";
                
                    string fileName = Path.GetFileName(postedFile.FileName);
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                        uploadedFile=fileName;
                        ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                    }
                string path2 = "~/images";
                Path.Combine(path2, fileName);
                _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault().Name = customer.Name;
                _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault().Name = customer.Name;
                _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault().Address = customer.Address;
                _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault().Province = customer.Province;
                _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault().District = customer.District;
                _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault().DietryRestriction = customer.DietryRestriction;
                _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault().ProfileImage = Path.Combine(path2, fileName);
                _context.SaveChanges();


                return RedirectToAction("customer_profile_reviews","Customer_profile",new {id=userid});
            }
            catch
            {
                return View(_context.Customers.Where(x => x.CustomerId == id).FirstOrDefault());
            }
        }

        // GET: Customer_ProfileController/Details/5
        public ActionResult Details(int id)
        {
            int userid = id;
            var userdetails = _context.Users.Where(x => x.UserId == userid).FirstOrDefault();
            var customerid = _context.Customers.Where(x => x.Cemail == userdetails.Email).FirstOrDefault();
            id = customerid.CustomerId;
            //int id = 1;
            using (foodilizerContext context = new foodilizerContext())
            {
                return View(_context.Customers.Where(x => x.CustomerId == id).FirstOrDefault());
            }
        }

        // GET: Customer_ProfileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer_ProfileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer_ProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer_ProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer_ProfileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer_ProfileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public void UploadFile(string email)
        {

            string folderPath = "wwwroot/resources/Customers/" + email + "/";

            //Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(folderPath);
            }

            ////Save the File to the Directory (Folder).
            //FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));

            ////Display the success message.
            //lblMessage.Text = Path.GetFileName(FileUpload1.FileName) + " has been uploaded.";
        }
    }
}
