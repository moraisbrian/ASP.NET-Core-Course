using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Routes.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        //[HttpGet("{id:int}")]
        //public int Get(int id)
        //{
        //    return id;
        //}
        
        public string Get()
        {
            return HttpContext.Request.Path;
        }
    }
}