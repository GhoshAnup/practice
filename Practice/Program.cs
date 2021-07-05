using InterviewPrep.Array;
using InterviewPrep.CSV;
using InterviewPrep.CSV.Models;
using InterviewPrep.CSV.Services;
using InterviewPrep.CSV.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.IO;

namespace InterviewPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the Csv file path.");
            var filePath = Console.ReadLine();
            if (!string.IsNullOrEmpty(filePath))
            {
                var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IProcessorService, ProcessorService>()
                .AddSingleton<IProcessCsvService, ProcessCsvService>()
                .BuildServiceProvider();

                var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

                var logger = serviceProvider.GetService<ILoggerFactory>()
                    .CreateLogger<Program>();
                logger.LogDebug("Starting application");

                var processor = serviceProvider.GetService<IProcessorService>();
                var outputPath = processor.ProcessFile(filePath);
                if (!string.IsNullOrEmpty(outputPath)) { Console.WriteLine($"You file is available in {outputPath}"); }
                logger.LogDebug("Process Completed!");
            }
            else
            {
                Console.WriteLine("Please enter the Csv file path.");
            }
            Console.Read();
        }
    }
}
