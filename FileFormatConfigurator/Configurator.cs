using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFormatConfigurator
{
    public enum FileFormat
    {
        xlsx, json, xml, csv, sql
    }
    public class Configurator
    {
        public static StringBuilder log = new StringBuilder();

        public static Boolean CommandLine = true;

        public Configurator()
        {
        }
        public void Load(string validImportFile, List<string> outputFilePathList, Boolean commandLine)
        {
            OnStatusMessage($"Loading '{validImportFile}'");
        }
        public void GenerateConfigurations(string validImportFile, List<string> outputFilePathList)
        {
            var excelGenerator = new ExcelGenerator();
                switch (Path.GetExtension(validImportFile))
                {
                    case ".xlsx":
                        OnStatusMessage($"Starting Excel Generator...");
                        ExcelGenerator.Load(validImportFile, outputFilePathList);
                        OnStatusMessage($"Finished to read the import file.");
                        foreach (var outputPath in outputFilePathList)
                        {
                            if (outputPath.Contains("json"))
                            {
                                OnStatusMessage($"Creating Json file...");
                                var jsonWriter = new JsonWriter(validImportFile, outputFilePathList, excelGenerator);
                                OnStatusMessage($"Created Json file : {outputPath}");
                            }
                            else if (outputPath.Contains("xml"))
                            {
                                OnStatusMessage($"Creating Xml file...");
                                var xmlWriter = new XmlWriter(validImportFile, outputFilePathList, excelGenerator);
                                OnStatusMessage($"Created Xml file : {outputPath}");
                            }
                        }
                        break;
                    case ".json":
                        break;
                    case ".xml":
                        break;
                    case ".csv":
                        break;
                    case ".sql":
                        break;
                    default:
                        break;
            }
        }
        public event EventHandler<MessageEventArgs> StatusMessage;
        protected void OnStatusMessage(string statusMessage)
        {
            string msg = "";
            if (CommandLine)
            {
                msg = $"{DateTime.Now.ToString(Config.DateTimeFormat)} {statusMessage} ";
                Console.WriteLine(msg);
                log.AppendLine(msg);
                Console.ResetColor();
            }
            else
            {
                if (StatusMessage != null)
                {
                    StatusMessage(this, new MessageEventArgs(statusMessage));
                }
            }
        }
        public event EventHandler<MessageEventArgs> ErrorMessage;
        public void LogExceptions(List<Exception> exceptions)
        {
            foreach (var exception in exceptions)
            {
                OnErrorMessage(exception.Message);
            }
        }
        protected void OnErrorMessage(string errorMessage)
        {
            string msg = "";
            if (CommandLine)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                msg = $"{DateTime.Now.ToString(Config.DateTimeFormat)} {errorMessage} ";
                Console.WriteLine(msg);
                log.AppendLine(msg);
                Console.ResetColor();
            }
            else if (ErrorMessage != null)
            {
                ErrorMessage(this, new MessageEventArgs(errorMessage));
            }
        }
    }
    public class MessageEventArgs : EventArgs
    {
        public MessageEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}
