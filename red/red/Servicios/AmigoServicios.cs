using red.Contexts;
using red.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace red.Servicios
{
    class AmigoServicios
    {
        private readonly AppDbContext _context;

        public AmigoServicios()
        {
            _context = App.GetContext();
        }

        public ObservableCollection<Amigo> ObtenerAmigos()
        {
            return _context.Amigos.ToObservableCollection();
        }

        public List<Amigo> ObtenerListaAmigos()
        {
            return _context.Amigos.ToList();
        }

        public void CrearAmigo(Amigo amigo)
        {
            try
            {
                _context.Amigos.Add(amigo);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
