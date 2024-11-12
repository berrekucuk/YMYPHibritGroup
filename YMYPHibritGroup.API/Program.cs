using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using YMYPHibritGroup.API.Filters;
using YMYPHibritGroup.API.Model;
using YMYPHibritGroup.API.Model.Repositories;
using YMYPHibritGroup.API.Model.Services;

var builder = WebApplication.CreateBuilder(args);


//AddScoped : Request, response d�n���nceye kadar ayn� nesne �rne�ini kullan�r.
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<NotFoundProductFilter>();



// Add services to the container.

builder.Services.AddMvc(opt => { 
    
    //add global filter
    //opt.Filters.Add<MyResourceFilter>(); //Filterlar� burada tan�mlarsak t�m enpointler i�in ge�erlidir.

    opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;}); //C# kendi hata kodunu kapatmay� ve sadece Fluent Validation �al��mas�n� sa�lar.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

var app = builder.Build();


app.Use(async (context, next) =>
{
    Console.WriteLine("1.middleware request");
    var request = context.Request;

    await next();

    Console.WriteLine("1.middleware response");

    var response = context.Response;
});

app.Use(async (context, next) =>
{
    Console.WriteLine("2.middleware request");
    var request = context.Request;

    await next();

    Console.WriteLine("2.middleware response");

    var response = context.Response;
});

//app.Run(context =>
//{
//    Console.WriteLine("Terminal middleware");

//    return Task.CompletedTask;
//});

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
