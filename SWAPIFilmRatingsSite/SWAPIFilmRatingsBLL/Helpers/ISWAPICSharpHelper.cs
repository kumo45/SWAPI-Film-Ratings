using SWAPIFilmRatingsBLL.DLL;
using System.Collections.Generic;

namespace SWAPIFilmRatingsBLL.Helpers
{
    public interface ISWAPICSharpHelper
    {
        List<Movie> GetMoviesFromAPI();
        bool CheckAPIAvilability();
    }
}