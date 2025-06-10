using ControleViagensApi.Models; 
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args); // Cria o builder para configurar a aplicação

// Configura o contexto do banco de dados usando SQLite e a string de conexão do appsettings.json
builder.Services.AddDbContext<ViagensContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Adiciona suporte a controllers para a API
builder.Services.AddControllers();

var app = builder.Build(); // Constrói a aplicação

app.UseCors(); // Habilita o CORS (Cross-Origin Resource Sharing) para permitir requisições de diferentes origens

// Garante que o banco de dados será criado ao iniciar a aplicação e executa o seed de dados
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ViagensContext>(); // Obtém o contexto do banco de dados
    db.Database.EnsureCreated(); // Cria o banco de dados se não existir
    SeedViagens.Seed(db); // Popula o banco de dados com dados iniciais
}

app.UseHttpsRedirection(); // Redireciona requisições HTTP para HTTPS
app.UseAuthorization(); // Habilita a autorização (controle de acesso)
app.MapControllers(); // Mapeia os endpoints dos controllers
app.Run(); // Inicia a aplicação