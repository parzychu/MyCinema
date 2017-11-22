using MyCinema.Models;

namespace MyCinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Seat")]
    public partial class Seat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public int? Status { get; set; }
        
        public bool IsAvaliable { get; set; } 

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }

        public virtual ICollection<SeatSeance> SeatsSeances { get; set; }
    }
}
