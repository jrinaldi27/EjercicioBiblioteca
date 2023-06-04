using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioBiblioteca
{
    public class Cliente : Persona
    {
        private int _idCliente;
        private string _email;

        public int IdCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public Cliente(int idCliente, string email, string nombre, string apellido,
            string direccion) :base(nombre,apellido,direccion)
        {
            idCliente = IdCliente;
            Email = email;
        }

        public override string ToString()
        {
            return this.IdCliente + ") " + this.Apellido + ", " + this.Nombre + ", " + this.Email;
        }

    }
}
