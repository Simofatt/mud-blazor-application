using CrystalDecisions.Shared;
using diagrammes2.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diagrammes2
{
    public static class ReportProcessor
    {

        public static byte[] GenerateReport(DataTable dataTable)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                CrystalReport1 crv = new CrystalReport1();
                crv.Database.Tables["Product"].SetDataSource(dataTable);

                crv.ExportToStream(ExportFormatType.PortableDocFormat).CopyTo(stream);

                return stream.ToArray();
            }
        }
    }
}
