using Microsoft.EntityFrameworkCore;
using WideWorldImporters.Warehouse.Context;
using WideWorldImporters.Warehouse.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WideWorldImportersStandardContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("AzureDb")));

builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();

builder.Services.AddAutoMapper(typeof(WarehouseRepository));

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
