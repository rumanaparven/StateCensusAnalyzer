using System;
using System.Collections.Generic;
using System.Text;

namespace StatesCensusAnalyzer
{
    class CensusAnalyzerException:Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND,INVALID_FILE_TYPE,INCORRECT_DELIMITER,INCORRECT_HEADER,NO_SUCH_COUNTRY
        }
        public ExceptionType type;
        public CensusAnalyzerException(string message,ExceptionType type) : base(message)
        {
            this.type = type;
        }
    }
}
