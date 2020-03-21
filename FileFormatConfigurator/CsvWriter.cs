using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFormatConfigurator
{
    public class CsvWriter
    {
        public List<Exception> Exceptions { get; private set; }
        private string _outputPath = "";
        public CsvWriter(string validImportFile, List<string> outputFilePathList, ExcelGenerator configuration)
        {
            try
            {
                foreach (var path in outputFilePathList)
                {
                    if (Path.GetExtension(path).Contains(FileFormat.csv.ToString()))
                    {
                        _outputPath = path;
                        CreateCsvFile(configuration);
                    }
                }
            }
            catch (Exception e)
            {
                Exceptions.Add(e);
            }
        }
        private void CreateCsvFile(ExcelGenerator configuration)
        {
            var csvContent = CreateCsvText(configuration);
            File.WriteAllText(
                path: _outputPath,
                contents: csvContent
             );
        }
        public static string CreateCsvText(ExcelGenerator configuration)
        {
            StringBuilder csv = new StringBuilder();

            var keyList = ExcelGenerator.Title_Row;
            var valueList = ExcelGenerator.Rows;

            for (int i = 0; i < ExcelGenerator.Title_Row[0].Count; i++)
            {
                csv.Append($"{keyList[0][i].ToString()}, ");
            }
            csv.Remove(csv.Length - 2, 1);
            csv.AppendLine();
            for (int i = 0; i < ExcelGenerator.Rows.Count; i++)
            {
                for (int j = 0; j < ExcelGenerator.Title_Row[0].Count; j++)
                {
                    csv.Append($"{valueList[i][j].ToString()}, ");
                }
                csv.Remove(csv.Length - 2, 1);
                csv.AppendLine();
            }
            return csv.ToString();
        }
    }
    
}
