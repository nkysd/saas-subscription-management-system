using Microsoft.AspNetCore.Mvc;
using MioMizutani_Lab3.Models;
using MioMizutani_Lab3.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MioMizutani_Lab3.Controllers
{
    [Authorize]
    public class SubscriptionController : Controller
    {
        private readonly AppDbContext _context;

        public SubscriptionController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.AdminName = "Mio Mizutani";
            ViewBag.RoleName = "Administrator";

            var subscriptions = _context.Subscriptions
                .Include(s => s.Customer)
                .Include(s => s.Plan)
                .ToList();

            return View(subscriptions);
        }

        public IActionResult Create()
        {
            List<SubscriptionPlan> plans = _context.SubscriptionPlans.ToList();

            ViewBag.AdminName = "Mio Mizutani";
            ViewBag.RoleName = "Administrator";
            ViewBag.Plans = plans;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string businessName, string planId, int users, string discountCode)
        {
            List<SubscriptionPlan> plans = _context.SubscriptionPlans.ToList();
            SubscriptionPlan? selectedPlan = null;

            if (int.TryParse(planId, out int planIdInt))
            {
                selectedPlan = plans.FirstOrDefault(p => p.PlanId == planIdInt);
            }

            ViewBag.AdminName = "Mio Mizutani";
            ViewBag.RoleName = "Administrator";
            ViewBag.Plans = plans;

            if (selectedPlan == null)
            {
                ViewBag.ErrorMessage = "Please select a valid plan.";
                return View();
            }

            if (string.IsNullOrWhiteSpace(businessName))
            {
                ViewBag.ErrorMessage = "Business name is required.";
                return View();
            }

            if (users < 1 || users > 100)
            {
                ViewBag.ErrorMessage = "Number of users must be between 1 and 100.";
                return View();
            }

            decimal totalPrice = selectedPlan.Price * users;
            decimal discountAmount = 0m;

            if (!string.IsNullOrWhiteSpace(discountCode) && discountCode.ToUpper() == "MIOM")
            {
                discountAmount = totalPrice * 0.15m;
                totalPrice = totalPrice - discountAmount;
            }

            Customer customer = new Customer();
            customer.FullName = businessName + " Contact";
            customer.Email = businessName.Replace(" ", "").ToLower() + "@example.com";
            customer.Phone = "0400000000";
            customer.BusinessName = businessName;

            _context.Customers.Add(customer);
            _context.SaveChanges();

            Subscription newSubscription = new Subscription();
            newSubscription.CustomerId = customer.UserId;
            newSubscription.PlanId = selectedPlan.PlanId;
            newSubscription.Users = users;
            newSubscription.Discount = discountAmount;
            newSubscription.TotalPrice = totalPrice;

            _context.Subscriptions.Add(newSubscription);
            _context.SaveChanges();

            Invoice newInvoice = new Invoice();
            newInvoice.SubscriptionId = newSubscription.SubscriptionId;
            newInvoice.Amount = newSubscription.TotalPrice;
            newInvoice.Status = "Pending";

            _context.Invoices.Add(newInvoice);
            _context.SaveChanges();

            ViewBag.SuccessMessage = "The entry is done for client "
                + businessName
                + " and the price is $"
                + totalPrice.ToString("F2");

            return View();
        }
    }
}