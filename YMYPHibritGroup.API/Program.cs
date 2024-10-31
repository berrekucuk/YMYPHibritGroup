using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using YMYPHibritGroup.API.Model;
using YMYPHibritGroup.API.Model.Repositories;
using YMYPHibritGroup.API.Model.Services;

var builder = WebApplication.CreateBuilder(args);


//AddScoped : Request, response d�n���nceye kadar ayn� nesne �rne�ini kullan�r.
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

//AddSingleton : Uygulama aya�a kalkt���nda bir kere nesne �retir ve kapat�lana kadar o nesneyi kullan�r. Veri taban�na gidilen ve business kullan�lan kodlarda kullan�lmaz.
builder.Services.AddSingleton<SeoHelper>(); // Basit yard�mc� nesneler i�in kullan�l�r.
builder.Services.AddScoped<SeoService>();

// AddTransient : Her constructor i�in s�f�rdan memory de nesne �rne�i olu�turur.
//builder.Services.AddTransient<SeoHelper>();


// Add services to the container.

builder.Services.AddMvc(opt => { opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;}); //C# kendi hata kodunu kapatmay� ve sadece Fluent Validation �al��mas�n� sa�lar.

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
