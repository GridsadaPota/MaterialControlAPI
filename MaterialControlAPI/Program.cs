using MaterialControlAPI.Interface;
using MaterialControlAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Service
builder.Services.AddSingleton<IMatTypeService, MatTypeService>();
builder.Services.AddSingleton<IMatLocalService, MatLocalService>();
builder.Services.AddSingleton<IMatShelfService, MatShelfService>();
builder.Services.AddSingleton<IMatStockMainService, MatStockMainService>();
builder.Services.AddSingleton<IMatStockInService, MatStockInService>();
builder.Services.AddSingleton<IMatStockOutService, MatStockOutService>();




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
