using FlowerStore.Core.Contracts;
using FlowerStore.Core.Services;
using FlowerStore.Core.ViewModels.Review;
using FlowerStore.Infrastructure.Common;
using FlowerStore.Infrastructure.Data;
using FlowerStore.Infrastructure.Data.Models;
using FlowerStore.Infrastructure.Data.Models.Roles;
using Microsoft.EntityFrameworkCore;

namespace FlowerStore.Tests.UnitTests
{
    [TestFixture]
    internal class ReviewServiceTests
    {
        //Depencendies
        private FlowerStoreDbContext dbContext;
        private IRepository repository;
        private IReviewService reviewService;

        //Collections
        private IEnumerable<ApplicationUser> users;
        private IEnumerable<Review> reviews;

        //Users
        private ApplicationUser firstUser;
        private ApplicationUser secondUser;

        //Reviews
        private Review firstReview;
        private Review secondReview;
        private Review thirdReview;

        [SetUp]
        public async Task Setup()
        {
            firstUser = new ApplicationUser
            {
                Id = "firstUserId",
                UserName = "firstuser@firstuser.com",
                NormalizedUserName = "FIRSTUSER@FIRSTUSER.COM",
                Email = "firstuser@firstuser.com",
                NormalizedEmail = "FIRSTUSER@FIRSTUSER.COM",
                FirstName = "First",
                LastName = "User",
                PhoneNumber = "1234567890"
            };

            secondUser = new ApplicationUser
            {
                Id = "secondUserId",
                UserName = "seconduser@seconduser.com",
                NormalizedUserName = "SECONDUSER@SECONDUSER.COM",
                Email = "seconduser@seconduser.com",
                NormalizedEmail = "SECONDUSER@SECONDUSER.COM",
                FirstName = "Second",
                LastName = "User",
                PhoneNumber = "1234567800"
            };

            firstReview = new Review
            {
                Id = 1,
                CreatedAt = DateTime.UtcNow.AddDays(-2),
                UserId = firstUser.Id,
                Content = "Awesome products! Definitely will buy again!"
            };

            secondReview = new Review
            {
                Id = 2,
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                UserId = secondUser.Id,
                Content = "The flowers are long-lasting, very beautiful and at reasonable prices!"
            };

            thirdReview = new Review
            {
                Id = 3,
                CreatedAt = DateTime.UtcNow,
                UserId = firstUser.Id,
                Content = "Amazing!"
            };

            users = new List<ApplicationUser>() { firstUser, secondUser };
            reviews = new List<Review>() { firstReview, secondReview, thirdReview }.OrderByDescending(r => r.CreatedAt);

            //Configuration of in-memory db
            var dbOptions = new DbContextOptionsBuilder<FlowerStoreDbContext>()
               .UseInMemoryDatabase("FlowerStoreTestDb" + Guid.NewGuid().ToString())
               .Options;

            dbContext = new FlowerStoreDbContext(dbOptions);

            //Seed data
            await dbContext.AddRangeAsync(users);
            await dbContext.AddRangeAsync(reviews);
            await dbContext.SaveChangesAsync();

            //Repository initialization
            repository = new Repository(dbContext);

            //ReviewService initialization
            reviewService = new ReviewService(repository);
        }

        //Clean db after each test
        [TearDown]
        public async Task Teardown()
        {
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.DisposeAsync();
        }

        //ReviewByIdExistAsync tests
        [Test]
        public async Task ReviewByIdExistAsync_WhenReviewExists_ReturnsProperReview()
        {
            var result = await reviewService.ReviewByIdExistAsync(1);
            var resultSecond = await reviewService.ReviewByIdExistAsync(2);

            Assert.Multiple(() =>  //first review
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(firstReview.Id));
                Assert.That(result.Content, Is.EqualTo(firstReview.Content));
                Assert.That(result.UserId, Is.EqualTo(firstReview.UserId));
            });

