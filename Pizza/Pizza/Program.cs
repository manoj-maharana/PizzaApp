using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Pizza.API.Filters;
using Pizza.API.Mappers;
using Pizza.Data;
using Pizza.Data.Interface;
using Pizza.Domain;
using Pizza.Domain.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApiVersioning();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//create another static class
builder.Services.AddScoped<IPizzaDeliveryServices, PizzaDeliveryServices>();
builder.Services.AddScoped<IPizzaDeliveryData, PizzaDeliveryData>();
//All the services need to register here

builder.Services.AddSwaggerGen();
builder.Services.AddCors(c =>
{
    c.AddPolicy(name:"AllowOrigin", builder => builder
    //.WithOrigins("http://localhost:4200")
    .AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Pizza API",
        Description = "An ASP.NET Core Web API for managing Pizza items",
       // TermsOfService = new Uri("https://example.com/terms"),
       
    });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers(config =>
{
   
    config.Filters.Add<HttpGlobalExceptionFilter>();
    config.Filters.Add(new ResponseCacheAttribute() { NoStore = true, Location = ResponseCacheLocation.None });
    config.AllowEmptyInputInBodyModelBinding = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();
app.UseCors("AllowOrigin");
app.UseHttpsRedirection();
app.UseAuthorization();

//app.MapControllers();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();