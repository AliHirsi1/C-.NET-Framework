using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrarys.Model
{
    public interface IDvdRepository
    {
        List<Dvd> GetAll();
        Dvd GetOne(int dvdId);
        void Add(Dvd dvd);
        void Edit(Dvd dvd);
        void Delete(int dvdId);
        List<Dvd> GetByTitle(string title);
        List<Dvd> GetByYear(int year);
        List<Dvd> GetByDirectorName(string director);
        List<Dvd> GetByRating(string rating);
    }
}
