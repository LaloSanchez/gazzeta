using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ecUAQ.Models
{
    public class Noticias
    {
        public Noticias()
        {
        }

        public int idNoticia { get; set; }
        public string titulo { get; set; }
        public string contenido { get; set; }
        public string _contenido;
        public string resumen {
            get
            {
                if (contenido.Length > 100)
                {
                    return contenido.ToString().Substring(0, 100) + "...";
                }else{
                    return contenido;
                }
            }
            set
            {
                _contenido = value;
            }
        }
        public string autor { get; set; }
        public string fechaPublicacion { get; set; }
        public string url_imagen { get; set; }
        public string activo { get; set; }
    }

    public class ListNoticias{
        public ObservableCollection<Noticias> listaNotic { get; set; }
    }
}
