using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileFormatConfigurator
{
    public enum Status { LOG, SUCCESS, ERROR, WARNING }
    public partial class GUI : Form
    {
        // Pass in parameters from command line
        private string _ImportPath;
        private string _ExportPath;
        private Dictionary<string, string> _ExportFormat;
        private List<string> OutputPathList = new List<string>() { };
        private List<string> ValidImportFilesPathList = new List<string> { };
        List<Exception> exceptions = new List<Exception>();
        private bool followThrough = true;
        
        private string logFilePath = "";
        public GUI()
        {
            FormLoad();
            InitializeComponent();
        }
        private void FormLoad()
        {
            //winform location
            var myScreen = Screen.FromControl(this);
            var mySecondScreen = Screen.AllScreens.FirstOrDefault(s => !s.Equals(myScreen)) ?? myScreen;
            this.Left = mySecondScreen.Bounds.Left + 10;
            this.Top = mySecondScreen.Bounds.Top + 10;
            this.StartPosition = FormStartPosition.Manual;
        }
        #region buttonclick
        private void btnImportBrowser_Click(object sender, EventArgs e)
        {
            var openImportFileDialog = new OpenFileDialog();
            openImportFileDialog.Filter = Config.ImportFileFilter;

            if (openImportFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                LogStatus("Invalid folder location!", Status.WARNING);
            }
            
            tbImportPath.Text = openImportFileDialog.FileName;
        }
        private void btnExportBrowser_Click(object sender, EventArgs e)
        {
            var openExportFolderDialog = new OpenFileDialog();
            openExportFolderDialog.Title = "Select the Machine-HotRunner Map File";
            if (openExportFolderDialog.ShowDialog(this) != DialogResult.OK)
            {
                LogStatus("Invalid map file!", Status.WARNING);
            }
            tbExportPath.Text = openExportFolderDialog.FileName;
        }
        private void btnDataFormatGenerate_Click(object sender, EventArgs e)
        {
            exceptions = new List<Exception>();
            Configurator.CommandLine = false;
            _ExportFormat = new Dictionary<string, string>() { };
            GenerateCheckedBox();
            GenerateDataFormat(tbImportPath.Text, tbExportPath.Text);
        }
        #endregion
        public void GenerateDataFormat(string importPath, string exportPath) {
            
            followThrough = true;
            ProcessingStart(importPath, exportPath, _ExportFormat);
            CheckValidPath(label1.Text, _ImportPath);
            CheckValidPath(label2.Text, _ExportPath);
            CheckValidFormat(_ImportPath, _ExportFormat);
            if (followThrough) {
                try
                {
                    var configurator = new Configurator();
                    configurator.ErrorMessage += OnConfigurator_ErrorMessage;
                    configurator.StatusMessage += OnConfigurator_StatusMessage;
                    if(ValidImportFilesPathList.Count > 0 && OutputPathList.Count > 0)
                    foreach (var validImportFilePath in ValidImportFilesPathList) {
                            if (Path.GetFileName(validImportFilePath)[0] != '~')
                            {
                                configurator.Load(validImportFilePath, OutputPathList, Configurator.CommandLine);
                                configurator.GenerateConfigurations(validImportFilePath, OutputPathList);
                            }
                        
                    }
                }
                catch (Exception e) { exceptions.Add(e); }
                finally
                {
                    ProcessingEnd();
                }
            }
            else { LogStatus("Failed processing configurations.", Status.ERROR); }
        }
        private void ProcessingStart(string importPath, string exportPath, Dictionary<string, string> _ExportFormat)
        {
            string dataExportFormatStr = "";
            _ImportPath = importPath;
            _ExportPath = exportPath;
            LogStatus($"Processing configurations...", Status.SUCCESS);
            LogStatus($"Import Path     : {_ImportPath}", Status.SUCCESS);
            LogStatus($"Export Path     : {_ExportPath}", Status.SUCCESS);
            foreach (var format in _ExportFormat.Keys)
            {
                dataExportFormatStr += format + ", ";
            }
            if (dataExportFormatStr.Length > 1)
            {
                dataExportFormatStr = dataExportFormatStr.Remove(dataExportFormatStr.Length - 2);
                LogStatus($"Export Format   : {dataExportFormatStr}", Status.SUCCESS);
            }
            else
            {
                LogStatus($"Please select at least one output format.", Status.ERROR);
                followThrough = false;
            }
        }
        private void CheckValidPath(string name, string inputPath)
        {
            //no input
            if (inputPath.Length == 0)
            {
                LogStatus($"Path can not be null. - {name} : null!", Status.ERROR);
                followThrough = false;
            }
            //import path
            if (inputPath == _ImportPath)
            {
                //if import path is file path
                if (!File.Exists(inputPath) && !Directory.Exists(inputPath)) {
                    PrintInvalidInput(name, inputPath);
                }
                //if import path is folder path
                if (Directory.Exists(inputPath))
                {
                    //check directory path has valid format
                    string[] fileEntries = Directory.GetFiles(inputPath);
                    
                    foreach (var file in fileEntries)
                    {
                        var filePath = Path.GetFullPath(file);
                        var fileformat = Path.GetExtension(filePath);
                        if (Regex.IsMatch(fileformat, Config.ImportFileFilterRange))
                        {
                            ValidImportFilesPathList.Add(filePath);
                            LogStatus($"Valid processing file   : '{Path.GetFileName(file)}'", Status.SUCCESS);
                        }
                        else
                        {
                            LogStatus($"Invalid processing file : '{Path.GetFileName(file)}'", Status.WARNING);
                        }
                    }
                    if (ValidImportFilesPathList.Count == 0)
                    {
                        followThrough = false;
                        LogStatus($"{name} - '{inputPath}' : There is no valid file format.", Status.ERROR);
                        LogStatus($"Valid file format : '{Config.ImportFileFilterRangeStr}'", Status.WARNING);
                    }
                }
            }
            else if (inputPath == _ExportPath)
            {
                if(!Directory.Exists(inputPath)) { PrintInvalidInput(name, inputPath); }
            }
        }
        private void CheckValidFormat(string importPath, Dictionary<string, string> formatList)
        {
            foreach (var format in formatList.Values)
            {
                if (File.Exists(importPath)) { PrintCreateFiles(importPath, format); }
                else {
                    string[] fileEntries = Directory.GetFiles(importPath);
                    foreach (string fileName in fileEntries) {
                        PrintCreateFiles(fileName, format);
                    }
                }
            }
            if (OutputPathList.Count == 0)
            {
                LogStatus($"There is same format between import path and selected format.", Status.ERROR);
            }
        }
        private void PrintCreateFiles(string importPath, string format)
        {            string path = importPath.Replace(Path.GetExtension(importPath), format);
            if ((path != importPath) && (Regex.IsMatch(Path.GetExtension(importPath), Config.ImportFileFilterRange)))
            {
                OutputPathList.Add(path);
                LogStatus($"Create File - '{path}'", Status.LOG);
            }
            else
            {
                LogStatus($"Duplicated path file will not generated. - '{path}'", Status.LOG);
            }
        }
        private void PrintInvalidInput(string name, string inputPath)
        {
            followThrough = false;
            LogStatus($"Invalid input! - {name} : '{inputPath}'", Status.ERROR);
        }
        private void ProcessingEnd()
        {
            if (exceptions.Count > 0)
            {
                foreach (var exception in exceptions)
                {
                    LogStatus("Exception: " + exception.Message, Status.WARNING);
                    if (exception.InnerException != null)
                    {
                        LogStatus("Inner Exception: " + exception.InnerException.Message, Status.WARNING);
                    }
                }
                LogStatus("Failed processing configurations.", Status.ERROR);
            }
            else
            {
                LogStatus("Done processing configurations.", Status.SUCCESS);
                LogStatus($"Output Path     : '{Path.GetFullPath(_ExportPath)}'", Status.SUCCESS);
            }
            GenerateLogFile();
            
        }
        public void GenerateCheckedBox()
        {
            followThrough = true;
            if (cbExcel.Checked)
            {
                _ExportFormat.Add(cbExcel.Text, ".xlsx");
            }
            if (cbJson.Checked)
            {
                _ExportFormat.Add(cbJson.Text, ".json");
            }
            if (cbXml.Checked)
            {
                _ExportFormat.Add(cbXml.Text, ".xml");
            }
            if (cbCsv.Checked)
            {
                _ExportFormat.Add(cbCsv.Text, ".csv");
            }
            if (cbSql.Checked)
            {
                _ExportFormat.Add(cbSql.Text, ".sql");
            }

        }
        #region log
        private void GenerateLogFile()
        {
            try
            {
                logFilePath = Path.Combine(_ExportPath, Config.LogFile);
                if (File.Exists(logFilePath)) { File.Delete(logFilePath); }
                LogStatus($"Log file Path   : '{Path.GetFullPath(logFilePath)}'", Status.SUCCESS);
                File.AppendAllText(logFilePath, Configurator.log.ToString());
                Configurator.log.Clear();
            }
            catch (Exception e) { throw new Exception(e.Message + "Error during generating Log file."); }
        }
        private void OnConfigurator_ErrorMessage(object sender, MessageEventArgs e)
        {
            LogStatus($"Warning: {e.Message}", Status.WARNING);
        }
        private void OnConfigurator_StatusMessage(object sender, MessageEventArgs e)
        {
            LogStatus(e.Message, Status.LOG);
        }
        //private void LogStatus(string statusMessage)
        //{
        //   StatusTextBox.AppendText(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " " + statusMessage + Environment.NewLine);
        //   StatusTextBox.ScrollToCaret();
        //   this.Refresh();
        //}
        private void LogStatus(string statusMessage)
        {
            string msg = $"{DateTime.Now.ToString(Config.DateTimeFormat)} {statusMessage}";
            Configurator.log.AppendLine(msg);
        }
        private void LogStatus(string statusMessage, Enum status)
        {
            string msg = $"{DateTime.Now.ToString(Config.DateTimeFormat)} {statusMessage}";
            if (Configurator.CommandLine)
            {
                switch (status)
                {
                    case Status.SUCCESS:
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        }
                    case Status.ERROR:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        }
                    case Status.WARNING:
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        }
                    case Status.LOG:
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                    default: break;
                }
                Configurator.log.AppendLine(msg);
                Console.WriteLine(msg);
                Console.ResetColor();
            }
            else
            {
                switch (status)
                {
                    case Status.SUCCESS:
                        {
                            StatusTextBox.Select(StatusTextBox.TextLength, 0);
                            StatusTextBox.SelectionColor = System.Drawing.Color.Green;
                            break;
                        }
                    case Status.ERROR:
                        {
                            StatusTextBox.Select(StatusTextBox.TextLength, 0);
                            StatusTextBox.SelectionColor = System.Drawing.Color.Red;
                            break;
                        }
                    case Status.WARNING:
                        {
                            StatusTextBox.Select(StatusTextBox.TextLength, 0);
                            StatusTextBox.SelectionColor = System.Drawing.Color.DarkOrange;
                            break;
                        }
                    case Status.LOG:
                        {
                            StatusTextBox.Select(StatusTextBox.TextLength, 0);
                            StatusTextBox.SelectionColor = System.Drawing.Color.Black;
                            break;
                        }
                    default: break;
                }
                Configurator.log.AppendLine(msg);
                StatusTextBox.AppendText(msg + Environment.NewLine);
                StatusTextBox.ScrollToCaret();
                this.Refresh();
            }
        }
        #endregion
        
    }
}
