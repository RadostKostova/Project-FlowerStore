using FlowerStore.Core.ViewModels.Review;
using FlowerStore.Infrastructure.Data.Models;

namespace FlowerStore.Core.Contracts
{
    /// <summary>
    /// Interface for review managing
    /// </summary>
    public interface IReviewService
    {
        Task<Review> ReviewByIdExistAsync(int reviewId);
        Task<IEnumerable<ReviewAllViewModel>> GetAllReviewsAsync();
        Task<int> AddReviewAsync(ReviewAddViewModel model);
        Task<ReviewDeleteViewModel> DeleteReviewAsync(int reviewId, string userId);
        Task<int> ConfirmDeleteAsync(int reviewId);

    }
}
