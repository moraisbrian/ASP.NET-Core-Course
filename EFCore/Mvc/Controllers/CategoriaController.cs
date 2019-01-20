using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaController(ApplicationDbContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public IActionResult Salvar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Categoria categoria)
        {
            if(categoria.Id == 0)
            {
                _context.Categorias.Add(categoria);
            }
            else
            {
                var model = _context.Categorias.First(x => x.Id == categoria.Id);
                model.Nome = categoria.Nome;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Consultar");

        }

        [HttpGet]
        public IActionResult Consultar()
        {
            var categoria = _context.Categorias.ToList();
            return View(categoria);
        }
        
        public IActionResult Detalhes(int id)
        {
            var categoria = _context.Categorias.First(x => x.Id == id);
            return View(categoria);
        }

        public IActionResult Editar(int id)
        {
            var categoria = _context.Categorias.First(x => x.Id == id);

            return View("Salvar", categoria);
        }


        public async Task<IActionResult> Deletar(int id)
        {
            var categoria = _context.Categorias.First(x => x.Id == id);
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return RedirectToAction("Consultar");
        }
    }
}