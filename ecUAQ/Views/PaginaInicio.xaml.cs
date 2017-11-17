using System;
using System.Collections.Generic;
using System.Diagnostics;
using ecUAQ.Models;
using Xamarin.Forms;

namespace ecUAQ.Views
{
    public partial class PaginaInicio : CarouselPage
    {
        public PaginaInicio()
        {
            InitializeComponent();
            CargarCategorias();
        }

        public void CargarCategorias() =>

            //List<ContentPage> categorias = new List<ContentPage> { };
            Device.BeginInvokeOnMainThread(async () =>
            {
                RestClient cliente = new RestClient();

                var categories = await cliente.Get<ListCategorias>("http://189.211.201.181:75/GazzetaWebservice2/api/tblcategorias", "listaCategos");
                if (categories != null)
                {
                    foreach (var catego in categories.listaCategos)
                    {

                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            RestClient cliente2 = new RestClient();

                            var noticias = await cliente.Get<ListNoticias>("http://189.211.201.181:75/GazzetaWebservice2/api/tblnoticias/categoria/" + catego.cveCategoria, "listaNotic");
                            if (noticias != null)
                            {
                                ListView listaNot = new ListView { };
                                Debug.WriteLine(noticias.listaNotic[0].titulo);
                                List<StackLayout> item = new List<StackLayout>();
                                foreach (var noticiaCatego in noticias.listaNotic)
                                {

                                    //empieza template noticias
                                    var titleLabel = new Label()
                                    {
                                        Text = "hola",
                                        FontFamily = "HelveticaNeue-Medium",
                                        FontSize = 18,
                                        TextColor = Color.Black
                                    };
                                    titleLabel.FontSize = 15;

                                    var discriptionLabel = new Label()
                                    {
                                        Text = "hola2",
                                        FontAttributes = FontAttributes.Bold,
                                        FontSize = 11,
                                        TextColor = Color.FromHex("#666")
                                    };
                                    //discriptionLabel.Text.Substring(0, 10);


                                    var ImagenPrincipal = new Image()
                                    {
                                        Source = noticiaCatego.url_imagen,
                                        AnchorX = 0,
                                        HeightRequest = 100,
                                        WidthRequest = 100,
                                        VerticalOptions = LayoutOptions.CenterAndExpand
                                    };

                                    var textLayout = new StackLayout
                                    {
                                        Orientation = StackOrientation.Vertical,
                                        Children = { titleLabel, discriptionLabel }
                                    };

                                    var generalStack = new StackLayout()
                                    {
                                        Spacing = 3,
                                        Orientation = StackOrientation.Horizontal,
                                        Children = { ImagenPrincipal, textLayout }
                                    };


                                    var cellLayout = new StackLayout
                                    {
                                        Spacing = 0,
                                        Padding = new Thickness(10, 5, 10, 5),
                                        Orientation = StackOrientation.Horizontal,
                                        HorizontalOptions = LayoutOptions.FillAndExpand,
                                        Children = { generalStack }
                                    };
                                    Debug.WriteLine(textLayout);
                                    item.Add(textLayout);
                                    //termina template noticias
                                }
                                listaNot.ItemsSource = item;
                                var blueContentPage = new ContentPage
                                {
                                    Content = new StackLayout
                                    {
                                        Children = {
                                             new Label()
                                                {
                                                Text = catego.descCategoria,
                                                    FontFamily = "HelveticaNeue-Medium",
                                                    FontSize = 18,
                                                    TextColor = Color.Black
                                                },
                                            listaNot
                                        }
                                    }
                                };
                                Children.Add(blueContentPage);

                                //listaNot.ItemSelected += async (sender, e) =>
                                //{
                                //    var selectedObject = e.SelectedItem as ecUAQ.Models.Noticias;
                                //    var SingleArticleView = new SingleArticleView(selectedObject);
                                //    //var WebViewPage = new WebViewPage("General Articles",string.Format("http:{0}",selectedObject.websiteLink));
                                //    var newPage = new ContentPage();
                                //    await Navigation.PushAsync(SingleArticleView);

                                //};
                            }
                        });



                    }
                }
            });
    }
}
