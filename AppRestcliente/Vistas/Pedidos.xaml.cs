using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRestcliente.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pedidosxaml : ContentPage
    {
        public Pedidosxaml()
        {
            InitializeComponent();
        }
        public static int idmesa;
    }
}