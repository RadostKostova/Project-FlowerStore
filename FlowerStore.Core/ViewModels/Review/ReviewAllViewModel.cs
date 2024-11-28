namespace FlowerStore.Core.ViewModels.Review
{
    /// <summary>
    /// Displays all reviews of the users
    /// </summary>
    public class ReviewAllViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public string CreatedAt { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;
    }
}
