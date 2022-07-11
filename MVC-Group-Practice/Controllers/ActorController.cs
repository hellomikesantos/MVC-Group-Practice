using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Group_Practice.Models;

namespace MVC_Group_Practice.Controllers
{
    public class ActorController : Controller
    {
        private MovieDatabaseContext _context;

        public ActorController(MovieDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Actor> actors = _context.Actors.ToList();
            return View(actors);
        }
    }
}
