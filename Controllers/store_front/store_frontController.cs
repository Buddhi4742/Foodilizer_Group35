using Foodilizer_Group35.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Foodilizer_Group35.Controllers
{
    public class store_frontController : Controller
    {
        private readonly ILogger<store_frontController> _logger;

        public store_frontController(ILogger<store_frontController> logger)
        {
            _logger = logger;
        }

        public IActionResult bronze_home()
        {
            return View();
        }

    }
}
