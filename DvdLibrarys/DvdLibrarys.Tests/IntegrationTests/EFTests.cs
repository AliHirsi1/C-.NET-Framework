using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DvdLibrarys.Data.EF;
using DvdLibrarys.Model;

namespace DvdLibrarys.Tests.IntegrationTests
{
    [TestFixture]
    public class EFTests
    {
        [Test]
        public void CanLoadDvdsWithEF()
        {
            IDvdRepository repo = new EFRepo();
            var dvd = repo.GetAll();
            Assert.AreEqual(8, dvd.Count);

            Assert.AreEqual(2, dvd[0].DvdId);
            Assert.AreEqual("FaceOff", dvd[0].Title);
            Assert.AreEqual(1997, dvd[0].ReleaseYear);

        }

        [Test]
        public void CanLoadSingleDvdWithEF()
        {
            IDvdRepository repo = new EFRepo();
            var dvd = repo.GetOne(6);
            Assert.AreEqual(6, dvd.DvdId);
            Assert.AreEqual("Suburbicon", dvd.Title);
            Assert.AreEqual(2017, dvd.ReleaseYear);
            Assert.AreEqual("PG-13", dvd.Rating);
            Assert.AreEqual("Matt Damon", dvd.DirectorName);
        }


        [Test]
        public void CanAddDvdWithEF()
        {
            IDvdRepository repo = new EFRepo();
            Dvd dvdToAdd = new Dvd();

            dvdToAdd.DvdId = 8;
            dvdToAdd.Title = "Spider-Man: Homecoming";
            dvdToAdd.ReleaseYear = 2017;
            dvdToAdd.Rating = "PG-13";
            dvdToAdd.DirectorName = "Jon Watts";
            repo.Add(dvdToAdd);

            var addedDvd = repo.GetOne(dvdToAdd.DvdId);

            Assert.AreEqual("Spider-Man: Homecoming", addedDvd.Title);
            Assert.AreNotEqual("R", addedDvd.Rating);


            

        }

        [Test]
        public void CanEditDvdWithEF()
        {
            IDvdRepository repo = new EFRepo();
            Dvd dvdToEdit = new Dvd();

            dvdToEdit.DvdId = 9;
            dvdToEdit.Title = "Spider-Man: Homecoming";
            dvdToEdit.ReleaseYear = 2017;
            dvdToEdit.Rating = "PG-13";
            dvdToEdit.DirectorName = "Jon Watts";
            repo.Add(dvdToEdit);


            dvdToEdit.Title = "Spider-Women: Going Away";
            dvdToEdit.ReleaseYear = 2019;
            dvdToEdit.Rating = "PG";
            dvdToEdit.DirectorName = "Ali Hirsi";


            repo.Edit(dvdToEdit);

            var updatedDvd = repo.GetOne(9);

            Assert.AreEqual(dvdToEdit.Title, updatedDvd.Title);
            Assert.AreEqual(dvdToEdit.Rating, updatedDvd.Rating);
            Assert.AreEqual(dvdToEdit.DirectorName, updatedDvd.DirectorName);

        }

        [Test]
        public void CanDeleteDvdWithEF()
        {
            IDvdRepository repo = new EFRepo();
            Dvd dvdToDelete = new Dvd();

            repo.Delete(9);

            repo.GetOne(9);
            Assert.AreNotEqual("Spider-Women: Going Away", dvdToDelete.Title);
            Assert.AreNotEqual(2019, dvdToDelete.ReleaseYear);
            Assert.AreNotEqual("PG", dvdToDelete.Rating);
        }

     



    }   
}
