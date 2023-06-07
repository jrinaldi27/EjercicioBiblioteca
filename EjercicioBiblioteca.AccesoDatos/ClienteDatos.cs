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
                string json2 = Webhelper.Get("Clientes");
                List<Cliente> resultado = Maplist(json2);
                return resultado;
            }
            public List<Cliente> Traer(int id)
            {
                string json2 = Webhelper.Get("Cliente/" + id.ToString());
                List<Cliente> resultado = Maplist(json2);
                return resultado;
            }

           

            private List<Cliente> Maplist (string json)
            {
                List<Cliente> lst = JsonConvert.DeserializeObject < List<Cliente<>>(Json);
                return lst;
            }

            private Cliente MapObj(string json)
            {
                Cliente lst = JsonConvert.DeserializeObject<Cliente>(json)
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
         n.Add("Nombre",cliente.nombre);
         n.Add("Apellido",cliente.apellido);
         n.Add("Direccion",cliente.direccion);
         n.Add("IdCliente", cliente.idCliente.ToString());
         n.Add("email"), cliente.email);
         n.Add("Usuario","") //falta
            return n;
      
   }
