namespace WroteAndFound
{
    class Program
    {
        // Variables Globales
        static string[] menu = new string[10];
        static List<List<string>> Usuarios = new List<List<string>>();
        static List<List<string>> Libros = new List<List<string>>()
        {
            new List<string>() { "Cien años de soledad", "Gabriel García Márquez", "1967", "Realismo mágico" },
            new List<string>() { "1984", "George Orwell", "1949", "Distopía" },
            new List<string>() { "El Principito", "Antoine de Saint-Exupéry", "1943", "Fábula" },
            new List<string>() { "Don Quijote de la Mancha", "Miguel de Cervantes", "1605", "Novela clásica" }
        };
        static bool salir = false;
        static int opcion;

        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("------- ¡Bienvenido a la biblioteca Wrote&Found! -------");
            ejecutarPrograma();
        }


        /// 
        /// Complementos para funciones
        /// 

        // Funcion para comprobar que el número que nos dan es
        static int pedirNumero(string pregunta, int x, int y, bool especial)
        {
            int numero;
            bool valido = false;
            do
            {
                Console.Write($"{pregunta}({x}-{y}): ");
                string entrada = Console.ReadLine();

                // Para casos especiales
                if (especial && entrada == "")
                {
                    return entrada;
                }

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
        
        // Función para hacer el menú bonito
        static void menuBonito(string nombreMenu, string[] menu, int ancho)
        {
            // Centrar el título
            int centrar = (ancho - 2 - nombreMenu.Length) / 2;
            string titulo = nombreMenu.PadLeft(nombreMenu.Length + centrar).PadRight(ancho - 2);

            // Línea Superior
            Console.WriteLine("╔" + new string('═', ancho - 2) + "╗");

            // Poner el Título
            Console.WriteLine($"║{titulo}║");

            // Línea de espacio
            Console.WriteLine("║" + new string(' ', ancho - 2) + "║");

            for (int i = 0; i < menu.Length; i++)
            {
                string opcion = $"{i + 1}. {menu[i]}";
                opcion = opcion.PadRight(ancho - 5); // Rellena con espacios a la derecha        
                Console.WriteLine($"║   {opcion}║");
            }
            // Otro espacio
            Console.WriteLine("║" + new string(' ', ancho - 2) + "║");

            // Salir
            string salir = "0. Salir";
            Console.WriteLine($"║   {salir.PadRight(ancho - 5)}║");

            // Última linea
            Console.WriteLine("╚" + new string('═', ancho - 2) + "╝");

            // Poner un espacio
            Console.WriteLine("");
        }

        // Función para comprobar que hay libros
        static bool hayLibros()
        {
            if (Libros.Count == 0) {
                // Simplemente le pedí a ChatGPT que pusiese los emojis
                Console.WriteLine("─────────────────────────────────────────────────────────");
                Console.WriteLine("📭  Actualmente no hay libros en la biblioteca...");
                Console.WriteLine("💨  ¡Parece que se han borrado todos! 😱");
                Console.WriteLine("");
                Console.WriteLine("✨  ¿Por qué no vas y añades uno nuevo? 📖");
                Console.WriteLine("─────────────────────────────────────────────────────────");
                Console.WriteLine("")
                Console.WriteLine("Presiona una tecla para volver...")
                Console.ReadKey();
                return false;
            } else {
                return true;
            }
        }
        

        static void ejecutarPrograma()
        {
            while (!salir)
            {
                Console.Clear();
                verMenu();
                opcion = pedirNumero("Escoge una opción ", 0, 8);
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
                        salir = true;
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
            menu = new string[] { "Catálogo de libros", "Crear un Usuario", "Coger un libro prestado", "Reservar un libro prestado", "Características de un libro", "Mirar préstamos en curso", "Devolver un libro", "Poner una reseña" };
            menuBonito("MENÚ", menu, 37);
        }

        /// OPCIÓN CATÁLOGO DE LIBROS
        static void catalogoLibros()
        {

            static void catalogoLibros()
            {
                Console.Clear();
                menu = new string[] { "Ver todos los libros", "Buscar por autor", "Añadir nuevo libro", "Volver al menú" };
                menuBonito("CATÁLOGO DE LIBROS", menu, 37);
                int opcion = pedirNumero("Escoge una opción ", 0, 4);
            }
          
            // Función ver libros
            static void verLibros()
            {
                Console.Clear();
                if (hayLibros)
                {
                    do
                    {
                        Console.WriteLine("");
                        Console.WriteLine("╔════════════════════════════╗");
                        for (int i = 0; i < Libros.Count; i++)
                        {
                            bool muchosLibros;
                            Console.WriteLine($"║   📘 {i+1}. {Libros[i][1]}  ║");
                            if ((i + 1) % 5 = 0)
                            {
                                // Por arreglar
                                Console.WriteLine("║   ... Presiona intro para ver mas libros")
                                Console.WriteLine("");
                                muchosLibros = true
    
                            } else {
                                Console.WriteLine("║   ... No hay mas libros")
                                Console.WriteLine("")
                                muchosLibros = false;
                            }
    
                            Console.WriteLine("║      0. Salir")
                            Console.WriteLine("╚════════════════════════════╝")
                            Console.WriteLine("");
                            Console.WriteLine("Puedes escribir el número del libro que quieres ver mas...")
                            Console.WriteLine("")
                            opcion = pedirNumero("¿Que quieres hacer?", 1, i + 1, muchosLibros)
                            if (opcion <= 0 && opcion >= (i + 1))
                            {
                                verCaracteristicasLibro(opcion);
                            }
                        } 
                    } while (!salir)
                }
            }
    
            // Ver características de los libros
            static void verCaracteristicasLibro(int l)
            {
                Console.WriteLine("---------------------------------------")
                Console.WriteLine($"📘 Libro {i + 1}:");
                Console.WriteLine($"   Título: {Libros[l][0]}");
                Console.WriteLine($"   Autor:  {Libros[l][1]}");
                Console.WriteLine($"   Año:    {Libros[l][2]}");
                Console.WriteLine($"   Género: {Libros[l][3]}");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Pulsa una tecla para volver")
                Console.ReadKey();
            }
        }

        /// 
        /// OPCIÓN CREAR CUENTA
        /// 
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


