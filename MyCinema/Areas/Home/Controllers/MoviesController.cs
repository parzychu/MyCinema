using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCinema.Areas.Home.Controllers
{
    public interface MovieDTO
    {
        string Title { get; set; }
        int Id { get; set; }
        string Duration { get; set; }
    }

    public class Movie
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public string Duration { get; set; }

        public Movie(int id, string title, string duration)
        {
            this.Title = title;
            this.Id = id;
            this.Duration = duration;
        }
    }

    public class MoviesController : Controller
    {

        // GET: Home/Movies
        public ActionResult CurrentlyPlaying()
        {
            var x = this.getCurrentlyPlayingMovies();

           

            return Json(x, JsonRequestBehavior.AllowGet);
        }

        public List<Object> getCurrentlyPlayingMovies()
        {
            Movie[] CurrentMovies = new []
            {
                new Movie(1, "Transformers", "25m"),
                new Movie(1, "Winnie The Pooh", "45m"),
                new Movie(1, "Shansa", "3m"),
                new Movie(1, "Shansa", "3m"),
                new Movie(1, "Shansa", "3m"),
                new Movie(1, "Shansa", "3m"),
                new Movie(1, "Shansa", "3m")
            };

            List<Object> result = new List<object>();
            foreach (Movie movie in CurrentMovies)
            {
                result.Add(
                    new
                    {
                        Title = movie.Title,
                        Id = movie.Id,
                        Duration = movie.Duration
                    });
            }

            return result;
        }
    }
}