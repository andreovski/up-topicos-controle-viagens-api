using Microsoft.AspNetCore.Mvc;
using ControleViagensApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleViagensApi.Rotas
{
    [ApiController]
    [Route("api/viagens")]
    public class ViagemPutController : ControllerBase
    {
        private readonly ViagensContext _context;

        public ViagemPutController(ViagensContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutViagem(int id, Viagem viagem)
        {
            if (id != viagem.Id)
                return BadRequest();

            _context.Entry(viagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Viagens.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }
    }
}