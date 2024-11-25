using Microsoft.AspNetCore.Mvc;

namespace GestaoLocacaoInstrumentos.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
