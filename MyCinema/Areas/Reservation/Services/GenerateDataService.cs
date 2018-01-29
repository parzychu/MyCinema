using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bogus;
using MyCinema.Models;

namespace MyCinema.Areas.Reservation.Services
{
    public static class GenerateDataService
    {
        public static void GenerateMovies(MyCinemaDB db, int count)
        {
            Faker<Movie> testMovie = new Faker<Movie>()
                .RuleFor(c => c.Title, f => f.Commerce.ProductName())
                .RuleFor(c => c.Release, f => f.Date.Between(new DateTime(2016, 1, 1), new DateTime(2019, 12, 31)))
                .RuleFor(c => c.DirectorName, f => f.Name.FullName())
                .RuleFor(c => c.RunningTime, f => f.Random.Short(66, 180))
                .RuleFor(c => c.PictureUrl, f => f.Image.People())
                .RuleFor(c => c.Description, f => f.Lorem.Paragraphs(f.Random.Number(1, 5)))
                .RuleFor(c => c.Genre, f => f.Commerce.ProductAdjective())
                .RuleFor(c => c.ProductionCountry, f => f.Address.Country());

            var movies = testMovie.Generate(count);
            foreach (Movie movie in movies)
            {
                db.Movies.Add(movie);
            }
        }

        public static void GenerateCinemas(MyCinemaDB db, int count)
        {
            Faker<Cinema> testCinema = new Faker<Cinema>()
                .RuleFor(c => c.Name, f => f.Address.City())
                .RuleFor(c => c.RoomCount, f => f.Random.Number(2, 7))
                .RuleFor(c => c.PictureUrl, f => f.Image.Nightlife())
                .RuleFor(c => c.City, f => f.Address.City())
                .RuleFor(c => c.Adress, (f, c) => f.Address.StreetName() + " " + 
                    f.Address.ZipCode() + " " + c.Name)
                .RuleFor(c => c.Telephone, (f, c) => f.Phone.PhoneNumber("###-###-###"))
                .RuleFor(c => c.Details, (f, c) => f.Lorem.Paragraphs(f.Random.Number(1, 7)))
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Name, "mycinema"));

            var cinemas = testCinema.Generate(count);
            foreach (Cinema cinema in cinemas)
            {
                db.Cinemas.Add(cinema);
            }
        }

        public static void GenerateRooms(MyCinemaDB db)
        {
            int minRows = 6;
            int maxRows = 15;
            int maxCols = 25;

            var cinemas = db.Cinemas.ToList();

            foreach (Cinema cinema in cinemas )
            {
                var count = cinema.RoomCount;

                Faker<Room> testRoom = new Faker<Room>()
                .RuleFor(c => c.Cinema, f => cinema)
                .RuleFor(c => c.RowCount, f => f.Random.Number(minRows, maxRows))
                .RuleFor(c => c.ColumnCount, (f, c) => f.Random.Number(c.RowCount, maxCols))
                .RuleFor(c => c.Name, (f, c) => "Room " + c.Id);

                var rooms = testRoom.Generate(count);
                foreach (Room room in rooms)
                {
                    db.Rooms.Add(room);
                }
            }

            
        }

        public static void GenerateSeats(MyCinemaDB db)
        {
            var rooms = db.Rooms.ToList();

            IList<Seat> newSeats = new List<Seat>();

            rooms.ForEach(room =>
            {
                for (int i = 1; i <= room.RowCount; i++)
                {
                    for (int j = 1; j <= room.ColumnCount; j++)
                    {
                        if (j == room.ColumnCount / 3 || j == room.ColumnCount / 3 + 1)
                            continue;

                        var newSeat = new Seat(room.Id * 10000 + i * room.ColumnCount + j, i, j, room.Id);
                        db.Seats.Add(newSeat);
                    }
                }
            });
        }

        public static void GenerateSeances(MyCinemaDB db, int count)
        {
            var cinemas = db.Cinemas.ToList();
            var movies = db.Movies.ToList();
            var rooms = db.Rooms.ToList();
            var daysInFuture = 20;

            Faker<Seance> testSeance = new Faker<Seance>()
                .RuleFor(c => c.Cinema, f => cinemas[f.Random.Number(cinemas.Count - 1)])
                .RuleFor(c => c.Movie, f => movies[f.Random.Number(movies.Count - 1)])
                .RuleFor(c => c.Room, f => rooms[f.Random.Number(rooms.Count - 1)])
                .RuleFor(c => c.Date, f => f.Date.Soon(daysInFuture))
                .RuleFor(c => c.Time, f =>
              {
                  var minutes = (f.Random.Number(3) * 15).ToString();
                  if (minutes == "0") minutes = "00";
                  var time = f.Random.Number(10, 22) + ":" + minutes;

                  return time;
                });

            var seances = testSeance.Generate(count);
            foreach (Seance seance in seances)
            {
                db.Seances.Add(seance);
            }
        }

        public static void GenerateSeatSeances(MyCinemaDB db)
        {
            var seances = db.Seances.ToList();

            foreach (var seance in seances)
            {
                var seanceSeats = db.Seats.Where(seat => seat.Room.Id == seance.Room.Id).ToList();

                foreach (var seat in seanceSeats)
                {
                    SeatSeance seatSeance = new SeatSeance(false, true, seat, seance);

                    db.SeatSeances.Add(seatSeance);
                }
            }
        }
    }
}