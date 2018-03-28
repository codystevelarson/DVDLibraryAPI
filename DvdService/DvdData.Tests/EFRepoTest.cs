using Dapper;
using DvdData.Repositories;
using DvdModels.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdData.Tests
{
    [TestFixture]
    class EFRepoTest
    {

        [SetUp]
        public void Init()
        {
            ResetDB();
        }


        private string connectionString = ConfigurationManager.ConnectionStrings["DvdLibraryEF"].ConnectionString;

        private void ResetDB()
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;

                conn.Execute("ResetDB", commandType: CommandType.StoredProcedure);
            }
        }


        [Test]
        public void EFGetAllTest()
        {
            var repo = new DvdRepositoryEF();
            List<Dvd> dvds = repo.GetAll();

            Assert.IsNotNull(dvds);
        }


        [TestCase(1, true)]
        [TestCase(99, false)]
        public void EFGetTest(int id, bool expected)
        {
            var repo = new DvdRepositoryEF();
            Dvd dvd = repo.Get(id);

            bool actual = false;

            if (dvd != null)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Good Burger", true)]
        [TestCase("Patton", false)]
        [TestCase("", false)]
        public void EFGetByTitleTest(string title, bool expected)
        {
            var repo = new DvdRepositoryEF();
            List<Dvd> dvds = repo.GetAllByTitle(title);

            bool actual = false;

            if (dvds != null)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }


        [TestCase("xxxxx", false)]
        [TestCase("PG", true)]
        [TestCase("PG-13", true)]
        public void EFGetByRating(string rating, bool expected)
        {
            var repo = new DvdRepositoryEF();
            List<Dvd> dvds = repo.GetAllByRating(rating);

            bool actual = false;

            if (dvds != null)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }


        [TestCase("David", true)]
        [TestCase("s", true)]
        [TestCase("xxx", false)]
        [TestCase("", false)]
        public void EFGetByDirector(string director, bool expected)
        {
            var repo = new DvdRepositoryEF();
            List<Dvd> dvds = repo.GetAllByDirector(director);

            bool actual = false;

            if (dvds != null)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }


        [TestCase(1997, true)]
        [TestCase(0, false)]
        [TestCase(50000, false)]
        [TestCase(12, false)]
        [TestCase(120, false)]
        public void EFGetByYear(int year, bool expected)
        {
            var repo = new DvdRepositoryEF();
            List<Dvd> dvds = repo.GetAllByYear(year);

            bool actual = false;

            if (dvds != null)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }


        [TestCase("Test1", 2018, "G", "The Rock", "Good movie", true)]
        [TestCase("", 2018, "G", "The Rock", "Good Movie", false)]
        [TestCase("Test2", null, "G", "The Rock", "Good Movie", false)]
        [TestCase("Test3", 2018, null, "The Rock", "Good Movie", false)]
        [TestCase("Test4", 2018, "G", null, "Good Movie", false)]
        [TestCase("Test5", 2018, "G", "The Rock", null, true)]
        public void EFCanCreate(string title, int releaseYear, string rating, string director, string notes, bool expected)
        {
            Dvd dvd = new Dvd
            {
                Title = title,
                ReleaseYear = releaseYear,
                Rating = rating,
                Director = director,
                Notes = notes
            };
            var repo = new DvdRepositoryEF();
            repo.Create(dvd);
            List<Dvd> dvdCheck = repo.GetAllByTitle(title);

            bool actual = false;

            if (dvdCheck != null)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, "Test", 2018, "G", "The Rock", null, true)]
        [TestCase(1, "Test", null, "G", "The Rock", null, false)]
        [TestCase(1, "Test", 2018, null, "The Rock", null, false)]
        [TestCase(1, "Test", 2018, "G", null, null, false)]
        [TestCase(100, "Test", 2018, "G", "The Rock", null, false)]
        public void EFCanUpdate(int id, string title, int releaseYear, string rating, string director, string notes, bool expected)
        {
            bool actual = false;

            Dvd dvd = new Dvd
            {
                DvdId = id,
                Title = title,
                ReleaseYear = releaseYear,
                Rating = rating,
                Director = director,
                Notes = notes
            };
            var repo = new DvdRepositoryEF();

            Dvd dvdCheck = repo.Get(id);

            if (dvdCheck != null)
            {
                repo.Update(dvd);
                dvdCheck = repo.Get(id);
                if (dvdCheck.Title == "Test")
                {
                    actual = true;
                }
            }

            Assert.AreEqual(expected, actual);
        }


        [TestCase(1, true)]
        [TestCase(90, false)]
        public void EFCanDelete(int id, bool expected)
        {
            bool actual = false;

            var repo = new DvdRepositoryEF();
            Dvd dvd = repo.Get(id);
            if (dvd != null)
            {
                repo.Delete(id);


                dvd = repo.Get(id);

                if (dvd == null)
                {
                    actual = true;
                }
            }
            Assert.AreEqual(expected, actual);
        }
    }
}
