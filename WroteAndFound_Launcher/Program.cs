using System.Formats.Tar;

namespace WroteAndFound
{
    class Program
    {
        static List<List<string>> Usuarios = new List<List<string>>();
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("------- ¡Bienvenido a la biblioteca Wrote&Found! -------");
            ejecutarPrograma();
        }
        static void ejecutarPrograma()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
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
                        verCaracteristicas();
                        break;
                    case 5:
                        verPrestamo();
                        break;
                    case 6:
                        devolverLibro();
                        break;
                    case 7:
                        ponerResenia();
                        break;
                    case 8:
                        Console.WriteLine("¡Gracias por venir a Wrote&Found! ¡Esperamos verte de nuevo!");
                        exit = true;
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
            Console.WriteLine("");
            string[] menuPrincipal = { "Catálogo de libros", "Crear un Usuario", "Coger un libro prestado", "Reservar un libro prestado", "Características de un libro", "Mirar préstamos en curso", "Devolver un libro", "Poner una reseña" };
            menuBonito("Menú", menuPrincipal, 40);
        }
        // Ajustar Título menú
        static string ajustarTituloMenu(string nombreMenu, int comoDeGrande)
        {
            int centrar = (comoDeGrande - nombreMenu.Length) / 2 - 1;
            nombreMenu = nombreMenu.PadLeft(nombreMenu.Length + centrar).PadRight(comoDeGrande - 2);
            return "║" + nombreMenu + "║";
        }
        // Ajustar la longitud opciones menú
        static string ajustarOpcionesMenu(string ajustar, int numeroOpcion, int comoDeGrande)
        {
            ajustar = ajustar.PadRight(comoDeGrande); // Rellena con espacios a la derecha        
            return "║   " + numeroOpcion + ". " + ajustar + "║";
        }
        
        // Función para hacer el menú bonito

        static void menuBonito(string nombreMenu, string[] menu, int ancho)
        {
            Console.WriteLine("╔════════════════════════════╗");
            Console.WriteLine(ajustarTituloMenu(nombreMenu, ancho));
            Console.WriteLine("║                            ║");
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine(ajustarOpcionesMenu(menu[i], i + 1, ancho));
            }
            Console.WriteLine("║                            ║");
            Console.WriteLine("╚════════════════════════════╝");

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
                if (int.TryParse(entrada, out numero) && numero >= x && numero <= y)
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
            Console.WriteLine("╔════════════════════════════╗");
            Console.WriteLine("║      CATÁLOGO DE LIBROS    ║");
            Console.WriteLine("║                            ║");
            Console.WriteLine("║  1. Ver todos los libros   ║");
            Console.WriteLine("║  2. Buscar por autor       ║");
            Console.WriteLine("║  3. Añadir nuevo libro     ║");
            Console.WriteLine("║  4. Volver al menú         ║");
            Console.WriteLine("╚════════════════════════════╝");

        }
        static void crearUsuario()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════╗");
            Console.WriteLine("║    [ CREAR CUENTA ]    ║");
            Console.WriteLine("╚════════════════════════╝");
            Console.WriteLine("");
            Console.WriteLine("    👤  Username: ");
            Console.WriteLine("    🔒  Password: ");
            
        }
        static void cogerPrestado()
        {

        }
        static void reservarLibro()
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
