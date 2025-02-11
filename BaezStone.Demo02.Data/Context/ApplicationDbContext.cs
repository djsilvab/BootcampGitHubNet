using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaezStone.Demo02.Models.Entities;
using BaezStone.Demo02.Models.Usp;
using Microsoft.EntityFrameworkCore;

namespace BaezStone.Demo02.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<PrecioOferta> PrecioOfertas { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<LibroPrecioOferta> LibrosPreciosOfertas { get; set; }
        public DbSet<AutorLibro> AutoresLibros { get; set; }
        public DbSet<LibroPublicado> LibrosPublicados { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<LibroPublicado>(e => e.HasNoKey());
        }
    }
}