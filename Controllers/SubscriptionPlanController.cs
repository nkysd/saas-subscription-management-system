using Microsoft.AspNetCore.Mvc;
using SaasSubscriptionManagementSystem.Models;
using SaasSubscriptionManagementSystem.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace SaasSubscriptionManagementSystem.Controllers
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

            ViewBag.AdminName = User.Identity.Name;
            ViewBag.RoleName = User.IsInRole("Administrator") ? "Administrator" : "User";

            return View(plans);
        }
    }
}