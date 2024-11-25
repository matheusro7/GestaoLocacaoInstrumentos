using Microsoft.AspNetCore.Mvc;

namespace GestaoLocacaoInstrumentos.Controllers
{
    public class LocacaoInstrumentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
