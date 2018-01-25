using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data.SqlClient;
using System.Configuration;
using DvdLibrarys.Data.ADO;
using DvdLibrarys.Model;
using DvdLibrarys.Bll;

namespace DvdLibrarys.Tests.IntegrationTests
{
    [TestFixture]
    public class ADOTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DvDLibrary"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanLoadDvsFromADO()
        {
            IDvdRepository repo = new ADORepo();

            var dvd = repo.GetAll();

            Assert.AreEqual(6, dvd.Count);
            Assert.AreEqual("FaceOff", dvd[0].Title);
            Assert.AreEqual(1997, dvd[0].ReleaseYear);
            Assert.AreEqual("PG", dvd[0].Rating);

        }

        [Test]
        public void NotFoundDvdReturnsNullFromADO()
        {
            IDvdRepository repo = new ADORepo();
            var dvd = repo.GetOne(100);
            Assert.IsNull(dvd);
        }


        [Test]
        public void CanAddDvdToAdo()
        {
            IDvdRepository repo = new ADORepo();
            Dvd dvdToAdd = new Dvd();
            dvdToAdd.DvdId = 7;
            dvdToAdd.Title = "Good Will Hunting";
            dvdToAdd.ReleaseYear = 2018;
            dvdToAdd.Rating = "PG-13";
            dvdToAdd.DirectorName = "Milaho Wehelie";

            repo.Add(dvdToAdd);

            var addedDvd = repo.GetOne(8);

            Assert.AreEqual("Good Will Hunting", addedDvd.Title);
            Assert.AreEqual(2018, addedDvd.ReleaseYear);
            Assert.AreEqual("PG-13", addedDvd.Rating);
            Assert.AreEqual("Milaho Wehelie", addedDvd.DirectorName);


        }


        [Test]
        public void CanEditDvdToADO()
        {
            IDvdRepository repo = new ADORepo();
            Dvd dvdToUpdate = new Dvd();

            dvdToUpdate.DvdId = 7;
            dvdToUpdate.Title = "Madia Goes To Jail";
            dvdToUpdate.ReleaseYear = 2014;
            dvdToUpdate.Rating = "R";
            dvdToUpdate.DirectorName = "Tyler Perry";
            repo.Edit(dvdToUpdate);


            dvdToUpdate.Title = "Spider-Women: Going Away";
            dvdToUpdate.ReleaseYear = 2019;
            dvdToUpdate.Rating = "PG";
            dvdToUpdate.DirectorName = "Ali Hirsi";

            repo.Edit(dvdToUpdate);


            var updatedDvd = repo.GetOne(8);

            Assert.AreEqual("Spider-Women: Going Away", updatedDvd.Title);
            Assert.AreEqual("PG", updatedDvd.Rating);
            Assert.AreEqual("Ali Hirsi", updatedDvd.DirectorName);
        }

        [Test]
        public void CanDeleteDvd()
        {
            IDvdRepository repo = new ADORepo();
            Dvd dvdToDelete = new Dvd();

            repo.Delete(2);

            repo.GetOne(2);
            Assert.AreNotEqual("FaceOff", dvdToDelete.DirectorName);
            Assert.AreNotEqual(1997, dvdToDelete.ReleaseYear);
            Assert.AreNotEqual("PG", dvdToDelete.Rating);

            
        }



    }
}
