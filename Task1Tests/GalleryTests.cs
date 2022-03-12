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
    public class GalleryTests
    {
        Painting[] paintings =
        {
            new Painting("Name1","Genre1","Author1",1),
            new Painting("Name2","Genre2","Author2",2),
            new Painting("Name3","Genre3","Author3",3),
            new Painting("Name4","Genre4","Author4",4),
            new Painting("Name5","Genre5","Author5",5),
            new Painting("Name6","Genre6","Author6",6)
        };

        [TestMethod()]
        public void ExhebitToTest_ExhibitPainting_HallToString()
        {
            Gallery gallery = new Gallery(paintings);
            gallery.Halls[1] = new Hall();
            gallery.ExhebitTo(0, gallery.Halls[1], 1);
            string expected = "1 - [Name1;Genre1;Author1;1]\n";
            Assert.AreEqual(expected,gallery.Halls[1].ToString());
        }

        [TestMethod()]
        public void MoveTest()
        {
            Gallery gallery = new Gallery(paintings);
            gallery.Halls[1] = new Hall();
            gallery.ExhebitTo(0, gallery.Halls[1], 1);
            gallery.Move(gallery.Halls[1], 1, gallery.Halls[1], 3);
            string expected = "3 - [Name1;Genre1;Author1;1]\n";
            Assert.AreEqual(expected, gallery.Halls[1].ToString());
        }

        [TestMethod()]
        public void ToStoreroomTest()
        {
            Gallery gallery = new Gallery(paintings);
            gallery.Halls[1] = new Hall();
            gallery.ExhebitTo(0, gallery.Halls[1], 1);
            gallery.ToStoreroom(gallery.Halls[1],1);
            string expected = "";
            Assert.AreEqual(expected, gallery.Halls[1].ToString());
        }
    }
}