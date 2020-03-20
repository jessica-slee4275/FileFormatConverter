using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFormatConfigurator
{
    public class XmlWriter
    {
        public List<Exception> Exceptions { get; private set; }
        private string _outputPath = "";
        private static string _fileName = "";
        public XmlWriter(string validImportFile, List<string> outputFilePathList, ExcelGenerator configuration)
        {
            try
            {
                _fileName = Path.GetFileNameWithoutExtension(validImportFile);
                foreach (var path in outputFilePathList)
                {
                    if (Path.GetExtension(path).Contains(FileFormat.xml.ToString()))
                    {
                        _outputPath = path;
                        CreateXmlFile(configuration);
                    }
                }
                
            }
            catch (Exception e)
            {
                Exceptions.Add(e);
            }
        }
        private void CreateXmlFile(ExcelGenerator configuration)
        {
            var xmlContent = CreateXmlText(configuration);
            File.WriteAllText(
                path: _outputPath,
                contents: xmlContent
             );
        }
        public static string CreateXmlText(ExcelGenerator configuration)
        {
            StringBuilder xml = new StringBuilder();

            var keyList = ExcelGenerator.Title_Row;
            var valueList = ExcelGenerator.Rows;
            xml.AppendLine($"<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            xml.AppendLine($"<{_fileName}>");

            for (int i = 0; i < ExcelGenerator.Rows.Count; i++)
            {
                xml.AppendLine($"<{ExcelGenerator.WorkSheetName.Replace(" ", "-")}-{i+1}>"); 
                for (int j = 0; j < ExcelGenerator.Title_Row[0].Count; j++)
                {
                    xml.AppendLine($"   <{keyList[0][j].ToString().Replace(" ", "")}>{valueList[i][j].ToString()}</{keyList[0][j].ToString().Replace(" ", "")}>");
                }
                xml.AppendLine($"</{ExcelGenerator.WorkSheetName.Replace(" ", "-")}-{i+1}>");
            }
            xml.AppendLine($"</{_fileName}>");
            return xml.ToString();
        }
    }
    
}
