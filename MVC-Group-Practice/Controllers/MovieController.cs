using Microsoft.AspNetCore.Mvc;
using MVC_Group_Practice.Models;

namespace MVC_Group_Practice.Controllers
{
    public class MovieController : Controller
    {
        private MovieDatabaseContext _context;

        public MovieController(MovieDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index(int actorId)
        {
            List<MovieActor> movieActors = _context.MovieActors.Where((e) => e.ActorId == actorId).ToList();
            List<int?> movieIds = movieActors.Select((d) => d.MovieId).ToList();
            List<Movie> movies = _context.Movies.Where((movie) => movieIds.Contains(movie.Id)).ToList();
            return View(movies);
        }
    }
}
