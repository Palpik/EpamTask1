using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tests
{
    [TestClass()]
    public class HallTests
    {
        [TestMethod()]
        public void FindByNameTest()
        {
            Hall hall = new Hall();
            hall.Places[1] = new Painting("Name1", "Genre1", "Author1", 0);
            hall.Places[2] = new Painting("Name2", "Genre2", "Author2", 1);
            hall.Places[3] = new Painting("Name3", "Genre3", "Author3", 2);
            hall.Places[4] = new Painting("Name1", "Genre3", "Author3", 2);
            List<Painting> expected = new List<Painting>(
                new Painting[] { new Painting("Name1", "Genre1", "Author1", 0),
                new Painting("Name1", "Genre3", "Author3", 2)});
            CollectionAssert.AreEqual(expected, hall.FindByName("Name1"));
        }

        [TestMethod()]
        public void FindByGenreTest()
        {
            Hall hall = new Hall();
            hall.Places[1] = new Painting("Name1", "Genre1", "Author1", 0);
            hall.Places[2] = new Painting("Name2", "Genre2", "Author2", 1);
            hall.Places[3] = new Painting("Name3", "Genre3", "Author3", 2);
            hall.Places[4] = new Painting("Name1", "Genre2", "Author3", 2);
            List<Painting> expected = new List<Painting>(
                new Painting[] { new Painting("Name2", "Genre2", "Author2", 1),
                new Painting("Name1", "Genre2", "Author3", 2)});
            CollectionAssert.AreEqual(expected, hall.FindByGenre("Genre2"));
        }

        [TestMethod()]
        public void FindByAuthor()
        {
            Hall hall = new Hall();
            hall.Places[1] = new Painting("Name1", "Genre1", "Author1", 0);
            hall.Places[2] = new Painting("Name2", "Genre2", "Author2", 1);
            hall.Places[3] = new Painting("Name3", "Genre3", "Author1", 2);
            hall.Places[4] = new Painting("Name1", "Genre3", "Author3", 2);
            List<Painting> expected = new List<Painting>(
                new Painting[] { new Painting("Name1", "Genre1", "Author1", 0),
                new Painting("Name3", "Genre3", "Author1", 2)});
            CollectionAssert.AreEqual(expected, hall.FindByAuthor("Author1"));
        }

        [TestMethod()]
        public void FindByYear()
        {
            Hall hall = new Hall();
            hall.Places[1] = new Painting("Name1", "Genre1", "Author1", 0);
            hall.Places[2] = new Painting("Name2", "Genre2", "Author2", 0);
            hall.Places[3] = new Painting("Name3", "Genre3", "Author3", 2);
            hall.Places[4] = new Painting("Name1", "Genre3", "Author3", 2);
            List<Painting> expected = new List<Painting>(
                new Painting[] { new Painting("Name1", "Genre1", "Author1", 0),
                new Painting("Name2", "Genre2", "Author2", 0)});
            CollectionAssert.AreEqual(expected, hall.FindByYear(0));
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Hall hall = new Hall();
            hall.Places[1] = new Painting("Name1", "Genre1", "Author1", 0);
            hall.Places[2] = new Painting("Name2", "Genre2", "Author2", 1);
            hall.Places[3] = new Painting("Name3", "Genre3", "Author3", 2);
            string expected = "1 - [Name1;Genre1;Author1;0]\n2 - [Name2;Genre2;Author2;1]\n3 - [Name3;Genre3;Author3;2]\n";
            Assert.AreEqual(expected, hall.ToString());
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Hall hall1 = new Hall();
            hall1.Places[1] = new Painting("Name1", "Genre1", "Author1", 0);
            hall1.Places[2] = new Painting("Name2", "Genre2", "Author2", 1);
            hall1.Places[3] = new Painting("Name3", "Genre3", "Author3", 2);
            Hall hall2 = new Hall();
            hall2.Places[1] = new Painting("Name1", "Genre1", "Author1", 0);
            hall2.Places[2] = new Painting("Name2", "Genre2", "Author2", 1);
            hall2.Places[3] = new Painting("Name3", "Genre3", "Author3", 2);
            Assert.AreEqual(hall1.GetHashCode(), hall2.GetHashCode());
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Hall hall1 = new Hall();
            hall1.Places[1] = new Painting("Name1", "Genre1", "Author1", 0);
            hall1.Places[2] = new Painting("Name2", "Genre2", "Author2", 1);
            hall1.Places[3] = new Painting("Name3", "Genre3", "Author3", 2);
            Hall hall2 = new Hall();
            hall2.Places[1] = new Painting("Name1", "Genre1", "Author1", 0);
            hall2.Places[2] = new Painting("Name2", "Genre2", "Author2", 1);
            hall2.Places[3] = new Painting("Name3", "Genre3", "Author3", 2);
            Assert.AreEqual(hall1, hall2);
        }
    }
}