using Microsoft.EntityFrameworkCore.Infrastructure;
using SWAPIFilmRatingsBLL.DLL;

namespace SWAPIFilmRatingsBLLTests.FakeDB
{
    /// <summary>
    /// this is just a stub to be extended to fake it better - I know it's messy but itwas first time I looked into mocking EF ;)
    /// </summary>
    internal class FakeDatabaseFacade : DatabaseFacade
    {
        public FakeDatabaseFacade() : base(new SWAPIFilmRatingsDbContext())
        {
        }

        public override bool EnsureCreated()
        {
            return true;
        }
    }
}
