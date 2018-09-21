using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ecUAQ.Models
{
    public class Galeria
    {
        public Galeria()
        {

        }

        public int idGaleria { get; set; }
        public string url_imagen { get;set;}
        public string activo{get;set;}
        public string fechaRegistro { get; set; }
        public string fechaActualizacion { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
    }
    public class ListaGale
    {
        public ObservableCollection<Galeria> listaGaleria { get; set; }
    }
}
