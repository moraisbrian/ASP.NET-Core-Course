using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if (produto.Id == 0)
            {
                _context.Produtos.Add(produto);
            }
            else
            {
                var model = _context.Produtos.First(x => x.Id == produto.Id);
                model.Nome = produto.Nome;
                model.Categoria = produto.Categoria;
                model.CategoriaId = produto.CategoriaId;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Consultar");
        }

        [HttpGet]
        public IActionResult Consultar()
        {
            //Removido para utilizar o Lazing Loading
            //var produto = _context.Produtos.Include(x => x.Categoria).ToList();
            //return View(produto);

            var produto = _context.Produtos.ToList();
            return View(produto);
        }

        public IActionResult Editar(int id)
        {
            ViewBag.Categorias = _context.Categorias.ToList();
            var produto = _context.Produtos.First(x => x.Id == id);
            return View("Salvar", produto);
        }


        public async Task<IActionResult> Deletar(int id)
        {
            var produto = _context.Produtos.First(x => x.Id == id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Consultar");
        }

        public IActionResult Detalhes(int id)
        {
            var produto = _context.Produtos.First(x => x.Id == id);
            return View(produto);
        }
    }
}