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
    public partial class Publicar : ContentPage
    {
        public Publicar()
        {
            InitializeComponent();
           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PkTipo.Items.Add("Publico");
            PkTipo.Items.Add("Privado");
            PkTipo.SelectedItem = "Publico";
            LblFecha.Text = ""+ DateTime.Now;
            if (Application.Current.Properties.ContainsKey("NombreCompleto"))
            {
                LblNombreCompleto.Text = Application.Current.Properties["NombreCompleto"] + "";
            }
        }

        private void BtnPublicar_Clicked(object sender, EventArgs e)
        {
            if (EntDescripcion.Text == null || EntDescripcion.Text =="" )
            {
                DisplayAlert("Alerta.", "El campo Descripcion es obligatorio.", "Aceptar");
            }
            else
            {
                var pkop = PkTipo.SelectedItem.ToString();
                var opcionPk = 0;
                if (pkop == "Publico")
                {
                    opcionPk = 0;
                }
                else if (pkop == "Privado")
                {
                    opcionPk = 1;
                }


                Publicacion pub = new Publicacion
                {
                    Id_usuario = int.Parse(Application.Current.Properties["IdUsuario"] + ""),
                    Tipo_publicacion = opcionPk,
                    Texto = EntDescripcion.Text,
                    Fecha = DateTime.Today
                };
                PublicacionServicios servicios = new PublicacionServicios();

                servicios.CrearPublicacion(pub);
                DisplayAlert("Creado.", "La publicacion se creo exitosamente.", "Aceptar");
                EntDescripcion.Text = "";
        
            }
        }
    }
}