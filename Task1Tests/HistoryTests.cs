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
    public class HistoryTests
    {
        [TestMethod()]
        public void StartExhibitTest()
        {
            History story = new History();
            story.StartExhibit(new DateTime(2022,12,3));
            Assert.IsTrue(story.IsGoingExhibit);
        }

        [TestMethod()]
        public void EndExhibitTest()
        {
            History story = new History();
            story.StartExhibit(new DateTime(2022, 12, 3));
            story.EndExhibit();
            Assert.IsFalse(story.IsGoingExhibit);
        }

        [TestMethod()]
        public void ToStringTest_ExhibitIsGoing()
        {
            History story = new History();
            story.StartExhibit(new DateTime(2022, 12, 3));
            story.StartExhibit(new DateTime(2022, 12, 3));
            string expectedToString = "03.12.2022 - 03.12.2022\n03.12.2022 - Going\n";
            Assert.AreEqual(expectedToString, story.ToString());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            History story = new History();
            story.StartExhibit(new DateTime(2022, 12, 3));
            story.StartExhibit(new DateTime(2022, 12, 3));
            story.EndExhibit(new DateTime(2022,12,3));
            string expectedToString = "03.12 .2022 - 03.12.2022\n03.12.2022 - 03.12.2022\n";
            Assert.AreEqual(expectedToString, story.ToString());
        }

        [TestMethod()]
        public void GetHashCodeTest_EqualentObjects_EqualHashCode()
        {
            History story = new History();
            story.StartExhibit(new DateTime(2022, 12, 3));
            story.StartExhibit(new DateTime(2022, 12, 3));
            story.EndExhibit(new DateTime(2022, 12, 3));
            History equalStory = new History();
            equalStory.StartExhibit(new DateTime(2022, 12, 3));
            equalStory.StartExhibit(new DateTime(2022, 12, 3));
            equalStory.EndExhibit(new DateTime(2022, 12, 3));
            Assert.IsTrue(story.GetHashCode() == equalStory.GetHashCode());
        }

        [TestMethod()]
        public void EqualsTest_EqualentObjects_True()
        {
            History story = new History();
            story.StartExhibit(new DateTime(2022, 12, 3));
            story.StartExhibit(new DateTime(2022, 12, 3));
            story.EndExhibit(new DateTime(2022, 12, 3));
            History equalStory = new History();
            equalStory.StartExhibit(new DateTime(2022, 12, 3));
            equalStory.StartExhibit(new DateTime(2022, 12, 3));
            equalStory.EndExhibit(new DateTime(2022, 12, 3));
            Assert.IsTrue(story.Equals(equalStory));
        }

        [TestMethod()]
        public void EqualsTest_DifferentObjects_False()
        {
            History story = new History();
            story.StartExhibit(new DateTime(2022, 12, 3));
            story.StartExhibit(new DateTime(2022, 12, 3));
            story.EndExhibit(new DateTime(2022, 12, 3));
            History equalStory = new History();
            story.StartExhibit(new DateTime(2022, 12, 3));
            equalStory.EndExhibit(new DateTime(2022, 12, 3));
            Assert.IsFalse(story.Equals(equalStory));
        }
    }
}