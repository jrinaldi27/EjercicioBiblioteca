using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioBiblioteca
{
    public class Biblioteca
    {
        private string _nombre;
        private string _direccion;
        private List<Libro> _libros;
        private List<Cliente> _clientes;
        private List<Prestamo> _prestamos;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Direccion { get { return _direccion; }
            set { _direccion = value; }
        }

        public List<Libro> Libros
        {
            get { return _libros; }
            set { _libros = value; }
        }

        public List<Cliente> Clientes
        {
            get { return _clientes; }
            set { _clientes = value; }
        }

        public List<Prestamo> Prestamos
        {
            get { return _prestamos; }
            set { _prestamos = value; }
        }

        public Biblioteca(string nombre, string direccion)
        {
            nombre = Nombre;
            direccion = Direccion;
            Libros = new List<Libro>();
            Prestamos = new List<Prestamo>();
            Clientes = new List<Cliente>();
        }

       

    }
}
