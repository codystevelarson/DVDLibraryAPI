using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibrary.Models
{
    public class DVDRepo
    {
        private static List<DVD> _dvds;

        static DVDRepo()
        {
            _dvds = new List<DVD>()
            {
                new DVD { MovieId=1, Title="Driving Miss Daisy", Year="2018", Director="Spyke Jones", Notes="Good Mobie", Rating="PG-13" },
                new DVD { MovieId=2, Title="Good Burger", Year="1997", Director="Brian Robbins", Notes="Genuine Classic (ORANGE VHS)", Rating="PG" },
                new DVD { MovieId=3, Title="The Nutty Professor", Year="1996", Director="Tom Shadyac", Notes="Great Acting", Rating="PG-13" },
            };
        }

        public static List<DVD> GetAll()
        {
            return _dvds;
        }

        public static List<DVD> GetAllByYear(string releaseYear)
        {
            return _dvds.Where(m => m.Year == releaseYear).ToList();
        }

        public static List<DVD> GetAllByTitle(string title)
        {
            return _dvds.Where(m => m.Title.ToLower() == title.ToLower()).ToList();
        }

        public static List<DVD> GetAllByRating(string rating)
        {
            return _dvds.Where(m => m.Rating.ToLower() == rating.ToLower()).ToList();
        }

        public static List<DVD> GetAllByDirector(string director)
        {
            return _dvds.Where(m => m.Director.ToLower() == director.ToLower()).ToList();
        }

        public static DVD Get(int movieId)
        {
            return _dvds.FirstOrDefault(m => m.MovieId == movieId);
        }

        public static void Create(DVD newDvd)
        {
            if (_dvds.Any())
            {
                newDvd.MovieId = _dvds.Max(m => m.MovieId) + 1;
            }
            else
            {
                newDvd.MovieId = 0;
            }

            _dvds.Add(newDvd);
        }

        public static void Update(DVD updatedMovie)
        {
            _dvds.RemoveAll(m => m.MovieId == updatedMovie.MovieId);
            _dvds.Add(updatedMovie);
        }

        public static void Delete(int movieId)
        {
            _dvds.RemoveAll(m => m.MovieId == movieId);
        }
    }
}
