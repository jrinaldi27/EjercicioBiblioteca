﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Collections.Specialized;


namespace EjercicioBiblioteca
{

    //clase de prueba para acdeder a los datos
    public class LibroDatos
    {
    
            public List<Libro> TraerTodos()
            {
                string json2 = WebHelper.Get("Libros"); // trae un texto en formato json de una web
                List<Libro> resultado = MapList(json2);
                return resultado;
            }

            public List<Libro> Traer(int id)
            {
                string json2 = WebHelper.Get("libro/" + id.ToString()); // trae un texto en formato json de una web
                List<Libro> resultado = MapList(json2);
                return resultado;
            }
        

            private List<Libro> MapList(string json)
            {
                List<Libro> lst = JsonConvert.DeserializeObject<List<Libro>>(json); // deserializacion
                return lst;
            }

            private Libro MapObj(string json)
            {
               Libro lst = JsonConvert.DeserializeObject<Libro>(json); // deserializacion
                return lst;
            }
            
          public TransactionResult InsertarLibro(Libro libro)
        {
            NameValueCollection libroDatos = ReverseMap(libro);
            string json = WebHelper.Post("Libro", libroDatos);

            TransactionResult resultado = JsonConvert.DeserializeObject<TransactionResult>(json);
            return resultado;
            
        }
        
      private NameValueCollection ReverseMap(Libro libro)
      {
         NameValueCollection n = new NameValueCollection();
         n.Add("Edicion",libro.edicion);
         n.Add("Paginas",libro.paginas.ToString());
         n.Add("Titulo",libro.titulo);
         n.Add("Autor", libro.autor);
         n.Add("Editorial", libro.editorial);
         n.Add("Tema",libro.tema)
         n.Add("Id", libro.id.Tostring())     
         n.Add("Usuario","") //falta
         return n;  
        
        
        }

   
}


