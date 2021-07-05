using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPrep.CSV.Services.Interface
{
    public interface IProcessorService
    {
        string ProcessFile(string filePath);
    }
}
