using System.Collections.Generic;
using static StatesCensusAnalyzer.CensusAnalyzer;

namespace StatesCensusAnalyzer
{
    public class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(Country country,string csvFilepath,string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyzer.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilepath, dataHeaders);
                /* case (CensusAnalyzer.Country.US):
                     return new IndianCensusAdapter.LoadCensusData(csvFilepath, dataHeaders);*/
                default:
                    throw new CensusAnalyzerException("No such country", CensusAnalyzerException.ExceptionType.NO_SUCH_COUNTRY);

            }
        }
    }
}
