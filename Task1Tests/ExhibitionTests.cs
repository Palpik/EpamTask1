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
    public class ExhibitionTests
    {
        [TestMethod()]
        public void ToStringTest_EndIsNull()
        {
            Exhibition exhibition = new Exhibition(new DateTime(2022, 03, 12));
            string expected = "12.03.2022 - Going";
            Assert.AreEqual(expected, exhibition.ToString());
        }

        [TestMethod()]
        public void ToStringTest_EndIsNOTNull()
        {
            Exhibition exhibition = new Exhibition(new DateTime(2022, 03, 12),new DateTime(2022,03,13));
            string expected = "12.03.2022 - 13.03.2022";
            Assert.AreEqual(expected, exhibition.ToString());
        }

        [TestMethod()]
        public void EqualsTest_EqualentObjects_True()
        {
            Exhibition exhibition = new Exhibition(new DateTime(2022, 03, 12), new DateTime(2022, 03, 13));
            Exhibition equalExhibiton = new Exhibition(new DateTime(2022, 03, 12), new DateTime(2022, 03, 13));
            Assert.IsTrue(exhibition.Equals(equalExhibiton));
        }

        [TestMethod()]
        public void EqualsTest_DifferentObjects_EqualHashCode()
        {
            Exhibition exhibition = new Exhibition(new DateTime(2022, 03, 12), new DateTime(2022, 03, 13));
            Exhibition differentExhibiton = new Exhibition(new DateTime(2022, 03, 12), new DateTime(2022, 03, 12));
            Assert.IsFalse(exhibition.Equals(differentExhibiton));
        }

        [TestMethod()]
        public void GetHashCodeTest_EqualentObjects_EqualHashCode()
        {
            Exhibition exhibition = new Exhibition(new DateTime(2022, 03, 12), new DateTime(2022, 03, 13));
            Exhibition equalExhibiton = new Exhibition(new DateTime(2022, 03, 12), new DateTime(2022, 03, 13));
            Assert.IsTrue(exhibition.GetHashCode() == equalExhibiton.GetHashCode());
        }
    }
}