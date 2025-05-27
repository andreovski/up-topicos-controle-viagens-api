using System.Linq;

namespace ControleViagensApi.Models
{
    public static class SeedViagens
    {
        public static void Seed(ViagensContext context)
        {
            if (!context.Viagens.Any())
            {
                context.Viagens.AddRange(
                    new Viagem { Destino = "Rio de Janeiro", DataPartida = DateTime.Parse("2024-06-01"), DataRetorno = DateTime.Parse("2024-06-07"), Preco = 1200.00, NomeViajante = "João Silva" },
                    new Viagem { Destino = "São Paulo", DataPartida = DateTime.Parse("2024-06-05"), DataRetorno = DateTime.Parse("2024-06-10"), Preco = 900.00, NomeViajante = "Maria Souza" },
                    new Viagem { Destino = "Salvador", DataPartida = DateTime.Parse("2024-06-10"), DataRetorno = DateTime.Parse("2024-06-17"), Preco = 1500.00, NomeViajante = "Carlos Oliveira" },
                    new Viagem { Destino = "Fortaleza", DataPartida = DateTime.Parse("2024-06-15"), DataRetorno = DateTime.Parse("2024-06-22"), Preco = 1300.00, NomeViajante = "Ana Paula" },
                    new Viagem { Destino = "Curitiba", DataPartida = DateTime.Parse("2024-06-20"), DataRetorno = DateTime.Parse("2024-06-25"), Preco = 1100.00, NomeViajante = "Pedro Santos" },
                    new Viagem { Destino = "Belo Horizonte", DataPartida = DateTime.Parse("2024-06-25"), DataRetorno = DateTime.Parse("2024-07-01"), Preco = 1000.00, NomeViajante = "Fernanda Lima" },
                    new Viagem { Destino = "Brasília", DataPartida = DateTime.Parse("2024-07-01"), DataRetorno = DateTime.Parse("2024-07-07"), Preco = 1400.00, NomeViajante = "Lucas Costa" },
                    new Viagem { Destino = "Recife", DataPartida = DateTime.Parse("2024-07-05"), DataRetorno = DateTime.Parse("2024-07-12"), Preco = 1600.00, NomeViajante = "Juliana Alves" },
                    new Viagem { Destino = "Porto Alegre", DataPartida = DateTime.Parse("2024-07-10"), DataRetorno = DateTime.Parse("2024-07-16"), Preco = 1250.00, NomeViajante = "Rafael Pereira" },
                    new Viagem { Destino = "Manaus", DataPartida = DateTime.Parse("2024-07-15"), DataRetorno = DateTime.Parse("2024-07-22"), Preco = 1700.00, NomeViajante = "Patrícia Gomes" }
                );
                context.SaveChanges();
            }
        }
    }
}