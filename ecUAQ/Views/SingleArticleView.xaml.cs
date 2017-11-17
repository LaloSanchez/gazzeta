using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace ecUAQ.Views
{
    public partial class SingleArticleView : ContentPage
    {
        public SingleArticleView(ecUAQ.Models.Noticias Noticia)
        {

            InitializeComponent();
            cargarNoticia(Noticia);
        }

        public void cargarNoticia(ecUAQ.Models.Noticias Noticia){
            try
            {
                List<ecUAQ.Models.Noticias> eventos = new List<ecUAQ.Models.Noticias>{
                    new ecUAQ.Models.Noticias {
                        titulo =Noticia.titulo,
                        contenido = Noticia.contenido,
                        url_imagen = Noticia.url_imagen
                    }
                };

                SingleNotice.ItemsSource = eventos;
            }catch(Exception ex){
                Debug.WriteLine(ex);
            }
        }
    }
}
