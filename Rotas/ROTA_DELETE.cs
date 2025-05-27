
using ControleViagensApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleViagensApi.Rotas
{
    [ApiController]
    [Route("api/viagens")]
    public class ViagemDeleteController : ControllerBase
    {
        private readonly ViagensContext _context;

        public ViagemDeleteController(ViagensContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var viagem = await _context.Viagens.FindAsync(id);
            if (viagem == null) return NotFound();

            _context.Viagens.Remove(viagem);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}