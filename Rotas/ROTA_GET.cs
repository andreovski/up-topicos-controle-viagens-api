using Microsoft.AspNetCore.Mvc; 
using ControleViagensApi.Models;
using Microsoft.EntityFrameworkCore; 

namespace ControleViagensApi.Rotas
{
    // Indica que esta classe é um controlador de API.
    [ApiController]
    // Define a rota base para este controlador: api/viagens
    [Route("api/viagens")]
    public class ViagemGetController : ControllerBase
    {
        // Contexto do banco de dados, usado para acessar os dados das viagens.
        private readonly ViagensContext _context;

        // Construtor que recebe o contexto do banco de dados via injeção de dependência.
        public ViagemGetController(ViagensContext context)
        {
            _context = context;
        }

        // Endpoint GET para retornar todas as viagens.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Viagem>>> GetAll()
        {
            // Busca todas as viagens no banco de dados de forma assíncrona.
            return await _context.Viagens.ToListAsync();
        }

        // Endpoint GET para retornar uma viagem específica pelo ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<Viagem>> GetById(int id)
        {
            // Busca a viagem pelo ID informado.
            var viagem = await _context.Viagens.FindAsync(id);
            // Se não encontrar, retorna 404 Not Found.
            if (viagem == null) return NotFound();
            // Se encontrar, retorna a viagem.
            return viagem;
        }
    }
}