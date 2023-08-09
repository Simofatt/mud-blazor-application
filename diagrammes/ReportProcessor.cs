using CrystalDecisions.Shared;
using diagrammes.Report;
using System;

using System.Data;
using System.IO;


namespace diagrammes
{
    public static class ReportProcessor
    {

        public static byte[] GenerateReport(DataTable dataTable)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Crv  crv = new Crv();
                crv.Database.Tables["Product"].SetDataSource(dataTable);

                crv.ExportToStream(ExportFormatType.PortableDocFormat).CopyTo(stream);

                return stream.ToArray();
            }
        }
    }
}
