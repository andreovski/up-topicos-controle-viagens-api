using Microsoft.EntityFrameworkCore;

/// Representa o contexto do banco de dados para a aplicação ControleViagensApi,
/// herdando de <see cref="DbContext"/> do Entity Framework Core.
/// Esta classe é responsável por gerenciar a conexão com o banco de dados e
/// fornecer acesso às entidades mapeadas, permitindo operações CRUD.

namespace ControleViagensApi.Models
{
public class ViagensContext : DbContext
{
    /// Construtor que recebe as opções de configuração do contexto.
    /// Opções de configuração do contexto, como string de conexão e provedores de banco de dados.
    public ViagensContext(DbContextOptions<ViagensContext> options) : base(options) { }

    /// Representa a tabela de viagens no banco de dados.
    /// Permite consultar, adicionar, atualizar e remover registros de viagens.
    public DbSet<Viagem> Viagens { get; set; }
}
}