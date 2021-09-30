using System;
using System.Collections.Generic;
using System.Linq;
using MovieRating.Core.IService;
using MovieRating.Core.Model;
using MovieRating.Domain.IRepositories;

namespace MovieRating.Domain.Service
{
    public class ReviewService : IReviewService
    {
        private IReviewRepository rp;
        private List<MovieReview> _list = new List<MovieReview>();

        public ReviewService(IReviewRepository Irp)
        {
            rp = Irp;
            _list = rp.FindAll();
        }

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            int i = 0;
            foreach (MovieReview mr in _list)
            {
                if (mr.Reviewer == reviewer)
                    i++;
            }

            return i;
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            double total = 0;
            double ratings = 0;
            foreach (MovieReview mr in _list)
            {
                if (mr.Reviewer == reviewer)
                {
                    total += mr.Grade;
                    ratings++;
                }
            }

            if (ratings == 0)
                return -1;

            // ReSharper disable once PossibleLossOfFraction
            double returnValue = total / ratings;
            return returnValue;
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            int i = 0;
            foreach (MovieReview review in _list)
            {
                if (reviewer == review.Reviewer && rate == review.Grade)
                {
                    i++;
                }
            }

            return i;
        }

        public int GetNumberOfReviews(int movie)
        {
            int count = 0;
            foreach (MovieReview m in rp.FindAll())
            {
                if (m.Movie == movie)
                    count++;
            }

            return count;
        }

        public double GetAverageRateOfMovie(int movie)
        {
            double rating = -1;
            List<double> rates = new List<double>();
            foreach (MovieReview m in rp.FindAll())
            {
                if (m.Movie == movie)
                {
                    rates.Add(m.Grade);
                }
            }

            rates.ForEach(i =>
            {
                if (rating == -1)
                {
                    rating = i;
                }
                else
                {
                    rating += i;
                }
            });
            return (rating/rates.Count);
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            int count = 0;
            foreach (MovieReview m in rp.FindAll())
            {
                if (m.Movie == movie && m.Grade == rate)
                    count++;
            }

            return count;
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            List<int> movies = new List<int>();
            foreach (var movieReview in _list)
            {
                if (movieReview.Grade == 5)
                {
                    movies.Add(movieReview.Movie);
                }
            }

            return movies.Distinct().ToList();
        }

        public List<int> GetMostProductiveReviewers()
        {
            List<int> reviewers = new List<int>();
            int most = 0;
            foreach (MovieReview movieReview in _list)
            {
                reviewers.Add(movieReview.Reviewer);
            }
            reviewers.Sort();
            reviewers.Reverse();
            return reviewers.Distinct().ToList();
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            return null;
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            return null;
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            return null;
        }
    }
}