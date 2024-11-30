using Microsoft.AspNetCore.Mvc;

namespace GestaoLocacaoInstrumentos.Controllers
{
    using GestaoLocacaoInstrumentos.Models;
    using global::GestaoLocacaoInstrumentos.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    namespace GestaoLocacaoInstrumentos.Controllers
    {
        public class LocacaoInstrumentoController : Controller
        {
            private readonly LocadoraContext _context;

            public LocacaoInstrumentoController(LocadoraContext context)
            {
                _context = context;
            }

            // GET: LocacaoInstrumento/Create
            public IActionResult Create()
            {
                ViewBag.Instrumentos = _context.Instrumentos.ToList();
                ViewBag.Salas = _context.Salas.Where(s => s.Disponivel).ToList(); // Exibir apenas salas disponíveis
                return View();
            }

            // POST: LocacaoInstrumento/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(LocacaoInstrumento locacao)
            {
                if (locacao.SalaId <= 0)
                {
                    ModelState.AddModelError("SalaId", "É obrigatório alugar uma sala junto com o instrumento.");
                }

                if (ModelState.IsValid)
                {
                    _context.LocacaoInstrumentos.Add(locacao);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Instrumentos = _context.Instrumentos.ToList();
                ViewBag.Salas = _context.Salas.Where(s => s.Disponivel).ToList();
                return View(locacao);
            }
        }
    }

}
