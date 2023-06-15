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
        }


        public List<Cliente> GetListaCliente()
        {
            List<Cliente> list = clienteDatos.TraerTodos();

            return list;
        }

        public List<Cliente> GetClientesPorUsuario(string usuario)
        {
            List<Cliente> lista = clienteDatos.Traer(usuario);

            return lista;
        }
    }
}
