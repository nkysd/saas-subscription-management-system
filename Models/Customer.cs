using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SaasSubscriptionManagementSystem.Models
{
    public class Customer : User
    {
        [Required(ErrorMessage = "Business name is required.")]
        [StringLength(100, ErrorMessage = "Business name must be less than 100 characters.")]
        public string BusinessName { get; set; } = string.Empty;

        public List<Subscription>? Subscriptions { get; set; }
    }
}