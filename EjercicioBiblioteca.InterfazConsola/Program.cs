using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioBiblioteca.InterfazConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca("biblio1", "calle nueva 123");

            bool continuarActivo = true;

            string menuPrincipal = "Presione una de las siguientes opciones\n1) Clientes \n2) Libros \n3) Prestamos " +
                "\n4) Ingresar Cliente" +
                " \nX) Salir";

            string menuClientes = ("Presione una de las siguientes opciones\n1) Agregar cliente \n 2) Consultar cliente \n 3) Listar clientes\n x) Salir ");

            string menuLibros = ("1) Agregar Libro \n 2) Consultar Libro \n 3) Listar libros \n " +
                "4) Agregar ejemplar \n 5) Borrar ejemplar \n 6) Traer Ejemplares \n 7)Traer cantidad ejemplares ");

            string menuPrestamos = ("1) Prestar libro \n 2) Devolver libro \n  ");

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
                            }
                            if (opcionCliente.ToUpper() == "2")
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
                            if (opcionLibro.ToUpper() == "1")
                            {
                                
                            }
                            else
                            {
                                break;
                            }
                            break;
                        case "3":
                            Console.WriteLine(menuPrestamos);
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
            Cliente c1 = new Cliente(Utilidades.InsertarInt("Ingrese id de cliente"),
                Utilidades.InsertarString("Ingrese email"), Utilidades.InsertarString("Ingrese nombre"),
                Utilidades.InsertarString("Ingrese apellido"), Utilidades.InsertarString("Ingrese direccion"));

            biblioteca.IngresarCliente(c1);
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
}
