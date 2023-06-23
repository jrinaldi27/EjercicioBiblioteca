using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EjercicioBiblioteca.CapaNegocio;

namespace EjercicioBiblioteca.InterfazConsola
{
    class Program
    {
        static void Main(string[] args)
        {

            LibroNegocio libroNegocio = new LibroNegocio();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            EjemplaresNegocio ejemplaresNegocio = new EjemplaresNegocio();
            PrestamoNegocio prestamoNegocio = new PrestamoNegocio();


        bool continuarActivo = true;

            string menuPrincipal = "Presione una de las siguientes opciones\n1) Clientes \n2) Libros \n3) Prestamos  \n4) Reportes" +
                
                " \nX) Salir";

            string menuClientes = ("Presione una de las siguientes opciones\n1) Agregar cliente \n 2) Consultar cliente \n 3) Listar clientes\n x) Salir ");

            string menuLibros = ("Presione una de las siguientes opciones\n1) Agregar Libro \n 2) Consultar Libro \n 3) Listar libros \n " +
                "4) Agregar ejemplar  \n 5) Traer Ejemplar por id \n 6) Listar Ejemplares \n");

            string menuPrestamos = ("1) Prestar libro \n 2) Listar Prestamos \n" +
                "3) Consultar Prestamos por libro \n  ");

            string menuReportes = ("1) Prestamos por cliente \n 2) Ejemplares por Libro \n");

            // pantalla de bienvenida
            Console.WriteLine("Bienvenido a Biblioteca");

            do
            {
                //mostramos el menú
                Console.WriteLine(menuPrincipal);

                try
                {
                    //capturamos la seleccion
                    string opcionSeleccionada = Console.ReadLine();
                    //string opcionCliente = Console.ReadLine();

                    // validamos si el input es válido (en este caso podemos tmb dejar que el switch se encargue en el default.
                    // lo dejo igual por las dudas si quieren usar el default del switch para otra cosa.
                    //String[] opcionesValidas = new String[] { "1", "2", "3", "4", "X" };
               

                    if (opcionSeleccionada.ToUpper() == "X")
                    {
                        continuarActivo = false;
                        continue;
                    }


                    switch (opcionSeleccionada)
                    {
                        case "1":

                            Console.WriteLine(menuClientes);
                            string opcionCliente = Console.ReadLine();
                            if (opcionCliente.ToUpper() == "1")
                            {

                                clienteNegocio.Alta(Utilidades.InsertarInt("ingrese dni"),
                                    Utilidades.InsertarString("ingrese nombre"),
                                    Utilidades.InsertarString("ingrese apellido"),
                                    Utilidades.InsertarString("ingrese direccion"),
                                    Utilidades.InsertarString("ingrese email"),
                                    Utilidades.InsertarString("ingrese telefono"),
                                    Utilidades.InsertarFecha("inserte fecha nacimiento"),
                                    DateTime.Now, true, Utilidades.InsertarString("inserte usuario"),
                                    Utilidades.InsertarInt("inserte id cliente"));

                            }

                            if (opcionCliente.ToUpper() == "2")
                            {
                                string usuario = Utilidades.InsertarString("Ingrese el usuario a buscar");
                               
                                List<Cliente> lista = clienteNegocio.GetClientesPorUsuario(usuario);

                                foreach(Cliente c in lista)
                                {
                                    Console.WriteLine(c.ToString());
                                }


                            }

                            if (opcionCliente.ToUpper() == "3")
                            {
                                List<Cliente> listado = clienteNegocio.GetListaCliente();
                                foreach (Cliente c in listado)
                                {
                                    String leyenda = c.ToString();
                                    Console.WriteLine(leyenda);
                                }
                            }
                            else
                            {
                                break;
                            }

                            break;
                        case "2":
                            Console.WriteLine(menuLibros);
                            string opcionLibro = Console.ReadLine();

                            if(opcionLibro.ToUpper() == "1")
                            {
                                libroNegocio.Alta(Utilidades.InsertarInt("inserte id de libro"), 
                                    Utilidades.InsertarString("inserte titulo")
                                    , Utilidades.InsertarString("inserte autor"), 
                                    Utilidades.InsertarString("inserte editorial"), 
                                    Utilidades.InsertarInt("inserte cantidad de paginas"), 
                                    Utilidades.InsertarInt("inserte numero de edicion"), 
                                    Utilidades.InsertarString("inserte tema"));
                            }

                            if (opcionLibro.ToUpper() == "2")
                            {
                                int idlibro = Utilidades.InsertarInt("ingrese id libro");

                                List<Libro> l1 = libroNegocio.GetListaLibro();
                                bool encontrado = false;
                                foreach (Libro l in l1)
                                {
                                    if (idlibro == l.Id)
                                    {
                                        Console.WriteLine(l.ToString());
                                        encontrado = true;
                                    } 
                                    
                                }

                                if(!encontrado)
                                {
                                    Console.WriteLine("No existen libros con ese Id");
                                }



                            }

                            if (opcionLibro.ToUpper() == "3")
                            {

                                List<Libro> listado = libroNegocio.GetListaLibro();
                                foreach (Libro l in listado)
                                {
                                    String leyenda = l.ToString();
                                    Console.WriteLine(leyenda);
                                }

                            }

                            if (opcionLibro.ToUpper() == "4")
                            {
                                ejemplaresNegocio.Alta(Utilidades.InsertarInt("ingrese id libro"),
                                    Utilidades.InsertarInt("ingrese id ejemplar"),
                                    Utilidades.InsertarString("ingrese observaciones"),
                                    DateTime.Now, Utilidades.InsertarInt("ingrese precio"));
                            }

                            if (opcionLibro.ToUpper() == "5")
                            {
                                string idLibro = Utilidades.InsertarString("Ingrese el ID del libro a buscar");

                                List<Ejemplar> lista = ejemplaresNegocio.GetEjemplaresPorId(idLibro);
                                foreach (Ejemplar e in lista)
                                {
                                    Console.WriteLine(e.ToString());
                                }
                            }

                            if (opcionLibro.ToUpper() == "6")
                            {
                                List<Ejemplar> listado = ejemplaresNegocio.GetListaEjemplares();
                                foreach (Ejemplar e in listado)
                                {
                                    String leyenda = e.ToString();
                                    Console.WriteLine(leyenda);
                                }
                            }

                            else
                            {
                                break;
                            }
                            break;
                        case "3":
                            Console.WriteLine(menuPrestamos);
                            string opcionPrestamo = Console.ReadLine();

                            if(opcionPrestamo.ToUpper() == "1")
                            {
                                prestamoNegocio.Alta(Utilidades.InsertarInt("ingrese id cliente"),
                                    Utilidades.InsertarInt("ingrese id ejemplar"),
                                    Utilidades.InsertarInt("ingrese plazo"),
                                    DateTime.Now, Utilidades.InsertarFecha("ingrese fecha de devolucion tentativa"),
                                    DateTime.Now, Utilidades.InsertarInt("ingrese id prestamo"));
                            }
                            
                            if (opcionPrestamo.ToUpper() == "2")
                            {
                                List<Prestamo> listado = prestamoNegocio.GetListaPrestamo();
                                foreach (Prestamo p in listado)
                                {
                                    String leyenda = p.ToString();
                                    Console.WriteLine(leyenda);
                                }
                            }

                           
                            if (opcionPrestamo.ToUpper() == "3")
                            {
                                int idejemplar = Utilidades.InsertarInt("ingrese id ejemplar");

                                List<Prestamo> lista = prestamoNegocio.GetListaPrestamo();
                                bool encontrado = false;
                                foreach (Prestamo p in lista)
                                {
                                    if (idejemplar == p.IdEjemplar)
                                    {
                                        Console.WriteLine(p.ToString());
                                        encontrado = true;
                                    }

                                }

                                if (!encontrado)
                                {
                                    Console.WriteLine("No se encontraron prestamos para ese ejemplar");
                                }

                            } else
                            {
                                break;
                            }
                            break;
                        case "4":
                            Console.WriteLine(menuReportes);
                            string opcionReporte = Console.ReadLine();

                            if (opcionReporte.ToUpper() == "1")
                            {

                                ReportePrestamosPorCliente(Utilidades.InsertarInt("Ingrese id del cliente a consultar"));
                            }
                         
                            if (opcionReporte.ToUpper() == "2")
                            {

                                ReporteEjemplaresPorLibro(Utilidades.InsertarInt("ingrese id del libro a consultar"));
                              
                            }

                            else
                            {
                                break;
                            }

                            break;



                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error durante la ejecución del comando. Por favor intente nuevamente. Mensaje: " + ex.Message);
                }
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                Console.Clear();
            }
            while (continuarActivo);

            Console.WriteLine("Gracias por usar la app.");
            Console.ReadKey();

        }

        public static void ReporteEjemplaresPorLibro(int idLibro)
        {
            LibroNegocio libroNegocio = new LibroNegocio();


            List<Libro> l1 = libroNegocio.GetListaLibro();
            bool encontrado = false;
            foreach (Libro l in l1)
            {
                if (idLibro == l.Id)
                {
                    Console.WriteLine(l.ToString());
                    encontrado = true;
                }

            }

            if (!encontrado)
            {
                Console.WriteLine("No existen libros con ese Id");
            }

            

            EjemplaresNegocio ejemplaresNegocio= new EjemplaresNegocio();

            List<Ejemplar> lista = ejemplaresNegocio.GetListaEjemplares();
            List<Ejemplar> encontrados = new List<Ejemplar>();
            encontrado = false;

            
            foreach (Ejemplar e in lista)
            {
                if (idLibro == e.IdLibro)
                {
                    encontrado = true;
                    
                    
                    encontrados.Add(e);

                }

            }
            
            Console.WriteLine("Cantidad de ejemplares: " + encontrados.Count.ToString());
            Console.WriteLine("Lista de ejemplares: ");

            foreach (Ejemplar e in encontrados)
            {
                Console.WriteLine("-" + e.Observaciones);
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontraron ejemplares asociados a ese idLibro");
            }



        }

        public static void ReportePrestamosPorCliente(int idCliente)
        {

            ClienteNegocio clienteNegocio = new ClienteNegocio();


            List<Cliente> clientes = clienteNegocio.GetListaCliente();
            bool encontrado = false;
            foreach (Cliente c in clientes)
            {
                if (idCliente == c.Id)
                {
                    Console.WriteLine(c.ToString());
                    encontrado = true;
                }

            }

            if (!encontrado)
            {
                Console.WriteLine("No existen clientes con ese Id");
            }



            PrestamoNegocio prestamoNegocio = new PrestamoNegocio();

            List<Prestamo> lista = prestamoNegocio.GetListaPrestamo();
            List<Prestamo> encontrados = new List<Prestamo>();

            encontrado = false;
            foreach (Prestamo p in lista)
            {
                if (idCliente == p.IdCliente)
                {
                    encontrado = true;
                    encontrados.Add(p);

                }

            }

            Console.WriteLine("Cantidad de prestamos: " + encontrados.Count.ToString());
            Console.WriteLine("Lista de prestamos: ");

            foreach (Prestamo p in encontrados)
            {
                Console.WriteLine("-" + p.ToString());
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontraron prestamos asociados a ese id de cliente");
            }
        }


    }

   
}

