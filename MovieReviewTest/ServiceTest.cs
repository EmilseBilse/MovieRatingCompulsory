using System.Collections.Generic;
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

        [Fact]
        public void TestAverageRateOnMovie()
        {
            int wantedMovie = 4;
            double exptecedResult = 3.25;
            double result = rs.GetAverageRateOfMovie(wantedMovie);
            Assert.Equal(exptecedResult,result);
        }

        [Fact]
        public void TestNumberOfReviews()
        {
            int movie = 1;
            int expectedNumberOfReviews = 4;
            int actualNumberOfReviews = rs.GetNumberOfReviews(movie);
            Assert.Equal(expectedNumberOfReviews,actualNumberOfReviews);
        }

        [Fact]
        public void TestGetNumberOfRates()
        {
            int movie = 1;
            int rate = 4;
            int expected = 2;
            int actual = rs.GetNumberOfRates(movie, rate);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetNumberOfRatesByReviewer()
        {
            int reviewer = 5;
            int rate = 4;
            int expected = 3;
            int actual = rs.GetNumberOfRatesByReviewer(reviewer,rate);
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void TestGetMoviesWithHighestNumberOfTopRates()
        {
            List<int> actual = rs.GetMoviesWithHighestNumberOfTopRates();
            List<int> expected = new List<int>() {9, 12,18,5,4,6};
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void TestGetMostProductiveReviewers()
        {
            List<int> actual = rs.GetMostProductiveReviewers();
            List<int> expected = new List<int>() { };
        }
    }
}