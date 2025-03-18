
using DDDCommerceBCC.Infra.Interfaces;
using DDDCommerceBCC.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
