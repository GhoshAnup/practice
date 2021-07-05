using InterviewPrep.CSV.Helper;
using InterviewPrep.CSV.Models;
using InterviewPrep.CSV.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InterviewPrep.CSV.Services
{
    public class ProcessCsvService : IProcessCsvService
    {
        private readonly ILogger<ProcessCsvService> Logger;
        private readonly ConfigHelper Helper;
        private readonly AppConfiguration AppConfiguration;
        private string OutputPath = string.Empty;
        private bool IsSuccess = true;
        public ProcessCsvService(ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory.CreateLogger<ProcessCsvService>();
            Helper = ConfigHelper.Instance;
            AppConfiguration = Helper.GetAppConfig();
        }
        public string[,] Convert(string filePath)
        {
            try
            {
                string inputFile = File.ReadAllText(filePath);
                inputFile = inputFile.Replace('\n', '\r');
                string[] lines = inputFile.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
                int rowNumber = lines.Length;
                int columnNumber = lines[0].Split(',').Length;
                string[,] output = new string[rowNumber, columnNumber];
                for (int r = 0; r < rowNumber; r++)
                {
                    var line = lines[r].Split(',');
                    for (int c = 0; c < columnNumber; c++)
                    {
                        output[r, c] = line[c];
                    }
                }
                Logger.LogInformation($"Object ready for processing.");
                return output;
            }
            catch (Exception ex)
            {
                Logger.LogInformation(ex?.Message);
            }
            return new string[0, 0];
        }
        public string ProcessWithDictionary(string[,] inputValues)
        {
            try
            {
                var inputWidth = inputValues.GetLength(0);
                if (inputWidth > 0)
                {
                    var imputColumns = GetColumns(AppConfiguration.InputColumnNames);
                    var CoulmnOneIndex = 0;
                    var ColumnTwoIndex = 0;
                    var outputCollection = new Dictionary<string, string>
                                        {
                                            {imputColumns[0], imputColumns[1] }
                                        };
                    for (int i = 0; i < inputValues.GetLength(0); i++)
                    {
                        if (i == 0)
                        {
                            for (int j = 0; j < inputValues.GetLength(0); j++)
                            {
                                if (CoulmnOneIndex == 0)
                                {
                                    CoulmnOneIndex = inputValues[i, j] == imputColumns[0] ? j : 0;
                                }
                                if (ColumnTwoIndex == 0)
                                {
                                    ColumnTwoIndex = inputValues[i, j] == imputColumns[1] ? j : 0;
                                }
                            }
                        }
                        else
                        {
                            if (!outputCollection.ContainsKey(inputValues[i, CoulmnOneIndex]))
                            {
                                outputCollection.Add(inputValues[i, CoulmnOneIndex], inputValues[i, ColumnTwoIndex]);
                            }
                            else
                            {
                                outputCollection.TryGetValue(inputValues[i, CoulmnOneIndex], out var value);
                                var newresult = System.Convert.ToDouble(value)
                                                + System.Convert.ToDouble(inputValues[i, ColumnTwoIndex]);
                                outputCollection[inputValues[i, CoulmnOneIndex]] = newresult.ToString();
                            }
                        }
                    }
                    var result = string.Join(Environment.NewLine, outputCollection.Select(d => $"{d.Key},{d.Value},"));
                    WriteOutput(result);
                    OutputPath = AppConfiguration.OutputTxtFilePath;
                }
                else { Logger.LogInformation($"No Data Found."); }
            }
            catch (Exception ex)
            {
                Logger.LogInformation(ex?.Message);
            }
            return OutputPath;
        }
        private void WriteOutput(string result)
        {
            using StreamWriter sw = File.AppendText(AppConfiguration.OutputTxtFilePath);
            sw.WriteLine(result);
        }
        public bool ProcessWithArray(string[,] inputValues)
        {
            try
            {
                var imputColumns = GetColumns(AppConfiguration.InputColumnNames);
                var CoulmnOneIndex = 0;
                var ColumnTwoIndex = 0;
                var itemCount = 0;
                string[,] outputCollection = new string[inputValues.GetLength(0), imputColumns.Length];
                outputCollection[0, 0] = imputColumns[0];
                outputCollection[0, 1] = imputColumns[1];

                var height = outputCollection.GetLength(1);
                var width = outputCollection.GetLength(0);
                for (int i = 0; i < inputValues.GetLength(0); i++)
                {
                    if (i == 0)
                    {
                        for (int j = 0; j < inputValues.GetLength(0); j++)
                        {
                            if (CoulmnOneIndex == 0)
                            {
                                CoulmnOneIndex = inputValues[i, j] == imputColumns[0] ? j : 0;
                            }
                            if (ColumnTwoIndex == 0)
                            {
                                ColumnTwoIndex = inputValues[i, j] == imputColumns[1] ? j : 0;
                            }
                        }
                    }
                    else
                    {
                        var code = inputValues[i, CoulmnOneIndex];
                        var cost = inputValues[i, ColumnTwoIndex];
                        var isExists = false;                       
                        for (int k = 0; k < height; k++)
                        {
                            if (outputCollection[k,0]== code)
                            {
                                isExists = true;
                                var costs = outputCollection[k, 1];
                                var cc = System.Convert.ToDouble(costs) + System.Convert.ToDouble(cost);
                                outputCollection[k, 1] = cc.ToString();
                            }

                        }
                        if (!isExists)
                        {
                            for (int k = 1; k <= height; k++)
                            {
                                if (outputCollection[k, 0] == null)
                                {
                                    outputCollection[k, 0] = code;
                                    outputCollection[k, 1] = cost;
                                    itemCount++;
                                    break;
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                Logger.LogInformation(ex?.Message);
            }
            return IsSuccess;
        }
        private string[] GetColumns(string inputColumns)
        {
            return inputColumns.Split(',');
        }
    }
}
