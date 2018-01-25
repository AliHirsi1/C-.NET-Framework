using DvdLibrarys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrarys.Data.EF
{
    public class EFRepo : IDvdRepository
    {
        DvdLibraryEntitites context = new DvdLibraryEntitites();

        // This method gets all the dvs in the database
        public List<Dvd> GetAll()
        {
            return context.Dvd.ToList();
        }


        // This method gets one dvd by it is id
        public Dvd GetOne(int dvdId)
        {
            return (from D in context.Dvd where D.DvdId == dvdId select D).FirstOrDefault();
        }

        // This method gets dvd by its release year
        public List<Dvd> GetByYear(int year)
        {
            return context.Dvd.Where(y => y.ReleaseYear == year).ToList();
        }


        // This method gets dvd by it is title
        public List<Dvd> GetByTitle(string title)
        {
            return context.Dvd.Where(t => t.Title == title).ToList();
        }


        // This method gets dvd it is director
        public List<Dvd> GetByDirectorName(string director)
        {
            return context.Dvd.Where(d => d.DirectorName == director).ToList();
        }


        // This method gets dvd by it is ratings
        public List<Dvd> GetByRating(string rating)
        {
            return context.Dvd.Where(r => r.Rating == rating).ToList();
        }


        // This method add new  dvd
        public void Add(Dvd dvd)
        {
            context.Dvd.Add(dvd);
            context.SaveChanges();
        }

        // This method edits an existing dvd
        public void Edit(Dvd dvd)
        {
            context.Entry(dvd).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        // This method deletes dvd it's ID
        public void Delete(int dvdId)
        {
            Dvd dvd = context.Dvd.Find(dvdId);
            context.Dvd.Remove(dvd);
            context.SaveChanges();
        }

        


        

        

        

        

       
    }
}
