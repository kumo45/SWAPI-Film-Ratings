using SWAPIFilmRatingsBLL.Helpers;
using System.Linq;

namespace SWAPIFilmRatingsBLL.DLL
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ISWAPICSharpHelper apiHelper;

        public DbInitializer(ISWAPICSharpHelper swAPICSharpHelper)
        {
            apiHelper = swAPICSharpHelper;
        }
        public void Initialize(SWAPIFilmRatingsDbContext context)
        {
            context.Database.EnsureCreated();

            if(!apiHelper.CheckAPIAvilability())
            {
                throw new System.Exception("API was not available to get data.");
            }

            if (context.Movies.Any())
            {
                return;
            }

            context.Movies.AddRange(apiHelper.GetMoviesFromAPI());
            context.SaveChanges();
        }
    }
}
