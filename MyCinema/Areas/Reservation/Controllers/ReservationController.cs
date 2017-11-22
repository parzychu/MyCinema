using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using WebGrease.Css.Extensions;

namespace MyCinema.Areas.Reservation.Controllers
{
    public class ReservationInfo
    {
        public int seanceId { get; set; }
        public int[] seatIds { get; set; }
    }

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
            MyCinemaDB context = new MyCinemaDB();
            
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
            MyCinemaDB context = new MyCinemaDB();

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
            MyCinemaDB context = new MyCinemaDB();

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

        public ActionResult CreateReservation(ReservationInfo info)
        {
            var reservation = new Models.Reservation();

            reservation.SeanceId = info.seanceId;

            using (var db = new MyCinemaDB())
            {
                db.Reservations.Add(reservation);

//               var seats = db.Seats
//                    .Where(seat => reservation.SeanceId == info.seanceId && info.seatIds.Contains(seat.Id))
//                    .Select(seat =>
//                    {
//                        id:  seat.Id
//                    }).ToList();
                db.SaveChanges();
            }

            return Json(reservation.Id);
        }

        public ActionResult SeatsInSeance()
        {
            using (var db = new MyCinemaDB())
            {
                var seatsInSeance = db.Seances
                    .Where(s => s.Id == 3)
                    .SelectMany(s => s.SeatsSeances
                    .Select(seats => seats.SeatId))
                    .ToList();

                return Json(seatsInSeance);
            }

        }

        public ActionResult Confirm(ReservationInfo data)
        {
            var reservationId = 4;

            using (var db = new MyCinemaDB())
            {
                db.Reservations
                    .Where(r => r.Id == reservationId)
                    .ForEach(r => r.UserId = User.Identity.GetUserId());

                var seances = db.Reservations.Where(r => r.Id == reservationId)
                    .Select(r => r.Seance.SeatsSeances.Where(seatSeance => seatSeance.SeanceId == r.Seance.Id))
                    .ToList();

                seances.ForEach(s => s.ForEach(
                    seatSeance =>
                    {
                        seatSeance.ReservationId = reservationId;
                        seatSeance.IsAvaliable = false;
                    }));
                db.SaveChanges();

                return new HttpStatusCodeResult(200);
            }
        }
    }
}