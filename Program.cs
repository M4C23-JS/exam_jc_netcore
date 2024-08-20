using exam_jc_netcore_react.Models.Repository;
using exam_jc_netcore_react.Models.Repository.Impl;
using exam_jc_netcore_react.Services;
using exam_jc_netcore_react.Services.Impl;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer(); builder.Services.AddScoped<IInstrumentService, InstrumentService>();
builder.Services.AddScoped<IInstrumentRepository>(provider => new InstrumentRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowAll");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
