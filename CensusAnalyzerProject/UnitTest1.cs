using NUnit.Framework;
using StatesCensusAnalyzer;
using System.Collections.Generic;

namespace CensusAnalyzerProject
{
    public class Tests
    {
       
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";

        static string indianStateCensusFilePath = @"C:\Users\RUMANA\source\repos\CSVStateCensusAnalyser\CensusAnalyzerProject\CSVFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\RUMANA\source\repos\CSVStateCensusAnalyser\CensusAnalyzerProject\CSVFiles\WrongIndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"C:\Users\RUMANA\source\repos\CSVStateCensusAnalyser\CensusAnalyzerProject\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianCensusFileType = @"C:\Users\RUMANApARVEN\source\repos\CSVStateCensusAnalyse\CensusAnalyzerProject\CSVFiles\WrongIndianStateCensusData.txt";
        static string wrongIndianCensusFilePath = @"C:\Users\RUMANApARVEN\source\repos\CSVStateCensusAnalyse\CensusAnalyzerProject\CSVFiles\IndiaData.csv";

        static string indianStateCodeFilePath = @"C:\Users\RUMANA\source\repos\CSVStateCensusAnalyser\CensusAnalyzerProject\CSVFiles\IndiaStateCode.csv";
        static string wrongHeadersStateCodefilePath = @"C:\Users\RUMANA\source\repos\CSVStateCensusAnalyser\CensusAnalyzerProject\CSVFiles\DelimiterIndiaStateCode.csv";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\RUMANA\source\repos\CSVStateCensusAnalyser\CensusAnalyzerProject\CSVFiles\DelimiterIndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\RUMANA\source\repos\CSVStateCensusAnalyse\CensusAnalyzerProject\CSVFiles\IndianStateCensusData.txt";

        CensusAnalyzer censusAnalyzer;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyzer = new CensusAnalyzer();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void TC1_1_GivenStateCensus_CheckToEnsureNumberOfRecords()
        {
            totalRecord = censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }

        [Test]
        public void TC1_2_GivenStateCensus_GiveCustomException_ForIncorrectPath()
        {
            var censusException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongIndianCensusFilePath, wrongHeaderIndianCensusFilePath));
            var stateException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongIndianCensusFilePath, wrongHeadersStateCodefilePath));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.FILE_NOT_FOUND, censusException.type);
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.FILE_NOT_FOUND, stateException.type);
        }
        [Test]
        public void TC1_3_GivenStateCensus_GiveCustomException_ForWrongFileType()
        {
            var censusException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongIndianCensusFileType, wrongHeaderIndianCensusFilePath));
            var stateException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongIndianStateCodeFileType, wrongHeadersStateCodefilePath));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_FILE_TYPE, censusException.type);
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_FILE_TYPE, stateException.type);
        }

        [Test]
        public void TC1_4_GivenStateCensus_GiveCustomException_ForIncorrectDelimiter()
        {
            var censusException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, delimiterIndianCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INCORRECT_DELIMITER, censusException.type);
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INCORRECT_DELIMITER, stateException.type);
        }
        [Test]
        public void TC1_5_GivenStateCensus_GiveCustomException_ForIncorrectHeader()
        {
            var censusException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongHeaderIndianCensusFilePath, wrongHeaderIndianCensusFilePath));
            var stateException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyzer.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongHeadersStateCodefilePath, wrongHeadersStateCodefilePath));
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INCORRECT_HEADER, censusException.type);
            Assert.AreEqual(CensusAnalyzerException.ExceptionType.INCORRECT_HEADER, stateException.type);
        }
    }
}