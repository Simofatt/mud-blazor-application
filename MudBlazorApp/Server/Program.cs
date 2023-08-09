
using Application.Interfaces.Repositories;
using AutoMapper;
using Infrastructure;
using Infrastructure.ApiClient;
using Infrastructure.Context;
using Infrastructure.MappingProfiles;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Infrastructure.Services;
using LijsDev.CrystalReportsRunner.Core;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using System.Security.Cryptography;
using Infrastructure.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddDbContext<AuditableContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefautlConnection")));
builder.Services.AddTransient<IUnitOfWork<int>, UnitOfWork<int>>();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(MappingProfiles));


builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();


var app = builder.Build();
/*using var engine = new CrystalReportsEngine();

// Optionally customize viewer settings
engine.ViewerSettings.AllowedExportFormats =
    ReportViewerExportFormats.PdfFormat |
    ReportViewerExportFormats.ExcelFormat;

engine.ViewerSettings.ShowRefreshButton = false;
engine.ViewerSettings.ShowCopyButton = false;
engine.ViewerSettings.ShowGroupTreeButton = false;

engine.ViewerSettings.SetUICulture(Thread.CurrentThread.CurrentUICulture);



var report = new Report("C:/Users/Simofatt/test.rpt", "test")
{
    Connection = CrystalReportsConnectionFactory.CreateSqlConnection(
        "localhost",
        "test")
};

report.Parameters.Add("ReportFrom", new DateTime(2022, 01, 01));
report.Parameters.Add("UserName", "Gerardo");

await engine.ShowReport(report);
*/


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseDeveloperExceptionPage();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
