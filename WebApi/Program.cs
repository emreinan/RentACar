using Application;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache(); // InMemory Cache
//builder.Services.AddStackExchangeRedisCache(options => options.Configuration = "localhost:6379"); // Redis Cache

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment()) // Development oratmýnda 
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//if (app.Environment.IsProduction()) // Production ortamýnda
	app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
