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
            Biblioteca biblioteca = new Biblioteca("biblio1", "calle nueva 123");
            
            LibroNegocio libroNegocio = new LibroNegocio();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            EjemplaresNegocio ejemplaresNegocio = new EjemplaresNegocio();
            PrestamoNegocio prestamoNegocio = new PrestamoNegocio();

            //
            //biblioteca.Libros = libroNegocio.GetListaLibro();
            //biblioteca.Clientes = clienteNegocio.GetListaCliente();
            //biblioteca.Prestamos = prestamoNegocio.GetListaPrestamo();
            
            

        bool continuarActivo = true;

            string menuPrincipal = "Presione una de las siguientes opciones\n1) Clientes \n2) Libros \n3) Prestamos " +
                
                " \nX) Salir";

            string menuClientes = ("Presione una de las siguientes opciones\n1) Agregar cliente \n 2) Consultar cliente \n 3) Listar clientes\n x) Salir ");

            string menuLibros = ("Presione una de las siguientes opciones\n1) Agregar Libro \n 2) Consultar Libro \n 3) Listar libros \n " +
                "4) Agregar ejemplar  \n 5) Traer Ejemplar por id \n  ");

            string menuPrestamos = ("1) Prestar libro \n 2) Listar Prestamos \n" +
                "3) Consultar Prestamos por libro \n  ");

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
                    String[] opcionesValidas = new String[] { "1", "2", "3", "4", "X" };
                    String[] opcionesClientes = new String[] { "1", "2", "3", "4", "X" };

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

                                AgregarCliente(biblioteca);
                                

                                
                                clienteNegocio.Alta(Utilidades.InsertarInt("ingrese dni"),
                                    Utilidades.InsertarString("ingrese nombre"),
                                    Utilidades.InsertarString("ingrese apellido"),
                                    Utilidades.InsertarString("ingrese direccion"),
                                    Utilidades.InsertarString("ingrese email"),
                                    Utilidades.InsertarString("ingrese telefono"),
                                    Utilidades.InsertarFecha("inserte fecha nacimiento"),
                                    DateTime.Now, true, Utilidades.InsertarString("inserte usuario"),
                                    Utilidades.InsertarInt("inserte id cliente")); ;
                                    

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

                           //ver porque los codigos de los libros son todos cero
                            if (opcionLibro.ToUpper() == "2")
                            {
                                int idlibro = Utilidades.InsertarInt("ingrese id libro");

                                List<Libro> l1 = libroNegocio.GetListaLibro();
                                foreach (Libro l in l1)
                                {
                                    if (idlibro == l.IdLibro)
                                    {
                                        Console.WriteLine(l.ToString());
                                        break;
                                    } else
                                    {
                                        Console.WriteLine("No existe un libro con ese id");
                                    }
                                    
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

                                List<Ejemplar> lista = ejemplaresNegocio.GetEjemplares(idLibro);
                                foreach (Ejemplar e in lista)
                                {
                                    Console.WriteLine(e.ToString());
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
                                foreach (Prestamo p in lista)
                                {
                                    if (idejemplar == p.IdEjemplar)
                                    {
                                        Console.WriteLine(p.ToString());
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("No existe un prestamo asociado a ese ejemplar");
                                    }

                                }
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

        public static void AgregarCliente(Biblioteca biblioteca)
        {
           // Cliente c1 = new Cliente(Utilidades.InsertarInt("Ingrese id de cliente"),
               // Utilidades.InsertarString("Ingrese email"), Utilidades.InsertarString("Ingrese nombre"),
              //  Utilidades.InsertarString("Ingrese apellido"), Utilidades.InsertarString("Ingrese direccion"));

           // biblioteca.IngresarCliente(c1);
            Console.WriteLine("cliente agregado");
        }

        public static void ListarClientes(Biblioteca biblioteca)
        {

            foreach (Cliente c in biblioteca.Clientes)
            {

                Console.WriteLine(c.ToString());
            }
        }

         private static void MostrarClientePorId()
        {
            Console.WriteLine("(Ingresar 'c' para cancelar)");
            try
            {
                int idCliente = Utilidades.PedirNumeroNatural("Ingresar Id del Cliente:");
                Cliente cliente = clienteNegocio.ObtenerClientePorId(idCliente);

                if (cliente == null)
                {
                    Utilidades.PedirContinuacion($"No existe un cliente con Id {idCliente}.");
                    return;
                }

                Console.WriteLine(cliente);
            }

            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error consultar los clientes. Vuelva a intentar en unos minutos.");
            }

            Console.WriteLine();



        }
        public static void AgregarLibro(Biblioteca biblioteca)
        {
            Libro l1 = new Libro(Utilidades.InsertarInt("Ingrese id de Libro"),
               Utilidades.InsertarString("Ingrese Titulo"), Utilidades.InsertarString("Ingrese autor"), Utilidades.InsertarFecha("Ingrese fecha"),
                Utilidades.InsertarString("Ingrese editorial"), Utilidades.InsertarInt("Ingrese edición"), Utilidades.InsertarInt("Ingrese paginas"), Utilidades.InsertarString("Ingrese tema"));

            biblioteca.IngresarCliente(l1);
            Console.WriteLine("libro agregado");
        }

        public static void ListarLibros(Biblioteca biblioteca)
        {

            foreach (Libro c in biblioteca.Libros)
            {

                Console.WriteLine(c.ToString());
            }
        }

        private static void MostrarLibroPorId()
        {
            Console.WriteLine("(Ingresar 'c' para cancelar)");
            try
            {
                int idLibro = Utilidades.PedirNumeroNatural("Ingresar Id del Cliente:");
                Libro libro = LibroNegocio.ObtenerLibroPorId();

                if (libro == null)
                {
                    Utilidades.PedirContinuacion($"No existe un libro con Id {idLibro}.");
                    return;
                }

                Console.WriteLine(libro);
            }

            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error consultar los libros. Vuelva a intentar en unos minutos.");
            }

            Console.WriteLine();

        }

        public static void AgregarEjemplar(Libro libro)
        {
            Ejemplar e1 = new Ejemplar(Utilidades.InsertarInt("Ingrese id del Libro"), Utilidades.InsertarInt("Ingrese el id del Ejemplar"),
            Utilidades.InsertarString("Ingrese obsevaciones"), Utilidades.InsertarInt("Ingrese precio"), Utilidades.InsertarFecha("Ingrese fecha de alta"));

            Ejemplar.IngresarEjemplar(e1);
            Console.WriteLine("Ejemplar agregado");
        }
    }
}

