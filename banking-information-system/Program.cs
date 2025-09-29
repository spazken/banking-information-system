var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// services property is used to register services in the dependency injection container.
var services = builder.Services;

ConfigureServices(services);
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

var webHostEnvironment = app.Environment;
Configure(app, webHostEnvironment);
// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();*/



app.Run();


void ConfigureServices(IServiceCollection serviceCollection)
{
    serviceCollection.AddControllers();
    serviceCollection.AddEndpointsApiExplorer();
    serviceCollection.AddSwaggerGen();
}

void Configure(WebApplication webApplication, IWebHostEnvironment webHostEnvironment1) { 
    if (webHostEnvironment1.IsDevelopment())
    {
        webApplication.UseSwagger();
        webApplication.UseSwaggerUI();
    }
    webApplication.UseHttpsRedirection();
    webApplication.UseAuthorization();
    webApplication.MapControllers();
}
