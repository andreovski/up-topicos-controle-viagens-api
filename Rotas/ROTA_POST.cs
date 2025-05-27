using ControleViagensApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleViagensApi.Rotas
{
    [ApiController]
    [Route("api/viagens")]
    public class ViagemPostController : ControllerBase
    {
        private readonly ViagensContext _context;

        public ViagemPostController(ViagensContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Viagem>> Create(Viagem viagem)
        {
            _context.Viagens.Add(viagem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), new { id = viagem.Id }, viagem);
        }
    }
}