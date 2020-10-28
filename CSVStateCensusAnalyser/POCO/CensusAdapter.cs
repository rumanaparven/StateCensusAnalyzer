using System.IO;

namespace StatesCensusAnalyzer
{
    public abstract class CensusAdapter
    {
        protected string[] GetCensusData(string csvFilePath,string dataHeaders)
        {
            string[] censusData;
            if (File.Exists(csvFilePath))
            {
                throw new CensusAnalyzerException("File Not Found", CensusAnalyzerException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyzerException("Invalid File type", CensusAnalyzerException.ExceptionType.INVALID_FILE_TYPE);
            }
            censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyzerException("Incorrect header in data", CensusAnalyzerException.ExceptionType.INCORRECT_HEADER);
            }
            return censusData;
        }
    }
}
