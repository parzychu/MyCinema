using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult ReservationDays()
        {

            return Json(x, JsonRequestBehavior.AllowGet);
        }
    }
}