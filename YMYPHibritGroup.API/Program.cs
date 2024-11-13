using YMYPHibritGroup.API.Extension;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddServiceAndRepositoryAndFilterExt();
builder.Services.AddMvcExt();
builder.Services.AddSwaggeExt();
builder.Services.AddValidationExt();

var app = builder.Build();

app.AddCommonMiddleware();

app.MapControllers();

app.Run();
