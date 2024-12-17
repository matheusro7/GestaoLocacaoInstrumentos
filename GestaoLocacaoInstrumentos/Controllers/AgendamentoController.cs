namespace GestaoLocacaoInstrumentos.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using GestaoLocacaoInstrumentos.Data;
using GestaoLocacaoInstrumentos.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;


public class AgendamentoController : Controller
{
    
    private List<Agendamento> agendamentos = new List<Agendamento>
    {
        new Agendamento { Id = 1, Estudio = "Estudio A", Data = DateTime.Now.AddDays(1),},
        new Agendamento { Id = 2, Estudio = "Estudio B", Data = DateTime.Now.AddDays(2) },
        new Agendamento { Id = 3, Estudio = "Estudio A", Data = DateTime.Now.AddDays(3) }
    };

    public IActionResult Index()
    {
        
        var agendamentosSimulados = agendamentos.ToList();
        return View(agendamentosSimulados);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Agendamento agendamento)
    {
       // if (ModelState.IsValid)
       // {
            
            agendamento.Id = agendamentos.Max(a => a.Id) + 1; 
            agendamentos.Add(agendamento);

            
            return RedirectToAction(nameof(Index));
      //  }
      //  return View(agendamento);
    }
    public IActionResult Edit(int id)
    {
        
        var agendamento = agendamentos.FirstOrDefault(a => a.Id == id);

        if (agendamento == null)
        {
            return NotFound();  
        }

        return View(agendamento);
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Agendamento agendamento)
    {
      //  if (ModelState.IsValid)
       // {
            
            var agendamentoExistente = agendamentos.FirstOrDefault(a => a.Id == agendamento.Id);

            if (agendamentoExistente == null)
            {
                return NotFound();  
            }

            
            agendamentoExistente.Estudio = agendamento.Estudio;
            agendamentoExistente.Data = agendamento.Data;
            agendamentoExistente.HoraInicio = agendamento.HoraInicio;
            agendamentoExistente.HoraFim = agendamento.HoraFim;
            agendamentoExistente.Cliente = agendamento.Cliente;
            agendamentoExistente.Valor = agendamento.Valor;

            
            return RedirectToAction(nameof(Index));
       // }

        
       // return View(agendamento);
    }

    // Ação para deletar um agendamento
    public IActionResult Delete(int id)
    {
        // Buscar o agendamento com o id
        var agendamento = agendamentos.FirstOrDefault(a => a.Id == id);

        if (agendamento == null)
        {
            return NotFound();  // Se não encontrar, retorna erro 404
        }

        // Remove o agendamento da lista
        agendamentos.Remove(agendamento);

        // Após deletar, redireciona para a página de listagem
        return RedirectToAction(nameof(Index));
    }

    // Outras ações...
}




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

