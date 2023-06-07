using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Collections.Specialized;


namespace EjercicioBiblioteca
    {
        public class EjemplaresDatos
        {
            public List<Ejemplar> TraerTodos()
            {
                string json2 = Webhelper.Get("Ejemplares");
                List<Ejemplar> resultado = Maplist(json2);
                return resultado;
            }
            public List<Ejemplar> Traer(int id)
            {
                string json2 = Webhelper.Get("Cliente/" + id.ToString());
                List<Ejemplar> resultado = Maplist(json2);
                return resultado;
            }

         
            private List<Ejemplar> Maplist (string json)
            {
                List<Cliente> lst = JsonConvert.DeserializeObject < List<Cliente<>>(json);
                return lst;
            }

            private Ejemplar MapObj(string json)
            {
                Ejemplar lst = JsonConvert.DeserializeObject<Cliente>(json)
             return lst;
            }
            
             private NameValueCollection ReverseMap( Ejemplar ejemplar)
        {
            NameValueCollection n = new NameValueCollection();
            {
              n.Add{ "idLibro", Convert.ToInt32(ejemplar.idLibro).ToString() },
              n.Add{ "observaciones", ejemplar.observaciones)},
              n.Add{ "Precio", ejemplar.Precio.ToString("F", CultureInfo.GetCultureInfo("es-AR"))}//Chequear,
              n.Add{ "fechaAlta", producto.fechaAlta.ToString("yyyy-MM-dd") },
              n.Add{"id", Convert.ToInt32(ejemplar,id).ToString()}
              n.Add{  } //Falta parametros
            };

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
