using ECommerce.API;
using ECommerce.BL;
using ECommerce.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDALServices();
builder.Services.AddBLServices();
builder.Services.AddAPIServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
