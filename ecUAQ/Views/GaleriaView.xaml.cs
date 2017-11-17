using System;
using System.Collections.Generic;
using System.Diagnostics;
using ecUAQ.Models;
using Xamarin.Forms;

namespace ecUAQ.Views
{
    public partial class GaleriaView : ContentPage
    {
        public GaleriaView()
        {
            InitializeComponent();
            cargaGaleria();
        }
        public void cargaGaleria()
        {
            List<Galeria> galerias = new List<Galeria> { };
            Device.BeginInvokeOnMainThread(async () =>
            {
                RestClient cliente = new RestClient();

                var galeria = await cliente.Get<ListaGale>("http://189.211.201.181:75/GazzetaWebservice2/api/tblgaleria","listaGaleria");
                if (galeria != null)
                {
                    foreach (var algo in galeria.listaGaleria)
                    {
                        
                        var objGal = new ecUAQ.Models.Galeria
                        {
                            idGaleria = algo.idGaleria,
                            titulo = algo.titulo,
                            descripcion = algo.descripcion,
                            url_imagen = "http://189.211.201.181:75/" +algo.url_imagen
                        };

                        galerias.Add(objGal);

                    }
                }
                ListaGaleria.ItemsSource = galerias;
            });
        }
    }
}
