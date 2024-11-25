using Microsoft.AspNetCore.Mvc;
using GestaoLocacaoInstrumentos.Data;
using GestaoLocacaoInstrumentos.Models;
using System.Linq;
using System.Diagnostics.Metrics;

public class InstrumentoController : Controller
{
    private readonly LocadoraContext _context;

    public InstrumentoController(LocadoraContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var instrumentos = _context.Instrumentos.ToList();
        return View(instrumentos);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Instrumento instrumento)
    {
        if (ModelState.IsValid)
        {
            _context.Instrumentos.Add(instrumento);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(instrumento);
    }
}

