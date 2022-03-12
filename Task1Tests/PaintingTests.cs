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
    public class PaintingTests
    {
        [TestMethod()]
        public void EqualsTest_DifferentPaintings_False()
        {
            Painting p1 = new Painting("Name", "Genre", "Author", 0);
            Painting p2 = new Painting("sdf", "sdfds", "fsdf", 132);
            Assert.IsFalse(p1.Equals(p2));
        }

        [TestMethod()]
        public void IsSimilarToTest_DifferentPaintings_ScoreEquals0()
        {
            Painting p1 = new Painting("Name", "Genre", "Author", 0);
            Painting p2 = new Painting("sdf", "sdfds", "fsdf", 132);
            Assert.IsTrue(p1.IsSimilarTo(p2) == 0);
        }

        [TestMethod()]
        public void IsSimilarToTest_SimilarPaintings_ScoreBigger0()
        {
            Painting p1 = new Painting("Name", "Genre", "Author", 0);
            Painting p2 = new Painting("Name", "Genre", "Author", 0);
            Assert.IsTrue(p1.IsSimilarTo(p2) == 4);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Painting p1 = new Painting("Name", "Genre", "Author", 0);
            string expected = "[Name;Genre;Author;0]";
            Assert.AreEqual(expected, p1.ToString());
        }

        [TestMethod()]
        public void GetHashCodeTest_EqualentObjects_EqualHashCode()
        {
            Painting p1 = new Painting("Name", "Genre", "Author", 0);
            Painting p2 = new Painting("Name", "Genre", "Author", 0);
            Assert.AreEqual(p1.GetHashCode(), p2.GetHashCode());
        }

        [TestMethod()]
        public void EqualsTest_EqualentObjects_True()
        {
            Painting p1 = new Painting("Name", "Genre", "Author", 0);
            Painting p2 = new Painting("Name", "Genre", "Author", 0);
            Assert.IsTrue(p1.Equals(p2));
        }
    }
}