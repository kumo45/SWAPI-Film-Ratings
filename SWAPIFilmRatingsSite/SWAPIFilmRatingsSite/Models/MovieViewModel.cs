using Microsoft.AspNetCore.Mvc.Rendering;
using SWAPIFilmRatingsBLL.DLL;
using System.Collections.Generic;
using System.Linq;

namespace SWAPIFilmRatingsSite.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Director { get; set; }
        public string EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Rating { get; set; }
        public List<SelectListItem> Ratings;

        public MovieViewModel()
        {
            Ratings = CreateRatings();
        }

        public MovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Director = movie.Director;
            EpisodeId = movie.EpisodeId;
            OpeningCrawl = movie.OpeningCrawl;
            Title = movie.Title;
            ReleaseDate = movie.ReleaseDate;
            Rating = movie.Rating.ToString();
            Ratings = CreateRatings();
        }

        private List<SelectListItem> CreateRatings()
        {
            int[] ratings = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            return ratings.Select(x => new SelectListItem
            {
                Selected = (x.ToString().Equals(Rating)),
                Text = x.ToString(),
                Value = x.ToString()
            }).ToList();
        }
    }
}
