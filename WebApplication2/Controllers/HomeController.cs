using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDbContext a;
        private readonly HttpClient h;

        public HomeController(ILogger<HomeController> logger, AppDbContext c)
        {
            _logger = logger;
            this.a = c;
        }

        public async Task<IActionResult> Index()
        {

            
            ViewBag.a = this.a.users;
            HttpClient h = new HttpClient();
            var response = await h.GetAsync("https://reqres.in/api/users?page=2");
            Console.WriteLine(response);
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
