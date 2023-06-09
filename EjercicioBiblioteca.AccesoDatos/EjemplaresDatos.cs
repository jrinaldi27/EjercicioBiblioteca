using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Globalization;

namespace EjercicioBiblioteca
{
    public class EjemplaresDatos
    {
        public List<Ejemplar> TraerTodos()
        {
            string json2 = WebHelper.Get("Ejemplares");
            List<Ejemplar> resultado = Maplist(json2);
            return resultado;
        }
        public List<Ejemplar> Traer(int id)
        {
            string json2 = WebHelper.Get("Cliente/" + id.ToString());
            List<Ejemplar> resultado = Maplist(json2);
            return resultado;
        }


        private List<Ejemplar> Maplist(string json)
        {
            List<Ejemplar> lst = JsonConvert.DeserializeObject<List<Ejemplar>>(json);
            return lst;
        }

        private Ejemplar MapObj(string json)
        {
            Ejemplar lst = JsonConvert.DeserializeObject<Ejemplar>(json);
            return lst;
        }

        private NameValueCollection ReverseMap(Ejemplar ejemplar)
        {
            NameValueCollection n = new NameValueCollection();

            n.Add("idLibro", Convert.ToInt32(ejemplar.IdLibro).ToString());
            n.Add("observaciones", ejemplar.Observaciones);
            n.Add("Precio", ejemplar.Precio.ToString("F", CultureInfo.GetCultureInfo("es-AR")));//Chequear,
            n.Add("fechaAlta", ejemplar.FechaAlta.ToString("yyyy-MM-dd"));
            n.Add("id", ejemplar.Id.ToString());



            return n;

        }
        public TransactionResult InsertarEjemplar(Ejemplar ejemplar)
        {
            NameValueCollection ejemplarDatos = ReverseMap(ejemplar);
            string json = WebHelper.Post("Ejemplar", ejemplarDatos);

            TransactionResult resultado = JsonConvert.DeserializeObject<TransactionResult>(json);
            return resultado;

        }


    }
}