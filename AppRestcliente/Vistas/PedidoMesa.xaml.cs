using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;
using ZXing.Mobile;
using System.Linq.Expressions;


namespace AppRestcliente.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PedidoMesa : ContentPage
    {
        public PedidoMesa()
        {
            InitializeComponent();
            
        }
        private CancellationTokenSource TimerCancelar;
        int IdMesa = 0;
        async public Task<string> EscannerFlash(bool flashOn)
        {
            TimerCancelar = new CancellationTokenSource();
            MobileBarcodeScanner escaneo = new MobileBarcodeScanner();
            escaneo.BottomText = "Escanea el código QR de la mesa";
            ZXing.Result resultado = null;
            CancellationTokenSource controlCancelado = TimerCancelar;
            TimeSpan ts = new TimeSpan(0, 0, 0, 2, 0);
            Device.StartTimer(ts, () =>
                {
                    if (controlCancelado.IsCancellationRequested)
                    {
                        return false;
                    }
                    if(resultado == null)
                    {
                        escaneo.AutoFocus();
                        if (flashOn)
                        {
                            escaneo.Torch(true);
                        }
                        return true;
                    }
                        return false;
                });

            resultado = await escaneo.Scan();
            if (resultado != null) 
            {
                await Stop();
                string idCapturado;
                idCapturado = resultado.Text;
                string cadena = idCapturado;
                string[] separadas = cadena.Split( '|' );
                string Idprocesado = separadas[1];
                IdMesa = Convert.ToInt32(Idprocesado);
                PasarDatos();


            }
            await Stop();
            return string.Empty;

        }
        private void PasarDatos() 
        {
            if (IdMesa > 0)
            {
                Pedidosxaml.idmesa = IdMesa;
                Application.Current.MainPage = new Pedidosxaml();
            }
        }
        async private Task Stop()
        {
            await Task.Run(() =>
            {
                Interlocked.Exchange(ref this.TimerCancelar, new CancellationTokenSource()).Cancel();
            });
        }
        private async void btnEscanear_Clicked(object sender, EventArgs e)
        {
            await EscannerFlash(true);
        }

    }
}