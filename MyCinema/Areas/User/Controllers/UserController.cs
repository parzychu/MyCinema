using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using static MyCinema.Areas.Reservation.Controllers.ReservationController;

namespace MyCinema.Areas.User.Controllers
{
  public class UserController : Controller
  {
    // GET: User/User

    public ActionResult GetUserProfileData()
    {
      var personalData = new
      {
        Login = HttpContext.User.Identity.Name,
        Roles = Roles.GetRolesForUser(),
        IsAuthenticated = HttpContext.User.Identity.IsAuthenticated
      };

      return Json(personalData);
    }

        public ActionResult GetUserReservations(string userName)
        {
           
            var db = new MyCinemaDB();

            var currentUserId = db.Users.First(user => user.UserName == userName).Id;

            var userReservations = db.Reservations
              .Where(reservation => reservation.UserId == currentUserId)
              .Select(x => new ReservationDTO()
              {
                  id = x.Id,
                  reservationTime = x.ConfirmedTime,
                  movieTitle = x.Seance.Movie.Title,
                  date = x.Seance.Date.ToString(),
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
    }
}