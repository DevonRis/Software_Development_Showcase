using System;

namespace SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall
{
    public class SessionLogsForApiCall
    {
        public Guid SessionId { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public int SessionCountsPerDate { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
