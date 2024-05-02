using Microsoft.EntityFrameworkCore;
using Zadatak2_Data.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
