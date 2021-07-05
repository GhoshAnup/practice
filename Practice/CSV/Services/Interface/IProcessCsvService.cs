using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPrep.CSV.Services.Interface
{
    public interface IProcessCsvService
    {
        string[,] Convert(string filePath);
        string ProcessWithDictionary(string[,] inputValue);
        bool ProcessWithArray(string[,] inputValues);
    }
}
