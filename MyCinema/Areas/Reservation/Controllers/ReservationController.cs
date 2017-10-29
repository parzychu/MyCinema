using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace MyCinema.Areas.Reservation.Controllers
{
    public class ReservationController : Controller
    {
        public class SeanceDTO
        {
            public string hour { get; set; }
            public string id { get; set; }
        }

        public class ReservationDaysDTO
        {
            public string day { get; set; }
            public IList<SeanceDTO> seances { get; set; }
        }

        // GET: Reservation/Reservation
        public ActionResult GetCinemas()
        {
            MyCinemaDBEntities2 context = new MyCinemaDBEntities2();
            
            var cinemaList = context.Cinemas
                .Select(cinema => new
                {
                    name=cinema.Name,
                    phone=cinema.Telephone,
                    id=cinema.Id
                })
                .ToList();

            return Json(cinemaList);
        }

        public ActionResult GetMovies()
        {
            MyCinemaDBEntities2 context = new MyCinemaDBEntities2();

            var movieList = context.Seances.GroupBy(seance => seance.MovieId).Select(seance => new
                {
                    name=seance.FirstOrDefault().Movie.Title,
                    id=seance.FirstOrDefault().Movie.Id,
                })
                .ToList();

            return Json(movieList);
        }

        public ActionResult GetDates()
        {
            MyCinemaDBEntities2 context = new MyCinemaDBEntities2();

            var dateList = context.Seances.Where(seance => seance.CinemaId == 7).GroupBy(seance => seance.Date).Select(date =>
                new 
                {
                    date=date.Key.ToString(),
                    seances=date.Select(seance => new
                    {
                        time = seance.Time,
                        id = seance.Id
                    })
                }
            ).ToList();
            

            return Json(dateList);
        }
    }
}