using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Globalization;

namespace EjercicioBiblioteca.AccesoDatos
{
    public class PrestamoDatos
    {

        public List<Prestamo> TraerTodos()
        {
            string json2 = WebHelper.Get("Biblioteca/Prestamos");
            List<Prestamo> resultado = Maplist(json2);
            return resultado;
        }
        


        private List<Prestamo> Maplist(string json)
        {
            List<Prestamo> lst = JsonConvert.DeserializeObject<List<Prestamo>>(json);
            return lst;
        }

      

        private NameValueCollection ReverseMap(Prestamo prestamo
            )
        {
            NameValueCollection n = new NameValueCollection();

            n.Add("idCliente", Convert.ToInt32(prestamo.IdCliente).ToString());
            n.Add("idEjemplar", prestamo.IdEjemplar.ToString());
            n.Add("plazo", prestamo.Plazo.ToString());//Chequear,
            n.Add("abierto", prestamo.Abierto.ToString());
            n.Add("fechaPrestamo", prestamo.FechaPrestamo.ToString());
            n.Add("fechaDevolucionTentativa", prestamo.FechaDevolucionTentativa.ToString());
            n.Add("fechaDevolucionReal", prestamo.FechaDevolucionReal.ToString());
            n.Add("id", prestamo.Id.ToString());




            return n;

        }
        public TransactionResult InsertarPrestamo(Prestamo prestamo)
        {
            NameValueCollection prestamoDatos = ReverseMap(prestamo);
            string json = WebHelper.Post("Biblioteca/Prestamos", prestamoDatos);

            TransactionResult resultado = JsonConvert.DeserializeObject<TransactionResult>(json);
            return resultado;

        }


    }
}

