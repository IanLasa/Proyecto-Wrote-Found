namespace WroteAndFound
{
    class Program
    {
        static List<List<string>> Usuarios = new List<List<string>>();
        static string[] menu = new string[10];
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("------- ¡Bienvenido a la biblioteca Wrote&Found! -------");
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
            menuBonito(8, "Menú");
        }
        // Ajustar la longitud opciones menú
        static string ajustarOpcionesMenu(string ajustar)
        {
            if (ajustar.Length > 39)
            {
                ajustar = ajustar.Substring(0, 39);
            }
            else
            {
                ajustar = ajustar.PadRight(39); // Rellena con espacios a la derecha
            }
                
        return ajustar + "║";
        }
        // Función para rellenar array para menú
        static void rellenarArray(string opcion1, string opcion2, string opcion3, string opcion4, string opcion5, string opcion6, string opcion7, string opcion8, string opcion9, string opcion10)
        {
            menu[0] = opcion1;
            menu[1] = opcion2;
            menu[2] = opcion3;
            menu[3] = opcion4;
            menu[4] = opcion5;
            menu[5] = opcion6;
            menu[6] = opcion7;
            menu[7] = opcion8;
            menu[8] = opcion9;
            menu[9] = opcion10;
        }
        // Función para hacer el menú bonito

        static void menuBonito(int largo, string nombreMenu)
        {
            rellenarArray("Catálogo de libros", "Crear un Usuario", "Coger un libro prestado", "Reservar un libro prestado", "Características de un libro", "Mirar préstamos en curso", "Devolver un libro", "Poner una reseña");
            Console.WriteLine("╔════════════════════════════╗");
            Console.WriteLine(nombreMenu);
            Console.WriteLine("║                            ║");
            for (int i = 0; i < largo; i++)
            {
                Console.WriteLine(ajustarOpcionesMenu(menu[i]));
            }
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
