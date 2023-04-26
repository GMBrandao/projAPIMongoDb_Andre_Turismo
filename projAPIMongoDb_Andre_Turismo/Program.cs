using Microsoft.Extensions.Options;
using projAPIMongoDb_Andre_Turismo.Config;
using projAPIMongoDb_Andre_Turismo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuration Singleton and AppSetting parameters.
builder.Services.Configure<Andre_TurismoSettings>(builder.Configuration.GetSection("Andre_TurismoSettings"));
builder.Services.AddSingleton<IAndre_TurismoSettings>(s => s.GetRequiredService<IOptions<Andre_TurismoSettings>>().Value);
builder.Services.AddSingleton<CustomerService>();
builder.Services.AddSingleton<AddressService>();
builder.Services.AddSingleton<CityService>();

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
