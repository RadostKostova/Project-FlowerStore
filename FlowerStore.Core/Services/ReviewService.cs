﻿using FlowerStore.Core.Contracts;
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

        //Check if review exist by id and returns it
        public async Task<Review> ReviewByIdExistAsync(int reviewId)
        {
            var reviewFound = await repository
                .AllAsReadOnly<Review>()
                .FirstOrDefaultAsync(r => r.Id == reviewId);

            return reviewFound;
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

        //Get edit form of review and return viewModel
        public async Task<ReviewEditViewModel> GetReviewForEditAsync(int reviewId, string userId, string username)
        {
            var review = await repository
                .AllAsReadOnly<Review>()
                .Include(r => r.User)
                .Where(r => r.Id == reviewId && r.UserId == userId)
                .FirstOrDefaultAsync();

            return new ReviewEditViewModel
            {
                Id = review.Id,
                Content = review.Content,
                UserId = review.UserId,
                UserName = username
            };
        }

        //Edit the review in the database
        public async Task<ReviewEditViewModel> PostEditReviewAsync(ReviewEditViewModel model)
        {
            var review = await repository
                .All<Review>()
                .Where(r => r.Id == model.Id)
                .FirstOrDefaultAsync();

            review.Content = model.Content;

            await repository.SaveChangesAsync();
            return model;
        }

        //Get review delete viewModel
        public async Task<ReviewDeleteViewModel> DeleteReviewAsync(int reviewId, string userId)
        {
            var review = await repository
                .AllAsReadOnly<Review>()
                .Where(r => r.Id == reviewId && r.UserId == userId)
                .FirstOrDefaultAsync();

            var model = new ReviewDeleteViewModel()
            {
                Id = review.Id,
                Content = review.Content
            };

            return model;
        }

        //Confirm deletion of review
        public async Task<int> ConfirmDeleteAsync(int reviewId)
        {
            var review = await repository
                .All<Review>()
                .Where(r => r.Id == reviewId)
                .FirstOrDefaultAsync();

            if (review == null)
            {
                throw new InvalidOperationException("Not found");
            }

            await repository.RemoveAsync(review);
            await repository.SaveChangesAsync();
            return review.Id;
        }
    }
}
