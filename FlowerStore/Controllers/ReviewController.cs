using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Review;
using FlowerStore.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Controllers
{
    /// <summary>
    /// This controller handles operation related to user reviews. Only authenticated users will be able to post a review.
    /// </summary>

    public class ReviewController : BaseController
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService _reviewService)
        {
            reviewService = _reviewService;
        }

        //Show all reviews
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var reviews = await reviewService.GetAllReviewsAsync();
            return View(reviews);
        }

        //Get review form
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ReviewAddViewModel()
            {
                UserId = User.GetUserId(),
                UserName = User.Identity!.Name!.ToString()
            };

            return View(model);
        }

        //Add review
        [HttpPost]
        public async Task<IActionResult> Add(ReviewAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.CreatedAt = DateTime.UtcNow;
            var modelId = await reviewService.AddReviewAsync(model);

            return RedirectToAction(nameof(All));
        }

        //Get edit form
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = User.GetUserId();
            var user = User.Identity!.Name!.ToString();

            var review = await reviewService.GetReviewForEditAsync(id, userId, user);

            if (review == null || review.UserId != userId)
            {
                return Unauthorized();
            }

            return View(review);
        }

        //Edit review
        [HttpPost]
        public async Task<IActionResult> Edit(ReviewEditViewModel model)
        {
            var userId = User.GetUserId();

            if (!ModelState.IsValid)
            {
                model.UserId = userId; //Reassigned for more security/correctness
                model.UserName = User.Identity!.Name!;
                return View(model);
            }

            var review = await reviewService.ReviewByIdExistAsync(model.Id);

            if (review == null || review.UserId != userId)
            {
                return Unauthorized();
            }

            await reviewService.PostEditReviewAsync(model);
            return RedirectToAction(nameof(All));
        }

        //Get delete view
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var review = await reviewService.ReviewByIdExistAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            if (review.UserId != User.GetUserId())
            {
                return Unauthorized();
            }

            var reviewFound = await reviewService.DeleteReviewAsync(review.Id, review.UserId);
            return View(reviewFound);
        }

        //Delete review from database
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(ReviewDeleteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var review = await reviewService.ReviewByIdExistAsync(model.Id);

            if (review == null)
            {
                return BadRequest();
            }

            await reviewService.ConfirmDeleteAsync(review.Id);
            return RedirectToAction(nameof(All));
        }
    }
}
