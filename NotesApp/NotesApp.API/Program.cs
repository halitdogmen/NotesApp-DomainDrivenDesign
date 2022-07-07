using NotesApp.API.Extensions;
using NotesApp.Application.Extensions;
using NotesApp.Infrastructure.Caching.Extensions;
using NotesApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddInfrastructureCachingLayer();
builder.Services.AddApplicationLayer();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
