using GestaoLocacaoInstrumentos.Data;
using GestaoLocacaoInstrumentos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly LocadoraContext _context;

    public ClienteController(LocadoraContext context)
    {
        _context = context;
    }

    // GET: api/Cliente
    [HttpGet]
    public IActionResult GetClientes()
    {
        return Ok(_context.Clientes.ToList());
    }

    // POST: api/Cliente
    [HttpPost]
    public IActionResult AddCliente([FromBody] Cliente cliente)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Clientes.Add(cliente);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetClientes), new { id = cliente.Id }, cliente);
    }

    // DELETE: api/Cliente/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteCliente(int id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente == null)
        {
            return NotFound();
        }

        _context.Clientes.Remove(cliente);
        _context.SaveChanges();
        return NoContent();
    }
}



