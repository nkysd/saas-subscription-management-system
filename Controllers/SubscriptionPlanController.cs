using Microsoft.AspNetCore.Mvc;
using MioMizutani_Lab3.Models;
using MioMizutani_Lab3.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace MioMizutani_Lab3.Controllers
{
    [Authorize]
    public class SubscriptionPlanController : Controller
    {
        private readonly AppDbContext _context;

        public SubscriptionPlanController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<SubscriptionPlan> plans = _context.SubscriptionPlans.ToList();

            ViewBag.AdminName = "Mio Mizutani";
            ViewBag.RoleName = "Administrator";

            return View(plans);
        }
    }
}