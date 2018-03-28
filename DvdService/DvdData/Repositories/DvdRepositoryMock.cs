using DvdModels.Interfaces;
using DvdModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DvdData.Repositories
{
    public class DvdRepositoryMock : IDvdRepository
    {
        private static List<Dvd> _dvds;

        static DvdRepositoryMock()
        {
            _dvds = new List<Dvd>()
            {
                new Dvd { DvdId=1, Title="Driving Miss Daisy", ReleaseYear=2018, Director="Spyke Jones", Notes="Good Mobie", Rating="PG-13" },
                new Dvd { DvdId=2, Title="Good Burger", ReleaseYear=1997, Director="Brian Robbins", Notes="Genuine Classic (ORANGE VHS)", Rating="PG" },
                new Dvd { DvdId=3, Title="The Nutty Professor", ReleaseYear=1996, Director="Tom Shadyac", Notes="Great Acting", Rating="PG-13" },
            };
        }


        public void Create(Dvd dvd)
        {
            if (dvd.Title == " " || string.IsNullOrEmpty(dvd.Title))
            {
                return;
            }

            //Empty or invalid release year 
            else if (dvd.ReleaseYear < 1000 || dvd.ReleaseYear > 9999)
            {
                return;
            }

            //Empty director name
            else if (dvd.Director == " " || string.IsNullOrEmpty(dvd.Director))
            {
                return;
            }

            //Empty rating 
            else if (dvd.Rating == " " || string.IsNullOrEmpty(dvd.Rating))
            {
                return;
            }


            if (_dvds.Any())
            {
                dvd.DvdId = _dvds.Max(m => m.DvdId) + 1;
            }
            else
            {
                dvd.DvdId = 0;
            }

            _dvds.Add(dvd);
        }

        public void Delete(int id)
        {
            _dvds.RemoveAll(m => m.DvdId == id);
        }

        public Dvd Get(int id)
        {
            return _dvds.SingleOrDefault(m => m.DvdId == id);
        }

        public List<Dvd> GetAll()
        {
            return _dvds;
        }

        public List<Dvd> GetAllByDirector(string director)
        {
            //Should bring back any director name containing the string parameter ("jo" passed in would return any dvd with director name containing "jo", Jones, Johnson, etc)
            if (string.IsNullOrEmpty(director))
            {
                return null;
            }

            var dvds = _dvds.Where(m => m.Director.ToLower().Contains(director.ToLower())).ToList();
            if(dvds.Any())
            {
                return dvds;
            }
            return null;
        }

        public List<Dvd> GetAllByRating(string rating)
        {
            return _dvds.Where(m => m.Rating.ToLower() == rating.ToLower()).ToList();
        }

        public List<Dvd> GetAllByTitle(string title)
        {
            return _dvds.Where(m => m.Title.ToLower() == title.ToLower()).ToList();
        }

        public List<Dvd> GetAllByYear(int releaseYear)
        {
            var dvds = _dvds.Where(m => m.ReleaseYear == releaseYear).ToList();
            if (dvds.Any())
            {
                return dvds;
            }
            return null;
        }

        public void Update(Dvd dvd)
        {
            if (dvd.Title == " " || string.IsNullOrEmpty(dvd.Title))
            {
                return;
            }

            //Empty or invalid release year 
            else if (dvd.ReleaseYear < 1000 || dvd.ReleaseYear > 9999)
            {
                return;
            }

            //Empty director name
            else if (dvd.Director == " " || string.IsNullOrEmpty(dvd.Director))
            {
                return;
            }

            //Empty rating 
            else if (dvd.Rating == " " || string.IsNullOrEmpty(dvd.Rating))
            {
                return;
            }

            _dvds.RemoveAll(m => m.DvdId == dvd.DvdId);
            _dvds.Add(dvd);
        }
    }
}
