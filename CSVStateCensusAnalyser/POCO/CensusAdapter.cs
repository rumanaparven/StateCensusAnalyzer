using System.IO;

namespace StatesCensusAnalyzer
{
    public abstract class CensusAdapter
    {
        private string csvFilepath;
        private string dataHeader;

        protected string[] GetCensusData(string csvFilePath,string dataHeaders)
        {
            string[] censusData;
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyzerException("Inavlid File Type", CensusAnalyzerException.ExceptionType.INVALID_FILE_TYPE);
            }
            if (!File.Exists(csvFilepath))
            {
                throw new CensusAnalyzerException("File not found", CensusAnalyzerException.ExceptionType.FILE_NOT_FOUND);
            }
            censusData = File.ReadAllLines(csvFilepath);
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyzerException("Incorrect header in Data", CensusAnalyzerException.ExceptionType.INCORRECT_HEADER);
            }
            return censusData;
        }
    }
}
