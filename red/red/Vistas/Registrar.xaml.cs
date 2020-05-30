using red.Modelos;
using red.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace red
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registrar : ContentPage
    {
        public Registrar()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (EntConfPassword.Text != Entpassword.Text)
            {
                DisplayAlert("Error", "Las contraceñas no coinciden.", "Aceptar");
                Entpassword.Text = "";
                EntConfPassword.Text = "";
            }
            else
            {
                if (EntNombre.Text == null || EntNombre.Text== "")
                {
                    DisplayAlert("Alerta", "El campo Nombre es obligatorio", "Aceptar");
                }
                else
                {
                    if (EntApellido.Text == null || EntApellido.Text == "")
                    {
                        DisplayAlert("Alerta", "El campo Apellido es obligatorio", "Aceptar");
                    }
                    else
                    {
                        if (EntEmail.Text == null || EntEmail.Text == "")
                        {
                            DisplayAlert("Alerta", "El campo Email es obligatorio", "Aceptar");
                        }
                        else
                        {
                            if (Entpassword.Text == null || Entpassword.Text == "")
                            {
                                DisplayAlert("Alerta", "El campo Contraseña es obligatorio", "Aceptar");
                            }
                            else
                            {
                                if (EntConfPassword.Text == null || EntConfPassword.Text == "")
                                {
                                    DisplayAlert("Alerta", "El campo Confirmar Contaseña es obligatorio", "Aceptar");
                                }
                                else
                                {
                                    try
                                    {
                                        Usuario usuario = new Usuario
                                        {
                                            Nombre = EntNombre.Text,
                                            Apellido = EntApellido.Text,
                                            Email = EntEmail.Text,
                                            Password = Entpassword.Text,
                                            Imagen = "",
                                            Fecha = DateTime.Today
                                        };
                                        UsuarioServicios servicios = new UsuarioServicios();
                                        var existe = servicios.ValidarUsuarioExiste(EntEmail.Text);
                                        if (existe=="true")
                                        {
                                            DisplayAlert("Alerta.", "El usuario " + EntEmail.Text.Trim() + " ya existe.", "Aceptar");
                                            EntEmail.Text = "";
                                        }
                                        else if (existe=="false")
                                        {
                                            servicios.CrearUsuario(usuario);
                                            DisplayAlert("Creado.", "El usuario " + EntEmail.Text.Trim() + " se creo exitosamente.", "Aceptar");
                                            EntNombre.Text = "";
                                            EntApellido.Text = "";
                                            EntEmail.Text = "";
                                            Entpassword.Text = "";
                                            EntConfPassword.Text = "";
                                            EntConfPassword.Text = "";
                                            Navigation.PopModalAsync();
                                        }
                                        else 
                                        {
                                            DisplayAlert("EROR.", existe, "Aceptar");
                                        }
                                       
                                    }
                                    catch (Exception ex)
                                    {

                                        DisplayAlert("ERROR", "Ocurrio el siguiente error:" + ex, "Aceptar");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnVolver_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}