using Microsoft.AspNetCore.Mvc;

namespace GestaoLocacaoInstrumentos.Data
{
    public class SeedData : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
