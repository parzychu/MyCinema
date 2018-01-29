using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Bogus;
using Bogus.DataSets;
using FizzWare.NBuilder;
using FizzWare.NBuilder.Dates;
using FizzWare.NBuilder.Implementation;
using Microsoft.Ajax.Utilities;
using Microsoft.ApplicationInsights.Web;
using Microsoft.AspNet.Identity;
using MyCinema.Areas.Reservation.Services;
using MyCinema.Models;
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
    public ActionResult GetCinemas(int movieId)
    {
      MyCinemaDB context = new MyCinemaDB();

      var cinemaList = context.Seances
          .Where(seance => seance.Movie.Id == movieId)
          .Join(context.Cinemas, s => s.Cinema.Id, c => c.Id, (s, c) => c)
          .Select(cinema => new
          {
            name = cinema.Name,
            phone = cinema.Telephone,
            id = cinema.Id
          })
          .Distinct()
          .ToList();

      return Json(cinemaList);
    }

    public ActionResult GetMovies()
    {
      MyCinemaDB context = new MyCinemaDB();

      var movieList = context.Seances.GroupBy(seance => seance.Movie.Id).Select(seance => new
      {
        name = seance.FirstOrDefault().Movie.Title,
        id = seance.FirstOrDefault().Movie.Id,
        directorName = seance.FirstOrDefault().Movie.DirectorName,
        runningTime = seance.FirstOrDefault().Movie.RunningTime,
      })
          .ToList();

      return Json(movieList);
    }

    public ActionResult GetDates(int cinemaId)
    {
      MyCinemaDB context = new MyCinemaDB();

      var next7Days = DateTime.Now.Date.AddDays(7);
      var dateList = context.Seances
          .Where(seance => seance.Cinema.Id == cinemaId && seance.Date <= next7Days)
          .GroupBy(seance => seance.Date)
          .Select(date =>
          new
          {
            date = date.Key.ToString(),
            seances = date.Select(seance => new
            {
              hour = seance.Time,
              id = seance.Id
            })
          }
      ).ToList();


      return Json(dateList);
    }

    public ActionResult GetSeats(int seanceId)
    {
      MyCinemaDB db = new MyCinemaDB();

      var seats = db.SeatSeances
          .Where(seatSeance => seatSeance.Seance.Id == seanceId)
          .Select(seat =>
              new
              {
                row = seat.Seat.Row,
                col = seat.Seat.Column,
                id = seat.Id,
                isAvaliable = seat.IsAvaliable,
                isVisible = seat.IsVisible
              }
          )
          .GroupBy(seat => seat.row)
          .ToList();

      return Json(seats);
    }

    public ActionResult GetMovieDetails(int movieId)
    {
      MyCinemaDB db = new MyCinemaDB();
      var movieDetails = db.Movies
          .Where(movie => movie.Id == movieId)
          .Select(movie => new
          {
            id = movie.Id,
            movie.Release,
            movie.RunningTime,
            movie.Title,
            movie.Id
          }).First();

      return Json(movieDetails);
    }

   

    public ActionResult GetResevationParams(int seanceId)
    {
      MyCinemaDB db = new MyCinemaDB();
      var seanceDetails = db.Seances
        .Where(seance => seance.Id == seanceId)
        .Select(seance => new
        {
          id = seance.Id,
          movieId = seance.Movie.Id,
          cinemaId = seance.Cinema.Id
        })
        .First();

      return Json(seanceDetails);
    }


    public ActionResult CreateReservation(ReservationInfo info)
    {
      var reservation = new Models.Reservation();

      reservation.SeanceId = info.seanceId;
      reservation.CreatedTime = DateTime.Now;

      using (var db = new MyCinemaDB())
      {
        db.Reservations.Add(reservation);


        var seats = db.SeatSeances
          .Where(seatSeance => seatSeance.Seance.Id == info.seanceId && info.seatIds.Contains(seatSeance.Id))
          .ToList();

        foreach (var seat in seats)
        {
          seat.PreReserved = true;
          seat.PreReservationTime = DateTime.Now;
          seat.Reservations = reservation;
          db.Entry(seat).Property(s => s.PreReserved).IsModified = true;
          db.Entry(seat).Property(s => s.PreReservationTime).IsModified = true;
          db.Entry(seat).Reference(s => s.Reservations);
        }
        db.SaveChanges();
      }

      return Json(reservation.Id);
    }


    public ActionResult SeatsInSeance()
    {
      using (var db = new MyCinemaDB())
      {
        //                var seatsInSeance = db.Seances
        //                    .Where(s => s.Id == 3)
        //                    .SelectMany(s => s.SeatsSeances)
        //                    .Select(seats => seats.Seat.Id))
        //                    .ToList();

        return Json("ok");
      }

    }

    public class SeatDTO
    {
      public int id { get; set; }
      public int column { get; set; }
      public int row { get; set; }
    }

    public class ReservationDTO
    {
      public int id { get; set; }
      public string movieTitle { get; set; }
      public DateTime date { get; set; }
      public string time { get; set; }
      public DateTime? reservationTime { get; set; }
      public string room { get; set; }
      public string cinema { get; set; }
      public IList<IGrouping<int, SeatDTO>> seats { get; set; }
    }

    public ActionResult ReservationDetails(int reservationId)
    {
      var db = new MyCinemaDB();
      var currentReservation = db.Reservations
        .First(reservation => reservation.Id == reservationId);

      var result = new ReservationDTO()
      {
        id = currentReservation.Id,
        movieTitle = currentReservation.Seance.Movie.Title,
        date = currentReservation.Seance.Date,
        time = currentReservation.Seance.Time,
        reservationTime = currentReservation.ConfirmedTime,
        room = currentReservation.Seance.Room.Name,
        cinema = currentReservation.Seance.Cinema.Name,
        seats = db.SeatSeances
            .Where(seatSeance => seatSeance.Reservations.Id == reservationId)
            .Select(seatSeance => new SeatDTO()
            {
              id = seatSeance.Seat.Id,
              column = seatSeance.Seat.Column,
              row = seatSeance.Seat.Row
            })
            .GroupBy(seat => seat.row)
            .ToList()
      };

      return Json(result);
    }

    public ActionResult GetUserReservations()
    {
      var currentUserId = HttpContext.User.Identity.GetUserId();

      var db = new MyCinemaDB();
      var userReservations = db.Reservations
        .Where(reservation => reservation.UserId == currentUserId)
        .Select(x => new ReservationDTO()
        {
          id = x.Id,
          reservationTime = x.ConfirmedTime,
          movieTitle = x.Seance.Movie.Title,
          date = x.Seance.Date,
          time = x.Seance.Time,
          room = x.Seance.Room.Name,
          seats = db.SeatSeances
            .Where(y => y.Reservations.Id == x.Id)
            .Select(seatSeance => new SeatDTO()
            {
              id = seatSeance.Seat.Id,
              column = seatSeance.Seat.Column,
              row = seatSeance.Seat.Row
            })
            .GroupBy(seat => seat.row)
            .ToList()
        });

      return Json(userReservations);
    }



    public ActionResult Confirm(int reservationId)
    {

      var userId = HttpContext.User.Identity.GetUserId();
      using (var db = new MyCinemaDB())
      {
        var currentReservation = db.Reservations.First(reservation => reservation.Id == reservationId);
        currentReservation.UserId = userId;

        currentReservation.ConfirmedTime = DateTime.Now;
        currentReservation.IsConfirmed = true;

        db.Reservations.Attach(currentReservation);
        db.Entry(currentReservation).Property(x => x.UserId).IsModified = true;
        db.Entry(currentReservation).Property(x => x.IsConfirmed).IsModified = true;
        db.Entry(currentReservation).Property(x => x.ConfirmedTime).IsModified = true;

        var seats = db.SeatSeances
          .Where(seatSeance => seatSeance.Reservations.Id == reservationId)
          .ToList();

        foreach (var seat in seats)
        {
          seat.IsAvaliable = false;
          db.Entry(seat).Property(s => s.IsAvaliable).IsModified = true;
        }

        db.SaveChanges();

        return Json(currentReservation.Id);
      }
    }

