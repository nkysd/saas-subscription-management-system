using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SaasSubscriptionManagementSystem.Models
{
    public class Module
    {
        public int ModuleId { get; set; }

        [Required(ErrorMessage = "Module name is required.")]
        [StringLength(50, ErrorMessage = "Module name must be less than 50 characters.")]
        public string ModuleName { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Description must be less than 200 characters.")]
        public string Description { get; set; } = string.Empty;

        public List<SubscriptionPlanModule>? SubscriptionPlanModules { get; set; }
    }
}