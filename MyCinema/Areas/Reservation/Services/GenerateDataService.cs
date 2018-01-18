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
            var moviesMock = new List<Movie>
            {
                new Movie(1, "Skazani na życie w mieście", new DateTime(2012 - 03 - 03), "Maciej Poczek", 122),
                new Movie(2, "Tańczący z psami", new DateTime(2016 - 04 - 03), "Michael Jaabar", 98),
                new Movie(3, "Niebieski kilometr", new DateTime(1994 - 09 - 21), "Frank Abignale", 88),
                new Movie(4, "Ojciec mojego brata", new DateTime(1971 - 12 - 13), "Mario Kontrabasso", 144),
                new Movie(5, "Dwanaście kobiet", new DateTime(1957 - 04 - 06), "Anna Maria", 104),
                new Movie(6, "Pulpeciki", new DateTime(2010 - 06 - 16), "Mike Like", 84)
            };

            int movieId = 0;
            int movieCount = 20;
            IList<int> movieIds = new List<int>();
            Faker<Movie> testMovie = new Faker<Movie>()
                .RuleFor(c => c.Title, f => f.Company.CatchPhrase())
                .RuleFor(c => c.Release, f => f.Date.Between(new DateTime(2016, 1, 1), new DateTime(2019, 12, 31)))
                .RuleFor(c => c.DirectorName, f => f.Name.FullName())
                .RuleFor(c => c.RunningTime, f => f.Random.Short(66, 180));

            var movies = testMovie.Generate(movieCount);
            foreach (Movie movie in movies)
            {
                db.Movies.Add(movie);
            }
        }

        public static void GenerateCinemas(MyCinemaDB db, int count)
        {
            int cinemaId = 0;
            Faker<Cinema> testCinema = new Faker<Cinema>()
                .RuleFor(c => c.Name, f => f.Address.City())
                .RuleFor(c => c.Id, f => cinemaId++)
                .RuleFor(c => c.Adress, (f, c) => f.Address.StreetName() + " " + f.Address.ZipCode() + " " + c.Name)
                .RuleFor(c => c.Telephone, (f, c) => f.Phone.PhoneNumber("###-###-###"))
                .RuleFor(c => c.Details, (f, c) => f.Lorem.Paragraphs(f.Random.Number(1, 7)))
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Name, "mycinema"));

            var cinemas = testCinema.Generate(count);
            foreach (Cinema cinema in cinemas)
            {
                db.Cinemas.Add(cinema);
            }
        }

        public static void GenerateRooms(MyCinemaDB db, int count)
        {
            int roomId = 0;
            int roomCount = 5;
            int maxRows = 15;
            int maxCols = 15;

            var cinemas = db.Cinemas.ToList();

            Faker<Room> testRoom = new Faker<Room>()
                .RuleFor(c => c.Id, f => f.Random.Number(12345))
                .RuleFor(c => c.Cinema, f => cinemas[f.Random.Number(cinemas.Count - 1)])
                .RuleFor(c => c.RowCount, f => f.Random.Number(5, maxRows))
                .RuleFor(c => c.ColumnCount, f => f.Random.Number(5, maxCols))
                .RuleFor(c => c.Name, (f, c) => "Room " + c.Id);

            var rooms = testRoom.Generate(count);
            foreach (Room room in rooms)
            {
                db.Rooms.Add(room);
            }
        }

        public static void GenerateSeats(MyCinemaDB db)
        {
            var rooms = db.Rooms.ToList();

            IList<Seat> newSeats = new List<Seat>();

            rooms.ForEach(room =>
            {
                for (int i = 0; i < room.RowCount; i++)
                {
                    for (int j = 0; j < room.ColumnCount; j++)
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
            int seanceId = 0;
            var cinemas = db.Cinemas.ToList();
            var movies = db.Movies.ToList();
            var rooms = db.Rooms.ToList();

            Faker<Seance> testSeance = new Faker<Seance>()
                .RuleFor(c => c.Id, f => f.Random.Number(Int32.MaxValue))
                .RuleFor(c => c.Cinema, f => cinemas[f.Random.Number(cinemas.Count - 1)])
                .RuleFor(c => c.Movie, f => movies[f.Random.Number(movies.Count - 1)])
                .RuleFor(c => c.Room, f => rooms[f.Random.Number(rooms.Count - 1)])
                .RuleFor(c => c.Date, f => f.Date.Soon(20))
                .RuleFor(c => c.Time, f => f.Random.Number(10, 22) + ":" + f.Random.Number(3) * 15);

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