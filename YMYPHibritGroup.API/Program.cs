using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using YMYPHibritGroup.API.Filters;
using YMYPHibritGroup.API.Model;
using YMYPHibritGroup.API.Model.Repositories;
using YMYPHibritGroup.API.Model.Services;

var builder = WebApplication.CreateBuilder(args);


//AddScoped : Request, response dönüþünceye kadar ayný nesne örneðini kullanýr.
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<NotFoundProductFilter>();



// Add services to the container.

builder.Services.AddMvc(opt => { 
    
    //add global filter
    //opt.Filters.Add<MyResourceFilter>();

    opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;}); //C# kendi hata kodunu kapatmayý ve sadece Fluent Validation çalýþmasýný saðlar.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

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
