using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoLocacaoInstrumentos.Data;
using GestaoLocacaoInstrumentos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.Metrics;

namespace GestaoLocacaoInstrumentos.Controllers
{
    public class EstudioController : Controller
    {
        private readonly LocadoraContext _context;
        public EstudioController(LocadoraContext context)
        {
            _context = context;
        }

        private static List<Estudio> _estudios = new List<Estudio>
        {
            new Estudio { Id = 1, Nome = "Estúdio A", Capacidade = 10, Valor = 150, Descricao = "A sala dispõe de Ar Condicionado, Frigobar e Sofá", Endereco = "Av Bento Gonçalves" },
            new Estudio { Id = 2, Nome = "Estúdio B", Capacidade = 5, Valor = 100, Descricao = "A sala dispõe apenas de Ar Condicionado", Endereco = "Av Bento Gonçalves" }
        };
        private readonly object estudios;

        public IActionResult Index()
        {
            return View(_estudios);
        }

        public IActionResult Details(int id)
        {
            var estudio = _estudios.FirstOrDefault(e => e.Id == id);
            return View(estudio);
        }


        // GET: Estudio/Create
        public IActionResult Create()
        {
            return View();
        }

        // Salvar o novo estúdio
        [HttpPost]
        public IActionResult Create(Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                estudio.Id = _estudios.Count + 1; // Gera um novo ID
                _estudios.Add(estudio);
                return RedirectToAction(nameof(Index));
            }
            return View(estudio);
        }

        // Exibir o formulário para editar um estúdio
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var estudio = _estudios.FirstOrDefault(e => e.Id == id);
            if (estudio == null) return NotFound();


            return View(estudio);
        }

        // Salvar as alterações do estúdio
        [HttpPost]
        public async Task<IActionResult> Edit(Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                var estudioExistente = _estudios.FirstOrDefault(e => e.Id == estudio.Id);
                if (estudioExistente != null)
                {
                    // Atualiza os dados do estúdio
                    estudioExistente.Nome = estudio.Nome;
                    estudioExistente.Capacidade = estudio.Capacidade;
                    estudioExistente.Valor = estudio.Valor;
                    estudioExistente.Descricao = estudio.Descricao;
                    estudioExistente.Endereco = estudio.Endereco;

                    _context.Update(estudio);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(estudio);
        }

        // Exibir a página de confirmação de exclusão
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var estudio = _estudios.FirstOrDefault(e => e.Id == id);
            if (estudio == null) return NotFound();

            return View(estudio);
        }

        // Confirmar exclusão do estúdio
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var estudio = _estudios.FirstOrDefault(e => e.Id == id);
            if (estudio != null)
            {
                _estudios.Remove(estudio);
                TempData["MensagemSucesso"] = "Estúdio excluído com sucesso!";
            }
            return RedirectToAction("Index");
        }
    }
}
