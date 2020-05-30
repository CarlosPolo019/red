using red.Contexts;
using red.Interfaces;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace red
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            GetContext().Database.EnsureCreated();
            MainPage = new NavigationPage( new Loginpage());
        }


        public static AppDbContext GetContext()
        {
            string DbPath = DependencyService.Get<IConfigDataBase>().GetFullPath("social.db");
            return new AppDbContext(DbPath);
        }




        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
