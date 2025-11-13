namespace WroteAndFound
{
    class Program
    {
        /// Variables Globales

        // Array global para crear menús
        static string[] menu = new string[10];

        // Lista global para los Usuarios
        static List<List<string>> Usuarios = new List<List<string>>();

        // Lista Global para los libros
        static List<List<string>> Libros = new List<List<string>>()
        {
            new List<string>() { "Cien años de soledad", "Gabriel García Márquez", "1967", "Realismo mágico" },
            new List<string>() { "1984", "George Orwell", "1949", "Distopía" },
            new List<string>() { "El Principito", "Antoine de Saint-Exupéry", "1943", "Fábula" },
            new List<string>() { "Don Quijote de la Mancha", "Miguel de Cervantes", "1605", "Novela clásica"},
            new List<string>() { "Orgullo y prejuicio", "Jane Austen", "1813", "Romance" },
            new List<string>() { "Moby Dick", "Herman Melville", "1851", "Aventura" },
            new List<string>() { "La Metamorfosis", "Franz Kafka", "1915", "Existencialismo" },
            new List<string>() { "Crimen y castigo", "Fiódor Dostoyevski", "1866", "Filosófica" },
            new List<string>() { "El Gran Gatsby", "F. Scott Fitzgerald", "1925", "Novela moderna" },
            new List<string>() { "Harry Potter y la piedra filosofal", "J.K. Rowling", "1997", "Fantasía" },
        };

        // Lista global para los DVDs
        static List<List<string>> DVDs = new List<List<string>>()
        {
            new List<string>() { "Cien años de soledad", "Gabriel García Márquez", "1967", "Realismo mágico" },
            new List<string>() { "1984", "George Orwell", "1949", "Distopía" },
            new List<string>() { "El Principito", "Antoine de Saint-Exupéry", "1943", "Fábula" },
            new List<string>() { "Don Quijote de la Mancha", "Miguel de Cervantes", "1605", "Novela clásica" },
            new List<string>() { "Don Quijote de la Mancha", "Miguel de Cervantes", "1605", "Novela clásica" },
            new List<string>() { "Don Quijote de la Mancha", "Miguel de Cervantes", "1605", "Novela clásica" },
        };

        // Una simple variable global para salir
        static bool salir = false;


        // Una simple variable globas para opciones int
        static int opcion;

        // Para cuando queiero pedir un string
        static string opcionString;

        // Se ejecura automaticamente cuando se ejecuta el programa
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("------- ¡Bienvenido a la biblioteca Wrote&Found! -------");
            ejecutarPrograma();
        }


        /// Complementos para funciones

        // Funcion para comprobar que el número que nos dan es correcto
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
                    return -1;
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

        // Funcion muy simple para comprobar que un string no esta vacío
        static string pedirString(string pregunta)
        {
            Console.Write($"{pregunta}: ");
            opcionString = Console.ReadLine();
            return opcionString;
        }
        // Función para hacer el menú bonito
        static void menuBonito(string nombreMenu, string[] menu, string pregunta, int x, int y, int ancho)
        {
            string textoSalir = "0. Salir";

            // Centrar el título
            int centrar = (ancho - 2 - nombreMenu.Length) / 2;
            string titulo = nombreMenu.PadLeft(nombreMenu.Length + centrar).PadRight(ancho - 2);

            while (!salir)
            {
                Console.Clear();
                // Línea Superior
                Console.WriteLine("╔" + new string('═', ancho - 2) + "╗");

                // Poner el Título
                Console.WriteLine($"║{titulo}║");

                // Línea de espacio
                Console.WriteLine("║" + new string(' ', ancho - 2) + "║");

                for (int i = 0; i < menu.Length; i++)
                {
                    string opcionMenu = $"{i + 1}. {menu[i]}";
                    opcionMenu = opcionMenu.PadRight(ancho - 5); // Rellena con espacios a la derecha        
                    Console.WriteLine($"║   {opcionMenu}║");
                    if ((i + 1) % 5 == 0 && menu.Length > 5)
                    {
                        // Ver más
                        string verMas = "Presiona intro para ver mas...";
                        Console.WriteLine($"║   {verMas.PadRight(ancho - 5)}║");

                        // Otro espacio
                        Console.WriteLine("║" + new string(' ', ancho - 2) + "║");

                        // Salir
                        Console.WriteLine($"║   {textoSalir.PadRight(ancho - 5)}║");

                        // Última linea
                        Console.WriteLine("╚" + new string('═', ancho - 2) + "╝");
                        Console.WriteLine("");

                        opcion = pedirNumero(pregunta, x, y, true);

                        if (opcion >= x && opcion <= y)
                        {
                            return;
                        }
                        Console.Clear();

                        // Línea Superior
                        Console.WriteLine("╔" + new string('═', ancho - 2) + "╗");

                        // Poner el Título
                        Console.WriteLine($"║{titulo}║");

                        // Línea de espacio
                        Console.WriteLine("║" + new string(' ', ancho - 2) + "║");
                    }
                }

                if (menu.Length <= 5)
                {
                    // Otro espacio
                    Console.WriteLine("║" + new string(' ', ancho - 2) + "║");

                    // Salir
                    Console.WriteLine($"║   {textoSalir.PadRight(ancho - 5)}║");

                    // Última linea
                    Console.WriteLine("╚" + new string('═', ancho - 2) + "╝");

                    // Poner un espacio
                    Console.WriteLine("");
                    opcion = pedirNumero(pregunta, x, y, false);
                    if (opcion >= x && opcion <= y)
                    {
                        return;
                    }
                }
                else
                {
                    // Ver más
                    string noHayMas = "No hay mas...";
                    Console.WriteLine($"║   {noHayMas.PadRight(ancho - 5)}║");

                    // Otro espacio
                    Console.WriteLine("║" + new string(' ', ancho - 2) + "║");

                    // Volver Atrás
                    string volverAtras = "Presiona intro para volve atras";
                    Console.WriteLine($"║   {volverAtras.PadRight(ancho - 5)}║");

                    // Otro espacio
                    Console.WriteLine("║" + new string(' ', ancho - 2) + "║");

                    // Salir
                    Console.WriteLine($"║   {textoSalir.PadRight(ancho - 5)}║");

                    // Última linea
                    Console.WriteLine("╚" + new string('═', ancho - 2) + "╝");

                    // Poner un espacio
                    Console.WriteLine("");
                    opcion = pedirNumero(pregunta, x, y, true);
                    if (opcion >= x && opcion <= y)
                    {
                        return;
                    }
                }
            }
        }
        
        // Función para hacer el menú bonito cuando es una lista de listas
        static void menuListaDeListas(string nombreMenu, List<List<string>> menu, int posicion, string pregunta, int x, int y, int ancho)
        {
            string textoSalir = "0. Salir";

            // Centrar el título
            int centrar = (ancho - 2 - nombreMenu.Length) / 2;
            string titulo = nombreMenu.PadLeft(nombreMenu.Length + centrar).PadRight(ancho - 2);

            while (!salir)
            {
                Console.Clear();
                // Línea Superior
                Console.WriteLine("╔" + new string('═', ancho - 2) + "╗");

                // Poner el Título
                Console.WriteLine($"║{titulo}║");

                // Línea de espacio
                Console.WriteLine("║" + new string(' ', ancho - 2) + "║");

                for (int i = 0; i < menu.Count; i++)
                {
                    string opcionMenu = $"{i + 1}. {menu[i][posicion]}";
                    opcionMenu = opcionMenu.PadRight(ancho - 5); // Rellena con espacios a la derecha        
                    Console.WriteLine($"║   {opcionMenu}║");
                    if ((i + 1) % 5 == 0 && menu.Count > 5)
                    {
                        // Ver más
                        string verMas = "Presiona intro para ver mas...";
                        Console.WriteLine($"║   {verMas.PadRight(ancho - 5)}║");

                        // Otro espacio
                        Console.WriteLine("║" + new string(' ', ancho - 2) + "║");

                        // Salir
                        Console.WriteLine($"║   {textoSalir.PadRight(ancho - 5)}║");

                        // Última linea
                        Console.WriteLine("╚" + new string('═', ancho - 2) + "╝");
                        Console.WriteLine("");

                        opcion = pedirNumero(pregunta, x, y, true);

                        if (opcion >= x && opcion <= y)
                        {
                            return;
                        }
                        Console.Clear();

                        // Línea Superior
                        Console.WriteLine("╔" + new string('═', ancho - 2) + "╗");

                        // Poner el Título
                        Console.WriteLine($"║{titulo}║");

                        // Línea de espacio
                        Console.WriteLine("║" + new string(' ', ancho - 2) + "║");
                    }
                }

                if (menu.Count <= 5)
                {
                    // Otro espacio
                    Console.WriteLine("║" + new string(' ', ancho - 2) + "║");

                    // Salir
                    Console.WriteLine($"║   {textoSalir.PadRight(ancho - 5)}║");

                    // Última linea
                    Console.WriteLine("╚" + new string('═', ancho - 2) + "╝");

                    // Poner un espacio
                    Console.WriteLine("");
                    opcion = pedirNumero(pregunta, x, y, false);
                    if (opcion >= x && opcion <= y)
                    {
                        return;
                    }
                }
                else
                {
                    // Ver más
                    string noHayMas = "No hay mas...";
                    Console.WriteLine($"║   {noHayMas.PadRight(ancho - 5)}║");

                    // Otro espacio
                    Console.WriteLine("║" + new string(' ', ancho - 2) + "║");

                    // Volver Atrás
                    string volverAtras = "Presiona intro para volve atras";
                    Console.WriteLine($"║   {volverAtras.PadRight(ancho - 5)}║");

                    // Otro espacio
                    Console.WriteLine("║" + new string(' ', ancho - 2) + "║");

                    // Salir
                    Console.WriteLine($"║   {textoSalir.PadRight(ancho - 5)}║");

                    // Última linea
                    Console.WriteLine("╚" + new string('═', ancho - 2) + "╝");

                    // Poner un espacio
                    Console.WriteLine("");
                    opcion = pedirNumero(pregunta, x, y, true);
                    if (opcion >= x && opcion <= y)
                    {
                        return;
                    }
                }
            }
        }
 
        // Función para comprobar que hay libros
        static bool hayLibros()
        {
            if (Libros.Count == 0)
            {
                // Simplemente le pedí a ChatGPT que pusiese los emojis
                Console.WriteLine("─────────────────────────────────────────────────────────");
                Console.WriteLine("📭  Actualmente no hay libros en la biblioteca...");
                Console.WriteLine("💨  ¡Parece que se han borrado todos! 😱");
                Console.WriteLine("");
                Console.WriteLine("✨  ¿Por qué no vas y añades uno nuevo? 📖");
                Console.WriteLine("─────────────────────────────────────────────────────────");
                Console.WriteLine("");
                Console.WriteLine("Presiona una tecla para volver...");
                Console.ReadKey();
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool hayReseñas()
        {
            for (int i = 0; i < Libros.Count; i++)
            {
                if (Libros[i].Count < 4)
                {
                    return true;
                }
            }
            return false;
            
        }
        static bool hayReseña(int numeroLibro)
        {
            if (Libros[numeroLibro].Count < 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// Menu principal

        // Menu principal e inicio del progrmama
        static void ejecutarPrograma()
        {
            while (!salir)
            {
                Console.Clear();
                verMenu();
                menu = new string[] { "Libros", "Usuarios", "Prestamos", "Ayuda", "Reseñas" };
                menuBonito("MENÚ", menu, "Escribe el número de lo que quieres hacer", 0, 5, 40);
                switch (opcion)
                {
                    case 1:
                        menuLibros();
                        break;
                    case 2:
                        menuUsuario();
                        break;
                    case 3:
                        menuPrestamos();
                        break;
                    case 4:
                        Ayuda();
                        break;
                    case 5:
                        Reseña();
                        break;
                    case 0:
                        Console.WriteLine("¡Gracias por venir a Wrote&Found! ¡Esperamos verte de nuevo!");
                        salir = true;
                        break;
                }
            }
        }

        // Menú principal
        static void verMenu()
        {
            Console.Clear();
            Console.WriteLine("");
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
            Console.WriteLine("  ¡Bienvenido/a a la biblioteca!");
            Console.WriteLine("");
            Console.WriteLine("  Presiona una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }


        /// OPCIÓN LIBROS

        // Menú de libros
        static void menuLibros()
        {
            do
            {
                Console.Clear();
                menu = new string[] { "Ver todos los libros", "Añadir nuevo libro", "Eliminar un libro", "Buscar Libro por"};
                menuBonito("OPCIONES LIBROS", menu, "Escribe el número de lo que quieres hacer", 0, 5, 37);
                switch (opcion)
                {
                    case 1:
                        verLibros();
                        break;
                    case 2:
                        anhadirLibro();
                        break;
                    case 3:
                        eliminarLibro();
                        break;
                    case 4:
                        buscarLibro();
                        break;
                    case 0:
                        Console.WriteLine("Volviendo al menú principal...");
                        salir = true;
                        break;
                }
            } while (!salir);
            salir = false;     
        }
        
        // Función ver libros
        static void verLibros()
        {
            Console.Clear();
            if (hayLibros())
            {
                do
                {
                    menuListaDeListas("LIBROS", Libros, 0, "Escribe el número del libro que quieres ver más", 0, Libros.Count, 50);
                    if (opcion > 0 && opcion <= Libros.Count)
                    {
                        verCaracteristicasLibro(opcion - 1);
                    }
                    else
                    {
                        salir = true;
                    }

                } while (!salir);
            }
            salir = false;
        }

        // Ver características de los libros
        static void verCaracteristicasLibro(int l)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"📘 Libro {l + 1}:");
            Console.WriteLine($"   Título: {Libros[l][0]}");
            Console.WriteLine($"   Autor:  {Libros[l][1]}");
            Console.WriteLine($"   Año:    {Libros[l][2]}");
            Console.WriteLine($"   Género: {Libros[l][3]}");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Pulsa una tecla para volver");
            Console.ReadKey();
        }

        // Función añadir libro
        static void anhadirLibro()
        {
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("   ¡Vamos a añadir un nuevo libro!");
                Console.WriteLine("");
                Console.WriteLine($"📘 Libro {Libros.Count + 1}:");
                Libros.Add(new List<string>() { pedirString("Título") });
                Libros[Libros.Count - 1].Add(pedirString("Autor"));
                Libros[Libros.Count - 1].Add(pedirString("Año"));
                Libros[Libros.Count - 1].Add(pedirString("Genero"));
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("¡Libro añadido!");
                Console.WriteLine("");
                pedirString("Escribe \"Salir\" para ir para atras, ¡escribe otra cosa para seguir añadiendo libros!");
                if (opcionString == "Salir")
                {
                    salir = true;
                }
            }
            salir = false;
        }
    

        // Función eliminar libro
        static void eliminarLibro()
        {
            while (!salir)
            {
                Console.Clear();
                if (hayLibros())
                {
                    menuListaDeListas("LIBROS", Libros, 0, "Escribe el número del libro que quieres eliminar", 0, Libros.Count, 50);
                    if (opcion != 0)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("");
                        Console.Write("Escribe \"Sí\" para confirmar o cualquier otra cosa para cancelar: ");
                        string confirmar = Console.ReadLine();
                        Console.WriteLine("");
                        if (confirmar == "Sí")
                        {
                            Libros.RemoveAt(opcion - 1);
                            Console.WriteLine("!Libro borrado del catálogo!");
                        }
                        else
                        {
                            Console.WriteLine("Has cancelado borrar un libro");
                        }

                        Console.WriteLine("");
                        Console.Write("¿Quieres borrar otro libro? (Sí/No): ");
                        string borrarOtro = Console.ReadLine();
                        if (borrarOtro != "Sí")
                        {
                            salir = true;
                        }
                    }
                    else
                    {
                        salir = true;
                    }
                }
            }
            salir = false;
        }

        // Menu Buscar Libro por lo que sea
        static void buscarLibro()
        {
            do
            {
                Console.Clear();
                menu = new string[] { "Buscar por Título", "Buscar por Autor", "Buscar por año", "Buscar por Genero", "Buscar por Reseñas" };
                menuBonito("BUSCAR POR", menu, "Escribe el número de lo que quieres hacer", 0, 5, 37);
                switch (opcion)
                {
                    case 1:
                        buscarLibroPor(opcion, "Título");
                        Console.ReadKey();
                        break;
                    case 2:
                        buscarLibroPor(opcion, "Autor");
                        Console.ReadKey();
                        break;
                    case 3:
                        buscarLibroPor(opcion, "Año");
                        Console.ReadKey();
                        break;
                    case 4:
                        buscarLibroPor(opcion, "Genero");
                        Console.ReadKey();
                        break;
                    case 5:
                        buscarLibroPor(opcion, "Reseñas");
                        Console.ReadKey();
                        break;
                    case 0:
                        salir = true;
                        break;
                }
            } while (!salir);
            salir = false;
        }

        // Función para cada busqueda
        static void buscarLibroPor(int campo, string tipo)
        {
            Console.Clear();
            int hayResultados = 0;
            if (tipo == "Reseñas" && !hayReseñas())
            {
                Console.WriteLine("No hay reseñas en ningún libro.");
                Console.WriteLine("");
                Console.WriteLine("Presiona una tecla para volver atrás");
                Console.ReadKey();
                return;
            }

            if (tipo == "Reseñas")
            {
                pedirNumero($"Escribe la {tipo} del libro", 0, 10, false);
            }
            else
            {
                pedirString($"Escribe el {tipo} del libro");
            }    

            Console.WriteLine("");
            Console.WriteLine("");
            for (int i = 0; i < Libros.Count; i++)
            {
                if (tipo == "Título" && opcionString == Libros[i][campo - 1])
                {
                    Console.WriteLine($"  {i}. {Libros[i][campo]}");
                    Console.WriteLine("");
                    hayResultados += 1;
                }
                else if (tipo != "Reseñas" && tipo != "Título" && opcionString == Libros[i][campo - 1])
                {
                    Console.WriteLine($"  {i}. {Libros[i][0]}");
                    Console.WriteLine($"       {Libros[i][campo]}");
                    Console.WriteLine("");
                    hayResultados += 1;

                }
                else if (tipo == "Reseñas" && hayReseña(campo))
                {
                    Console.WriteLine($"  {i}. {Libros[i][0]}");
                    Console.WriteLine($"       {Libros[i][campo]}");
                    Console.WriteLine("");
                    hayResultados += 1;
                }
            }
            if (hayResultados != 0)
            {
                Console.WriteLine($"Hay {hayResultados} resultados para {opcionString}.");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("No hay resultados...");
                Console.WriteLine("");
                Console.WriteLine("Presiona una tecla para volver atrás");
            }
        }


        /// OPCIÓN CREAR CUENTA

        static void menuUsuario()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════╗");
            Console.WriteLine("║    [ CREAR CUENTA ]    ║");
            Console.WriteLine("╚════════════════════════╝");
            Console.WriteLine("");
            Console.WriteLine("    👤  Username: ");
            Console.WriteLine("    🔒  Password: ");

        }
        static void menuPrestamos()
        {

        }

        static void Ayuda()
        {

        }
        static void Reseña()
        {

        }            
    }
} 
