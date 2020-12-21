using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEFCore.DataContext;
using XamEFCore.Interfaces;
using XamEFCore.Views;


namespace XamEFCore
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            GetContext().Database.EnsureCreated();
            MainPage = new NavigationPage(new Views.MainPage());

        }

        // Método para obtener el contexto cuando se inicia la aplicación
        public static AppDbContext GetContext()
        {
            string DbPath = DependencyService.Get<IConfigDataBase>().GetFullPath("efCore.db");

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
