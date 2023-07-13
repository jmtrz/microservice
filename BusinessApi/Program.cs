using BusinessApi.Data;
using BusinessApi.Interfaces;
using BusinessApi.Middlware;
using BusinessApi.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IInventory, InventoryService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<InventoryDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("InventoryDbConnection"));
});

// builder.Services.AddSqlite<InventoryDbContext>(builder.Configuration.GetConnectionString("InventoryDbConnection"));

builder.Services.AddSwaggerGen();

builder.Services.AddTransient<GlobalExceptionHandlerMiddlware>();

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
