using FlowerStore.Core.ViewModels.Review;

namespace FlowerStore.Core.Contracts
{
    /// <summary>
    /// Interface for review managing
    /// </summary>
    public interface IReviewService
    {
        Task<IEnumerable<ReviewAllViewModel>> GetAllReviewsAsync();
    }
}
