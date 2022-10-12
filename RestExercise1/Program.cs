using Microsoft.EntityFrameworkCore;
using RestExercise8;
using RestExercise8.Managers;

string allowAllPolicy = "AllowAll";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowAllPolicy,
                              policy =>
                              {
                                  policy.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader();
                              });
});

builder.Services.AddDbContext<RestContext>(opt => opt.UseSqlServer(Secrets.ConnectionString));

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseCors(allowAllPolicy);

app.MapControllers();

app.Run();
