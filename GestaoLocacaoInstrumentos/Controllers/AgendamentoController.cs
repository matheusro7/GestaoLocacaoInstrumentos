using Microsoft.AspNetCore.Mvc;
using GestaoLocacaoInstrumentos.Data;
using GestaoLocacaoInstrumentos.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoLocacaoInstrumentos.Controllers;
public class AgendamentoController : Controller
{
    private readonly LocadoraContext _context;

    public AgendamentoController(LocadoraContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Agendamentos.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Agendamento agendamento)
    {
        
        //if (ModelState.IsValid)
       // {
            _context.Add(agendamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        //}
        //return View(agendamento);
    }

    // Método Edit GET: Carrega o formulário com os dados existentes ///////////////////////////////////
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var agendamento = await _context.Agendamentos.FindAsync(id);
        if (agendamento == null)
            return NotFound();

        return View(agendamento);
    }

    // Método Edit POST: Salva as alterações no banco
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Agendamento agendamento)
    {
        if (id != agendamento.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(agendamento);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Agendamento atualizado com sucesso!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendamentoExists(agendamento.Id))
                    return NotFound();

                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(agendamento);
    }

    // Verificação de existência
    private bool AgendamentoExists(int id)
    {
        return _context.Agendamentos.Any(e => e.Id == id);
    }
  /// <summary>
  /// 
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
    //private List<Agendamento> agendamentos = new List<Agendamento>
    //{
    //    new Agendamento { Id = 1, Estudio = "Estudio A", Data = DateTime.Now.AddDays(1), HoraInicio = TimeSpan.FromHours(12), HoraFim = TimeSpan.FromHours(13), Cliente = "Cliente 1", Valor = 150.00M, Descricao = "abc"},
    //    new Agendamento { Id = 2, Estudio = "Estudio B", Data = DateTime.Now.AddDays(2), HoraInicio = TimeSpan.FromHours(16), HoraFim = TimeSpan.FromHours(18), Cliente = "Cliente 2", Valor = 200.00M, Descricao = "def"},
    //    new Agendamento { Id = 3, Estudio = "Estudio A", Data = DateTime.Now.AddDays(3),HoraInicio = TimeSpan.FromHours(20), HoraFim = TimeSpan.FromHours(23), Cliente = "Cliente 13", Valor = 250.00M, Descricao = "ghi" }
    //};

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var agendamento = await _context.Agendamentos.FindAsync(id);
        if (agendamento == null) return NotFound();

        return View(agendamento);
    }

    //Exibir a página de confirmação de exclusão
    public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
             {
            return NotFound();
            }

            var agendamento = await _context.Agendamentos
            .FirstOrDefaultAsync(m => m.Id == id);

            if (agendamento == null)
            {
            return NotFound();
            }

            return View(agendamento);
    }

   // Realizar a exclusão
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento != null)
            {
                 _context.Agendamentos.Remove(agendamento);
                 await _context.SaveChangesAsync();
            }
             return RedirectToAction(nameof(Index));



    }

}
///////////////////////////////////
//acima código oficial
//////////////////////////////

//namespace GestaoLocacaoInstrumentos.Controllers
//{
//    public class AgendamentoController : Controller
//    {
//        private readonly LocadoraContext _context;

//        public AgendamentoController(LocadoraContext context)
//        {
//            _context = context;
//        }

//        // Listar todos os agendamentos
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Agendamentos.ToListAsync());
//        }

//        // Exibir detalhes de um agendamento
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//                return NotFound();

//            var agendamento = await _context.Agendamentos.FindAsync(id);
//            if (agendamento == null)
//                return NotFound();

//            return View(agendamento);
//        }

//        private List<Agendamento> agendamentos = new List<Agendamento>
//  {
//        new Agendamento { Id = 1, Estudio = "Estudio A", Data = DateTime.Now.AddDays(1), HoraInicio = TimeSpan.FromHours(12), HoraFim = TimeSpan.FromHours(13), Cliente = "Cliente 1", Valor = 150.00M, Descricao = "abc"},
//        new Agendamento { Id = 2, Estudio = "Estudio B", Data = DateTime.Now.AddDays(2), HoraInicio = TimeSpan.FromHours(16), HoraFim = TimeSpan.FromHours(18), Cliente = "Cliente 2", Valor = 200.00M, Descricao = "def"},
//        new Agendamento { Id = 3, Estudio = "Estudio A", Data = DateTime.Now.AddDays(3),HoraInicio = TimeSpan.FromHours(20), HoraFim = TimeSpan.FromHours(23), Cliente = "Cliente 13", Valor = 250.00M, Descricao = "ghi" }
// };

//        // GET: Exibir formulário de criação
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Criar um novo agendamento
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(Agendamento agendamento)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(agendamento);
//                await _context.SaveChangesAsync();
//                TempData["Message"] = "Agendamento criado com sucesso!";
//                return RedirectToAction(nameof(Index));
//            }
//            return View(agendamento);
//        }

