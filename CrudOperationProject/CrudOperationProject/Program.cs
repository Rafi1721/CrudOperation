using CrudOperationProject.Operations.Interface;
using CrudOperationProject.Repository.Interface;
using CrudOperationProject.Operations;
using CrudOperationProject.Repository;
using CrudOperationProject.Helpers.Interface;
using CrudOperationProject.Model;
using System.Text.Json.Serialization;
using System.Text;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using ServiceStack.Configuration;
using System.Configuration;
using CrudOperationProject.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddCors();
    services.AddControllers();
 


    services.AddScoped<Ishopcakeops, shopcakeOps>();
    services.AddSingleton<Ishopcakerepo, shopcakeRepo>();
    services.AddScoped<IAPIResponseHelper, APIResponseHelper>();
    services.AddScoped<ICSVHelper, CSVHelper>();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "CrudOperationProject", Version = "v1" });
    });

}






builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
