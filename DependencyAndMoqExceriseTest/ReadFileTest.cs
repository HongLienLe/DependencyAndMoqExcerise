using NUnit.Framework;
using Moq;
using DependencyAndMoqExcerise;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        ReadFile _ReadFile;
        [SetUp]
        public void SetUp(){
            _ReadFile = new ReadFile();
        }

        [Test]
        public void CanReadFilesReturnAList()
        {
            var result = _ReadFile.ReadGroupFile();
            List<string> expected = new List<string>()
            {
                "\"Group1\" -> [ \"Tom\", \"Group2\", \"James\", \"Patrick\"]",
                "\"Group2\" -> [ \"Group3\"]",
                "\"Group3\" ->  [ \"Sarah\" ]"
            };

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void CanSplitTheFilesIntoKeyAndValues()
        {
            string testLine ="\"Group1\" -> [ \"Tom\", \"Group2\", \"James\", \"Patrick\"]";
            var result = _ReadFile.SplitArrayContent(testLine);
            var resultString = result.Item1;
            var resultList = result.Item2;

            var expectedString = "Group1";
            var expectedList = new List<string>() {"Tom","Group2","James","Patrick" };

            Assert.AreEqual(resultString, expectedString);
            Assert.AreEqual(expectedList, resultList);

        }
        [Test]
        public void ShouldBeAbleToTrimWhiteSpace()
        {
            string[] testLine = {"     Hong","Cong    " };
            var result = _ReadFile.TrimWhiteSpace(testLine);
            string[] expected = {"Hong","Cong"};
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void CanAddToTheDictionary()
        {

        }
        [Test]
        public void DoesKeyAlreadyExistInDictionary()
        {

        }
        
    }
}