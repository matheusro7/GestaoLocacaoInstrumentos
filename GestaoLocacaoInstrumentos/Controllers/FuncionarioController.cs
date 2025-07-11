using Microsoft.AspNetCore.Mvc;
using GestaoLocacaoInstrumentos.Data;
using GestaoLocacaoInstrumentos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace GestaoLocacaoInstrumentos.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly LocadoraContext _context;

        public FuncionarioController(LocadoraContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Funcionarios.ToListAsync());
        }

    public IActionResult Create()
       {
           return View();
       }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null) return NotFound();

            return View(funcionario);
        }

            // Lista estática para simular dados em memória
            private static List<Funcionario> funcionarios = new List<Funcionario>
        {
            new Funcionario { Id = 1, Nome = "João Silva", Senha = "senha123", Cargo = CargoEnum.Gerente, },
            new Funcionario { Id = 2, Nome = "Maria Santos", Senha = "senha456", Cargo = CargoEnum.Atendente, }
        };

        // Método GET: Carrega o formulário de edição com os dados do funcionário
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null) 
                    return NotFound("Funcionário não encontrado");

            return View(funcionario);
        }
        

        // Método POST: Salva os dados editados e atualiza a lista
        [HttpPost]
        public async Task<IActionResult> Edit(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                // Localiza e atualiza o funcionário na lista
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();

                TempData["Message"] = "Funcionário editado com sucesso!";
                return RedirectToAction(nameof(Index));
            }

            return View(funcionario);
        }

    // Exibir a página de confirmação de exclusão
    public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.Id == id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // Realizar a exclusão
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario != null)
            {
                _context.Funcionarios.Remove(funcionario);
                TempData["MensagemSucesso"] = "Funcionário excluído com sucesso!";
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }

    }
}