            Assert.Multiple(() => //second review
            {
                Assert.That(resultSecond, Is.Not.Null);
                Assert.That(resultSecond.Id, Is.EqualTo(secondReview.Id));
                Assert.That(resultSecond.Content, Is.EqualTo(secondReview.Content));
                Assert.That(resultSecond.UserId, Is.EqualTo(secondReview.UserId));
            });
        }

        [Test]
        public async Task ReviewByIdExistAsync_WhenReviewDoesNotExist_ReturnsNull()
        {
            var result = await reviewService.ReviewByIdExistAsync(674);
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task ReviewByIdExistAsync_WhenReviewIdIsZero_ReturnsNull()
        {
            var result = await reviewService.ReviewByIdExistAsync(0);
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task ReviewByIdExistAsync_WhenIdIsNegative_ReturnsNull()
        {
            var result = await reviewService.ReviewByIdExistAsync(-100);
            Assert.That(result, Is.Null);
        }

        //GetAllReviewsAsync tests
        [Test]
        public async Task GetAllReviewsAsync_WhenReviewsExist_ReturnsAllReviews()
        {
            var result = await reviewService.GetAllReviewsAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(3));

            var resultList = result.ToList();

            Assert.Multiple(() =>
            {
                Assert.That(resultList[0].Content, Is.EqualTo(thirdReview.Content));
                Assert.That(resultList[1].UserName, Is.EqualTo(secondUser.UserName));
                Assert.That(resultList[2].CreatedAt, Is.EqualTo(firstReview.CreatedAt.ToString("dd-MM-yyyy HH:mm")));
            });
        }

        [Test]
        public async Task GetAllReviewsAsync_WhenNoReviewsExist_ReturnsEmptyCollection()
        {
            await dbContext.Database.EnsureDeletedAsync(); // Clear db

            var result = await reviewService.GetAllReviewsAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Empty);
        }

        //AddReviewAsync tests (invalid data is handled outside the service)
        [Test]
        public async Task AddReviewAsync_WhenValidViewModelIsProvided_AddsReviewAndReturnsId()
        {
            var model = new ReviewAddViewModel
            {
                UserId = secondUser.Id,
                Content = "This is new test review.",
                CreatedAt = DateTime.UtcNow
            };

            var modelId = await reviewService.AddReviewAsync(model);
            var newReview = await dbContext.Reviews.FirstOrDefaultAsync(r => r.Id == modelId);

            Assert.That(newReview, Is.Not.Null);
            Assert.That(newReview.Id, Is.EqualTo(modelId));
            Assert.That(newReview.UserId, Is.EqualTo(model.UserId));
            Assert.That(newReview.Content, Is.EqualTo(model.Content));
            Assert.That(newReview.CreatedAt, Is.EqualTo(model.CreatedAt));
        }

        [Test]
        public void AddReviewAsync_WhenInValidViewModelIsProvided_DoesNothing()
        {
            var model = new ReviewAddViewModel
            {
                UserId = null!,
                Content = null!,
                CreatedAt = DateTime.UtcNow
            };

            Assert.ThrowsAsync<DbUpdateException>(async () => await reviewService.AddReviewAsync(model));
        }


        //GetReviewForEditAsync tests
        [Test]
        public async Task GetReviewForEditAsync_WhenReviewExistsWithItsUser_ReturnsCorrectViewModel()
        {
            var result = await reviewService.GetReviewForEditAsync(firstReview.Id, firstUser.Id, "firstuser@firstuser.com");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(firstReview.Id));
            Assert.That(result.Content, Is.EqualTo(firstReview.Content));
            Assert.That(result.UserId, Is.EqualTo(firstUser.Id));
            Assert.That(result.UserName, Is.EqualTo("firstuser@firstuser.com"));
        }

        [Test]
        public void GetReviewForEditAsync_WhenReviewDoesNotExist_ThrowsNullException()
        {
            Assert.ThrowsAsync<NullReferenceException>(async () =>
                await reviewService.GetReviewForEditAsync(999, "noexistingId", "noexisting@user.com"));
        }

        [Test]
        public void GetReviewForEditAsync_WhenReviewExistsButWithDifferentUser_ThrowsUnauthorized()
        {
            Assert.ThrowsAsync<NullReferenceException>(async () =>
                await reviewService.GetReviewForEditAsync(firstReview.Id, secondUser.Id, secondUser.UserName));
        }

        //PostEditReviewAsync Tests
        [Test]
        public async Task PostEditReviewAsync_WhenViewModelIsValid_EditReviewProperly()
        {
            var model = new ReviewEditViewModel
            {
                Id = firstReview.Id,
                Content = "Test Content",
                UserId = firstReview.UserId,
                UserName = "firstuser@firstuser.com"
            };

            var result = await reviewService.PostEditReviewAsync(model);
            var editedReview = await dbContext.Reviews.FirstOrDefaultAsync(r => r.Id == firstReview.Id);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(editedReview, Is.Not.Null);
                Assert.That(editedReview!.Id, Is.EqualTo(result.Id));
                Assert.That(editedReview.UserId, Is.EqualTo(result.UserId));
                Assert.That(editedReview.Content, Is.EqualTo(result.Content));
                Assert.That(editedReview.User.UserName, Is.EqualTo(result.UserName));
            });
        }

        [Test]
        public void PostEditReviewAsync_WhenViewModelIsInvalid_ThrowsNullException()
        {
            var model = new ReviewEditViewModel //does not exist
            {
                Id = 999,
                Content = "Test Content",
                UserId = firstUser.Id,
                UserName = "nonexistent@user.com"
            };

            Assert.ThrowsAsync<NullReferenceException>(async () => await reviewService.PostEditReviewAsync(model));
        }

        //DeleteReviewAsync tests
        [Test]
        public async Task DeleteReviewAsync_WhenViewModelIsValid_ReturnsReviewProperly()
        {
            var result = await reviewService.DeleteReviewAsync(secondReview.Id, secondReview.UserId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(secondReview.Id));
            Assert.That(result.Content, Is.EqualTo(secondReview.Content));
        }

        [Test]
        public void DeleteReviewAsync_WhenReviewDoesNotExist_ThrowsNullException()
        {
            Assert.ThrowsAsync<NullReferenceException>(async () =>
                await reviewService.DeleteReviewAsync(999, firstUser.Id));
        }

        [Test]
        public void DeleteReviewAsync_WhenReviewDoesNotBelongToUser_ThrowsNullException()
        {
            Assert.ThrowsAsync<NullReferenceException>(async () =>
                await reviewService.DeleteReviewAsync(thirdReview.Id, secondUser.Id));
        }

        //ConfirmDeleteAsync Tests
        [Test]
        public async Task ConfirmDeleteAsync_WhenReviewExists_RemovesReviewProperly()
        {
            var result = await reviewService.ConfirmDeleteAsync(firstReview.Id);
            var deletedReview = await dbContext.Reviews.FirstOrDefaultAsync(r => r.Id == firstReview.Id);

            Assert.That(result, Is.EqualTo(firstReview.Id));
            Assert.That(deletedReview, Is.Null);
        }

        [Test]
        public void ConfirmDeleteAsync_WhenReviewIdIsInvalid_ThrowsInvalidOpException()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async () => await reviewService.ConfirmDeleteAsync(355));
        }
    }
}
