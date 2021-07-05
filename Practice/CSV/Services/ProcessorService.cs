using InterviewPrep.CSV.Services.Interface;
using Microsoft.Extensions.Logging;
using System.IO;

namespace InterviewPrep.CSV.Services
{
    public class ProcessorService : IProcessorService
    {
        private readonly ILogger<ProcessorService> Logger;
        private readonly IProcessCsvService CsvProcessor;
        public ProcessorService(ILoggerFactory loggerFactory, IProcessCsvService processCsvService)
        {
            Logger = loggerFactory.CreateLogger<ProcessorService>();
            CsvProcessor = processCsvService;
        }
        public string ProcessFile(string filePath)
        {
            var ouputPath = string.Empty;
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                Logger.LogInformation($"Reading input file.....");
                var inputValues = CsvProcessor.Convert(filePath);

                if (CsvProcessor.ProcessWithArray(inputValues)) { Logger.LogInformation($"Writing output file completed."); }
                else { Logger.LogInformation($"Writing output file is not completed."); }

                ouputPath = CsvProcessor.ProcessWithDictionary(inputValues);
                if (!string.IsNullOrEmpty(ouputPath))
                { Logger.LogInformation($"Writing output file completed."); }
                else { Logger.LogInformation($"Writing output file is not completed."); }
            }
            return ouputPath;
        }
    }
}
