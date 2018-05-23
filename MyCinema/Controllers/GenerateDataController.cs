using MyCinema.Areas.Reservation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCinema.Controllers
{
    public class GenerateDataController : Controller
    {


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