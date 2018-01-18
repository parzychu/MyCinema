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
        public int Id { get; set; }

        public SeatSeance()
        {
        }

        public SeatSeance(bool isAvaliable, bool isVisible, Seat seat, Seance seance)
        {
            IsAvaliable = isAvaliable;
            IsVisible = isVisible;
            Seat = seat;
            Seance = seance;
        }

        public bool IsAvaliable { get; set; }

        public bool IsVisible { get; set; }

        public bool PreReserved { get; set; }

        public DateTime? PreReservationTime { get; set; }
        
        public virtual Seat Seat { get; set; }
        
        public virtual Seance Seance { get; set; }

        public virtual Reservation Reservations { get; set; }
    }
}