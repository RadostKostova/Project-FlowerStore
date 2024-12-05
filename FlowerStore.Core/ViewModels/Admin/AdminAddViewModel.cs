using System.ComponentModel.DataAnnotations;

namespace FlowerStore.Core.ViewModels.Admin
{
    public class AdminAddViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
