using StarWarsApiCSharp;

namespace SWAPIFilmRatingsBLL.DLL
{
    /// <summary>
    /// Our representation of movie - to simplify whole process it is derived from Nuget package library.
    /// In proper implementation I would generate client myself using e.g. Swagger - it would help
    /// with references to other entities which here are just links with API queries.
    /// </summary>
    public class Movie
    {
        public int Id { get; set; }
        public string Director { get; set; }
        public string EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public int Rating { get; set; }

        public Movie()
        {
        }

        public Movie(Film film)
        {
            Director = film.Director;
            EpisodeId = film.EpisodeId;
            OpeningCrawl = film.OpeningCrawl;
            Title = film.Title;
            ReleaseDate = film.ReleaseDate;
        }
    }
}
