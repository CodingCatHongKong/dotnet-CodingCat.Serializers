using System;
using System.Text;
using CodingCat.Serializers.Impls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingCat.Serializers.Tests
{
    [TestClass]
    public class TestStringSerializer
    {
        [TestMethod]
        public void Test_ConvertWithDefaultEncoding_Ok()
        {
            // Arrange
            var serializer = new StringSerializer();
            var expected = Guid.NewGuid().ToString();
            var bytes = serializer.ToBytes(expected);

            // Act
            var actual = serializer.FromBytes(bytes);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ConvertWithASCIIEncoding_Ok()
        {
            // Arrange
            var serializer = new StringSerializer()
                .WithEncoding(Encoding.ASCII);
            var expected = Guid.NewGuid().ToString();
            var bytes = serializer.ToBytes(expected);

            // Act
            var actual = serializer.FromBytes(bytes);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
