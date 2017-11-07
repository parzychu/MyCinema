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
            
            var cinemaList = context.Seances
                .Where(seance => seance.MovieId == 4)
                .Join(context.Cinemas, s => s.CinemaId, c => c.Id, (s, c) => c)
                .Select(cinema => new
                {
                    name=cinema.Name,
                    phone=cinema.Telephone,
                    id=cinema.Id
                })
                .Distinct()
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
                    directorName=seance.FirstOrDefault().Movie.DirectorName,
                    runningTime=seance.FirstOrDefault().Movie.RunningTime,
                })
                .ToList();

            return Json(movieList);
        }

        public ActionResult GetDates(int cinemaId)
        {
            MyCinemaDBEntities2 context = new MyCinemaDBEntities2();

            var dateList = context.Seances.Where(seance => seance.CinemaId == cinemaId).GroupBy(seance => seance.Date).Select(date =>
                new 
                {
                    date=date.Key.ToString(),
                    seances=date.Select(seance => new
                    {
                        hour = seance.Time,
                        id = seance.Id
                    })
                }
            ).ToList();
            

            return Json(dateList);
        }
    }
}