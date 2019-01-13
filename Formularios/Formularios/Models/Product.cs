using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Formularios.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(3, ErrorMessage = "Valor maior que 3 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue)]
        public int Price { get; set; }
    }
}
