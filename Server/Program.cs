using BL;
using BL.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IBL, BLManager>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(c => c.AddPolicy("AllowAll", option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyHeader()));

var app = builder.Build();

app.UseCors("AllowAll");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
