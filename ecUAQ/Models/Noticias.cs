using System;
using System.Collections.Generic;

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
        public string autor { get; set; }
        public string fechaPublicacion { get; set; }
        public string url_imagen { get; set; }
        public string activo { get; set; }
    }

    public class ListNoticias{
        public List<Noticias> listaNotic { get; set; }
    }
}
