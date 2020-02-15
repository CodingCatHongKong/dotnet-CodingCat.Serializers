using System;
using CodingCat.Serializers.Impls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingCat.Serializers.Tests
{
    [TestClass]
    public class TestToStringSerializers
    {
        [TestMethod]
        public void Test_JsonSerializer_Ok()
        {
            // Arrange
            var serializer = new JsonSerializer<dynamic>();
            var expected = new
            {
                Tick = DateTime.Now.Ticks.ToString()
            };
            var serialized = serializer.Serialize(expected);

            // Act
            var actual = serializer.Deserialize(serialized);

            // Assert
            Assert.AreEqual(expected.Tick, actual.Tick.ToString());
        }

        [TestMethod]
        public void Test_Int16Serializer_Ok()
        {
            // Arrange
            var serializer = new Int16Serializer();
            var expected = (short)new Random().Next(
                short.MinValue, short.MaxValue
            );
            var serialized = serializer.Serialize(expected);

            // Act
            var actual = serializer.Deserialize(serialized);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Int32Serializer_Ok()
        {
            // Arrange
            var serializer = new Int32Serializer();
            var expected = new Random().Next(
                int.MinValue, int.MaxValue
            );
            var serialized = serializer.Serialize(expected);

            // Act
            var actual = serializer.Deserialize(serialized);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_BooleanSerializer_Ok()
        {
            // Arrange
            var serializer = new BooleanSerializer();
            var expectedTrue = true;
            var expectedFalse = false;

            var serializedTrue = serializer.Serialize(expectedTrue);
            var serializedFalse = serializer.Serialize(expectedFalse);

            // Act
            var actualTrue = serializer.Deserialize(serializedTrue);
            var actualFalse = serializer.Deserialize(serializedFalse);

            // Assert
            Assert.AreEqual(expectedTrue, actualTrue);
            Assert.AreEqual(expectedFalse, actualFalse);
        }
    }
}
