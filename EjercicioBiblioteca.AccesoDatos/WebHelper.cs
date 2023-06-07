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
        
        public static string post(string url, NameValueCollection parametros)
        {
            string uri = rutaBase + url;
            try
            {
               var response = client.UploadValues(uri,"POST", parametros);
                var responseString= Encoding.Default.GetString(response);
                return responseString;
            }
            catch (Exception ex)
            {
                return "{}"; //falta return
            }
             
            public static string Put(string url, NameValueCollection parametros)
            { 
                string uri = rutaBase + url;
            try
            {
               var response = client.UploadValues(uri,"PUT", parametros);
                var responseString= Encoding.Default.GetString(response);
                return responseString;
            }
            catch (Exception ex)
            {
                return "{}";
            }
    }
}
