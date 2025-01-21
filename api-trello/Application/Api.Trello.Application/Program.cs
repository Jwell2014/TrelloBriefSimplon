using Api.Trello.Business.Service;
using Api.Trello.Business.Service.Contrat;
using Api.Trello.Data.Entity;
using Api.Trello.Data.Entity.Model;
using Api.Trello.Data.Repository;
using Api.Trello.Data.Repository.Contrat;
using Api.Trello.DAta.Context.Contrat;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

// Connexion à la base de donnée
string connectionString = configuration.GetConnectionString("BddConnection");
builder.Services.AddDbContext<ITrelloDBContext, TrelloDBContext>(
options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// IOC des repository
builder.Services.AddScoped<IActionRepository, ActionRepository>();
builder.Services.AddScoped<IMembreProjetRepository, MembreProjetRepository>();
builder.Services.AddScoped<IProjetRepository, ProjetRepository>();
builder.Services.AddScoped<IStatusTacheRepository, StatusTacheRepository>();
builder.Services.AddScoped<ITacheRepository, TacheRepository>();
builder.Services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();



// IOC des services
builder.Services.AddScoped<IActionsService, ActionsService>();
builder.Services.AddScoped<IMembreProjetService, MembreProjetService>();
builder.Services.AddScoped<IProjetService, ProjetService>();
builder.Services.AddScoped<IStatutTacheService, StatutTacheService>();
builder.Services.AddScoped<ITacheService, TacheService>();
builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();


builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);






// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(options => options
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
        );

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

