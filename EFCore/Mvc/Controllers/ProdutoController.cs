using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Salvar()
        {
            ViewBag.Categorias = _context.Categorias.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Produto produto)
        {
            //var categoria = _context.Categorias.First(x => x.Id == produto.CategoriaId);
            //produto.Categoria = categoria;
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Consultar");
        }

        [HttpGet]
        public IActionResult Consultar()
        {
            var produto = _context.Produtos.ToList();
            return View(produto);
        }
    }
}