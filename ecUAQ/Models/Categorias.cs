using System;
using System.Collections.Generic;

namespace ecUAQ.Models
{
    public class Categorias
    {
        public Categorias(){}
        public int cveCategoria { get; set; }
        public string descCategoria { get; set; }
        public string activo { get; set; }
        public string fechaRegistro { get; set; }
    }
    public class ListCategorias{
        public List<Categorias> listaCategos { get; set; }
    }
}
