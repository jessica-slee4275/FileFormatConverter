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
        private string OutputPath = "";
        public JsonWriter(string validImportFile, List<string> outputFilePathList, ExcelGenerator configuration)
        {
            try
            {
                foreach (var path in outputFilePathList)
                {
                    if (Path.GetExtension(path).Contains(FileFormat.json.ToString()))
                    {
                        OutputPath = path;
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
                path: @"C:\Users\asdfk\source\repos\FileFormatConverter\Output\Financial Sample.json",
                contents: jsonContent
             );
        }
        public static string CreateJsonText(ExcelGenerator configuration)
        {
            StringBuilder json = new StringBuilder();

            var keyList = ExcelGenerator.Title_Row;
            var valueList = ExcelGenerator.Rows;
            json.AppendLine("{");
            json.AppendLine("   \"Financial Sample\" : [");
            
            for (int i = 0; i < 200; i++) {
                json.AppendLine("       {");
                for (int j = 0; j < 16; j++)
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
