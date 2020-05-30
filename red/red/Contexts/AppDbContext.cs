using Microsoft.EntityFrameworkCore;
using red.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace red.Contexts
{
    public class AppDbContext:DbContext 
    {
        private readonly string DbPath = string.Empty;
        public AppDbContext(string dbPath)
        {
            DbPath = dbPath;
        }

        #region Listado_de_datos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Amigo> Amigos { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        #endregion

        #region Config

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DbPath}");
        }
        #endregion
    }
}
