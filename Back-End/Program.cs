using Back_End.Data;
using Back_End.Services;
using Back_End.Services.Camera;
using Back_End.Services.Interfaces;
using Back_End.Services.Login;
using Back_End.Services.Trafego;
using Microsoft.EntityFrameworkCore;
// using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineConnection")); });
// builder.Services.AddDbContext<DataContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });

builder.Services.AddScoped<IProprietarioService, ProprietarioService>();
builder.Services.AddScoped<IRuaService, RuaService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IVeiculoService, VeiculoService>();
builder.Services.AddScoped<IEmissaoService, EmissaoService>();
builder.Services.AddScoped<ICameraService, CameraService>();
builder.Services.AddScoped<ITrafegoService, TrafegoService>();

// builder.Services.AddScoped<IViaCep, ViaCep>();
// builder.Services.AddRefitClient<IIntegracao>().ConfigureHttpClient(c => { c.BaseAddress = new Uri("https://viacep.com.br"); });
// builder.Services.AddHttpClient<IViaCepClient, ViaCepClient>(client => { client.BaseAddress = new Uri("https://viacep.com.br/"); });
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

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
