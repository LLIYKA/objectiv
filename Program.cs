using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Controller = Objective.Controller;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var contro = new Controller();

app.MapGet("/", ([FromQuery] int? roomCount) => contro.Get(roomCount));
app.MapGet("/median", ([FromQuery] int? roomCount) => contro.GetMedian(roomCount));

app.Run();