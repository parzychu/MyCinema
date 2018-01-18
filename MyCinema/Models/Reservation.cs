using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using MyCinema.Areas.Auth.Models;

namespace MyCinema.Models
{
    [Table("Reservation")]
    public partial class Reservation
    {
        public int Id { get; set; }

        public string UserId { get; set; }
            
        public int SeanceId { get; set; }

        public int Test { get; set; }

        public bool IsConfirmed { get; set; }
        
        public DateTime? CreatedTime { get; set; }
        
        public DateTime? ConfirmedTime { get; set; }

        public virtual IdentityUser User { get; set; }

        public virtual Seance Seance { get; set; }
    }
}