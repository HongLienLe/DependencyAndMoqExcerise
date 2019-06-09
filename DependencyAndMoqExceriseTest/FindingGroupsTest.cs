using NUnit.Framework;
using Moq;
using DependencyAndMoqExcerise;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Tests
{
    [TestFixture]
    public class FindingGroupsTest
    {
        string path = "/Users/hongle/Projects/DependencyAndMoqExcerise/DependencyAndMoqExcerise/TestFile.txt";
        Dictionary<string, List<string>> testGroup = new Dictionary<string, List<string>>()
            {
                {"Testing", new List<string>() { "Name1","Testing2" }},
                {"Testing2", new List<string>() { "Name2","Name3","Testing3" }},
                {"Testing3", new List<string>() {"Name4"} }

            };
        [Test]
        public void CanReturnADictionaryFromTextFile()
        {

            var mockFile = new Mock<IReadFile>();
            mockFile.Setup(x => x.GetDictionary()).Returns(testGroup);

            var groupTest = new Groups(mockFile.Object);

            Assert.AreEqual(groupTest.GetAllGroups(), testGroup);

        }
       [Test]
        public void CanGetAGroupFromDictionary()
        {
            var mockFile = new Mock<IReadFile>();
            mockFile.Setup(x => x.GetDictionary()).Returns(testGroup);

            var groupTest = new Groups(mockFile.Object);
            var result = groupTest.GetAGroup("Testing");
           
            List<string> expected = new List<string>() {"Name1","Testing2"};

            Assert.AreEqual(expected, result);

        }
        [Test]
        public void CanTellUserIfGroupDoesNotExist()
        {
            var mockFile = new Mock<IReadFile>();
            mockFile.Setup(x => x.GetDictionary()).Returns(testGroup);

            var groupTest = new Groups(mockFile.Object);

            Assert.Throws<Exception>(() => groupTest.GetAGroup("ThatDoesNotExist"));
        }
        //[Test]
        //public void CanGetAllValuesInDictionaryFromKeys()
        //{
        //    Dictionary<string, List<string>> testGroup = new Dictionary<string, List<string>>()
        //    {
        //        {"Testing", new List<string>() { "Name1","Testing2" }},
        //        {"Testing2", new List<string>() { "Name2","Name3","Testing3" }},
        //        {"Testing3", new List<string>() {"Name4"} }

        //    };
        //    Groups test = new Groups(testGroup);
        //    var expected = new List<string>() { "Name1", "Testing2", "Name2", "Name3", "Testing3", "Name4" };
        //    var result = test.GetGroup("Testing");

        //    Assert.AreEqual(expected, result);
        //}
    }
}
