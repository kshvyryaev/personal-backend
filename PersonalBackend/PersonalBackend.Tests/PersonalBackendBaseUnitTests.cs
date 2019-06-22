using Moq;
using NUnit.Framework;
using PersonalBackend.Domain.Database.Values;
using PersonalBackend.Domain.Database.KeyIdPairs;

namespace PersonalBackend.Tests
{
    [TestFixture]
    public class PersonalBackendBaseUnitTests
    {
        #region Set tests

        [Test]
        public void Set_KeyIsNull_ReturnIsFalse()
        {
            // Arrange
            var valuesMock = new Mock<IValuesRepository>();
            var keyIdPairsMock = new Mock<IKeyIdPairsRepository>();
            var personalBackend = new PersonalBackendModel(
                valuesMock.Object,
                keyIdPairsMock.Object);

            // Act
            var result = personalBackend.TestSetMethod<object>(null, null);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Set_KeyIsLong_ReturnIsFalse()
        {
            // Arrange
            var valuesMock = new Mock<IValuesRepository>();
            var keyIdPairsMock = new Mock<IKeyIdPairsRepository>();
            var personalBackend = new PersonalBackendModel(
                valuesMock.Object,
                keyIdPairsMock.Object);

            // Act
            var result = personalBackend.TestSetMethod<object>(new string('k', 200), null);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Set_ObjectIsNull_ReturnIsTrue()
        {
            // Arrange
            var valuesMock = new Mock<IValuesRepository>();
            valuesMock
                .Setup(x => x.Set(It.IsAny<Value>()))
                .Returns(true);

            var keyIdPairsMock = new Mock<IKeyIdPairsRepository>();
            keyIdPairsMock
                .Setup(x => x.Set(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(true);

            var personalBackend = new PersonalBackendModel(
                valuesMock.Object,
                keyIdPairsMock.Object);

            // Act
            var result = personalBackend.TestSetMethod<object>("key", null);

            // Assert
            Assert.IsTrue(result);

            valuesMock.Verify(x =>
                x.Set(It.IsAny<Value>()),
                Times.Once());

            keyIdPairsMock.Verify(x =>
                x.Set(It.IsAny<string>(), It.IsAny<int>()),
                Times.Once());
        }

        [Test]
        public void Set_ValuesReturnFalse_ReturnIsFalse()
        {
            // Arrange
            var valuesMock = new Mock<IValuesRepository>();
            valuesMock
                .Setup(x => x.Set(It.IsAny<Value>()))
                .Returns(false);

            var keyIdPairsMock = new Mock<IKeyIdPairsRepository>();
            keyIdPairsMock
                .Setup(x => x.Set(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(true);

            var personalBackend = new PersonalBackendModel(
                valuesMock.Object,
                keyIdPairsMock.Object);

            // Act
            var result = personalBackend.TestSetMethod<object>("key", "value");

            // Assert
            Assert.IsFalse(result);

            valuesMock.Verify(x =>
                x.Set(It.IsAny<Value>()),
                Times.Once());

            keyIdPairsMock.Verify(x =>
                x.Set(It.IsAny<string>(), It.IsAny<int>()),
                Times.Never());
        }

        [Test]
        public void Set_KeyIdPairReturnFalse_ReturnIsFalse()
        {
            // Arrange
            var valuesMock = new Mock<IValuesRepository>();
            valuesMock
                .Setup(x => x.Set(It.IsAny<Value>()))
                .Returns(true);

            var keyIdPairsMock = new Mock<IKeyIdPairsRepository>();
            keyIdPairsMock
                .Setup(x => x.Set(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(false);

            var personalBackend = new PersonalBackendModel(
                valuesMock.Object,
                keyIdPairsMock.Object);

            // Act
            var result = personalBackend.TestSetMethod<object>("key", "value");

            // Assert
            Assert.IsFalse(result);

            valuesMock.Verify(x =>
                x.Set(It.IsAny<Value>()),
                Times.Once());

            keyIdPairsMock.Verify(x =>
                x.Set(It.IsAny<string>(), It.IsAny<int>()),
                Times.Once());
        }

        [Test]
        public void Set_EverythingIsOk_ReturnIsTrue()
        {
            // Arrange
            var valuesMock = new Mock<IValuesRepository>();
            valuesMock
                .Setup(x => x.Set(It.IsAny<Value>()))
                .Returns(true);

            var keyIdPairsMock = new Mock<IKeyIdPairsRepository>();
            keyIdPairsMock
                .Setup(x => x.Set(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(true);

            var personalBackend = new PersonalBackendModel(
                valuesMock.Object,
                keyIdPairsMock.Object);

            // Act
            var result = personalBackend.TestSetMethod<object>("key", "value");

            // Assert
            Assert.IsTrue(result);

            valuesMock.Verify(x =>
                x.Set(It.IsAny<Value>()),
                Times.Once());

            keyIdPairsMock.Verify(x =>
                x.Set(It.IsAny<string>(), It.IsAny<int>()),
                Times.Once());
        }

        #endregion Set tests

        #region Get tests

        [Test]
        public void Get_KeyIsNull_ReturnIsNull()
        {
            // Arrange
            var valuesMock = new Mock<IValuesRepository>();
            var keyIdPairsMock = new Mock<IKeyIdPairsRepository>();
            var personalBackend = new PersonalBackendModel(
                valuesMock.Object,
                keyIdPairsMock.Object);

            // Act
            var result = personalBackend.TestGetMethod<object>(null);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Get_KeyIsLong_ReturnIsNull()
        {
            // Arrange
            var valuesMock = new Mock<IValuesRepository>();
            var keyIdPairsMock = new Mock<IKeyIdPairsRepository>();
            var personalBackend = new PersonalBackendModel(
                valuesMock.Object,
                keyIdPairsMock.Object);

            // Act
            var result = personalBackend.TestGetMethod<object>(new string('k', 200));

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Get_KeyIdPairReturnFalse_ReturnIsNull()
        {
            // Arrange
            var valuesMock = new Mock<IValuesRepository>();

            int keyIdPairsResult;
            var keyIdPairsMock = new Mock<IKeyIdPairsRepository>();
            keyIdPairsMock
                .Setup(x => x.TryGet(It.IsAny<string>(), out keyIdPairsResult))
                .Returns(false);

            var personalBackend = new PersonalBackendModel(
                valuesMock.Object,
                keyIdPairsMock.Object);

            // Act
            var result = personalBackend.TestGetMethod<object>("key");

            // Assert
            Assert.IsNull(result);

            keyIdPairsMock.Verify(x =>
                x.TryGet(It.IsAny<string>(), out keyIdPairsResult),
                Times.Once());

            valuesMock.Verify(x =>
                x.Get(It.IsAny<int>()),
                Times.Never());
        }

        [Test]
        public void Get_ValuesReturnNull_ReturnIsNull()
        {
            // Arrange
            var valuesMock = new Mock<IValuesRepository>();
            valuesMock
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns<Value>(null);

            int keyIdPairsResult;
            var keyIdPairsMock = new Mock<IKeyIdPairsRepository>();
            keyIdPairsMock
                .Setup(x => x.TryGet(It.IsAny<string>(), out keyIdPairsResult))
                .Returns(true);

            var personalBackend = new PersonalBackendModel(
                valuesMock.Object,
                keyIdPairsMock.Object);

            // Act
            var result = personalBackend.TestGetMethod<object>("key");

            // Assert
            Assert.IsNull(result);

            keyIdPairsMock.Verify(x =>
                x.TryGet(It.IsAny<string>(), out keyIdPairsResult),
                Times.Once());

            valuesMock.Verify(x =>
                x.Get(It.IsAny<int>()),
                Times.Once());
        }

        [Test]
        public void Get_ValuesReturnObjectWithEmptyJsonValue_ReturnIsNull()
        {
            // Arrange
            var valuesMock = new Mock<IValuesRepository>();
            valuesMock
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns(new Value { JsonValue = string.Empty });

            int keyIdPairsResult;
            var keyIdPairsMock = new Mock<IKeyIdPairsRepository>();
            keyIdPairsMock
                .Setup(x => x.TryGet(It.IsAny<string>(), out keyIdPairsResult))
                .Returns(true);

            var personalBackend = new PersonalBackendModel(
                valuesMock.Object,
                keyIdPairsMock.Object);

            // Act
            var result = personalBackend.TestGetMethod<object>("key");

            // Assert
            Assert.IsNull(result);

            keyIdPairsMock.Verify(x =>
                x.TryGet(It.IsAny<string>(), out keyIdPairsResult),
                Times.Once());

            valuesMock.Verify(x =>
                x.Get(It.IsAny<int>()),
                Times.Once());
        }

        [Test]
        public void Get_EverythingIsOk_ReturnIsNotNull()
        {
            // Arrange
            var valuesMock = new Mock<IValuesRepository>();
            valuesMock
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns(new Value { JsonValue = "{ id: 3 }" });

            int keyIdPairsResult;
            var keyIdPairsMock = new Mock<IKeyIdPairsRepository>();
            keyIdPairsMock
                .Setup(x => x.TryGet(It.IsAny<string>(), out keyIdPairsResult))
                .Returns(true);

            var personalBackend = new PersonalBackendModel(
                valuesMock.Object,
                keyIdPairsMock.Object);

            // Act
            var result = personalBackend.TestGetMethod<object>("key");

            // Assert
            Assert.IsNotNull(result);

            keyIdPairsMock.Verify(x =>
                x.TryGet(It.IsAny<string>(), out keyIdPairsResult),
                Times.Once());

            valuesMock.Verify(x =>
                x.Get(It.IsAny<int>()),
                Times.Once());
        }

        #endregion Get tests
    }
}
