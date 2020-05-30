using red.Contexts;
using red.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace red.Servicios
{
    class PublicacionServicios
    {
        private readonly AppDbContext _context;

        public PublicacionServicios()
        {
            _context = App.GetContext();
        }

        public ObservableCollection<Publicacion> ObtenerPublicaciones()
        {
            return _context.Publicaciones.ToObservableCollection();
        }

        public List<Publicacion> ObtenerListaPublicaciones()
        {
            return _context.Publicaciones.ToList();
        }

        public void CrearPublicacion(Publicacion publicacion)
        {
            try
            {
                _context.Publicaciones.Add(publicacion);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
