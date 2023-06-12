//using Serilog;

using MagicVilla_Api;
using MagicVilla_Api.Data;
using MagicVilla_Api.Repository;
using MagicVilla_Api.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Using custom Logs
//Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
//    .WriteTo.File("log/villaLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();

//builder.Host.UseSerilog();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

builder.Services.AddScoped<IVillaRepository, VillaRepository>();

builder.Services.AddScoped<IVillaNumberRepository, VillaNumberRepository>();

builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddControllers(option =>
{
    //option.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
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

app.Run();