using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;
using N5API.Domain.Abstractions.Repository;
using N5API.Domain.Abstractions.Service;
using N5API.Domain.DTO;
using N5API.Domain.Entities;
using N5API.Infraestructure.Data.Command;
using N5API.Infraestructure.Data.Query;
using N5API.Infraestructure.Data.Repositories;
using N5API.Infraestructure.DataPersistence;
using N5API.Service;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
.WriteTo.Console()
.CreateLogger();

builder.Services.AddLogging(build => build.AddSerilog());

builder.Services.ConfigureRepositoryWrapper();
builder.Services.AddElasticsearch(builder.Configuration);

builder.Services.AddDbContext<PermissionContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("DbPermission")));

builder.Services.Configure<KafkaConfig>(builder.Configuration.GetSection("KafkaConfig"));

builder.Services.AddSingleton<ISerializer<KafkaEvent>>(new KafkaEventSerializer<KafkaEvent>());
builder.Services.AddSingleton<IProducerService, KafkaProducerService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IPermissionTypeRepository, PermissionTypeRepository>();

builder.Services.AddScoped<ICommandHandler<PermissionCreateDTO>, CreatePermissionHandler>();
builder.Services.AddScoped<ICommandHandler<PermissionModifyDTO>, ModifyPermissionHandler>();

builder.Services.AddScoped<IQueryHandler<GetPermissionQuery, PermissionDTO>, GetPermissionHandler>();
builder.Services.AddScoped<IQueryHandler<GetPermissionTypeQuery, PermissionTypeDTO>, GetPermissionTypeHandler>();

// Add services to the container.

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

app.UseCors(builder => builder
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
    );

app.Run();
