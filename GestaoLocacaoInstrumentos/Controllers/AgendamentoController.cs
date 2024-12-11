namespace GestaoLocacaoInstrumentos.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using GestaoLocacaoInstrumentos.Data;
using GestaoLocacaoInstrumentos.Models;
using System.Diagnostics;

[DebuggerDisplay($"{{{nameof(DebuggerDisplay)}(),nq}}")]
public class AgendamentoController : Controller
{
    private readonly LocadoraContext _context;

    public AgendamentoController(LocadoraContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var agendamentos = _context.Agendamentos.ToList();
        return View(agendamentos);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Agendamento agendamento)
    {
        if (ModelState.IsValid)
        {
            _context.Add(agendamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(agendamento);
    }

    private string DebuggerDisplay => ToString();
}

