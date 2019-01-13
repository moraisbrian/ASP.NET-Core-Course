using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Routes.Controllers
{
    //[Route("[controller/Sobre]")]
    public class SobreController : Controller
    {
        
        public IActionResult Sobre()
        {
            return View();
        }
    }
}