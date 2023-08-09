using LijsDev.CrystalReportsRunner.Core;
using Synaplic.UniRH.Shared.Wrapper;
using System;
using System.Threading.Tasks;
using System.IO;

namespace ServerMudBlazorApp.Server
{
    public class ShowCrystalReport
    {
        public ShowCrystalReport() { }

        public async Task SaveCrystalReport(string destinationFilePath)
        {
            using var engine = new CrystalReportsEngine();

            // Optionally customize viewer settings (not required for saving the report)
            engine.ViewerSettings.AllowedExportFormats =
                ReportViewerExportFormats.PdfFormat |
                ReportViewerExportFormats.ExcelFormat;

            engine.ViewerSettings.ShowRefreshButton = false;
            engine.ViewerSettings.ShowCopyButton = false;
            engine.ViewerSettings.ShowGroupTreeButton = false;

            engine.ViewerSettings.SetUICulture(Thread.CurrentThread.CurrentUICulture);

            var report = new Report("C:\\Users\\Simofatt\\test.rpt", "test") { };
            /* {
                 //Connection = CrystalReportsConnectionFactory.CreateSqlConnection("localhost", "test")
             };
            */
            // report.Parameters.Add("ReportFrom", new DateTime(2022, 01, 01));
            //report.Parameters.Add("UserName", "Gerardo");

            // Save the report to the specified file
            
           
            await engine.Export(report, ReportExportFormats.CrystalReport, destinationFilePath, overwrite: false);
        }
    }
}


