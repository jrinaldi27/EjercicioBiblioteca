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

    }
}
