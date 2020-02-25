using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
            getExcelFile(validImportFile);

        }
        public static void getExcelFile(string path)
        {
            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open($"{path}");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 1; i <= rowCount; i++)
            {
                List<string> title_row = new List<string>() { };
                List<string> row = new List<string>() { };
                
                for (int j = 1; j <= colCount; j++)
                {
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null) {
                        string val = xlRange.Cells[i, j].Value2.ToString();
                        if (i == 1)
                        {
                            title_row.Add(val);
                        }
                        else
                        {
                            row.Add(val);
                        } 
                        //string n = (xlRange.Cells[i, j].Value2.ToString() + "\t");
                    }
                }
                if (i == 1)
                {
                    Title_Row.Add(title_row);
                }
                else { Rows.Add(row); }
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
    }
}
