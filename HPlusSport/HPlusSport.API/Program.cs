using HPlusSport.API.Models;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers()
//    .ConfigureApiBehaviorOptions(options =>
//    {
//        options.SuppressModelStateInvalidFilter = true;
//    });

builder.Services.AddControllers();

builder.Services.AddApiVersioning(options => {
    // Used by URL Versioning
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified= true;

    // Used by Header Versioning (*** Comment out to implement Query String Versioning ***)
    // Usage: https://localhost:7218/products?api-version=2.0
    // options.ApiVersionReader = new HeaderApiVersionReader("X-API-Version");

    // In addition to commenting out the above line, to implement Query String Versioning, you could:
    options.ApiVersionReader = new QueryStringApiVersionReader("hps-api-version");
    // Usage: https://localhost:7218/products?hps-api-version=2.0
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// *** To remediate "ERROR: Fetch errorresponse status is 500 https://localhost:7218/swagger/v1/swagger.json"
builder.Services.AddVersionedApiExplorer(options => 
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShopContext>(options =>
{
    options.UseInMemoryDatabase("Shop");
});

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
