using System;
using System.ComponentModel.DataAnnotations;

namespace SkillsShowcase.Shared.Domain.Models
{
    public class SessionLogs
    {
        [Key]
        public Guid SessionId { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public int SessionCountsPerDate { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
