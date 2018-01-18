using MyCinema.Models;

namespace MyCinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Seat")]
    public class Seat
    {
      public Seat()
      {
      }

      public Seat(int id, int row, int column, int roomId)
        {
            Id = id;
            Row = row;
            Column = column;
            RoomId = roomId;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
        
        public int RoomId { get; set; }

        public virtual Room Room { get; set; }

        public virtual ICollection<SeatSeance> SeatsSeances { get; set; }
    }
}
