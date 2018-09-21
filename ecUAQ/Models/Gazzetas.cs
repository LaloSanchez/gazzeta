using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ecUAQ.Models
{
    public class Gazzetas
    {
        public Gazzetas()
        {
        }

        public int idGacetaPdf { get; set; }
        public string url_pdf { get; set; }
        public string infor { get; set; }
        public string url_imagen { get; set; }
        public string activo { get; set; }
        public string fechaRegistro { get; set; }
        public string fechaActualizacion { get; set; }
        public string titulo { get; set; }

        public class ListaGazzeta
        {
            public ObservableCollection<Gazzetas> listaGazzetas { get; set; }
        }
    }
}
