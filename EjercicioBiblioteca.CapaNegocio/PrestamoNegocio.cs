using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjercicioBiblioteca.AccesoDatos;

namespace EjercicioBiblioteca.CapaNegocio
{
    public class PrestamoNegocio
    {
        PrestamoDatos prestamoDatos = new PrestamoDatos();

        public List<Prestamo> GetListaPrestamo()
        {
            List<Prestamo> list = prestamoDatos.TraerTodos();

            return list;
        }

        public void Alta(int idCliente, int idEjemplar, int plazo, DateTime fechaPrestamo, DateTime fechaDevolucionTentativa,
            DateTime fechaDevolucionReal, int id)
        {
            Prestamo prestamo = new Prestamo(idCliente, idEjemplar, plazo, fechaPrestamo, fechaDevolucionTentativa, fechaDevolucionReal, id);

            TransactionResult transaction = prestamoDatos.InsertarPrestamo(prestamo);

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }


    }
}
