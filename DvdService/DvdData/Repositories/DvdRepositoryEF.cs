using DvdModels.Interfaces;
using DvdModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdData.Repositories
{
    public class DvdRepositoryEF : IDvdRepository
    {

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

            using (var context = new DvdLibraryEntities())
            {
                context.Dvds.Add(dvd);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new DvdLibraryEntities())
            {
                Dvd dvd = context.Dvds.SingleOrDefault(d => d.DvdId == id);
                if (dvd != null)
                {
                    context.Dvds.Remove(dvd);
                    context.SaveChanges();
                }
            }
               
        }

        public Dvd Get(int id)
        {
            using (var context = new DvdLibraryEntities())
            {
                return context.Dvds.SingleOrDefault(d => d.DvdId == id);
            }
        }

        public List<Dvd> GetAll()
        {
            using (var context = new DvdLibraryEntities())
            {
                return context.Dvds.ToList();
            }
        }

        public List<Dvd> GetAllByDirector(string director)
        {
            if (string.IsNullOrEmpty(director))
            {
                return null;
            }

            using (var context = new DvdLibraryEntities())
            {
                List<Dvd> dvds = context.Dvds.Where(d => d.Director.Contains(director)).ToList();
                if (dvds.Any())
                {
                    return dvds;
                }
                return null;
            }
                
        }

        public List<Dvd> GetAllByRating(string rating)
        {
            using (var context = new DvdLibraryEntities())
            {
                List<Dvd> dvds = context.Dvds.Where(d => d.Rating == rating).ToList();
                if (dvds.Any())
                {
                    return dvds;
                }
                return null;
            }
               
        }

        public List<Dvd> GetAllByTitle(string title)
        {
            if(string.IsNullOrEmpty(title))
            {
                return null;
            }
            using (var context = new DvdLibraryEntities())
            {
                List<Dvd> dvds = context.Dvds.Where(d => d.Title.Contains(title)).ToList();
                if (dvds.Any())
                {
                    return dvds;
                }
                return null;
            }               
        }

        public List<Dvd> GetAllByYear(int releaseYear)
        {
            using (var context = new DvdLibraryEntities())
            {
                List<Dvd> dvds = context.Dvds.Where(d => d.ReleaseYear == releaseYear).ToList();
                if (dvds.Any())
                {
                    return dvds;
                }
                return null;
            }               
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
            var context = new DvdLibraryEntities();
            context.Dvds.Attach(dvd);
            context.Entry(dvd).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
