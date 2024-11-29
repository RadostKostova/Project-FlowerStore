using FlowerStore.Core.Contracts;
using FlowerStore.Core.Services;
using FlowerStore.Core.ViewModels.Product;
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
            await reviewService.AddReviewAsync(model);

            return RedirectToAction(nameof(All));
        }
    }
}
