using Microsoft.EntityFrameworkCore;
using YMYPHibrit3GroupEFCore.API.Model.Repositories;
using YMYPHibrit3GroupEFCore.API.Model.Repositories.Entities;
using YMYPHibrit3GroupEFCore.API.Model.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("SqlServer");

    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

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
