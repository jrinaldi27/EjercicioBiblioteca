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
        private DateTime _fechaAlta;
        private bool _activo;
        public string _usuario;
        public string _host;
        private int _dni;
        private string _telefono;

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
        
        public DateTime FechaAlta
        {
            get { return _fechaAlta ; }
            set { _fechaAlta = value; }

        }

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }

        }

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }

        }
        public string Host
        {
            get { return _host; }
            set { _host = value; }

        }
        public int Dni

        {
            get { return _dni; }
            set { _dni = value; }

        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }




        public Cliente(int dni, string nombre, string apellido, string direccion, string email,  string telefono
           ,DateTime fechaNacimiento, DateTime fechaAlta, bool activo, string usuario,int idCliente) :base(nombre,apellido,direccion,fechaNacimiento)
        {
            IdCliente = idCliente;
            Email = email;
            Telefono = telefono;
            FechaAlta = fechaAlta;
            Activo = activo;
            Usuario = usuario;
            Host = "";

        }

        public override string ToString()
        {
            return this.IdCliente + ") " + this.Apellido + ", " + this.Nombre + ", " + this.Email;
        }

    }
}
