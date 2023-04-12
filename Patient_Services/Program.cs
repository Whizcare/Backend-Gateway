
using DataEntities;
using DataEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Patient_Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Patient Services",
        Version = "v1"
    });
});

var config = builder.Configuration.GetConnectionString("PatientDatabase");
builder.Services.AddDbContext<ProjectDatabaseContext>(options => options.UseSqlServer(config));

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
        )
    );

builder.Services.AddScoped<IPatient, PatientRepo>();
builder.Services.AddScoped<IPatientLogic, PatientLogic>();
builder.Services.AddScoped<IHealthHistory, HealthHistoryRepo>();
builder.Services.AddScoped<IHealthHistoryLogic, HealthHistoryLogic>();
builder.Services.AddScoped<IPrescriptions, Presciptions>();
builder.Services.AddScoped<IPresciptionLogic, PrescriptionsLogic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
