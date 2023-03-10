using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Entities.Profissoes;
using RestApi.Entities.Usuarios;
using RestApi.Model.Context;

namespace RestApi.Controllers.Profissoes
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissaoController : ControllerBase
    {
        private readonly DataContext _context;

        public ProfissaoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Profissao>>> GetProfissaoAll()
        {
            return await _context.Profissoes.ToListAsync();
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Profissao>> GetProfissaoById(int id)
        {
            var model = await _context.Profissoes.FindAsync(id);

            if (model == null)
                throw new Exception("Cadastro nao encontrato.");

            return model;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Usuario>> PostProfissao(Profissao model)
        {
            _context.Profissoes.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { id = model.Id }, model);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> PutProfissao(Profissao model)
        {
            if (model.Id <= 0)
            {
                return Ok(new
                {
                    success = false,
                    mensage = "O Id informado nao é valido para essa operacao"
                });
            }

            try
            {
                _context.Entry(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadastroExists(model.Id))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(new
                    {
                        success = false,
                        mensage = "Ocorreu um erro interno da Api"
                    });
                }
            }

            return NoContent();
        }

        [HttpDelete("Delet/{id}")]
        public async Task<IActionResult> DeleteProfissao(int id)
        {
            var model = await _context.Profissoes.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            _context.Profissoes.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CadastroExists(int id)
        {
            return _context.Profissoes.Any(e => e.Id == id);
        }
    }
}
