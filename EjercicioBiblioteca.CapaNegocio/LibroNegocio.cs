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

        public List<Libro> GetbyId(int id)
        {
            List<Libro> lista = _libroDatos.Traer(id);

            return lista;
        }

        public void Alta(int id, string titulo, string autor, string editorial, int paginas, int edicion, string tema)
        {
            Libro libro = new Libro(id, titulo, autor, editorial, paginas, edicion, tema);


            TransactionResult transaction = _libroDatos.InsertarLibro(libro);

            if (!transaction.IsOk)
            {
                throw new Exception(transaction.Error);
            } else
            {
                Console.WriteLine("Libro Agregado");
            }

        }

        //chequear el find de libro
         public Libro ObtenerLibroPorId(int idLibro)
        {
            Libro libro = null;
            if (idLibro == 0) return null;
            
            List<Libro> libros = _libroDatos.Traer(idLibro);//No funciona
            //return Libro.Find(Libro => Libro.IdCliente == idLibro);
            return libro;
        }
    }
}
