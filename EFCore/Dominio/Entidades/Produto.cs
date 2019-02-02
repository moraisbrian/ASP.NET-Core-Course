using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        //virtual para Lazing Loading
        public virtual Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}
