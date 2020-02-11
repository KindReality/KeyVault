using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KeyVault.Models;
using Microsoft.Extensions.Configuration;

namespace KeyVault.Controllers
{
    public class HomeController : Controller
    {
        //addded
        private readonly IConfiguration _configuration = null;
        private readonly ILogger<HomeController> _logger;

        //updated
        public HomeController(IConfiguration configuration, ILogger<HomeController> logger)
        {
            //added
            _configuration = configuration;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //added
            ViewBag.Message = "My key val = " + _configuration["AppSecret"];
            return View();
        }

        public IActionResult Privacy()
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
