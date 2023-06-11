using Data;
using Data.AccessLayer;
using Data.Models;
using Data.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CatalogApi.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("SqlDbConnectionString");

builder.Services.AddDbContext<StudentsDbContext>(options => options.UseSqlServer(connString));

builder.Services.AddScoped<IAccessLayer, AccessLayer>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<InvalidIdExceptionFilter>();
    options.Filters.Add<DuplicatedIdExceptionFilter>();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => AddSwaggerDocumentation(o));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void AddSwaggerDocumentation(SwaggerGenOptions o)
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
}