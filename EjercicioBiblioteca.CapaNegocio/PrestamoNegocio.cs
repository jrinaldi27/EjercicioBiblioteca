﻿using System;
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

        public List<Prestamo> TraerPorLibro(int id)
        {
            List<Prestamo> list = prestamoDatos.Traer(id);

            if(list.Count == 0)
            {
                Console.WriteLine("No hay un prestamo con ese Id de ejemplar");
            }

            return list;
        }

        public void Alta(int idCliente, int idEjemplar, int plazo, DateTime fechaPrestamo, DateTime fechaDevolucionTentativa,
            DateTime fechaDevolucionReal, int id)
        {
            Prestamo prestamo = new Prestamo(idCliente, idEjemplar, plazo, fechaPrestamo, fechaDevolucionTentativa, fechaDevolucionReal, id);

            TransactionResult transaction = prestamoDatos.InsertarPrestamo(prestamo);

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);

            else
            {
                Console.WriteLine("Prestamo agregado");   
            }
        }


    }
}