//        // GET: Exibir formulário de edição
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//                return NotFound();

//            var agendamento = await _context.Agendamentos.FindAsync(id);
//            if (agendamento == null)
//                return NotFound();

//            return View(agendamento);
//        }

//        // POST: Salvar alterações de edição
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, Agendamento agendamento)
//        {
//            if (id != agendamento.Id)
//                return NotFound();

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(agendamento);
//                    await _context.SaveChangesAsync();
//                    TempData["Message"] = "Agendamento atualizado com sucesso!";
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!AgendamentoExists(agendamento.Id))
//                        return NotFound();

//                    throw;
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(agendamento);
//        }

//        // GET: Confirmar exclusão
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//                return NotFound();

//            var agendamento = await _context.Agendamentos
//                .FirstOrDefaultAsync(a => a.Id == id);

//            if (agendamento == null)
//                return NotFound();

//            return View(agendamento);
//        }

//        // POST: Realizar exclusão
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var agendamento = await _context.Agendamentos.FindAsync(id);
//            if (agendamento != null)
//            {
//                _context.Agendamentos.Remove(agendamento);
//                await _context.SaveChangesAsync();
//                TempData["Message"] = "Agendamento excluído com sucesso!";
//            }
//            return RedirectToAction(nameof(Index));
//        }

//        // Verificar se o agendamento existe
//        private bool AgendamentoExists(int id)
//        {
//            return _context.Agendamentos.Any(e => e.Id == id);
//        }
//    }
//}







////////////////////////////////////////
//public IActionResult Index()
//{

//var agendamentosSimulados = agendamentos.ToList();
//  return View(agendamentos);
// }

//public IActionResult Create()
//{
//   return View();
//}

//[HttpPost]
//[ValidateAntiForgeryToken]
//public IActionResult Create(Agendamento agendamento)
// {
//   if (ModelState.IsValid)
// {

//    agendamento.Id = agendamentos.Max(a => a.Id) + 1; 
//  agendamentos.Add(agendamento);


//   return RedirectToAction(nameof(Index));
// }
//  return View(agendamento);
//}
//public IActionResult Edit(int id)
//{

//  var agendamento = agendamentos.FirstOrDefault(a => a.Id == id);

//if (agendamento == null)
//{
//  return NotFound();  
//}

//        return View(agendamento);
//  }


//[HttpPost]
//[ValidateAntiForgeryToken]
//public IActionResult Edit(Agendamento agendamento)
// {
//if (ModelState.IsValid)
//{

// var agendamentoExistente = agendamentos.FirstOrDefault(a => a.Id == agendamento.Id);

//if (agendamentoExistente == null)
// {
// return NotFound();  
//}


// agendamentoExistente.Estudio = agendamento.Estudio;
//  agendamentoExistente.Data = agendamento.Data;
//  agendamentoExistente.HoraInicio = agendamento.HoraInicio;
//  agendamentoExistente.HoraFim = agendamento.HoraFim;
//   agendamentoExistente.Cliente = agendamento.Cliente;
//    agendamentoExistente.Valor = agendamento.Valor;


//           return RedirectToAction(nameof(Index));
//       }


//       return View(agendamento);
// }

// Ação para deletar um agendamento
//public IActionResult Delete(int id)
// {
// Buscar o agendamento com o id
//   var agendamento = agendamentos.FirstOrDefault(a => a.Id == id);

// if (agendamento == null)
// {
//   return NotFound();  // Se não encontrar, retorna erro 404
//}

//        return View(agendamento);
// Remove o agendamento da lista
//agendamentos.Remove(agendamento);

// Após deletar, redireciona para a página de listagem
//return RedirectToAction(nameof(Index));
//}

//   [HttpPost, ActionName("Delete")]
// [ValidateAntiForgeryToken]
// public IActionResult DeleteConfirmed(int id)
// {
//   var agendamento = agendamentos.FirstOrDefault(a => a.Id == id);

// if (agendamento != null)
//  {
//    agendamentos.Remove(agendamento);
// }

//        return RedirectToAction(nameof(Index));
//  }
//}


// Outras ações...





//[DebuggerDisplay($"{{{nameof(DebuggerDisplay)}(),nq}}")]
//public class AgendamentoController : Controller
//{
//    private readonly LocadoraContext _context;

//    public AgendamentoController(LocadoraContext context)
//    {
//        _context = context;
//    }

//public IActionResult Index()
//{
//   var agendamentos = _context.Agendamentos.ToList();
//  return View(agendamentos);
//}

//    public IActionResult Create()
//    {
//       return View();
//   }

//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Create(Agendamento agendamento)
//   {
//     if (ModelState.IsValid)
//   {
//     _context.Add(agendamento);
//   await _context.SaveChangesAsync();
// return RedirectToAction(nameof(Index));
// }
//return View(agendamento);
// }

//private string DebuggerDisplay => ToString();
//}

