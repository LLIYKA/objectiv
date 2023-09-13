using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Controller = Objective.Controller;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
var app = builder.Build();

var contro = new Controller();
app.UseCors(builder => builder.AllowAnyOrigin());
app.MapGet("/", ([FromQuery] int? roomCount) => contro.Get(roomCount));
app.MapGet("/medians", ([FromQuery] int? roomCount) => contro.GetMedian(roomCount));

app.Run();