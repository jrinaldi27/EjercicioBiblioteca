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
            LibroNegocio libros = new LibroNegocio();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            EjemplaresNegocio ejemplaresNegocio = new EjemplaresNegocio();
            PrestamoNegocio prestamoNegocio = new PrestamoNegocio();

            //
            biblioteca.Libros = libros.GetListaLibro();
            biblioteca.Clientes = clienteNegocio.GetListaCliente();
            biblioteca.Prestamos = prestamoNegocio.GetListaPrestamo();
            
            

        bool continuarActivo = true;

            string menuPrincipal = "Presione una de las siguientes opciones\n1) Clientes \n2) Libros \n3) Prestamos " +
                
                " \nX) Salir";

            string menuClientes = ("Presione una de las siguientes opciones\n1) Agregar cliente \n 2) Consultar cliente \n 3) Listar clientes\n x) Salir ");

            string menuLibros = ("Presione una de las siguientes opciones\n1) Agregar Libro \n 2) Consultar Libro \n 3) Listar libros \n " +
                "4) Agregar ejemplar \n 5) Borrar ejemplar \n 6) Traer Ejemplar por id \n 7)Traer cantidad ejemplares ");

            string menuPrestamos = ("1) Prestar libro \n 2) Listar Prestamos \n  ");

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
                                //AgregarCliente(biblioteca);
                                //clienteNegocio.Alta(43253514, "Julian", "Rinaldi", "Jb 4427", "jr", "11234", Convert.ToDateTime("08-05-2001"), Convert.ToDateTime("09-06-2023"), true, "904251", 1);
                            }
                            if (opcionCliente.ToUpper() == "3")
                            {
                                ListarClientes(biblioteca);
                            }
                            else
                            {
                                break;
                            }

                            break;
                        case "2":
                            Console.WriteLine(menuLibros);
                            string opcionLibro = Console.ReadLine();
                            if (opcionLibro.ToUpper() == "3")
                            {
                                biblioteca.ListarLibros();

                            }

                            if (opcionLibro.ToUpper() == "6")
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
                            
                            if (opcionPrestamo.ToUpper() == "2")
                            {
                               foreach (Prestamo p in biblioteca.Prestamos)
                                {
                                    Console.WriteLine(p.ToString());
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

        
    }
}

