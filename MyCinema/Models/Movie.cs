namespace MyCinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Movie")]
    public partial class Movie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movie() { }

        public Movie(int id, string title, DateTime release, string directorName, short runningTime)
        {
            Id = id;
            Title = title;
            Release = release;
            DirectorName = directorName;
            RunningTime = runningTime;
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Column(TypeName = "date")]
        public DateTime Release { get; set; }

        [Required]
        public string DirectorName { get; set; }

        public short RunningTime { get; set; }

        public string PictureUrl { get; set; }

        public string Description { get; set; }

        public string Genre { get; set; }

        public string ProductionCountry { get; set; }
        
        public virtual ICollection<Seance> Seances { get; set; }
    }
}
