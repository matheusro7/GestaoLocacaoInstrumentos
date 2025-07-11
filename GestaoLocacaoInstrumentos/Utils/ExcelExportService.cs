namespace GestaoLocacaoInstrumentos.Utils
{
    using ClosedXML.Excel;
    using GestaoLocacaoInstrumentos.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class ExcelExportService
    {
        public void ExportarAgendamentosParaExcel(List<Agendamento> agendamentos, string caminhoArquivo)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Agendamentos");

            // Cabeçalho
            worksheet.Cell("A1").Value = "ID";
            worksheet.Cell("B1").Value = "Estúdio";
            worksheet.Cell("C1").Value = "Data";
            worksheet.Cell("D1").Value = "Hora Início";
            worksheet.Cell("E1").Value = "Hora Fim";
            worksheet.Cell("F1").Value = "Cliente";
            worksheet.Cell("G1").Value = "Valor";

            // Conteúdo
            int linha = 2;
            foreach (var agendamento in agendamentos)
            {
                worksheet.Cell(linha, 1).Value = agendamento.Id;
                worksheet.Cell(linha, 2).Value = agendamento.Estudio;
                worksheet.Cell(linha, 3).Value = agendamento.Data.ToString("dd/MM/yyyy");
                worksheet.Cell(linha, 4).Value = agendamento.HoraInicio.ToString(@"hh\:mm");
                worksheet.Cell(linha, 5).Value = agendamento.HoraFim.ToString(@"hh\:mm");
                worksheet.Cell(linha, 6).Value = agendamento.Cliente;
                worksheet.Cell(linha, 7).Value = agendamento.Valor;
                linha++;
            }

            // Ajusta a largura automática das colunas
            worksheet.Columns().AdjustToContents();

            // Salva o arquivo
            workbook.SaveAs(caminhoArquivo);
        }
    }

}
