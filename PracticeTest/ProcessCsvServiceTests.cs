using InterviewPrep.CSV.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace InterviewPrepTest
{
    [TestClass]
    public class ProcessCsvServiceTests
    {
        private readonly Mock<ILoggerFactory> MockLoggerFactory;
        public ProcessCsvServiceTests()
        {
            var mockLogger = new Mock<ILogger<ProcessorService>>();
            mockLogger.Setup(
                m => m.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.IsAny<object>(),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<object, Exception, string>>()));

            MockLoggerFactory = new Mock<ILoggerFactory>();
            MockLoggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(() => mockLogger.Object);
        }
        [TestMethod]
        public void ShouldReturnAnArray_WhenInputIsValid()
        {
            var inputPath = "..\\..\\..\\TestFiles\\Test.csv";
            var processCsvService = new ProcessCsvService(MockLoggerFactory.Object);
            var result = processCsvService.Convert(inputPath);
            Assert.AreEqual(5, result.GetLength(0));
        }
        [TestMethod]
        public void ShouldReturnAnEmptyArray_WhenInputIsNotValid()
        {
            var inputPath = "..\\..\\..\\TestFiles\\NegetiveTest.csv";
            var processCsvService = new ProcessCsvService(MockLoggerFactory.Object);
            var result = processCsvService.Convert(inputPath);
            Assert.AreEqual(0, result.GetLength(0));
        }

        [TestMethod]
        public void ShouldReturnOutputPath_WhenInputIsValid()
        {
            var filePath = "..\\..\\..\\TestFiles\\Test.csv";
            var processCsvService = new ProcessCsvService(MockLoggerFactory.Object);
            var input = processCsvService.Convert(filePath);
            var result = processCsvService.ProcessWithDictionary(input);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void ShouldReturnEmptyResult_WhenInputIsNotValid()
        {
            var processCsvService = new ProcessCsvService(MockLoggerFactory.Object);
            var result = processCsvService.ProcessWithDictionary(new string[0, 0]);
            Assert.AreEqual(string.Empty, result);
        }
    }
}
