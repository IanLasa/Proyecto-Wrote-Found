using System;
using System.Collections.Generic;

namespace WroteAndFound
{
    class Program
    {
        static List<List<string>> Usuarios = new List<List<string>>();
        static void Main(string[] args)
        {
            ejecutarPrograma();
        }
        static void ejecutarPrograma()
        {
            Console.Clear();
            bool exit = false;
            while (!exit)
            {
                verMenu();
                int opcion = pedirNumero("Escoge una opción ", 0, 8);
                switch(opcion)
                {
                    case 0:
                        catalogoLibros();
                        break;
                    case 1:
                        crearUsuario();
                        break;
                    case 2:
                        cogerPrestado();
                        break;
                    case 3:
                        reservarLibro();
                        break;
                    case 4:
                        solicitarNuevo();
                        break;
                    case 5:
                        verCaracteristicas();
                        break;
                    case 6:
                        verPrestamo();
                        break;
                    case 7:
                        devolverLibro();
                        break;
                    case 8:
                        ponerResenia();
                        break;
                    case 9:
                        Console.WriteLine("¡Gracias por venir a Wrote&Found! ¡Esperamos verte de nuevo!");
                        exit = false;
                        break;
                }
            }
        }
        static void verMenu()
        {
            Console.WriteLine("       --------------------");
            Console.WriteLine("       |                | |");
            Console.WriteLine("       |                | |");
            Console.WriteLine("       |      Wrote     | |");
            Console.WriteLine("       |        &       | |");
            Console.WriteLine("       |      Found     | |");
            Console.WriteLine("       |                | |");
            Console.WriteLine("       |                | |");
            Console.WriteLine("       --------------------");
            Console.WriteLine("====================================");
            Console.WriteLine("  0. Catálogo de libros");
            Console.WriteLine("  1. Crear un usuario");
            Console.WriteLine("  2. Coger un libro Préstado");
            Console.WriteLine("  3. Reservar un libro (si está prestado)");
            Console.WriteLine("  4. Solicitar un libro (Que no esté en el catálogo)");
            Console.WriteLine("  5. Ver carecterísticas y resumen");
            Console.WriteLine("  6. Ver mis libros en préstamo");
            Console.WriteLine("  7. Devolver un libro");
            Console.WriteLine("  8. Poner una reseña a un libro");
            Console.WriteLine("  9. Salir de Wrote&Found");
        }

        // Funcion para comprobar que el número que nos dan es
        static int pedirNumero(string pregunta, int x, int y)
        {
            int numero;
            bool valido = false;
            do
            {
                Console.Write($"{pregunta}({x}-{y}): ");
                string entrada = Console.ReadLine();

                // Comprueba que lo que escriba el usuario se puede convertir en un int.
                if (int.TryParse(entrada, out numero) && numero >= 0 && numero <= 9)
                {
                    valido = true;
                }
                else
                {
                    Console.WriteLine($"{entrada} no es un número válido, vuelve a intentarlo.");
                    Console.ReadKey();
                }

            } while (!valido);
            return numero;

        }
        static void catalogoLibros()
        {

        }
        static void crearUsuario()
        {

        }
        static void cogerPrestado()
        {

        }
        static void reservarLibro()
        {

        }
        static void solicitarNuevo()
        {

        }
        static void verCaracteristicas()
        {

        }
        static void verPrestamo()
        {

        }
        static void devolverLibro()
        {

        }
        static void ponerResenia()
        {
            
        }
            
    }
} 