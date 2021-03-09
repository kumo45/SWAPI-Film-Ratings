using StarWarsApiCSharp;
using SWAPIFilmRatingsBLL.DLL;
using System.Collections.Generic;

namespace SWAPIFilmRatingsBLL.Helpers
{
    public class SWAPICSharpHelper : ISWAPICSharpHelper
    {
        public bool CheckAPIAvilability()
        {
            try
            {
                Repository<Film> filmRepository = new Repository<Film>();

                filmRepository.GetEntities();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Movie> GetMoviesFromAPI()
        {
            List<Movie> movies = new List<Movie>();
            Repository<Film> filmRepository = new Repository<Film>();

            foreach(Film film in filmRepository.GetEntities())
            {
                movies.Add(new Movie(film));
            }

            return movies;
        }
    }
}
