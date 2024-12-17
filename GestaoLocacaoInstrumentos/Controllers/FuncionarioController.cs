using Microsoft.AspNetCore.Mvc;
using GestaoLocacaoInstrumentos.Data;
using GestaoLocacaoInstrumentos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        //[HttpGet]
       // public async Task<IActionResult> Get()
        //{
         //   var funcionarios = await _context.Funcionarios.ToListAsync();

         //   var nomefuncionarios = funcionarios.Select(x => x.Nome);
          //  var joao = nomefuncionarios.Where(x => x.Contains("João"));

          //  return Ok(funcionarios);
       // }

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

        // Editar Funcionário
        // public async Task<IActionResult> Edit(int? id)
        // {
        //  if (id == null) return NotFound();
        //
        //var funcionario = await _context.Funcionarios.FindAsync(id);
        //if (funcionario == null) return NotFound();

        // return View(funcionario);
        // }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, Funcionario funcionario)
        //{
        //  if (id != funcionario.Id) return NotFound();

        //if (ModelState.IsValid)
        //{
        //  try
        //{
        //  _context.Update(funcionario);
        //await _context.SaveChangesAsync();
        //}
        //catch (DbUpdateConcurrencyException)
        //{
        //  if (!FuncionarioExists(funcionario.Id))
        //{
        //  return NotFound();
        //}
        //else
        //{
        //  throw;
        //}
        //}
        //return RedirectToAction(nameof(Index));
        //}
        //return View(funcionario);
        //}
        //private bool FuncionarioExists(int id)
        //{
        //   return _context.Funcionarios.Any(e => e.Id == id);
        //}

        // Editar


        //public class FuncionarioController : Controller
       // {
            // Lista estática para simular dados em memória
            private static List<Funcionario> funcionarios = new List<Funcionario>
        {
            new Funcionario { Id = 1, Nome = "João Silva", Senha = "senha123", Cargo = CargoEnum.Gerente, },
            new Funcionario { Id = 2, Nome = "Maria Santos", Senha = "senha456", Cargo = CargoEnum.Atendente, }
        };

            // Exibir a lista de funcionários
           // public IActionResult Index()
           // {
           //     return View(funcionarios);
           // }

            // Método GET: Carrega o formulário de edição com os dados do funcionário
            public IActionResult Edit(int id)
            {
                var funcionario = funcionarios.FirstOrDefault(f => f.Id == id);
                if (funcionario == null)
                    return NotFound();

                return View(funcionario);
            }

            // Método POST: Salva os dados editados e atualiza a lista
            [HttpPost]
            public IActionResult Edit(Funcionario funcionario)
            {
                if (ModelState.IsValid)
                {
                    // Localiza e atualiza o funcionário na lista
                    var funcionarioExistente = funcionarios.FirstOrDefault(f => f.Id == funcionario.Id);
                    if (funcionarioExistente != null)
                    {
                        funcionarioExistente.Nome = funcionario.Nome;
                        funcionarioExistente.Senha = funcionario.Senha;
                        funcionarioExistente.Cargo = funcionario.Cargo;

                    }

                    TempData["Message"] = "Funcionário editado com sucesso!";
                    return RedirectToAction("Index");
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
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }



        // GET: Funcionarios/Edit/5
        //        public async Task<IActionResult> Edit(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }
        //
        //            var funcionario = await _context.Funcionarios.FindAsync(id);
        //            if (funcionario == null)
        //            {
        //                return NotFound();
        //            }
        //            return View(funcionario);
        //        }

        // POST: Funcionarios/Edit/5
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cargo,Disponivel")] Funcionario funcionario)
        //        {
        //            if (id != funcionario.Id)
        //            {
        //               return NotFound();
        //           }

        //            if (ModelState.IsValid)
        //            {
        //                try
        //                {
        //                    _context.Update(funcionario);
        //                    await _context.SaveChangesAsync();
        //                }
        //                catch (DbUpdateConcurrencyException)
        //                {
        //                    if (!FuncionarioExists(funcionario.Id))
        //                    {
        //                        return NotFound();
        //                    }
        //                    else
        //                    {
        //                        throw;
        //                    }
        //                }
        //                return RedirectToAction(nameof(Index));
        //            }
        //            return View(funcionario);

        //ModelState.AddModelError("", "Ocorreu um erro ao salvar as alterações. Verifique os dados e tente novamente.");
        //return View(funcionario);
        //        }
        //        private bool FuncionarioExists(int id)
        //        {
        //            return _context.Funcionarios.Any(e => e.Id == id);
        //        }

    }
}



