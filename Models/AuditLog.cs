using System;
using System.ComponentModel.DataAnnotations;

namespace MioMizutani_Lab3.Models
{
    public class AuditLog
    {
        public int AuditLogId { get; set; }

        [Required(ErrorMessage = "Action is required.")]
        [StringLength(100, ErrorMessage = "Action must be less than 100 characters.")]
        public string Action { get; set; } = string.Empty;

        [Required(ErrorMessage = "Entity name is required.")]
        [StringLength(100, ErrorMessage = "Entity name must be less than 100 characters.")]
        public string EntityName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Performed by is required.")]
        [StringLength(100, ErrorMessage = "Performed by must be less than 100 characters.")]
        public string PerformedBy { get; set; } = string.Empty;

        [Required(ErrorMessage = "Timestamp is required.")]
        public DateTime Timestamp { get; set; }

        [StringLength(255, ErrorMessage = "Details must be less than 255 characters.")]
        public string? Details { get; set; }
    }
}