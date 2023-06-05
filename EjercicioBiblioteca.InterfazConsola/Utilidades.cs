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
    }
}
