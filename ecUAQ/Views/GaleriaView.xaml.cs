using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ecUAQ.Models;
using Xamarin.Forms;

namespace ecUAQ.Views
{
    public partial class GaleriaView : ContentPage
    {
        Config config = new Config();
        public GaleriaView()
        {
            InitializeComponent();
            cargaGaleria();
            Title = "Galeria Universitaria";
        }
        public void cargaGaleria()
        {
            ObservableCollection<Galeria> galerias = new ObservableCollection<Galeria> { };
            Device.BeginInvokeOnMainThread(async () =>
            {
                RestClient cliente = new RestClient();

                var galeria = await cliente.Get<ListaGale>(config.ipPrueba+ "GazzetaWebservice2/api/tblgaleria", "listaGaleria");
                if (galeria != null)
                {
                    foreach (var algo in galeria.listaGaleria)
                    {
                        
                        var objGal = new ecUAQ.Models.Galeria
                        {
                            idGaleria = algo.idGaleria,
                            titulo = algo.titulo,
                            descripcion = algo.descripcion,
                            url_imagen = config.ipPrueba + algo.url_imagen
                        };

                        galerias.Add(objGal);

                    }
                }
                ListaGaleria.ItemsSource = galerias;
                ListaGaleria.ItemSelected += (sender, e) =>
                {
                    ListaGaleria.SelectedItem = null;
                };

            });
        }
    }
}
