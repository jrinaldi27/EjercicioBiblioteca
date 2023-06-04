using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioBiblioteca
{
    public class Libro
    {
        private int _id;
        private string _titulo;
        private string _autor;
        private DateTime _fechaPublicacion;
        private string _editorial;
        public int _edicion;
        public int _paginas;
        public string _tema;
        private List<Ejemplar> _ejemplares;

        public int IdLibro
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public string Autor
        {
            get { return _autor; }
            set { _autor = value; }
        }

        public DateTime FechaPublicacion
        {
            get { return _fechaPublicacion; }
            set { _fechaPublicacion = value; }
        }

        public string Editorial
        {
            get { return _editorial; }
            set { _editorial = value; }
        }

        public int Paginas
        {
            get { return _paginas;}
            set { _paginas = value; }
        }

        public int Edicion
        {
            get { return _edicion;}
            set { _edicion = value; }
        }

        public string Tema
        {
            get { return _tema; }
            set { _tema = value; }
        }
        public List<Ejemplar> Ejemplares
        {
            get { return _ejemplares; }
            set { _ejemplares= value; }
        }


        public Libro(int idLibro, string titulo, string autor, DateTime fechaPublicacion,
            string editorial, int paginas, int edicion, string tema)
        {
            IdLibro = idLibro;
            Titulo = titulo;
            Autor = autor;
            FechaPublicacion = fechaPublicacion;
            Editorial = editorial;
            Ejemplares = new List<Ejemplar>();
            Tema = tema;
            Edicion = edicion;
            Paginas = paginas;

        }


        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}-{8}", IdLibro, Titulo, Autor, FechaPublicacion, Editorial, Tema, Edicion, Paginas);
        }


        public void AgregarEjemplar(Ejemplar ejemplar)
        {
            Ejemplares.Add(ejemplar);
        }

        public void BorrarEjemplar (int id)
        {
            bool encontrado = false;

            foreach (Ejemplar e in Ejemplares)
            {
                if (e.Id == id)
                {
                    Ejemplares.Remove(e);
                    encontrado = true;
                }
   
            }

            if (encontrado == false)
            {
                throw new Exception("No se encontro el ejemplar a eliminar");

            }

            else
            {
                Console.WriteLine("Se elimino correctamente el ejemplar nro " + id + " del libro " + this.Titulo);
            }
        }

        public int TraerCantidadEjemplares()
        {
            return Ejemplares.Count();
        }
       
        
        public List<Ejemplar> TraerEjemplares(int idLibro)
       {
          List<Ejemplar> ejemplaresEncontrados = new List<Ejemplar>();

            foreach (Ejemplar ejemplar in Ejemplares)
            {
               if (ejemplar.IdLibro == idLibro)
                {
                  ejemplaresEncontrados.Add(ejemplar);
                }
            }

     return ejemplaresEncontrados;
}
       
    }
}
