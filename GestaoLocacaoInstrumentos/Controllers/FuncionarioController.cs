﻿using Microsoft.AspNetCore.Mvc;

namespace GestaoLocacaoInstrumentos.Controllers
{
    public class FuncionarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
