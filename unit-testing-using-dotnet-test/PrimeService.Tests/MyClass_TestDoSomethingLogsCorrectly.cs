using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using Prime.Services;

namespace Prime.UnitTests.Services
{
    public class MyClass_TestDoSomethingLogsCorrectly
    {
        private readonly Mock<ILogger<MyClass>> _mockLogger;
        private readonly MyClass _myClass;

        public MyClass_TestDoSomethingLogsCorrectly()
        {
            _mockLogger = new Mock<ILogger<MyClass>>();
            _myClass = new MyClass(_mockLogger.Object);
        }

        [Fact]
        public void TestDoSomethingLogsCorrectly()
        {
            // Arrange
            _mockLogger.Setup(x => x.Log(
            It.Is<LogLevel>(l => l == LogLevel.Information),
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Doing something")),
            It.IsAny<Exception>(),
            It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)));

            // Act
            _myClass.DoSomething();

             // Assert
            _mockLogger.Verify(x => x.Log(
            It.Is<LogLevel>(l => l == LogLevel.Information),
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Doing something")),
            It.IsAny<Exception>(),
            It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
            Times.Once);
        }
    }
}