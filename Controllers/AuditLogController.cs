using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaasSubscriptionManagementSystem.Data;
using System.Linq;

namespace SaasSubscriptionManagementSystem.Controllers
{
    [Authorize]
    public class AuditLogController : Controller
    {
        private readonly AppDbContext _context;

        public AuditLogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var logs = _context.AuditLogs
                .OrderByDescending(a => a.Timestamp)
                .ToList();

            return View(logs);
        }
    }
}