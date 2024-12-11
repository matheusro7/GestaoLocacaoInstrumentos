using GestaoLocacaoInstrumentos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoLocacaoInstrumentos.Data;
using GestaoLocacaoInstrumentos.Models;

namespace GestaoLocacaoInstrumentos.Controllers
{
    public class InstrumentoController : Controller
    {
        private readonly LocadoraContext _context;

        public InstrumentoController(LocadoraContext context)
        {
            _context = context;
        }

        // GET: Instrumento
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instrumentos.ToListAsync());
        }

        // GET: Instrumento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var instrumento = await _context.Instrumentos.FirstOrDefaultAsync(m => m.Id == id);
            if (instrumento == null) return NotFound();

            return View(instrumento);
        }

        // GET: Instrumento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instrumento/Create
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

        // GET: Instrumento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var instrumento = await _context.Instrumentos.FindAsync(id);
            if (instrumento == null) return NotFound();

            return View(instrumento);
        }

        // POST: Instrumento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modelo,Marca,Nome,Descricao,ValorAluguel")] Instrumento instrumento)
        {
            if (id != instrumento.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instrumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstrumentoExists(instrumento.Id))
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(instrumento);
        }

        // GET: Instrumento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var instrumento = await _context.Instrumentos.FirstOrDefaultAsync(m => m.Id == id);
            if (instrumento == null) return NotFound();

            return View(instrumento);
        }

        // POST: Instrumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instrumento = await _context.Instrumentos.FindAsync(id);
            _context.Instrumentos.Remove(instrumento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstrumentoExists(int id)
        {
            return _context.Instrumentos.Any(e => e.Id == id);
        }
    }
}
