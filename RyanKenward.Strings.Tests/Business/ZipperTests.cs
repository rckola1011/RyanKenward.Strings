using NUnit.Framework;
using RyanKenward.Strings.Business;

namespace RyanKenward.Strings.Tests.Business
{
    [TestFixture]
    public class ZipperTests
    {
        private Zipper _zipper;

        [SetUp]
        public void Setup()
        {
            _zipper = new Zipper();
        }

        [Test]
        public void Zip_EqualLengthStrings_ReturnsZipperedString()
        {
            var str1 = "abc";
            var str2 = "123";

            var result = _zipper.zip(str1, str2);

            Assert.AreEqual("a1b2c3", result);
        }

        [Test]
        public void Zip_String1LongerThanString2_ReturnsZipperedString()
        {
            var str1 = "abcdef";
            var str2 = "123";

            var result = _zipper.zip(str1, str2);

            Assert.AreEqual("a1b2c3def", result);
        }

        [Test]
        public void Zip_String2LongerThanString1_ReturnsZipperedString()
        {
            var str1 = "abc";
            var str2 = "123456";

            var result = _zipper.zip(str1, str2);

            Assert.AreEqual("a1b2c3456", result);
        }

        [Test]
        public void Zip_String1IsNull_ReturnsString2()
        {
            string str1 = null;
            var str2 = "123";

            var result = _zipper.zip(str1, str2);

            Assert.AreEqual(str2, result);
        }

        [Test]
        public void Zip_String1IsEmpty_ReturnsString2()
        {
            var str1 = string.Empty;
            var str2 = "123";

            var result = _zipper.zip(str1, str2);

            Assert.AreEqual(str2, result);
        }

        [Test]
        public void Zip_String2IsNull_ReturnsString1()
        {
            var str1 = "abc";
            string str2 = null;

            var result = _zipper.zip(str1, str2);

            Assert.AreEqual(str1, result);
        }

        [Test]
        public void Zip_String2IsEmpty_ReturnsString1()
        {
            var str1 = "abc";
            var str2 = string.Empty;

            var result = _zipper.zip(str1, str2);

            Assert.AreEqual(str1, result);
        }
    }
}
