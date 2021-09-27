using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using MovieRating.Core.Model;
using MovieRating.Domain.IRepositories;
using Newtonsoft.Json;

namespace MovieRating.Infrastucture
{
    public class ReviewRepository : IReviewRepository
    {
        private string _fileName;

        private static List<MovieReview> _list;

        public ReviewRepository(string fileName = "ratings.json")
        {
            _fileName = fileName;
            _list = new List<MovieReview>();
            initData();
        }

        private void initData()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.DateFormatString = "yyy-MM-dd";

            string line = "";

            using (StreamReader sr = new StreamReader(_fileName))
            {
                while ((line = sr.ReadLine()?.Trim()) != null)
                {
                    line = line.Substring(0, line.Length - 1);
                    _list.Add(JsonConvert.DeserializeObject<MovieReview>(line, settings));
                }
            }
        }

        public List<MovieReview> FindAll()
        {
            if (_list.Count == 0)
                initData();
            return _list;
        }
    }
}