using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioBiblioteca.CapaNegocio
{
    public class EjemplaresNegocio
    {

        EjemplaresDatos ejemplaresDatos = new EjemplaresDatos();



        public List<Ejemplar> GetListaEjemplares()
        {
            List<Ejemplar> list = ejemplaresDatos.TraerTodos();

            return list;
        }



        public List<Ejemplar> GetEjemplaresPorId(string idLibro)
        {
            List <Ejemplar> lista = ejemplaresDatos.Traer(idLibro);

            if(lista.Count == 0)
            {
                Console.WriteLine("No hay un ejemplar con ese Id de libro");
            }

            
            return lista;
        }



        public void Alta(int idLibro, int id, string observaciones, DateTime FechaAlta, int precio)
        {
            Ejemplar libro = new Ejemplar(idLibro, id, observaciones, FechaAlta, precio);


            TransactionResult transaction = ejemplaresDatos.InsertarEjemplar(libro);

            if (!transaction.IsOk)
            {
                throw new Exception(transaction.Error);
            } else
            {
                Console.WriteLine("Ejemplar agregado");
            }

        }


         //public Libro ObtenerEjemplarPorId(int idEjemplar)
        //{
          //  if (idEjemplar == 0) return null;

            //List<Libro> Ejemplar = EjemplaresDatos.Traer(idEjemplar);//No funciona
            //return Libro.Find(Libro => Libro.IdCliente == idLibro);
        //}
    }
}
