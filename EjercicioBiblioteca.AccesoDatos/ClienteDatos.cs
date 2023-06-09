using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Collections.Specialized;


namespace EjercicioBiblioteca
{
    public class ClienteDatos
    {
        public List<Cliente> TraerTodos()
        {
            string json2 = WebHelper.Get("Clientes");
            List<Cliente> resultado = Maplist(json2);
            return resultado;
        }
        public List<Cliente> Traer(int id)
        {
            string json2 = WebHelper.Get("Cliente/" + id.ToString());
            List<Cliente> resultado = Maplist(json2);
            return resultado;
        }



        private List<Cliente> Maplist(string json)
        {
            List<Cliente> lst = JsonConvert.DeserializeObject <List<Cliente>>(json);
            return lst;
        }

        private Cliente MapObj(string json)
        {
            Cliente lst = JsonConvert.DeserializeObject<Cliente>(json);
            return lst;
        }

        public TransactionResult InsertarCliente(Cliente cliente)
        {
            NameValueCollection clienteDatos = ReverseMap(cliente);
            string json = WebHelper.Post("Cliente", clienteDatos);

            TransactionResult resultado = JsonConvert.DeserializeObject<TransactionResult>(json);
            return resultado;

        }

        private NameValueCollection ReverseMap(Cliente cliente)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("Nombre", cliente.Nombre);
            n.Add("Apellido", cliente.Apellido);
            n.Add("Direccion", cliente.Direccion);
            n.Add("IdCliente", cliente.IdCliente.ToString());
            n.Add("email", cliente.Email);
            n.Add("Usuario", ""); //falta
            return n;

        }

    }
}