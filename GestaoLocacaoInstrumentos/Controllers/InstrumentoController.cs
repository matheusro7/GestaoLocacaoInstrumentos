using Microsoft.AspNetCore.Mvc;
using GestaoLocacaoInstrumentos.Data;
using GestaoLocacaoInstrumentos.Models;
using System.Linq;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;

public class InstrumentoController : Controller
{
    private readonly LocadoraContext _context;

    public InstrumentoController(LocadoraContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Instrumentos.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Modelo,Marca,Nome,Descricao,ValorAluguel")] Instrumento instrumento)
    {
        if (ModelState.IsValid)
        {
            _context.Add(instrumento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(instrumento);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var instrumento = await _context.Instrumentos.FindAsync(id);
        if (instrumento == null)
        {
            return NotFound();
        }
        return View(instrumento);
    }

    // Outras actions para Details e Delete aqui...
}