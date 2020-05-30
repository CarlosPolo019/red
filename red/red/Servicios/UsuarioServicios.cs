using red.Contexts;
using red.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace red.Servicios
{
    public class UsuarioServicios
    {
        private readonly AppDbContext _context;

        public UsuarioServicios()
        {
            _context = App.GetContext();
        }

        public ObservableCollection<Usuario> ObtenerUsuarios()
        {
            return _context.Usuarios.ToObservableCollection();
        }

        public List<Usuario> ObtenerListaUsuario()
        {
            return _context.Usuarios.ToList();
        }


        public void CrearUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ValidarUsuarioExiste( string email)
        { 
            try
            {
                Usuario usuario = new Usuario();
                usuario = _context.Usuarios.Where(x => x.Email.Trim() == email.Trim()).FirstOrDefault();
                if (usuario != null)
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            catch (Exception ex)
            {

                return "? "+ex;
            }
           
        }

        public string IngresarUsuario(string email,string password)
        {
            try
            {
                Usuario usuario = new Usuario();
                Usuario usuario2 = new Usuario();
                usuario = _context.Usuarios.Where(x => x.Email.Trim() == email.Trim()).FirstOrDefault();
                if (usuario != null)
                {
                    usuario2 = _context.Usuarios.Where(x => x.Email.Trim() == email.Trim() && x.Password.Trim() ==password.Trim()).FirstOrDefault();
                    if (usuario2 != null)
                    {
                        return "true";
                    }
                    else
                    {
                        return "false";
                    }
                }
                else
                {
                    return "null";
                }
            }
            catch (Exception ex)
            {

                return "? " + ex;
            }

        }
        public string ObtenerIdUsuario(string email)
        {
            try
            {
                Usuario usuario = new Usuario();

                usuario = _context.Usuarios.Where(x => x.Email.Trim() == email.Trim()).FirstOrDefault();
                var id = usuario.UsuarioID + "";
                return id;
               
            }
            catch (Exception ex)
            {

                return "? " + ex;
            }

        }
        public string ObtenerNombreCompletoUsuario(string email)
        {
            try
            {
               

               var usuario = _context.Usuarios.Where(x => x.Email.Trim() == email.Trim()).FirstOrDefault();
                var nombre= usuario.Nombre.Trim() + " " + usuario.Apellido.Trim();
                return nombre;

            }
            catch (Exception ex)
            {

                return "? " + ex;
            }

        }
      
    }
}
