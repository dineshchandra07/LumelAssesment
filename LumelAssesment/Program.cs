using LumelAssesment.DataAccess;
using LumelAssesment.Helper;
using LumelAssesment.Services;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<LumelDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LumelDefaultConnectionString"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
}
    );
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<ICSVHelper, CSVHelper>();
builder.Services.AddScoped<IOrderdataAccess, OrderdataAccess>();
builder.Services.AddScoped<IProductDataAccess, ProductsDataAccess>();
builder.Services.AddScoped<ICustomerDataAccess, CustomerDataAccess>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
