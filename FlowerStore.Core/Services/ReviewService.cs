using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Product;
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

        //Get all reviews
        public async Task<IEnumerable<ReviewAllViewModel>> GetAllReviewsAsync()
        {
            var reviews = await repository
                .AllAsReadOnly<Review>()
                .Include(r => r.User)
                .OrderByDescending(r => r.CreatedAt)
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

        //Add review to database
        public async Task<int> AddReviewAsync(ReviewAddViewModel model)
        {
            var review = new Review
            {
                UserId = model.UserId,
                Content = model.Content,
                CreatedAt = model.CreatedAt
            };

            await repository.AddAsync(review);
            await repository.SaveChangesAsync();
            return review.Id;
        }
    }
}
