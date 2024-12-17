using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoLocacaoInstrumentos.Data;
using GestaoLocacaoInstrumentos.Models;


using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GestaoLocacaoInstrumentos.Controllers
{
    public class EstudioController : Controller
    {
        private static List<Estudio> _estudios = new List<Estudio>
        {
            new Estudio { Id = 1, Nome = "Estúdio A", Capacidade = 10, Valor = 150, Descricao = "Ar condicionado, frigobar e sofá" },
            new Estudio { Id = 2, Nome = "Estúdio B", Capacidade = 5, Valor = 100, Descricao = "Apenas ar condicionado" }
        };

        public IActionResult Index()
        {
            return View(_estudios);
        }

        public IActionResult Details(int id)
        {
            var estudio = _estudios.FirstOrDefault(e => e.Id == id);
            return View(estudio);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Estudio estudio)
        {
            estudio.Id = _estudios.Count + 1;
            _estudios.Add(estudio);
            return RedirectToAction("Index");
        }
    }
}




//namespace GestaoLocacaoInstrumentos.Controllers
//{
//    public class EstudioController : Controller
//  {
//    private readonly LocadoraContext _context;

//  public EstudioController(LocadoraContext context)
//{
//  _context = context;
//}

// GET: Estudio/Index
//public async Task<IActionResult> Index()
//{
//  var estudios = await _context.Estudios.ToListAsync();
//return View(estudios);
//}

// GET: Estudio/Details/5
// public async Task<IActionResult> Details(int? id)
//{
//  if (id == null) return NotFound();

//var estudio = await _context.Estudios.FirstOrDefaultAsync(e => e.Id == id);
//if (estudio == null) return NotFound();

//return View(estudio);
//}

// GET: Estudio/Create
//public IActionResult Create()
//{
//  return View();
//}

// POST: Estudio/Create
// [HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> Create([Bind("Id,Nome,Capacidade,Valor,Descricao")] Estudio estudio)
//{
//  if (ModelState.IsValid)
//{
//  _context.Add(estudio);
//await _context.SaveChangesAsync();
//return RedirectToAction(nameof(Index));
//}
//return View(estudio);
//}

// GET: Estudio/Edit/5
//public async Task<IActionResult> Edit(int? id)
//{
//  if (id == null) return NotFound();

//var estudio = await _context.Estudios.FindAsync(id);
//if (estudio == null) return NotFound();

//  return View(estudio);
//}

// POST: Estudio/Edit/5
//[HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Capacidade,Valor,Descricao")] Estudio estudio)
//{
//  if (id != estudio.Id) return NotFound();

//if (ModelState.IsValid)
//{
//  try
//{
//  _context.Update(estudio);
//await _context.SaveChangesAsync();
// }
//  catch (DbUpdateConcurrencyException)
//{
//if (!EstudioExists(estudio.Id))
//  {
//  return NotFound();
//}

//                    throw;
//              }
//            return RedirectToAction(nameof(Index));
//      }
//    return View(estudio);
//}

// GET: Estudio/Delete/5
//public async Task<IActionResult> Delete(int? id)
//{
//  if (id == null) return NotFound();

//var estudio = await _context.Estudios.FirstOrDefaultAsync(e => e.Id == id);
//if (estudio == null) return NotFound();

//   return View(estudio);
//}

// POST: Estudio/Delete/5
//[HttpPost, ActionName("Delete")]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> DeleteConfirmed(int id)
//{
//  var estudio = await _context.Estudios.FindAsync(id);
//if (estudio != null)
//{
//  _context.Estudios.Remove(estudio);
//await _context.SaveChangesAsync();
//}
//return RedirectToAction(nameof(Index));
//}

// private bool EstudioExists(int id)
//{
//  return _context.Estudios.Any(e => e.Id == id);
//}
//}
//}
