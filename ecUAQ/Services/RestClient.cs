using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace ecUAQ
{
    public class RestClient
    {
        public async Task<T> Get<T>(string url,string nombre){
            try{
                HttpClient cliente = new HttpClient();
                cliente.Timeout = TimeSpan.FromSeconds(10000);
                Debug.Write(url);
                var respuesta = await cliente.GetAsync(url);
                Debug.Write(url);
                if(respuesta.StatusCode == System.Net.HttpStatusCode.OK){
                    var jsonRespuesta = await respuesta.Content.ReadAsStringAsync();
                    var jsonArmado = "{\""+nombre+"\":" + jsonRespuesta + "}";

                    Debug.WriteLine(jsonArmado); 
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonArmado);
                }
            } catch(Exception ex){
                Debug.WriteLine("\nOcurrio un error en la funcion Get del Task"); 
                Debug.WriteLine(ex); 
            }
            return default(T);
        }
    }
}
