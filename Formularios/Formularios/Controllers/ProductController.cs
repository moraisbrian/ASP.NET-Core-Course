using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formularios.Models;
using Microsoft.AspNetCore.Mvc;

namespace Formularios.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Validacao = "Produto inválido";
            }
            return View();
        }
    }
}