using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioBiblioteca

{
    public class LibroNegocio
    {
        private LibroDatos _libroDatos;

        public LibroNegocio()
        {
            _libroDatos = new LibroDatos();
            
        }
        //probando metodo
        public List<Libro> GetListaLibro()
        {
            List<Libro> list = _libroDatos.TraerTodos();

            return list;
        } 
        
        //public void Alta(int id, string titulo, string autor, DateTime fechaPublicacion, string email)
       // {
                 //Libro libro = new Libro();
                // libro.IdLibro = id;
                // libro.Titulo = titulo;
                // cliente.Direccion=direccion;
                // cliente.IdCliente=idCliente;
                // cliente.Email=email;
                 
                // TransactionResult transaction= _clienteDatos.Insertar(Cliente);
                 
                // if(!transaction.IsOk)
                 //    throw new Exception(transaction.Error);
        }

    } 
//}
