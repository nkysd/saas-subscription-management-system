using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SaasSubscriptionManagementSystem.Models
{
    public class SubscriptionPlan
    {
        [Key]
        public int PlanId { get; set; }

        [Required(ErrorMessage = "Plan name is required.")]
        [StringLength(50, ErrorMessage = "Plan name must be less than 50 characters.")]
        public string PlanName { get; set; } = string.Empty;

        [Range(0.01, 99999, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        public List<Subscription>? Subscriptions { get; set; }
        public List<SubscriptionPlanModule>? SubscriptionPlanModules { get; set; }

        public SubscriptionPlan()
        {
        }

        public SubscriptionPlan(int id, string planName, decimal price)
        {
            PlanId = id;
            PlanName = planName;
            Price = price;
        }

        public static List<SubscriptionPlan> GetDefaultPlans()
        {
            return new List<SubscriptionPlan>
            {
                new SubscriptionPlan(1, "Startup", 10.00m),
                new SubscriptionPlan(2, "Standard", 20.00m),
                new SubscriptionPlan(3, "Premium", 30.00m),
                new SubscriptionPlan(4, "Enterprise", 40.00m),
                new SubscriptionPlan(5, "Ultimate", 50.00m)
            };
        }
    }
}