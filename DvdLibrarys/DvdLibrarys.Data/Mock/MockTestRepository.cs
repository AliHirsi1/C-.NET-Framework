using DvdLibrarys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrarys.Data.Mock
{
    public class MockTestRepository : IDvdRepository
    {

        private static List<Dvd> _dvd;

        // In Memory Data
        static MockTestRepository()
        {
            _dvd = new List<Dvd>()
            {
               new Dvd { DvdId = 1, Title = "FaceOff", ReleaseYear = 1997, Rating = "PG", DirectorName = "John Woo" },
               new Dvd { DvdId = 2, Title = "Pulp Finction", ReleaseYear = 1994, Rating = "PG", DirectorName = "Quentin Tarantino" },
               new Dvd { DvdId = 3, Title = "The Pursuit of Happiness", ReleaseYear = 2006, Rating = "PG-13", DirectorName = "Gabriele Muccino" },
               new Dvd { DvdId = 4, Title = "Hitch", ReleaseYear = 2005, Rating = "PG", DirectorName = "Andy Tennanto" },
               new Dvd { DvdId = 5, Title = "Toy Story", ReleaseYear = 1995, DirectorName = "John Lasseter", Rating = "PG-13" },
               new Dvd { DvdId = 2, Title = "Seven", ReleaseYear = 1991, DirectorName = "David Fincher", Rating = "R" },
               new Dvd { DvdId = 3, Title = "12 Monkeys", ReleaseYear = 1993, DirectorName = "Terry Gilliam", Rating = "M" },
               new Dvd { DvdId = 4, Title = "The Usual Suspects", ReleaseYear = 1995, Rating = "PG-13", DirectorName = "Bryan Singer" }
             };
        }

        public List<Dvd> GetAll()
        {
            return _dvd;
        }

        public Dvd GetOne(int dvdId)
        {
            return _dvd.FirstOrDefault(d => d.DvdId == dvdId);
        }

        public void Add(Dvd dvd)
        {
            if (_dvd.Count <= 0 || _dvd == null)
            {
                dvd.DvdId = 1;
            }
            else
            {
                dvd.DvdId = _dvd.Max(m => m.DvdId) + 1;
            }

            _dvd.Add(dvd);
        }

        public void Edit(Dvd dvd)
        {
            _dvd.RemoveAll(d => d.DvdId == dvd.DvdId);
            _dvd.Add(dvd);
        }


        public void Delete(int dvdId)
        {
            _dvd.RemoveAll(d => d.DvdId == dvdId);
        }


        public List<Dvd> GetByDirectorName(string director)
        {
            return _dvd.Where(d => d.DirectorName == director).ToList();
        }

        public List<Dvd> GetByRating(string rating)
        {
            return _dvd.Where(r => r.Rating == rating).ToList();
        }

        public List<Dvd> GetByTitle(string title)
        {
            return _dvd.Where(t => t.Title == title).ToList();
        }

        public List<Dvd> GetByYear(int year)
        {
            return _dvd.Where(y => y.ReleaseYear == year).ToList();
        }

    }
}
