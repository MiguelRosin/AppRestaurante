using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppRestcliente.Vistas;

namespace AppRestcliente
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PedidoMesa();
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
