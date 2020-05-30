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
    public partial class Loginpage : ContentPage
    {
        public Loginpage()
        {
            InitializeComponent();


        }

        private void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            if (EntEmail.Text == null || EntEmail.Text == "")
            {
                DisplayAlert("Alerta", "El campo E-mail es obligatorio", "Aceptar");
            }
            else
            {
                if (EntPasword.Text == null || EntPasword.Text == "")
                {
                    DisplayAlert("Alerta", "El campo Contaseña es obligatorio", "Aceptar");
                }
                else
                {
                    try
                    {
                        UsuarioServicios servicios = new UsuarioServicios();
                        var existe = servicios.IngresarUsuario(EntEmail.Text,EntPasword.Text);
                        if (existe == "true")
                        {
                            DisplayAlert("Login.", "El usuario " + EntEmail.Text.Trim() + " ingreso correctamente.", "Aceptar");
                            string id = servicios.ObtenerIdUsuario(EntEmail.Text);
                            Application.Current.Properties["IdUsuario"] = id;
                            string nc = servicios.ObtenerNombreCompletoUsuario(EntEmail.Text);
                            Application.Current.Properties["NombreCompleto"] = nc;
                            Application.Current.SavePropertiesAsync();
                            EntEmail.Text = "";
                            EntPasword.Text = "";
                            Navigation.PushAsync(new opciones());
                        }
                        else if (existe == "false")
                        {
                            DisplayAlert("Alerta.", "El usuario " + EntEmail.Text.Trim() + " o la Contraseña es incorrecto.", "Aceptar");
                            EntEmail.Text = "";
                            EntPasword.Text = "";
                        }
                        else if (existe == "null")
                        {
                            DisplayAlert("ERROR.", "El usuario " + EntEmail.Text.Trim() + " no esta registrado ", "Aceptar");
                        }
                        else
                        {
                            DisplayAlert("ERROR.", existe, "Aceptar");
                        }

                    }
                    catch (Exception ex)
                    {

                        DisplayAlert("ERROR", "Ocurrio el siguiente error:" + ex, "Aceptar");
                    }
                }
            }
        }

        private void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Registrar());
        }

      
    }
}