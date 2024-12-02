using Microsoft.AspNetCore.Mvc;

namespace GestaoLocacaoInstrumentos.Data
{
    public class DbInitializer : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
