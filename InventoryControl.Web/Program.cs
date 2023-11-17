using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;
using AlmacenSQLiteEntities;
using AlmacenDataContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

string databasePath = Path.Combine(Environment.CurrentDirectory,"..","Libraries","AlmacenSQLiteEntities","Almacen.db");

builder.Services.AddDbContext<Almacen>(options => options.UseSqlite($"Connection: Filename= {databasePath}"));

var app = builder.Build();

if(!app.Environment.IsDevelopment()) // Si esta en modo development
{
    app.UseHsts();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseDefaultFiles();

app.UseStaticFiles();

app.MapRazorPages();

//app.MapGet("/", () => "Hello World!");

app.Run();
