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
    }
}
