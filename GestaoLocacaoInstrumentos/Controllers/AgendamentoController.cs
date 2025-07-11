using Microsoft.AspNetCore.Mvc;
using GestaoLocacaoInstrumentos.Data;
using GestaoLocacaoInstrumentos.Models;
using Microsoft.EntityFrameworkCore;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using GestaoLocacaoInstrumentos.Utils;

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
    public string Relatorio(FiltroAgendamento filtroAgendamento)
    {
        // Começa com a query base
        var query = _context.Agendamentos.AsQueryable();

        // Aplica os filtros apenas se os campos não forem nulos
        if (filtroAgendamento.Data != null)
        {
            query = query.Where(x => x.Data == filtroAgendamento.Data);
        }

        if (!string.IsNullOrEmpty(filtroAgendamento.Cliente))
        {
            query = query.Where(x => x.Cliente == filtroAgendamento.Cliente);
        }

        if (!string.IsNullOrEmpty(filtroAgendamento.Estudio))
        {
            query = query.Where(x => x.Estudio == filtroAgendamento.Estudio);
        }

        var agendamentosFiltrados = query.ToList();

        if (agendamentosFiltrados == null) return "Não há registros para os filtros informados";

        var exportador = new ExcelExportService();

        string downloadsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "Downloads"
        );

        string caminho = downloadsPath + "\\Agendamentos.xlsx";
        exportador.ExportarAgendamentosParaExcel(agendamentosFiltrados, caminho);


        return "Relatório gerado com sucesso";
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Agendamento agendamento)
    {
        _context.Add(agendamento);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
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
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var agendamento = await _context.Agendamentos.FirstOrDefaultAsync(m => m.Id == id);
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
            TempData["MensagemSucesso"] = "Agendamento excluído com sucesso!";
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
