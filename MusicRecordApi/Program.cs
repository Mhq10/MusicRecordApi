using MusicRecordApi.Interfaces;
using MusicRecordApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();
builder.Services.AddSingleton<IRecordInterface, RecordsRepository>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReadOnly", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .WithMethods("GET");
    });
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
