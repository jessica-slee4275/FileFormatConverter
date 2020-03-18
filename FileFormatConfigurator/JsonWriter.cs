using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFormatConfigurator
{
    public class JsonWriter
    {
        public List<Exception> Exceptions { get; private set; }
        private string _outputPath = "";
        private static string _fileName = "";
        public JsonWriter(string validImportFile, List<string> outputFilePathList, ExcelGenerator configuration)
        {
            try
            {
                _fileName = Path.GetFileNameWithoutExtension(validImportFile);
                foreach (var path in outputFilePathList)
                {
                    if (Path.GetExtension(path).Contains(FileFormat.json.ToString()))
                    {
                        _outputPath = path;
                        CreateJsonFile(configuration);
                    }
                }
                
            }
            catch (Exception e)
            {
                Exceptions.Add(e);
            }
        }
        private void CreateJsonFile(ExcelGenerator configuration)
        {
            var jsonContent = CreateJsonText(configuration);
            File.WriteAllText(
                path: _outputPath,
                contents: jsonContent
             );
        }
        public static string CreateJsonText(ExcelGenerator configuration)
        {
            StringBuilder json = new StringBuilder();

            var keyList = ExcelGenerator.Title_Row;
            var valueList = ExcelGenerator.Rows;
            json.AppendLine("{");
            json.AppendLine($"   \"{_fileName}\" : [");

            for (int i = 0; i < ExcelGenerator.Rows.Count; i++)
            {
                json.AppendLine("       {");
                for (int j = 0; j < ExcelGenerator.Title_Row[0].Count; j++)
                {
                    json.AppendLine($"          \"{keyList[0][j].ToString()}\" : \"{valueList[i][j].ToString()}\",");
                }
                json.Remove(json.Length - 3, 1);
                json.AppendLine("       },");
            }

            json.Remove(json.Length - 3, 1);
            json.AppendLine("   ]");
            json.AppendLine("}");
            return json.ToString();
        }
    }
    
}
