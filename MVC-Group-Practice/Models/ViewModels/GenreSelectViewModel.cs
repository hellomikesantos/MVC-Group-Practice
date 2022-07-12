using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_Group_Practice.Models.ViewModels
{
    public class GenreSelectViewModel
    {
        public List<SelectListItem> GenreSelectItems { get; set; } = new List<SelectListItem>();
        public List<Movie> MovieList { get; set; } 
        public GenreSelectViewModel(List<Genre> genres)
        {
            genres.ForEach(genre =>
            {
                GenreSelectItems.Add(new SelectListItem(genre.Name, genre.Id.ToString()));
            });
        }
    }
}
