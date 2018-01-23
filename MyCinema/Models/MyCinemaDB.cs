using Microsoft.AspNet.Identity.EntityFramework;
using MyCinema.Areas.Auth.Models;
using MyCinema.Models;

namespace MyCinema
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyCinemaDB : IdentityDbContext<IdentityUser>
    {
        public MyCinemaDB()
            : base("name=MyCinemaDB")
        {
        }

        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Seance> Seances { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<SeatSeance> SeatSeances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cinema>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.Cinema)
                .WillCascadeOnDelete(false);
            
            modelBuilder.Entity<Movie>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Seances)
                .WithRequired(e => e.Movie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Seats)
                .WithRequired(e => e.Room)
                .WillCascadeOnDelete(false);
            
        }
    }
}
