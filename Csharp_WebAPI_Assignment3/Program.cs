using Csharp_WebAPI_Assignment3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Reflection;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Csharp_WebAPI_Assignment3",
        Version = "v1",
        Description = "Movie Application",
        TermsOfService = new Uri("Https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Pim",
            Url = new Uri("Https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "The Fun License",
            Url = new Uri("Https://example.com/license")
        }
    });
    //using System.Reflection
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

//connectionstring
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MoviesDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(Program));

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
