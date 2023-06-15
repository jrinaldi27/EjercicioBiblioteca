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
            string json2 = WebHelper.Get("cliente/");
            List<Cliente> resultado = Maplist(json2);
            return resultado;
        }
        public List<Cliente> Traer(string id)
        {
            string json = WebHelper.Get("cliente/" + id.ToString());
            List<Cliente> resultado = Maplist(json);
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
            string json = WebHelper.Post("cliente", clienteDatos);

            TransactionResult resultado = JsonConvert.DeserializeObject<TransactionResult>(json);
            return resultado;

        }

        private NameValueCollection ReverseMap(Cliente cliente)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("Dni", cliente.Dni.ToString());
            n.Add("Nombre", cliente.Nombre);
            n.Add("Apellido", cliente.Apellido);
            n.Add("Direccion", cliente.Direccion);
            n.Add("email", cliente.Email);
            n.Add("Telefono", cliente.Telefono);
            n.Add("Fecha nacimiento", cliente.FechaNacimiento.ToString("yyyy-MM-dd"));
            n.Add("Fecha Alta", cliente.FechaAlta.ToString("yyyy-MM-dd"));
            n.Add("Activo", cliente.Activo.ToString());
            n.Add("Usuario", cliente.Usuario);
            n.Add("Host", cliente.Host);

            n.Add("IdCliente", cliente.IdCliente.ToString());
            
            
            return n;

        }

    }
}