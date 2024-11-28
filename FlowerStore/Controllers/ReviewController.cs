using FlowerStore.Core.Contracts;
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
        public async Task<IActionResult> All()
        {
            var reviews = await reviewService.GetAllReviewsAsync();
            return View();
        }

        //Add review
        public async Task<IActionResult> Add()
        {
            //var reviews = await reviewService.GetAllReviewsAsync();
            return View();
        }
    }
}
