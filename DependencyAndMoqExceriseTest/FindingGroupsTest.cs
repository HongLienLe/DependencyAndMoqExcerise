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

        [Test]
        public void CanCheckIfKeyExistInDictionary()
        {
            Dictionary<string, List<string>> testGroup = new Dictionary<string, List<string>>()
            {
                {"Testing", new List<string>() { "Name1" }}
            };
        
            Groups test = new Groups(testGroup);

            Assert.IsTrue(test.DoesKeyExist("Testing"));

        }
//       [Test]
        //public void ThrowsExpectionIfKeyDoesNotExist()
        //{
        //    Dictionary<string, List<string>> testGroup = new Dictionary<string, List<string>>()
        //    {
        //        {"Testing", new List<string>() { "Name1" }}
        //    };

        //    Groups test = new Groups(testGroup);
        //    var result = Assert.Throws<Exception>(() => test.DoesKeyExist("false"));


        //    Assert.That(result.Message, Is.EqualTo("Group does not exist"));
        //}
        //[Test]
        //public void CanGetTheValuesFromKey()
        //{
        //    Dictionary<string, List<string>> testGroup = new Dictionary<string, List<string>>()
        //    {
        //        {"Testing", new List<string>() { "Name1" }}
        //    };
        //    Groups test = new Groups(testGroup);

        //    var result = test.GetGroup("Testing");
        //    List<string> expected = new List<string>() { "Name1" };
        //    Assert.AreEqual(expected, result);

        //}
        [Test]
        public void CanGetAllValuesInDictionaryFromKeys()
        {
            Dictionary<string, List<string>> testGroup = new Dictionary<string, List<string>>()
            {
                {"Testing", new List<string>() { "Name1","Testing2" }},
                {"Testing2", new List<string>() { "Name2","Name3","Testing3" }},
                {"Testing3", new List<string>() {"Name4"} }

            };
            Groups test = new Groups(testGroup);
            var expected = new List<string>() { "Name1", "Testing2", "Name2", "Name3", "Testing3", "Name4" };
            var result = test.GetGroup("Testing");

            Assert.AreEqual(expected, result);


        }
    }
}
