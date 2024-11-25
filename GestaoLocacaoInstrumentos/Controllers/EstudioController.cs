using Microsoft.AspNetCore.Mvc;

namespace GestaoLocacaoInstrumentos.Controllers
{
    public class EstudioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
