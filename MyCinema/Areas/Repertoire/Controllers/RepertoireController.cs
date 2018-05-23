using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCinema.Areas.Repertoire.Controllers
{

    public class RepertoireDTO
    {
      public string title { get; set; }
      public string date { get; set; }
      public IList<RepertoireSeanceDTO> seances { get; set; }
    }

    public class RepertoireSeanceDTO
    {
      public int id { get; set; }
      public string time { get; set; }
    }

  public class RepertoireController : Controller
    {
      public ActionResult GetRepertoire(int cinemaId, DateTime? date)
      {
        date = (date ?? DateTime.Today).Date;
        MyCinemaDB db = new MyCinemaDB();
        var repertoire = db.Seances
            .Where(seance => seance.Cinema.Id == cinemaId)
            .Where(seance => DbFunctions
                .TruncateTime(seance.Date) == date)
            .GroupBy(seance => seance.Movie)
            .Select(x => new RepertoireDTO
            {
              title = x.Key.Title,
              date = date.ToString(),
              seances = x.Key.Seances
                    .Where(seance => DbFunctions
                        .TruncateTime(seance.Date) == date)
                    .Select(seance => new RepertoireSeanceDTO
                    {
                      id = seance.Id,
                      time = seance.Time
                    }).ToList()
            }).ToList();

        return Json(repertoire);
      }
        
        public ActionResult GetCinemas()
        {
            MyCinemaDB db = new MyCinemaDB();

            var cinemas = db.Cinemas.Select(cinema => new
            {
                name = "MyCinema " + cinema.Name,
                id = cinema.Id
            }).ToList();

            return Json(cinemas);
        }
  }
}