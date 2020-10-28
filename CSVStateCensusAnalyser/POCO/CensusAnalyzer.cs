using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace StatesCensusAnalyzer
{
    public class CensusAnalyzer
    {
        public enum Country
        {
            INDIA, US, BRAZIL
        }
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilepath, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilepath, dataHeaders);
            return dataMap;
        }

        public object GetSortedStateCodeDataInJsonFormat(Country country, string csvFilepath, string dataHeaders, string sortField, SortOrder sortBy)
        {
            var censusData = LoadCensusData(country, csvFilepath, dataHeaders);
            List<CensusDTO> lines = censusData.Values.ToList();
            List<CensusDTO> lists = GetSortedData(sortField, lines);
            if (sortBy.Equals(SortOrder.Descending))
            {
                lists.Reverse();
            }
            return JsonConvert.SerializeObject(lists);
        }

        private List<CensusDTO> GetSortedData(string sortField, List<CensusDTO> lines)
        {
            switch (sortField)
            {
                case "stateName": return lines.OrderBy(x => x.stateName).ToList();
                case "stateCode": return lines.OrderBy(x => x.stateName).ToList();
                case "state": return lines.OrderBy(x => x.stateName).ToList();
                case "area": return lines.OrderBy(x => x.stateName).ToList();
                case "USArea": return lines.OrderBy(x => x.stateName).ToList();
                case "populationDensity": return lines.OrderBy(x => x.stateName).ToList();
                case "density": return lines.OrderBy(x => x.stateName).ToList();
                case "population": return lines.OrderBy(x => x.stateName).ToList();
                default: return lines.OrderBy(x => x.tin).ToList();

            }
        }
        /* public string GetMostDenseStateBetweenUSAndIndia(CensusDAO censusDao,USCensusDao uSCensusDao)
         {
             Console.WriteLine(censusDao.density + " " + uSCensusDao.populationDensity);
             string state = (censusDao.density > uSCensusDao.populationDensity)
                 ? censusDao.state : uSCensusDao.stateName;
             return state;
         }*/
    }
}
