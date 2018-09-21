using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ecUAQ.Models;
using Xamarin.Forms;

namespace ecUAQ.Views
{
    public partial class PaginaInicio : TabbedPage
    {
        Config config = new Config();
        public PaginaInicio()
        {
            InitializeComponent();
            CargarCategorias();
        }

        public void CargarCategorias() =>

            //List<ContentPage> categorias = new List<ContentPage> { };
            Device.BeginInvokeOnMainThread(async () =>
            {
                try{
                    RestClient cliente = new RestClient();
                    
                var categories = await cliente.Get<ListCategorias>(config.ipPrueba +"GazzetaWebservice2/api/tblcategorias", "listaCategos");                    if (categories != null)
                    {
                        if (categories != null)
                        {
                            foreach (var catego in categories.listaCategos)
                            {

                               // Device.BeginInvokeOnMainThread(async () =>
                                //{
                                    RestClient cliente2 = new RestClient();

                                var noticias = await cliente.Get<ListNoticias>(config.ipPrueba +"GazzetaWebservice2/api/tblnoticias/categoria/" + catego.cveCategoria, "listaNotic");
                                    if (noticias != null)
                                    {
                                        if (noticias.listaNotic.Count > 0)
                                        {


                                            ListView listaNot = new ListView { RowHeight = 100 };
                                            
                                            Debug.WriteLine(noticias.listaNotic[0].titulo);
                                        ObservableCollection<Noticias> item = new ObservableCollection<Noticias>();
                                            foreach (var noticiaCatego in noticias.listaNotic)
                                            {
                                                Noticias notic = new Noticias
                                                {
                                                    titulo = noticiaCatego.titulo,
                                                    contenido = noticiaCatego.contenido,
                                                    url_imagen = config.ipPrueba + noticiaCatego.url_imagen,
                                                };
                                                item.Add(notic);
                                            }
                                            
                                            listaNot.ItemsSource = item;
                                            listaNot.ItemTemplate = new DataTemplate(typeof(listTemplate));
                                            listaNot.ItemSelected += async (sender, e) =>
                                            {
        										if(e.SelectedItem == null)
        											return;
                                                var selectedObject = e.SelectedItem as ecUAQ.Models.Noticias;
                                                var SingleArticleView = new SingleArticleView(selectedObject);

                                                var newPage = new ContentPage();
                                                await Navigation.PushAsync(SingleArticleView);
                                        listaNot.SelectedItem = null;
                                            };
                                            var blueContentPage = new ContentPage
                                            {
                                                Content = new StackLayout
                                                {
                                                    HeightRequest = 100f,
                                                    Children = {

                                                        listaNot
                                                }
                                                }
                                            };
                                            blueContentPage.Title = catego.descCategoria;
                                            Children.Add(blueContentPage);
                                        }
                                    }
                               // });



                            }
                        }
                    }
            }catch(Exception ex){
                ListView listaNot = new ListView { RowHeight = 100 };
                ObservableCollection<Noticias> item = new ObservableCollection<Noticias>();
                Noticias notic = new Noticias
                {
                    titulo = "Noticias no disponibles",
                };
                item.Add(notic);
                listaNot.ItemsSource = item;
                    listaNot.ItemTemplate = new DataTemplate(typeof(listTemplate));
                var blueContentPage = new ContentPage
                {
                    Content = new StackLayout
                    {
                        HeightRequest = 100f,
                        Children = {

                                                    listaNot
                                            }
                    }
                };
                Children.Add(blueContentPage);
                Debug.WriteLine(ex);
            }
            });
    }
}
