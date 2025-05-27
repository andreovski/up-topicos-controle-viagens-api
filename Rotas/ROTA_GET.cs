using Microsoft.AspNetCore.Mvc;
using ControleViagensApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleViagensApi.Rotas
{
    [ApiController]
    [Route("api/viagens")]
    public class ViagemGetController : ControllerBase
    {
        private readonly ViagensContext _context;

        public ViagemGetController(ViagensContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Viagem>>> GetAll()
        {
            return await _context.Viagens.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Viagem>> GetById(int id)
        {
            var viagem = await _context.Viagens.FindAsync(id);
            if (viagem == null) return NotFound();
            return viagem;
        }
    }
}