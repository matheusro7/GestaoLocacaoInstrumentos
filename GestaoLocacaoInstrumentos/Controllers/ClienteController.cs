using GestaoLocacaoInstrumentos.Data;
using GestaoLocacaoInstrumentos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;



namespace GestaoLocacaoInstrumentos.Controllers
{
    public class ClienteController : Controller
    {
        private static List<Cliente> _clientes = new List<Cliente>
        {
            new Cliente { Id = 1, Nome = "Carlos Silva", Senha = "123456789", Email = "carlos.silva@example.com" },
            new Cliente { Id = 2, Nome = "Maria Oliveira", Senha = "987654321", Email = "maria.oliveira@example.com" }
        };

        // Listar todos os clientes
        public IActionResult Index()
        {
            return View(_clientes);
        }

        // Exibir os detalhes de um cliente
        public IActionResult Details(int id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        // Exibir o formulário para criar um novo cliente
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Salvar o novo cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            // if (ModelState.IsValid)
           // {
                cliente.Id = _clientes.Any() ? _clientes.Max(c => c.Id) + 1 : 1; 
                _clientes.Add(cliente);
                TempData["Message"] = "Cliente criado com sucesso!";
                return RedirectToAction(nameof(Index));
          //  }
           // return View(cliente);
        }

        // Exibir o formulário para editar um cliente
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        // Salvar as alterações do cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cliente cliente)
        {
            //if (ModelState.IsValid)
            {
                var clienteExistente = _clientes.FirstOrDefault(c => c.Id == cliente.Id);
                if (clienteExistente != null)
                {
                    // Atualiza os dados do cliente
                    clienteExistente.Nome = cliente.Nome;
                    clienteExistente.Id = cliente.Id;
                    clienteExistente.Email = cliente.Email;

                    TempData["Message"] = "Cliente atualizado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(cliente);
        }

        // Exibir a página de confirmação de exclusão
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        // Confirmar exclusão do cliente
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                _clientes.Remove(cliente);
                TempData["Message"] = "Cliente excluído com sucesso!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}






//[Route("api/[controller]")]
//[ApiController]
//public class ClienteController : ControllerBase
//{
//    private readonly LocadoraContext _context;

//    public ClienteController(LocadoraContext context)
//    {
//        _context = context;
//    }

//    // GET: api/Cliente
//    [HttpGet]
//    public IActionResult GetClientes()
//    {
//        return Ok(_context.Clientes.ToList());
//    }

//    // POST: api/Cliente
//    [HttpPost]
//    public IActionResult AddCliente([FromBody] Cliente cliente)
//    {
//        //if (!ModelState.IsValid)
//        {
//            return BadRequest(ModelState);
//        }

//       // _context.Clientes.Add(cliente);
//       // _context.SaveChanges();
//       // return CreatedAtAction(nameof(GetClientes), new { id = cliente.Id }, cliente);
//    }

//    // DELETE: api/Cliente/{id}
//    [HttpDelete("{id}")]
//    public IActionResult DeleteCliente(int id)
//    {
//        var cliente = _context.Clientes.Find(id);
//        if (cliente == null)
//        {
//            return NotFound();
//        }

//        _context.Clientes.Remove(cliente);
//        _context.SaveChanges();
//        return NoContent();
//    }
//}



