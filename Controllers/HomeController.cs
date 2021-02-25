using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DeployWeb.Models;
using DeployWeb.Data;
using DeployWeb.Data.Model;

namespace DeployWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DeployDbContext _deployDbContext;

        public HomeController(ILogger<HomeController> logger, DeployDbContext deployDbContext)
        {
            _logger = logger;
            _deployDbContext = deployDbContext;
        }

        public IActionResult Index()
        {
            var model = new PayloadViewModel();
            var reps = _deployDbContext.Query<Repository>("SELECT DISTINCT Id, Name, Full_name, Url FROM Repository ");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
