using SkillsShowcase.Shared.Domain.Models;
using System.Threading.Tasks;

namespace SkillsShowcase.Shared.Domain.Data
{
    public class Secrets
    {
        public static GoogleLoginSecrets GetLoginSecrets { get; set; } = new GoogleLoginSecrets();
        public static async Task LoadAsync()
        {
            SetInternalApiClientSecrets();
        }
        private static void SetInternalApiClientSecrets()
        {
            GetLoginSecrets = new GoogleLoginSecrets()
            {
                ClientId = "736251455348-hfa16o54esp4p94goln37ugqj36f9rc3.apps.googleusercontent.com",
                ClientSecret = "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"
            };
        }
    }
}