#if DEBUG
    

    public ActionResult GenerateCinemas()
    {
      var db = new MyCinemaDB();

      GenerateDataService.GenerateCinemas(db, 10);

      db.SaveChanges();

      return Json("Cinemas Generated");
    }

    public ActionResult GenerateMovies()
    {
        var db = new MyCinemaDB();

        GenerateDataService.GenerateMovies(db, 25);

        db.SaveChanges();

        return Json("Movies Generated");
    }

        public ActionResult GenerateRooms()
        {
            var db = new MyCinemaDB();

            GenerateDataService.GenerateRooms(db);

            db.SaveChanges();

            return Json("Rooms Generated");
        }

        public ActionResult GenerateSeats()
    {
        var db = new MyCinemaDB();

        GenerateDataService.GenerateSeats(db);

        db.SaveChanges();

        return Json("Seats Generated");
    }

    public ActionResult GenerateSeances()
    {
        var db = new MyCinemaDB();

        GenerateDataService.GenerateSeances(db, 200);

        db.SaveChanges();

        return Json("Seances Generated");
    }

    public ActionResult GenerateSeatsSeances()
        {
            var db = new MyCinemaDB();

            GenerateDataService.GenerateSeatSeances(db);

            db.SaveChanges();

            return Json("Seats Seances Generated");
        }


#endif

    }
}