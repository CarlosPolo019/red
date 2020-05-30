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
    public partial class opciones : ContentPage
    {
        public opciones()
        {
            InitializeComponent();
        }

        private void BtnPublicaciones_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Publicar());

        }

        private void BtnPublicar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Publicar());
        }

        private void BtnBuscraA_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Publicar());

        }
    }
}