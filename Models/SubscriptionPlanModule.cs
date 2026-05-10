namespace SaasSubscriptionManagementSystem.Models
{
    public class SubscriptionPlanModule
    {
        public int PlanId { get; set; }
        public SubscriptionPlan? SubscriptionPlan { get; set; }

        public int ModuleId { get; set; }
        public Module? Module { get; set; }
    }
}