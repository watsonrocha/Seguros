using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seguros.Models;

namespace Seguros.Controllers
{
    public class ConsultarSegurosController : Controller
    {
       

        [HttpPost]
        public IActionResult Index(ConsultarSegurosModel seguro, string TxtValor_Veiculo)
        {
            if (ModelState.IsValid)
            {
                //Registrar o usuário
                seguro.RegistrarSeguros(TxtValor_Veiculo);
                return RedirectToAction("Index", "ConsultarSeguros");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult Relatorio()
        {
            ConsultarSegurosModel cadastro = new ConsultarSegurosModel();
            ViewBag.Relatorio = cadastro.ListaSaldo();
            return View();
        }

    }
}