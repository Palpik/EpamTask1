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
    public class StoreroomTests
    {
        [TestMethod()]
        public void FindByNameTest()
        {
            Storeroom st = new Storeroom();
            st.Paintings.Add(new Painting("Name1", "Genre1", "Author1", 0));
            st.Paintings.Add(new Painting("Name2", "Genre2", "Author2", 1));
            st.Paintings.Add(new Painting("Name3", "Genre3", "Author3", 2));
            st.Paintings.Add(new Painting("Name1", "Genre3", "Author3", 2));
            List<Painting> expected = new List<Painting>(
                new Painting[] { new Painting("Name1", "Genre1", "Author1", 0),
                new Painting("Name1", "Genre3", "Author3", 2)});
            CollectionAssert.AreEqual(expected, st.FindByName("Name1"));
        }

        [TestMethod()]
        public void FindByGenreTest()
        {
            Storeroom st = new Storeroom();
            st.Paintings.Add(new Painting("Name1", "Genre1", "Author1", 0));
            st.Paintings.Add(new Painting("Name2", "Genre2", "Author2", 1));
            st.Paintings.Add(new Painting("Name3", "Genre3", "Author3", 2));
            st.Paintings.Add(new Painting("Name1", "Genre2", "Author3", 2));
            List<Painting> expected = new List<Painting>(
                new Painting[] { new Painting("Name2", "Genre2", "Author2", 1),
                new Painting("Name1", "Genre2", "Author3", 2)});
            CollectionAssert.AreEqual(expected, st.FindByGenre("Genre2"));
        }

        [TestMethod()]
        public void FindByAuthor()
        {
            Storeroom st = new Storeroom();
            st.Paintings.Add(new Painting("Name1", "Genre1", "Author1", 0));
            st.Paintings.Add(new Painting("Name2", "Genre2", "Author2", 1));
            st.Paintings.Add(new Painting("Name3", "Genre3", "Author3", 2));
            st.Paintings.Add(new Painting("Name1", "Genre0", "Author3", 3));
            List<Painting> expected = new List<Painting>(
                new Painting[] { new Painting("Name3", "Genre3", "Author3", 2),
                new Painting("Name1", "Genre0", "Author3", 3)});
            CollectionAssert.AreEqual(expected, st.FindByAuthor("Author3"));
        }

        [TestMethod()]
        public void FindByYear()
        {
            Storeroom st = new Storeroom();
            st.Paintings.Add(new Painting("Name1", "Genre1", "Author1", 0));
            st.Paintings.Add(new Painting("Name2", "Genre2", "Author2", 1));
            st.Paintings.Add(new Painting("Name3", "Genre3", "Author3", 2));
            st.Paintings.Add(new Painting("Name1", "Genre0", "Author1", 2));
            List<Painting> expected = new List<Painting>(
                new Painting[] { new Painting("Name3", "Genre3", "Author3", 2),
                new Painting("Name1", "Genre0", "Author1", 2)});
            CollectionAssert.AreEqual(expected, st.FindByYear(2));
        }
        [TestMethod()]
        public void ToStringTest()
        {
            Storeroom st = new Storeroom();
            st.Paintings.Add(new Painting("Name1", "Genre1", "Author1", 0));
            st.Paintings.Add(new Painting("Name2", "Genre2", "Author2", 1));
            st.Paintings.Add(new Painting("Name3", "Genre3", "Author3", 2));
            string expected = "[Name1;Genre1;Author1;0]\n[Name2;Genre2;Author2;1]\n[Name3;Genre3;Author3;2]\n";
            Assert.AreEqual(expected,st.ToString());
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Storeroom st1 = new Storeroom();
            st1.Paintings.Add(new Painting("Name1", "Genre1", "Author1", 0));
            st1.Paintings.Add(new Painting("Name2", "Genre2", "Author2", 1));
            st1.Paintings.Add(new Painting("Name3", "Genre3", "Author3", 2));
            Storeroom st2 = new Storeroom();
            st2.Paintings.Add(new Painting("Name1", "Genre1", "Author1", 0));
            st2.Paintings.Add(new Painting("Name2", "Genre2", "Author2", 1));
            st2.Paintings.Add(new Painting("Name3", "Genre3", "Author3", 2));
            Assert.AreEqual(st1.GetHashCode(),st2.GetHashCode());
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Storeroom st1 = new Storeroom();
            st1.Paintings.Add(new Painting("Name1", "Genre1", "Author1", 0));
            st1.Paintings.Add(new Painting("Name2", "Genre2", "Author2", 1));
            st1.Paintings.Add(new Painting("Name3", "Genre3", "Author3", 2));
            Storeroom st2 = new Storeroom();
            st2.Paintings.Add(new Painting("Name1", "Genre1", "Author1", 0));
            st2.Paintings.Add(new Painting("Name2", "Genre2", "Author2", 1));
            st2.Paintings.Add(new Painting("Name3", "Genre3", "Author3", 2));
            Assert.AreEqual(st1, st2);
        }
    }
}