using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MioMizutani_Lab3.Models;
using Microsoft.AspNetCore.Authorization;

namespace MioMizutani_Lab3.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            Admin admin = new Admin();
            admin.FullName = "Mio Mizutani";
            admin.Email = "mio@example.com";
            admin.Phone = "0400000000";
            admin.RoleName = "Administrator";

            ViewBag.AdminName = admin.FullName;
            ViewBag.RoleName = admin.RoleName;

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