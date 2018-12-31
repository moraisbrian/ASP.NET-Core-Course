using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using injecaodependencia.Models;
using injecaodependencia.Repository;

namespace injecaodependencia.Controllers
{
    public class HomeController : Controller
    {
        private IPeopleRepository _pepleRepository;
        public HomeController(IPeopleRepository repository)
        {
            _pepleRepository = repository;
        }
        public IActionResult Index()
        {
            ViewData["name"] = _pepleRepository.GetNameById(2);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
