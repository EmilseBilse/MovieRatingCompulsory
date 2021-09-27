using MovieRating.Core.IService;
using MovieRating.Domain.Service;
using MovieRating.Infrastucture;
using Xunit;
namespace MovieReviewTest
{
    public class ServiceTest
    {
        private ReviewRepository rr;
        private IReviewService rs;

        public ServiceTest()
        {
            rr = new ReviewRepository("MOCK.json");
            rs = new ReviewService(rr);
        }

        [Fact]
        public void TestAmountOfReviewsFromReviewer()
        {
            //ratings: expected=547 | reviewer=1
            int expectedResult = 10;
            int wantedReviewer = 1;
            int amount = rs.GetNumberOfReviewsFromReviewer(wantedReviewer);
            Assert.Equal(expectedResult, amount);
        }

        [Fact]
        public void TestAverageRatingFromReviewer()
        {
            //ratings: expected=??? | reviewer=1
            int wantedViewer = 2;
            double expectedResult = 3.1;
            double result = rs.GetAverageRateFromReviewer(wantedViewer);
            Assert.Equal(expectedResult, result);
        }
    }
}