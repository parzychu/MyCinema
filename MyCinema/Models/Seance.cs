using MyCinema.Models;

namespace MyCinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Seance")]
    public class Seance
    {
      public Seance()
      {
      }

        [Key]
        public int Id { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
    
        public string Time { get; set; }
        
        public virtual Movie Movie { get; set; }
        
        public virtual Room Room { get; set; }

        public virtual Cinema Cinema { get; set; }
    }
}
