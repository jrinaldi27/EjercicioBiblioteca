using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioBiblioteca.CapaNegocio
{
    public class ClienteNegocio
    {
        ClienteDatos clienteDatos = new ClienteDatos();
        public void Alta(int dni, string nombre, string apellido, string direccion, string email, string telefono
           , DateTime fechaNacimiento, DateTime fechaAlta, bool activo, string usuario, int idCliente)
        {


            Cliente c = new Cliente(dni, nombre, apellido, direccion, email, telefono, fechaNacimiento, fechaAlta, activo, usuario, idCliente);
            TransactionResult transaction = clienteDatos.InsertarCliente(c);

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
            else
            {
                Console.WriteLine("Cliente Agregado");
            }
        }


        public List<Cliente> GetListaCliente()
        {
            List<Cliente> list = clienteDatos.TraerTodos();

            return list;
        }

        public List<Cliente> GetClientesPorUsuario(string usuario)
        {
            List<Cliente> lista = clienteDatos.Traer(usuario);
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay un cliente con ese usuario");
            }

            return lista;
        }

        //no funciona porque el traer espera un string

         //public Cliente ObtenerClientePorId(int idCliente)
        //{
            //if (idCliente == 0) return null;

            //List<Cliente> clientes = ClienteDatos.Traer(idCliente);//No funciona
            //return clientes.Find(cliente => cliente.IdCliente == idCliente);
        //}
    }
}
