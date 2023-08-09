using DTO.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace diagrammes
{
    public static class Extension
    {
        public static DataTable ConvertAuthorsToDataTable(this List<AuthorDto> authors)
        {
            DataTable dataTable = new DataTable();



            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));


            foreach (var author in authors)
            {
               
                dataTable.Rows.Add(author.FirstName, author.LastName);

            }

            return dataTable;
        }
    }

}
