using Microsoft.AspNetCore.Mvc;

namespace GestaoLocacaoInstrumentos.Data
{
    public class Migrations : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
