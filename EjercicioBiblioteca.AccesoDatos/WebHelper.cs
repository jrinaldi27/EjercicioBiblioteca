using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace EjercicioBiblioteca
{
    public static class WebHelper
    {
         static WebClient client;
         static string rutaBase;

         static WebHelper()
        {
            client = new WebClient();
            client.Encoding = Encoding.UTF8;
            rutaBase = "https://cai-api.azurewebsites.net/api/v1/Biblioteca/";

            client.Headers.Add("contentType", "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        } 

        public static string Get(string url)
        {
            var uri = rutaBase + url;

            var responseString = client.DownloadString(uri);

            return responseString;
        }
    }
}
