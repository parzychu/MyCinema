using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyCinema.Models
{
    public class SeatSeance
    {
        public bool IsAvaliable { get; set; }

        public bool IsVisible { get; set; }

        [Key, Column(Order = 1)]
        public int SeatId { get; set; }

        [Key, Column(Order = 0)]
        public int SeanceId { get; set; }

        public int? ReservationId { get; set; }

        public virtual Seat Seat { get; set; }

        public virtual Seance Seance { get; set; }

        public virtual Reservation Reservations { get; set; }
    }
}