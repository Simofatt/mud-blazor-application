
using Microsoft.AspNetCore.Mvc;
using Synaplic.UniRH.Shared.Wrapper;
using Infrastructure.Services;
using Infrastructure.Models;
using diagrammes.Report;
using diagrammes;
using DTO.DataModels;
using AutoMapper;
using Azure.Core;

namespace MudBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrystalReport : ControllerBase
    {
        private readonly string _reportFileName = "report.rpt";// Provide the desired file path and name
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

       // private readonly ILogger<CrystalReport> _logger;

        public CrystalReport(IAuthorService authorService,   IMapper mapper)
        {
            _authorService = authorService;
           // _logger = logger;
            _mapper = mapper;
        }
      /*  [HttpGet("executeCrystalReport")]
        public async Task<IActionResult> ExecuteCrystalReport()
        {
            ShowCrystalReport crystalReport = new ShowCrystalReport();
            // Get the user's Downloads folder path
            string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string _reportFilePath = Path.Combine(downloadsFolder, "Downloads", _reportFileName);

            await crystalReport.SaveCrystalReport(_reportFilePath);



            if (!System.IO.File.Exists(_reportFilePath))
                return NotFound();

            /*  // Read the report file content 
              byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(_reportFilePath);

              // Set the content type based on the file format (if known)
              var contentType = "application/rpt"; // Adjust the content type as needed

              // Return the file content as a FileContentResult to trigger download
              return new FileContentResult(fileBytes, contentType)
              {
                  FileDownloadName = "report.rpt" // Adjust the file name as needed
              };
            return Ok();
        }
      */
        /*[HttpGet("GetAuthors")]
        public async Task<Result<IEnumerable<Author>>> GetAuthors()
        {
           return await _authorService.GetAuthors(); 
           
        }*/

        [HttpGet("ReportRpt")]
        public async Task<IActionResult> ReportRpt()
        {
            
                var authors =_mapper.Map<List<AuthorDto>>( await _authorService.GetAuthors());

                var reportPath = Path.Combine(Server.MapPath($@"~/Reports/{request.ModelName}.rpt"));


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
            
               /* var dataTable = Extension.ConvertAuthorsToDataTable(authors);

                var pdfBytes = ReportProcessor.GenerateReport(dataTable);

                // Return the PDF file for download
                return File(pdfBytes, "application/pdf", "report.pdf");*/
               
            
           

        }
    }




}
