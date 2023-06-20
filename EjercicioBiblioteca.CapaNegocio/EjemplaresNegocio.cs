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


        public List<Ejemplar> GetEjemplares(string idLibro)
        {
            List <Ejemplar> lista = ejemplaresDatos.Traer(idLibro);


            
            return lista;
        }



        public void Alta(int idLibro, int id, string observaciones, DateTime FechaAlta, int precio)
        {
            Ejemplar libro = new Ejemplar(idLibro, id, observaciones, FechaAlta, precio);


            TransactionResult transaction = ejemplaresDatos.InsertarEjemplar(libro);

            if (!transaction.IsOk)
            {
                throw new Exception(transaction.Error);
            }

        }
         public Libro ObtenerEjemplarPorId(int idEjemplar)
        {
            if (idEjemplar == 0) return null;

            List<Libro> Ejemplar = EjemplaresDatos.Traer(idEjemplar);//No funciona
            return Libro.Find(Libro => Libro.IdCliente == idLibro);
        }
    }
}
