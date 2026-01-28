using Microsoft.EntityFrameworkCore;
using SmartCash.Aplicacao;
using SmartCash.Aplicacao.Interfaces;
using SmartCash.Repositorio;
using SmartCash.Repositorio.Contexto;
using SmartCash.Repositorio.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
builder.Services.AddScoped<IEmpresaRepositorio, EmpresaRepositorio>();
builder.Services.AddScoped<IEmpresaAplicacao, EmpresaAplicacao>();
builder.Services.AddScoped<ITransacaoRepositorio, TransacaoRepositorio>();
builder.Services.AddScoped<ITransacaoAplicacao, TransacaoAplicacao>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SmartCashContexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
