using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrystalReportsApplication1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public async Task ReportRpt()
        {


            var reportPath = "Cry"


            ReportDocument rd = new ReportDocument();
            rd.Load(reportPath, OpenReportMethod.OpenReportByTempCopy);
            rd.SetDataSource(printlist);

            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                rd.Dispose();
                return File(stream, "application/pdf", request.ModelName.ToUpper() + ".pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

         



        }
    
}
}
