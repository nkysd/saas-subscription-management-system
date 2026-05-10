using System.ComponentModel.DataAnnotations;

namespace SaasSubscriptionManagementSystem.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public int SubscriptionId { get; set; }
        public Subscription? Subscription { get; set; }

        [Range(0.01, 999999, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(30, ErrorMessage = "Status must be less than 30 characters.")]
        public string Status { get; set; } = string.Empty;
    }
}