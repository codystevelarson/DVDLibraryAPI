using DvdModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdModels.Interfaces
{
    public interface IDvdRepository
    {
        List<Dvd> GetAll();
        List<Dvd> GetAllByYear(int releaseYear);
        List<Dvd> GetAllByTitle(string title);
        List<Dvd> GetAllByRating(string rating);
        List<Dvd> GetAllByDirector(string director);
        Dvd Get(int id);
        void Create(Dvd dvd);
        void Update(Dvd dvd);
        void Delete(int id);
    }
}
