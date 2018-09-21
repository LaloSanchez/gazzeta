using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ecUAQ.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace ecUAQ.Services
{
    public class EventosDataStore: InterfaceEventosDataStore<Eventos>
    {
        Config config = new Config();
        HttpClient cliente;//Se inicializa un cliente de donde obtener los datos

        IEnumerable<Eventos> eventos;//Crea una coleccion (EINumerable) de tipo Eventos

        public EventosDataStore()
        {
            string url = config.ipPrueba + "GazzetaWebservice2/";//url
            cliente = new HttpClient();//Se crea la instancia del cliente
            cliente.BaseAddress = new Uri(url);//Se asigna la url
            eventos = new List<Eventos>();
        }

        public async Task<IEnumerable<Eventos>> getEventos(bool forceRefresh = false)
        {
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                var json = await cliente.GetStringAsync($"api/tblgaleria");
                eventos = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Eventos>>(json));
            }
            return eventos;
        }

    }
}
