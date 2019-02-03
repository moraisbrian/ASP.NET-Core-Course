using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entidades;

namespace Dados
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Para Lazing Loading
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Produto>().Property(x => x.Nome).HasMaxLength(50);
            modelBuilder.Entity<Produto>().Property(x => x.Nome).IsRequired();
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<Categoria>().Property(x => x.Nome).IsRequired();
            modelBuilder.Entity<Pedido>().ToTable("Pedido");
            modelBuilder.Entity<Pedido>().HasKey(x => x.Numero);
            modelBuilder.Entity<Pedido>().Property(x => x.Data).HasDefaultValueSql("getdate()");
        }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }
    }
}
