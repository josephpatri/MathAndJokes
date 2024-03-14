using Microsoft.OpenApi.Models;
using Application;
using Persistence;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "�Maths and Jokes Api!", Version = "v1" });
});

builder.Services.AddAplicationLayer();
builder.Services.AddPersistenceInfra(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api version V1");
    });
}

app.UseHttpsRedirection();

app.UseErrorHandlingMiddleWare();

app.UseAuthorization();

app.MapControllers();

app.Run();
