using System.Linq;
using Microsoft.AspNetCore.Identity;
using SaasSubscriptionManagementSystem.Models;

namespace SaasSubscriptionManagementSystem.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {

            if (!context.Admins.Any())
            {
                var hasher = new PasswordHasher<Admin>();

                var admin = new Admin
                {
                    UserId = 1,
                    FullName = "Mio Mizutani",
                    Email = "admin@qutech.com",
                    Phone = "0400000000",
                    RoleName = "Administrator",
                    Username = "admin"
                };

                admin.PasswordHash = hasher.HashPassword(admin, "Admin123!");

                context.Admins.Add(admin);
                context.SaveChanges();
            }

            if (!context.Modules.Any())
            {
                context.Modules.AddRange(
                    new Module { ModuleId = 1, ModuleName = "Analytics", Description = "Data analysis" },
                    new Module { ModuleId = 2, ModuleName = "Reporting", Description = "Generate reports" },
                    new Module { ModuleId = 3, ModuleName = "Billing", Description = "Manage billing" },
                    new Module { ModuleId = 4, ModuleName = "User Management", Description = "Manage users" },
                    new Module { ModuleId = 5, ModuleName = "Notifications", Description = "Send notifications" }
                );
                context.SaveChanges();
            }

            if (!context.SubscriptionPlans.Any())
            {
                context.SubscriptionPlans.AddRange(
                    new SubscriptionPlan { PlanId = 1, PlanName = "Startup", Price = 10.00m },
                    new SubscriptionPlan { PlanId = 2, PlanName = "Standard", Price = 20.00m },
                    new SubscriptionPlan { PlanId = 3, PlanName = "Premium", Price = 30.00m },
                    new SubscriptionPlan { PlanId = 4, PlanName = "Enterprise", Price = 40.00m },
                    new SubscriptionPlan { PlanId = 5, PlanName = "Ultimate", Price = 50.00m }
                );
                context.SaveChanges();
            }

            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    new Customer { UserId = 2, FullName = "ABC Company", Email = "abc@test.com", Phone = "0400000001", BusinessName = "ABC Pty Ltd" },
                    new Customer { UserId = 3, FullName = "XYZ Company", Email = "xyz@test.com", Phone = "0400000002", BusinessName = "XYZ Pty Ltd" },
                    new Customer { UserId = 4, FullName = "Tech Corp", Email = "tech@test.com", Phone = "0400000003", BusinessName = "Tech Corp Ltd" },
                    new Customer { UserId = 5, FullName = "Future Ltd", Email = "future@test.com", Phone = "0400000004", BusinessName = "Future Ltd" },
                    new Customer { UserId = 6, FullName = "Global Inc", Email = "global@test.com", Phone = "0400000005", BusinessName = "Global Inc" }
                );
                context.SaveChanges();
            }

            if (!context.Subscriptions.Any())
            {
                context.Subscriptions.AddRange(
                    new Subscription { SubscriptionId = 1, CustomerId = 2, PlanId = 1, Users = 10, TotalPrice = 100, Discount = 0 },
                    new Subscription { SubscriptionId = 2, CustomerId = 3, PlanId = 2, Users = 20, TotalPrice = 340, Discount = 60 },
                    new Subscription { SubscriptionId = 3, CustomerId = 4, PlanId = 3, Users = 15, TotalPrice = 450, Discount = 0 },
                    new Subscription { SubscriptionId = 4, CustomerId = 5, PlanId = 4, Users = 25, TotalPrice = 850, Discount = 150 },
                    new Subscription { SubscriptionId = 5, CustomerId = 6, PlanId = 5, Users = 30, TotalPrice = 1500, Discount = 0 }
            );
                context.SaveChanges();
            }

            if (!context.Invoices.Any())
            {
                context.Invoices.AddRange(
                    new Invoice { SubscriptionId = 1, Amount = 100, Status = "Paid" },
                    new Invoice { SubscriptionId = 2, Amount = 340, Status = "Pending" },
                    new Invoice { SubscriptionId = 3, Amount = 450, Status = "Paid" },
                    new Invoice { SubscriptionId = 4, Amount = 850, Status = "Pending" },
                    new Invoice { SubscriptionId = 5, Amount = 1500, Status = "Paid" }
                );
                context.SaveChanges();
            }

            if (!context.AuditLogs.Any())
{
    context.AuditLogs.AddRange(
        new AuditLog
        {
            Action = "Create",
            EntityName = "SubscriptionPlan",
            PerformedBy = "Mio Mizutani",
            Timestamp = DateTime.Now.AddDays(-5),
            Details = "Created Startup plan"
        },
        new AuditLog
        {
            Action = "Create",
            EntityName = "Module",
            PerformedBy = "admin",
            Timestamp = DateTime.Now.AddDays(-4),
            Details = "Added Analytics module"
        },
        new AuditLog
        {
            Action = "Create",
            EntityName = "Customer",
            PerformedBy = "admin",
            Timestamp = DateTime.Now.AddDays(-3),
            Details = "Added ABC Pty Ltd"
        },
        new AuditLog
        {
            Action = "Create",
            EntityName = "Subscription",
            PerformedBy = "admin",
            Timestamp = DateTime.Now.AddDays(-2),
            Details = "Created subscription for XYZ Pty Ltd"
        },
        new AuditLog
        {
            Action = "Generate",
            EntityName = "Invoice",
            PerformedBy = "admin",
            Timestamp = DateTime.Now.AddDays(-1),
            Details = "Generated invoice for subscription 1"
        }
    );

    context.SaveChanges();
}
        }
    }
}