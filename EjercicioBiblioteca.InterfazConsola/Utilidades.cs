using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioBiblioteca.InterfazConsola
{
    public class Utilidades
    {
        public static string InsertarString(string mensaje)
        {

            string datoIngresado = "";

            do
            {

                Console.WriteLine(mensaje);
                datoIngresado = Console.ReadLine();

                if (datoIngresado == "")
                {
                    Console.WriteLine("el dato esta vacio.Ingreselo nuevamente");

                }

            } while (datoIngresado == "");

            return datoIngresado;
        }

        public static int InsertarInt(string mensaje)
        {
            int dato;

            do
            {

                Console.WriteLine(mensaje);
                dato = Convert.ToInt32(Console.ReadLine());

                if (dato < 1)
                {
                    Console.WriteLine("el dato ingresado no puede ser 0 o negativo.Ingreselo nuevamente");
                }


            } while (dato < 1);

            return dato;
        }

        public static DateTime InsertarFecha(string mensaje)
        {
            Console.WriteLine(mensaje);
            DateTime dato = Convert.ToDateTime(Console.ReadLine());
            return dato;
        }

        internal static int PedirNumeroNatural(
         string mensaje = "Ingresar un numero:",
         int min = 0,
         int max = int.MaxValue,
         bool obligatorio = false
     )
        {
            int numeroEntero = (int)PedirNumeroEntero(mensaje, min, max, obligatorio);
            return numeroEntero;
        }

        internal static long PedirNumeroEntero(
          string mensaje = "Ingresar un numero:",
          long min = long.MinValue,
          long max = long.MaxValue,
          bool obligatorio = false
      )
        {
            long numeroEntero;
            string input;

            Console.WriteLine(mensaje);
            while (!long.TryParse(input = Console.ReadLine(), out numeroEntero) || numeroEntero < min || numeroEntero > max)
            {
                
                if (!obligatorio && string.IsNullOrWhiteSpace(input)) return numeroEntero;
                Console.WriteLine("El numero ingresado no es valido. Ingresar un numero distinto:");
            }

            return numeroEntero;
        }

        internal static void PedirContinuacion(string mensaje = "")
        {
            if (!string.IsNullOrWhiteSpace(mensaje)) Console.WriteLine(mensaje);
            Console.WriteLine("Presionar una tecla para continuar");
            Console.ReadKey();
        }
    }
}
