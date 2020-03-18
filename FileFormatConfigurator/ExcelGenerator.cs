using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace FileFormatConfigurator
{
    public class ExcelGenerator
    {
        public static List<List<string>> Title_Row = new List<List<string>>() { };
        public static List<List<string>> Rows = new List<List<string>>() { };
        public ExcelGenerator()
        {
        }
        public static void Load(string validImportFile, List<string> outputFilePathList)
        {
            KillSpecificExcelFileProcess(Path.GetFileNameWithoutExtension(validImportFile).ToString());
            getExcelFile(validImportFile);
        }
        public static void getExcelFile(string path)
        {
            //Create COM Objects. Create a COM object for everything that is referenced
            Application xlApp = new Excel.Application();
            Workbook xlWorkbook = xlApp.Workbooks.Open($"{path}");
            Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Range xlRange = xlWorksheet.UsedRange;
            Names wbNames = xlWorkbook.Names;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            int titleRowStart = 1;
            int titleRowEnd = rowCount;
            int titleColStart = 1;
            int titleColEnd = 1;

            foreach (Name range in wbNames)
            {
                var  rangeName = range.NameLocal;
                List<string> title_row = new List<string>() { };
                if (rangeName.Contains("Key"))
                {
                    string titleRange = range.RefersToLocal;
                    string titleStartCell = Regex.Match(titleRange, @"'!\$.+\:").Value.ToString();
                    string titleEndCell = Regex.Match(titleRange, @":\$.+").Value.ToString();

                    titleStartCell = Regex.Replace(titleStartCell, @"('!\$)|(\$)|(:)", "");
                    titleEndCell   = Regex.Replace(titleEndCell, @"('!\$)|(\$)|(:)", "");

                    titleRowStart = Int32.Parse(Regex.Match(titleStartCell, @"\d").Value.ToString());
                    titleRowEnd   = Int32.Parse(Regex.Match(titleEndCell, @"\d").Value.ToString());

                    titleColStart = (Char.Parse(Regex.Match(titleStartCell, @"[a-zA-Z]").Value.ToString()) - 65 + 1);
                    titleColEnd   = (Char.Parse(Regex.Match(titleEndCell, @"[a-zA-Z]").Value.ToString()) - 65 + 1);
                    
                    for (int i = titleRowStart; i <= titleRowEnd; i++)
                    {
                        for (int j = titleColStart; j <= titleColEnd; j++)
                        {
                            string val = xlRange.Cells[i, j].Value2.ToString();
                            title_row.Add(val);
                        }
                    }
                    Title_Row.Add(title_row);
                }
            }
            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = titleRowEnd+1; i <= rowCount; i++)
            {
                //값들이 첫row만 읽어옴
                List<string> row = new List<string>() { };
                
                for (int j = 1; j <= colCount; j++)
                {
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null) {
                        string val = xlRange.Cells[i, j].Value2.ToString();
                        row.Add(val);
                        //string n = (xlRange.Cells[i, j].Value2.ToString() + "\t");
                    }
                }
                Rows.Add(row); 
            }

            //cleanup

            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }


        internal static void KillSpecificExcelFileProcess(string excelFileName)
        {
            var processes = from p in Process.GetProcessesByName("EXCEL")
                            select p;

            foreach (var process in processes)
            {
                if (process.MainWindowTitle.Contains(excelFileName))
                    process.Kill();
            }
        }
    }
}
