using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWAPIFilmRatingsBLL.DLL;
using SWAPIFilmRatingsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWAPIFilmRatingsSite.Controllers
{
    public class MoviesController : Controller
    {
        private readonly SWAPIFilmRatingsDbContext _context;

        public MoviesController(SWAPIFilmRatingsDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<MovieViewModel> movies = (await _context.Movies.ToListAsync()).Select(x => new MovieViewModel(x)).ToList();
            return View(model: movies);
        }

        [HttpPost]
        public  IActionResult Save(int id, string rating)
        {
            Movie movieToUpdate = _context.Movies.Find(id);
            if (movieToUpdate == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (!int.TryParse(rating, out int newRating))
                    {
                        throw new ArgumentException("Rating is not a proper number");
                    }
                    movieToUpdate.Rating = newRating;
                    _context.Update(movieToUpdate);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            return RedirectToAction("Index", "Movies");
        }

        

        public IActionResult Edit(int id, [Bind("Id,Director,EpisodeId,OpeningCrawl,Title,ReleaseDate,Rating")] MovieViewModel movie)
        {
            return View(movie);
        }
    }
}
