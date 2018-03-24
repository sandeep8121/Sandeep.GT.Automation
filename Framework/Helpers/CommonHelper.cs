using AutoItX3Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Framework.Configuration;
using Framework.Base;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Framework.Helpers
{
    public  class CommonHelper
    {

        

        public static void IntroduceSleep(int inMilliSec)
        {
            try
            {
                Thread.Sleep(inMilliSec);
            }
            catch (ThreadInterruptedException e)
            {
                Trace.WriteLine("Thread Sleep timeout " + e.StackTrace);
            }
        }


        public static void TakeScreenShot()
        {
            try
            {
                if (Settings.IsScreenShot.Equals("Y"))
                {
                    var testName = ScenarioContext.Current.ScenarioInfo.Title;                   
                    Screenshot ss = ((ITakesScreenshot)DriverContext.Driver).GetScreenshot();
                    string fp = Path.Combine(AssemblyDirectory, "ScreenShots", testName) + "_" + DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt") + ".png";                   
                    ss.SaveAsFile(fp, ScreenshotImageFormat.Png);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static object DocumentUpload(string documentToUpload)
        {
            var isUploadWindowOpen = 0;
            try
            {
                var AutoIT = new AutoItX3();                
                IntroduceSleep(1000);
                /*For Firefox Browser
                AutoIT.WinWait("File Upload");        
                AutoIT.WinActivate("File Upload");
                */
                AutoIT.WinWait("Open");
                AutoIT.WinActivate("Open");
                AutoIT.Send(documentToUpload);
                IntroduceSleep(1000);
                AutoIT.Send("{ENTER}");
                IntroduceSleep(700);
                isUploadWindowOpen = AutoIT.WinExists("File Upload");                
            }
            catch (ThreadInterruptedException e)
            {
                Trace.WriteLine("Document upload failed because " + "\n" + e.InnerException.Message + "\n" + e.StackTrace);
            }

            return isUploadWindowOpen;
        }


        public static void LoginNtlm(string userName, string password)
        {
            try
            {
                var AutoIT = new AutoItX3();                           
                AutoIT.WinWaitActive("Authentication Required", "", 5);
                AutoIT.Send(userName);               
                AutoIT.Send("{TAB}");              
                AutoIT.Send(password);
                AutoIT.Send("{ENTER}");
            }

            catch(Exception e)
            {
                Trace.WriteLine("User login failed" + "\n" + e.InnerException.Message + "\n" + e.StackTrace);
            }
        }


        public static IEnumerable<KeyValuePair<string, string>> ExcelDcoumentTypes(string fileName, int workSheet)
        {
            //create the Application object we can use in the member functions.
            Microsoft.Office.Interop.Excel.Application _excelApp = new Microsoft.Office.Interop.Excel.Application();
            _excelApp.Visible = true;
                       
            //open the workbook
            Workbook workbook = _excelApp.Workbooks.Open(fileName,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);

            //select the first sheet        
            Worksheet worksheet = (Worksheet)workbook.Worksheets[workSheet];           

            //find the used range in worksheet
            Range excelRange = worksheet.UsedRange;

            //get an object array of all of the cells in the worksheet (their values)
            object[,] valueArray = (object[,])excelRange.get_Value(
                        XlRangeValueDataType.xlRangeValueDefault);
         
            Dictionary<string, string> docMap = new Dictionary<string, string>();
         
            //access the cells
            for (int Exlrow = 1; Exlrow <= worksheet.UsedRange.Rows.Count; ++Exlrow)
            {
                var value1 = valueArray[Exlrow, 1].ToString();
                var value2 = valueArray[Exlrow, 2].ToString();
               // yield return new KeyValuePair<string, string>(value1, value2);
                 docMap.Add(value1, value2);
            }

            //clean up stuffs
            workbook.Close(false, Type.Missing, Type.Missing);
            Marshal.ReleaseComObject(workbook);

            _excelApp.Quit();
            Marshal.FinalReleaseComObject(_excelApp);

             return docMap;
        }


        /// <summary>
        /// This gets the path of the files included in the project
        /// </summary>
        public static string AssemblyDirectory {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
