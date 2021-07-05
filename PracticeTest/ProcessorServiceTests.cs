using InterviewPrep.CSV.Services;
using InterviewPrep.CSV.Services.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace InterviewPrepTest
{
    [TestClass]
    public class ProcessorServiceTests
    {
        private readonly Mock<ILoggerFactory> MockLoggerFactory;
        public ProcessorServiceTests()
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
        public void ShouldReturnEmptyResult_WhenInputIsEmpty()
        {
            var input = string.Empty;
            var processCsvServiceMock = new Mock<IProcessCsvService>();
            processCsvServiceMock
                .Setup(m => m.Convert(input))
                .Returns(new string[0, 0])
                .Verifiable();

            var csvShort = new ProcessorService(MockLoggerFactory.Object, processCsvServiceMock.Object);
            var result = csvShort.ProcessFile(input);
            Assert.AreEqual(string.Empty, result);
        }
        [TestMethod]
        public void ShouldReturnOutput_WhenInputIsValid()
        {
            var input = string.Empty;
            var inputPath = "..\\..\\..\\TestFiles\\Test.csv";
            var outputPath = "..\\..\\..\\TestFiles\\Output.txt";
            var processCsvServiceMock = new Mock<IProcessCsvService>();
            processCsvServiceMock
                .Setup(m => m.Convert(input))
                .Returns(new string[0, 0])
                .Verifiable();

            processCsvServiceMock
               .Setup(m => m.ProcessWithDictionary(new string[0, 0]))
               .Returns(outputPath)
               .Verifiable();

            var processorService = new ProcessorService(MockLoggerFactory.Object, processCsvServiceMock.Object);
            var result = processorService.ProcessFile(inputPath);
            Assert.AreEqual(outputPath, result);
        }
    }
}

