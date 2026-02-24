using Filmes.WebAPI.BdContextFilme;
using Filmes.WebAPI.Intterface;
using Filmes.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<FilmeContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Adiciona o repositorio ao container de injeção de dependencia
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();

//Adiciona o serviço de Controllers
builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();

app.Run();
