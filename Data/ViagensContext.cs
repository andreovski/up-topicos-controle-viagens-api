using Microsoft.EntityFrameworkCore;

namespace ControleViagensApi.Models
{
    public class ViagensContext : DbContext
    {
        public ViagensContext(DbContextOptions<ViagensContext> options) : base(options) { }
        public DbSet<Viagem> Viagens { get; set; }
    }
}