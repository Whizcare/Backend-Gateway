using Audit_BusinessLogic;
using Audit_DataEntites;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(
    policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    }));

var config = builder.Configuration.GetConnectionString("AuditString");
builder.Services.AddDbContext<Audit_DataEntites.Entity.AuditDbContext>(options => options.UseSqlServer(config));

builder.Services.AddScoped<IAuditLogic, AuditLogic>();
builder.Services.AddScoped<IAuditData, AuditDataRepo>();


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

