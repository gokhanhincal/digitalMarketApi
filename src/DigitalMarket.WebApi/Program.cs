using DigitalMarket.Core.Interfaces;
using DigitalMarket.Core.Middlewares;
using DigitalMarket.Core.Services;
using DigitalMarket.Data.Repositories;
using DigitalMarketing.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<OrderDbSettings>(
    builder.Configuration.GetSection(nameof(OrderDbSettings)));

builder.Services.AddSingleton<IOrderDbSettings>(sp => sp.GetRequiredService<IOptions<OrderDbSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("OrderDbSettings:ConnectionString")));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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

app.AddGlobalErrorHandler();

app.Run();