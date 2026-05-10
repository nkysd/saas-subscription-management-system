namespace SaasSubscriptionManagementSystem.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int PlanId { get; set; }
        public SubscriptionPlan? Plan { get; set; }

        public int Users { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal Discount { get; set; }
    }
}