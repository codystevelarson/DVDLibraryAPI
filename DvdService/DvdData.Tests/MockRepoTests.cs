//using DvdData.Repositories;
//using DvdModels.Models;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DvdData.Tests
//{
//    [TestFixture]
//    public class MockRepoTests
//    {
//        [Test]
//        public void GetAllTest()
//        {
//            var repo = new DvdRepositoryMock();
//            List<Dvd> dvds = repo.GetAll();

//            Assert.IsNotNull(dvds);
//        }


//        [TestCase(1, true)]
//        [TestCase(9, false)]
//        public void GetTest(int id, bool expected)
//        {
//            var repo = new DvdRepositoryMock();
//            Dvd dvd = repo.Get(id);

//            bool actual = false;

//            if (dvd != null)
//            {
//                actual = true;
//            }

//            Assert.AreEqual(expected, actual);
//        }

//        [TestCase("Good Burger", true)]
//        [TestCase("Patton", false)]
//        [TestCase("", false)]
//        public void GetByTitleTest(string title, bool expected)
//        {
//            var repo = new DvdRepositoryMock();
//            List<Dvd> dvds = repo.GetAllByTitle(title);

//            bool actual = false;

//            if (dvds.Any())
//            {
//                actual = true;
//            }

//            Assert.AreEqual(expected, actual);
//        }


//        [TestCase("R", false)]
//        [TestCase("PG", true)]
//        [TestCase("PG-13", true)]
//        public void GetByRating(string rating, bool expected)
//        {
//            var repo = new DvdRepositoryMock();
//            List<Dvd> dvds = repo.GetAllByRating(rating);

//            bool actual = false;

//            if (dvds.Any())
//            {
//                actual = true;
//            }

//            Assert.AreEqual(expected, actual);
//        }


//        [TestCase("Spyke", true)]
//        [TestCase("s", true)]
//        [TestCase("z", false)]
//        [TestCase("", false)]
//        public void GetByDirector(string director, bool expected)
//        {
//            var repo = new DvdRepositoryMock();
//            List<Dvd> dvds = repo.GetAllByDirector(director);

//            bool actual = false;

//            if (dvds != null)
//            {
//                actual = true;
//            }

//            Assert.AreEqual(expected, actual);
//        }


//        [TestCase(1997, true)]
//        [TestCase(0, false)]
//        [TestCase(50000, false)]
//        [TestCase(12, false)]
//        [TestCase(120, false)]
//        public void GetByYear(int year, bool expected)
//        {
//            var repo = new DvdRepositoryMock();
//            List<Dvd> dvds = repo.GetAllByYear(year);

//            bool actual = false;

//            if (dvds != null)
//            {
//                actual = true;
//            }

//            Assert.AreEqual(expected, actual);
//        }


//        [TestCase("Test1", 2018, "G", "The Rock", "Good movie", true)]
//        [TestCase("", 2018, "G", "The Rock", "Good Movie", false)]
//        [TestCase("Test2", null, "G", "The Rock", "Good Movie", false)]
//        [TestCase("Test3", 2018, null, "The Rock", "Good Movie", false)]
//        [TestCase("Test4", 2018, "G", null, "Good Movie", false)]
//        [TestCase("Test5", 2018, "G", "The Rock", null, true)]
//        public void CanCreate(string title, int releaseYear, string rating, string director, string notes, bool expected)
//        {
//            Dvd dvd = new Dvd
//            {
//                Title = title,
//                ReleaseYear = releaseYear,
//                Rating = rating,
//                Director = director,
//                Notes = notes
//            };
//            var repo = new DvdRepositoryMock();
//            repo.Create(dvd);
//            List<Dvd> dvdCheck = repo.GetAllByTitle(title);

//            bool actual = false;

//            if(dvdCheck.Any())
//            {
//                actual = true;
//            }
//            Assert.AreEqual(expected, actual);
//        }

//        [TestCase(1,"Test", 2018, "G", "The Rock", null, true)]
//        [TestCase(1, "Test", null, "G", "The Rock", null, false)]
//        [TestCase(1, "Test", 2018, null, "The Rock", null, false)]
//        [TestCase(1, "Test", 2018, "G", null, null, false)]
//        [TestCase(100, "Test", 2018, "G", "The Rock", null, false)]
//        public void CanUpdate(int id,string title, int releaseYear, string rating, string director, string notes, bool expected)
//        {
//            bool actual = false;

//            Dvd dvd = new Dvd
//            {
//                DvdId = id,
//                Title = title,
//                ReleaseYear = releaseYear,
//                Rating = rating,
//                Director = director,
//                Notes = notes
//            };
//            var repo = new DvdRepositoryMock();

//            Dvd dvdCheck = repo.Get(id);

//            if (dvdCheck != null)
//            {
//                repo.Update(dvd);
//                dvdCheck = repo.Get(id);
//                if (dvdCheck.Title == "Test")
//                {
//                    actual = true;
//                }
//            }
  
//            Assert.AreEqual(expected, actual);
//        }


//        [TestCase(1, true)]
//        [TestCase(9, false)]
//        public void CanDelete(int id, bool expected)
//        {
//            bool actual = false;

//            var repo = new DvdRepositoryMock();
//            Dvd dvd = repo.Get(id);
//            if (dvd != null)
//            {
//                repo.Delete(id);


//                dvd = repo.Get(id);

//                if (dvd == null)
//                {
//                    actual = true;
//                }
//            }
//            Assert.AreEqual(expected, actual);
//        }
//    }
//}
