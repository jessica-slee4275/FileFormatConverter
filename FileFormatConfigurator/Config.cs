using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFormatConfigurator
{
    public class Config
    {
        public const string DateTimeFormat = "yyyy-MM-dd hh:mm:ss";
        public const string LogFile = "log.txt";
        public const string ImportFileFilterRangeStr = ".xlsx, .json, .xml, .csv, .sql";
        public const string ImportFileFilter = "excel files (*.xlsx)|*.xlsx|json files (*.json)|*.json|xml files (*.xml)|*.xml|csv files (*.csv)|*.csv|sql files (*.sql)|*.sql|All files (*.*)|*.*";
        public const string ImportFileFilterRange = @".xlsx|.json|.xml|.csv|.sql";
        
    }
}
