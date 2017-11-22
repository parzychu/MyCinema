using MyCinema.Models;

namespace MyCinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Seance")]
    public partial class Seance
    {
        public int Id { get; set; }

        public int CinemaId { get; set; }

        public int MovieId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(10)]
        public string Time { get; set; }

        public int RoomId { get; set; }

        public virtual Cinema Cinema { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual ICollection<SeatSeance> SeatsSeances { get; set; }
    }
}
