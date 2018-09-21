using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ecUAQ.Models;
using Xamarin.Forms;
using static ecUAQ.Models.Gazzetas;

namespace ecUAQ.Views
{
    public partial class GazzetasAnteriores : ContentPage
    {
        Config config = new Config();
        public GazzetasAnteriores()
        {
            InitializeComponent();
            cargaAnteriores();
            Title = "Gazzeta UAQ";
        }
        public void cargaAnteriores()
        {
            ObservableCollection<Gazzetas> galerias = new ObservableCollection<Gazzetas> { };
            Device.BeginInvokeOnMainThread(async () =>
            {
                RestClient cliente = new RestClient();

                var galeria = await cliente.Get<ListaGazzeta>(config.ipPrueba +"GazzetaWebservice2/api/tblgacetaspdf", "ListaGazzetas");
                if (galeria != null)
                {
                    foreach (var algo in galeria.listaGazzetas)
                    {

                        var objGal = new ecUAQ.Models.Gazzetas
                        {
                            idGacetaPdf = algo.idGacetaPdf,
                            titulo = algo.titulo,
                            infor = "Click para descargar",
                            url_imagen = "descarga.png",
                            url_pdf =  algo.url_pdf
                        };

                        galerias.Add(objGal);

                    }
                }
                ListaAnteriores.ItemsSource = galerias;

                ListaAnteriores.ItemSelected += (sender, e) =>
                {
                    var selectedObject = e.SelectedItem as ecUAQ.Models.Gazzetas;
                    if(selectedObject.url_pdf != ""){
                        Device.OpenUri(new Uri(config.ipPrueba+selectedObject.url_pdf));
                    }
                };
            });
        }
    }
}
