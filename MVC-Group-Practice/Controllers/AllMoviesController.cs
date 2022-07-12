using Microsoft.AspNetCore.Mvc;
using MVC_Group_Practice.Models;
using MVC_Group_Practice.Models.ViewModels;

namespace MVC_Group_Practice.Controllers
{
    public class AllMoviesController : Controller
    {
        private MovieDatabaseContext _dbContext;
        public AllMoviesController(MovieDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index() { 
     
            GenreSelectViewModel genreselect = new GenreSelectViewModel(_dbContext.Genres.ToList());
            return View(genreselect);
        }

        public IActionResult AllMovies(int? genreId) 
        { 
            if( genreId != null)
            {
                try
                {
                    List<Movie> movies = new List<Movie>();
                    foreach (MovieGenre moviegenre in _dbContext.MovieGenres)
                    {
                        if(moviegenre.Genre.Id == genreId)
                        {
                            movies.Add(moviegenre.Movie);
                        }
                    }
                    return View(movies);
                }
                catch
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
