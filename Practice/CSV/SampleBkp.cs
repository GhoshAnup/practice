using InterviewPrep.CSV.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewPrep.CSV
{
    public class SampleBkp
    {
        public void LoadCsvToArray(string filename)
        {
            //var inputValues = ConvertToArray.ConvertCSV(filename);
            //var keyIndex = 0;
            //var valueIndex = 0;
            //var outputCollection = new Dictionary<string, string>
            //{
            //    { "CountryCode", "TotalCost" }
            //};

            ////***************************
            //for (int i = 0; i < inputValues.GetLength(0); i++)
            //{
            //    if (i == 0)
            //    {
            //        for (int j = 0; j < inputValues.GetLength(0); j++)
            //        {
            //            if (keyIndex == 0)
            //            {
            //                keyIndex = inputValues[i, j] == "CountryCode" ? j : 0;
            //            }
            //            if (valueIndex == 0)
            //            {
            //                valueIndex = inputValues[i, j] == "Cost" ? j : 0;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (!outputCollection.ContainsKey(inputValues[i, keyIndex]))
            //        {
            //            outputCollection.Add(inputValues[i, keyIndex], inputValues[i, valueIndex]);
            //        }
            //        else
            //        {
            //            outputCollection.TryGetValue(inputValues[i, keyIndex], out var result);
            //            var newresult = Convert.ToDouble(result) + Convert.ToDouble(inputValues[i, valueIndex]);
            //            outputCollection[inputValues[i, keyIndex]] = newresult.ToString();
            //        }
            //    }
            //}
            //****************************

            //for (int i = 0; i < 1; i++)
            //{
            //    for (int j = 0; j < values.GetLength(0); j++)
            //    {
            //        if (keyIndex == 0)
            //        {
            //            keyIndex = values[i, j] == "CountryCode" ? j : 0;
            //        }
            //        if (valueIndex == 0)
            //        {
            //            valueIndex = values[i, j] == "Cost" ? j : 0;
            //        }
            //    }
            //}          
            //for (int i = 1; i < values.GetLength(0); i++)
            //{
            //    if (!collection.ContainsKey(values[i, keyIndex]))
            //    {
            //        collection.Add(values[i, keyIndex], values[i, valueIndex]);
            //    }
            //    else
            //    {
            //        collection.TryGetValue(values[i, keyIndex], out var result);
            //        var newresult = Convert.ToDouble(result) + Convert.ToDouble(values[i, valueIndex]);
            //        collection[values[i, keyIndex]] = newresult.ToString();
            //    }
            //}
            //var output = string.Join(
            //                Environment.NewLine,
            //                outputCollection.Select(d => $"{d.Key},{d.Value},")
            //            );
            //System.IO.File.WriteAllText("C:\\Users\\anupm\\Downloads\\output2.csv", output);
            //return inputValues;
        }
    }
}
