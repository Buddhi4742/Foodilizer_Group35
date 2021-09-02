using Foodilizer_Group35.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
//using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.Graph;

namespace Foodilizer_Group35.Controllers
{
    public class OwnerController : Controller
    {
        private readonly foodilizerContext _context;
        public OwnerController(foodilizerContext context)
        {
            _context = context;
        }
        public IActionResult Owner_home()
        {
            return View();
        }
        public IActionResult Owner_register()
        {
            return View();
        }
        public IActionResult Owner_price()
        {
            return View();
        }
        public IActionResult Owner_redirect()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
