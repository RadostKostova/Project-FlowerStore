using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Review;
using FlowerStore.Infrastructure.Common;
using FlowerStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerStore.Core.Services
{
    /// <summary>
    /// Service for managing reviews of authenticated-users only
    /// </summary>
    public class ReviewService : IReviewService
    {
        private readonly IRepository repository;

        public ReviewService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<ReviewAllViewModel>> GetAllReviewsAsync()
        {
            var reviews = await repository
                .AllAsReadOnly<Review>()
                .Include(r => r.User)
                .OrderByDescending(r => r.CreatedAt) // Most recent first
                .Select(r => new ReviewAllViewModel
                {
                    Id = r.Id,
                    Content = r.Content,
                    CreatedAt = r.CreatedAt.ToString("dd-MM-yyyy HH:mm"),
                    UserName = r.User.UserName
                })
                .ToListAsync();
            
            return reviews;
        }
    }
}
