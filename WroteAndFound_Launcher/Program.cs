namespace WroteAndFound
{
    class Program
    {
        /// 
        /// Separar partes principales del código
        /// 
        
        /*
            Cosas nuevas no vistas en clase
        */


        // Se ejecura automaticamente cuando se ejecuta el programa
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("------- ¡Bienvenido a la biblioteca Wrote&Found! -------");
            ejecutarPrograma();
        }

        /// 
        /// Variables Globales
        /// 

        // Array global para crear menús
        static string[] menu = new string[10];

        // Lista global para los Usuarios
        static List<List<string>> Usuarios = new List<List<string>>();

        // Lista Global para los libros
        static List<List<string>> Libros = new List<List<string>>()
        {
            new List<string>() { "Cien años de soledad", "Gabriel García Márquez", "1967", "Realismo mágico", "Disponible" },
            new List<string>() { "1984", "George Orwell", "1949", "Distopía", "Disponible" },
            new List<string>() { "El Principito", "Antoine de Saint-Exupéry", "1943", "Fábula", "Disponible" },
            new List<string>() { "Don Quijote de la Mancha", "Miguel de Cervantes", "1605", "Novela clásica", "Disponible" },
            new List<string>() { "Orgullo y prejuicio", "Jane Austen", "1813", "Romance", "Disponible" },
            new List<string>() { "Moby Dick", "Herman Melville", "1851", "Aventura", "Disponible" },
            new List<string>() { "La Metamorfosis", "Franz Kafka", "1915", "Existencialismo", "Disponible" },
            new List<string>() { "Crimen y castigo", "Fiódor Dostoyevski", "1866", "Filosófica", "Disponible" },
            new List<string>() { "El Gran Gatsby", "F. Scott Fitzgerald", "1925", "Novela moderna", "Disponible" },
            new List<string>() { "Harry Potter y la piedra filosofal", "J.K. Rowling", "1997", "Fantasía", "Disponible" },
        };

        // Una simple variable global para salir
        static bool salir = false;


        // Una simple variable globas para opciones int
        static int opcion;

        // Otra variable int global
        static int opcion2;

        // Para cuando quiero pedir un string
        static string opcionString;

        // Otra variable string global
        static string opcionString2;

        // Para saber si hay usuario actual
        static bool hayUsuarioActual = false;

        // Para saber cual es el usuario actual
        static string usuarioActual;

        // Para saber que número es el usuario actual
        static int numUsuarioActual;


        /// 
        /// Funciones complementarias
        /// 

        // Funcion para comprobar que el número que nos dan es correcto
        static int pedirNumero(string pregunta, int x, int y, bool especial)
        {
            int valor;
            do
            {
                Console.Write($"{pregunta}({x}-{y}): ");
                string entrada = Console.ReadLine();

                // Para casos en los que quiero que puedan hacer intro
                if (especial && entrada == "")
                {
                    return -1;
                }

                /* 
                    Comprueba que lo que escriba el usuario se puede convertir en un int.
                */
                if (int.TryParse(entrada, out valor) && valor >= x && valor <= y)
                {
                    salir = true;
                }
                else
                {
                    Console.WriteLine($"{entrada} no es un número válido, vuelve a intentarlo.");
                    Console.ReadKey();
                }

            } while (!salir);
            salir = false;
            return valor;

        }

        // Funcion muy simple para comprobar que un string no esta vacío
        static string pedirString(string pregunta, int maximo)
        {
            while (!salir)
            {
                Console.Write($"{pregunta}: ");
                opcionString = Console.ReadLine();

                // Si el string que nos den es demasiado grande, da error y vuelve a pedir.
                if (opcionString.Length > maximo)
                {
                    Console.WriteLine("Demasiado largo, vuelve a intentarlo...");
                    Console.ReadKey();

                }
                else
                {
                    salir = true;
                }
            }
            salir = false;
            return opcionString;
        }
        
        // Función para hacer el menú bonito
        static void menuBonito(string nombreMenu, string[] menu, string pregunta, int x, int y, int ancho)
        {
            string textoSalir = "0. Salir";

            // Centrar el título

            // Restar a ancho - 2 (por los ║), y luego dividirlo en dos, para los dos lados.
            int centrar = (ancho - 2 - nombreMenu.Length) / 2;

            // Crear el string que dice cuantos espacios a la izquierda, y como de grande ha de ser a lo máximo.
            string titulo = nombreMenu.PadLeft(nombreMenu.Length + centrar).PadRight(ancho - 2);

            while (!salir)
            {
                Console.Clear();
                // Línea Superior
                /*
                    new string('═', int), es para que rellele un texto con un caracter, unas ciertas veces.
                */
                Console.WriteLine("╔" + new string('═', ancho - 2) + "╗");

                // Poner el Título
                Console.WriteLine($"║{titulo}║");

                // Línea de espacio
                Console.WriteLine("║" + new string(' ', ancho - 2) + "║");

                for (int i = 0; i < menu.Length; i++)
                {
                    string opcionMenu = $"{i + 1}. {menu[i]}";
                    opcionMenu = opcionMenu.PadRight(ancho - 5);       
                    Console.WriteLine($"║   {opcionMenu}║");

                    // Si el menú sin contar el título, es mas grande que 5, lo va dividiendo en partes de 5.
                    // Que se pueden ver gracias a lo de especial, y presionando intro.
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

                        // Pide automáticamente, para mayor facilidad, el propio menu el número.
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

                // Si el menu, sin contar el título, es más pequeño que cinco, no divide nada ni deja hacer intro.
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
                    // Si llegas al último grupo de 5, te pone "No hay mas", y con intro, vuelve al primer grupo de 5.
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
        
        // Esencialmente lo mismo, pero para si lo que necisito pasar es una lista de listas, en vez de un array.

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
                Console.WriteLine("─────────────────────────────────────────────────────────");
                Console.WriteLine("     Actualmente no hay libros en la biblioteca...");
                Console.WriteLine("    ¡Parece que se han borrado todos! ");
                Console.WriteLine("");
                Console.WriteLine("    ¿Por qué no vas y añades uno nuevo? ");
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

        // Comprueba si hay reseñas, no tiene mucho más.
        static bool hayReseñas()
        {
            for (int i = 0; i < Libros.Count; i++)
            {
                if (Libros[i].Count > 5)
                {
                    return true;
                }
            }
            return false;
            
        }

        // Comprobar que hay usuarios
        static bool hayUsuarios()
        {
            if (Usuarios.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// 
        /// Inicio del progrmama / Funciones Principales
        /// 
        static void ejecutarPrograma()
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
            // Llama al menú para que continue el programa.
            verMenu();
        }

        /// Menu principal
        static void verMenu()
        {
            while (!salir)
            {
                Console.Clear();

                menu = new string[] { "Libros", "Usuarios", "Prestamos", "Autoría"};
                menuBonito("MENÚ", menu, "Escribe el número de lo que quieres hacer", 0, 4, 40);
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
                        autoria();
                        break;
                    case 0:
                        Console.Clear();
                        for (int i = 1; i <= 5; i++)
                        {
                            Console.WriteLine("");
                        }
                        Console.WriteLine("¡Gracias por venir a Wrote&Found! ¡Esperamos verte de nuevo!");
                        salir = true;
                        break;
                }
            }
        }

        /// OPCIÓN LIBROS

        // Menú de libros
        static void menuLibros()
        {
            do
            {
                Console.Clear();
                // Hacer que el array empieze desde cero, para luego rellenarlo.
                menu = new string[] { "Ver todos los libros", "Añadir nuevo libro", "Eliminar un libro", "Buscar Libro por", "Poner Reseñas"};
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
                    case 5:
                        ponerResenhas();
                        break;
                    case 0:
                        Console.WriteLine("Volviendo al menú principal...");
                        salir = true;
                        break;
                }
            } while (!salir);
            salir = false;     
        }
        
        // Menu para poder ver un catálogo de libros. libros
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
                        verCaracteristicasLibro(opcion - 1, false);

                    }
                    else
                    {
                        salir = true;
                    }

                } while (!salir);
            }
            salir = false;
        }

        // Ver características del libro que se pida
        static void verCaracteristicasLibro(int l, bool special)
        {
            int i = 5;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"   Libro {l + 1}:");
                Console.WriteLine($"   Título: {Libros[l][0]}");
                Console.WriteLine($"   Autor:  {Libros[l][1]}");
                Console.WriteLine($"   Año:    {Libros[l][2]}");
                Console.WriteLine($"   Género: {Libros[l][3]}");
                Console.WriteLine("");
                Console.WriteLine($"   Estado: {Libros[l][4]}");
                i = caracteristicasReseñas(l, i);
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("");
                if (i != 6 && !special)
                {
                    // Simplemente tiene que poner "Si" para salir volver
                    pedirString("Escribe \"Si\" para volver atras", 50);
                    if (opcionString == "Si")
                    {
                        salir = true;
                    }
                }
                else if (i == 6 && !special)
                {
                    Console.WriteLine("Presiona una tecla para volver...");
                    Console.ReadKey();
                    salir = true;
                }
                else
                {
                    salir = true;
                }
            }
            salir = false;
        }

        static int caracteristicasReseñas(int l, int i)
        {
                    
            if (hayReseñas())
            {   
                // Contador para que muestre máximo dos, luego deje darle al intro.
                int Contador = 0;
                for (int j = i; j < Libros[l].Count - 1; j += 2)
                {
                    if (Contador == 2)
                    {
                        Console.WriteLine("Pulsa cualquier tecla para ver más reseñas");
                        return j;
                    }
                    opcionString = $"{Libros[l][j] }: {Libros[l][j + 1]}";
                    Console.WriteLine($"   {opcionString.PadRight(18)}");
                    Contador += 1;
                }
                Console.WriteLine("No hay mas reseñas. Presiona intro ir para atras");
                return 6;

            }
            else
            {
                Console.WriteLine("   No hay Reseñas");
                return 6;
            }
        }
        // Función añadir libro
        static void anhadirLibro()
        {
            Console.Clear();
            if (hayUsuarioActual == false)
            {
                Console.WriteLine("");
                Console.WriteLine("No estás iniciado como un usario, por favor crea uno o cambia a uno");
                Console.ReadKey();
            }
            else
            {
                while (!salir)
                {
                    Console.Clear();
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine("   ¡Vamos a añadir un nuevo libro!");
                    Console.WriteLine("");
                    Console.WriteLine($"📘 Libro {Libros.Count + 1}:");

                    // Crea una nueva lista , dentro de la lista de Libros
                    Libros.Add(new List<string>() { pedirString("Título", 40) });
                    Libros[Libros.Count - 1].Add(pedirString("Autor", 30));
                    Libros[Libros.Count - 1].Add(pedirString("Año", 8));
                    Libros[Libros.Count - 1].Add(pedirString("Genero", 30));
                    Libros[Libros.Count - 1].Add("Disponible");
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine("¡Libro añadido!");
                    Console.WriteLine("");
                    pedirString("Escribe \"salir\", si no quieres seguir añadiendo", 10);
                    if (opcionString == "salir")
                    {
                        salir = true;
                    }
                }
                salir = false;
            }   
        }

        // Función eliminar libro
        static void eliminarLibro()
        {
            Console.Clear();
            if (hayUsuarioActual == false)
            {
                Console.WriteLine("");
                Console.WriteLine("No estás iniciado como un usario, por favor crea uno o cambia a uno");
                Console.ReadKey();
            }
            else
            {
                while (!salir)
                {
                    Console.Clear();
                    if (hayLibros())
                    {
                        menuListaDeListas("LIBROS", Libros, 0, "Escribe el número del libro que quieres eliminar", 0, Libros.Count, 50);
                        if (opcion != 0)
                        {
                            Console.Clear();
                            Console.WriteLine("");
                            Console.WriteLine("---------------------------------------");
                            Console.WriteLine("");
                            Console.Write("Escribe \"si\" para confirmar o cualquier otra cosa para cancelar: ");
                            string confirmar = Console.ReadLine();
                            Console.WriteLine("");
                            if (confirmar == "si")
                            {
                                Console.WriteLine("!Libro borrado del catálogo!");
                                // Lo de abajo, es para que se borre el libros y no aparezca como prestado en un usuario.
                                for (int i = 0; i < Usuarios.Count; i++)
                                {
                                    for (int j = 2; j < Usuarios[i].Count; j++)
                                    {
                                        if (Usuarios[i][j] == Libros[opcion - 1][0])
                                        {
                                            Usuarios[i].RemoveAt(j);
                                        }
                                    }
                                }
                                Libros.RemoveAt(opcion - 1);
                            }
                            else
                            {
                                Console.WriteLine("Has cancelado borrar un libro");
                            }

                            Console.WriteLine("");
                            Console.Write("Escribe \"si\", si quieres borrar otro");
                            string borrarOtro = Console.ReadLine();
                            if (borrarOtro != "si")
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

        // Función buscar en cada caso
        static void buscarLibroPor(int campo, string tipo)
        {
            Console.Clear();

            // Contador de resultados
            int hayResultados = 0;

            // Cuantas estrellas tiene una reseña
            int estrellas = -1;

            // Si no hay reseñas, sale
            if (tipo == "Reseñas" && !hayReseñas())
            {
                Console.WriteLine("No hay reseñas en ningún libro.");
                Console.WriteLine("");
                Console.WriteLine("Presiona una tecla para volver atrás");
                return;
            }

            // Si son reseñas pide int, sino un string.
            if (tipo == "Reseñas")
            {
                estrellas = pedirNumero($"Escribe la {tipo} del libro", 1, 5, false);
            }
            else
            {
                pedirString($"Escribe el {tipo} del libro", 30);
            }

            Console.WriteLine("");
            Console.WriteLine("");

            // Como se muestra si es título, Reseña, y las demas juntas.
            for (int i = 0; i < Libros.Count; i++)
            {
                if (tipo == "Título" && opcionString == Libros[i][campo - 1])
                {
                    Console.WriteLine($"  {i + 1}. {Libros[i][campo]}");
                    Console.WriteLine("");
                    hayResultados += 1;
                }
                else if (tipo != "Reseñas" && tipo != "Título" && opcionString == Libros[i][campo - 1])
                {
                    Console.WriteLine($"  {i + 1}. {Libros[i][0]}");
                    Console.WriteLine($"       {Libros[i][campo - 1]}");
                    Console.WriteLine("");
                    hayResultados += 1;

                }
                else if (tipo == "Reseñas")
                {
                    for (int j = 5; j < Libros[i].Count; j++)
                    {
                        if (estrellas == Libros[i][j].Length)
                        {
                            Console.WriteLine($"  {i + 1}. {Libros[i][0]}");
                            Console.WriteLine($"       {Libros[i][j]}");
                            Console.WriteLine("");
                            hayResultados += 1;
                        }
                    }
                }
            }
            // Si hay resultados, te dice quantos.
            if (hayResultados != 0)
            {   // Uno para Reseñas y el otro para los demás
                if (tipo == "Reseñas")
                {
                    Console.WriteLine($"Hay {hayResultados} resultados para {estrellas} estrellas.");
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine($"Hay {hayResultados} resultados para {opcionString}.");
                    Console.WriteLine("");
                }
                
            }
            else
            {
                Console.WriteLine("No hay resultados...");
                Console.WriteLine("");
                Console.WriteLine("Presiona una tecla para volver atrás");
            }
        }

        // Poner Reseña
        static void ponerResenhas()
        {
            Console.Clear();
            // Sale si no esta iniciado sesión
            if (!hayUsuarioActual)
            {
                Console.WriteLine("");
                Console.WriteLine("No estás iniciado como un usario, por favor crea uno o cambia a uno");
                Console.ReadKey();
            }
            else
            {
                while (!salir)
                {
                    Console.Clear();
                    if (hayLibros())
                    {
                        menuListaDeListas("Libros", Libros, 0, "Escribe el número del libro que quieres poner reseña", 0, Libros.Count, 50);
                        if (opcion != 0)
                        {
                            for (int i = 5; i < Libros[opcion - 1].Count; i += 2)
                            {
                                if (usuarioActual == Libros[opcion - 1][i])
                                {
                                    // En el caso de que ya haya puesto antes una reseña
                                    Console.Clear();
                                    Console.WriteLine(" Este usuario ya le ha puesto una reseña a este libro...");
                                    Console.WriteLine("");
                                    Console.WriteLine("Presiona una tecla para volver a intentarlo...");
                                    Console.ReadKey();
                                    salir = true;
                                }
                            }
                            if (!salir)
                            {
                                // Pedir y añadir Reseñá
                                Console.Clear();
                                verCaracteristicasLibro(opcion - 1, true);
                                Console.WriteLine();
                                opcion2 = pedirNumero("Que reseña le quieres poner", 1, 5, false);
                                Console.WriteLine();
                                Libros[opcion - 1].Add(usuarioActual);
                                Libros[opcion - 1].Add(new string('⭐', opcion2));
                                Console.Clear();
                                Console.WriteLine("Se ha añadido la reseña correctamente");
                                Console.WriteLine();
                                Console.WriteLine("Pulsa una tecla para continuar");
                                salir = true;
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            salir = true;
                        }
                    }
                    else
                    {
                        salir = true;
                    }
                }
                salir = false;
            }
        }

        /// MÉNU DE USUARIOS

        static void menuUsuario()
        {
            while (!salir)
            {
                Console.Clear();
                menu = new string[] { "Crear Usuario", "Cambiar Usuario", "Eliminar Usuario", "Usuario Actual" };
                menuBonito("USUARIOS", menu, "Escribe el número de la opción que quieras", 0, 4, 40);
                switch (opcion)
                {
                    case 1:
                        crearUsuario();
                        break;
                    case 2:
                        cambiarUsuario();
                        break;
                    case 3:
                        eliminarUsuario();
                        break;
                    case 4:
                        actualUsuario();
                        break;
                    case 0:
                        salir = true;
                        break;
                }
            }
            salir = false;
        }

        // Opción crear cuenta de usuario
        static void crearUsuario()
        {
            Console.Clear();
            Console.WriteLine("        ╔════════════════════════╗");
            Console.WriteLine("        ║    [ CREAR CUENTA ]    ║");
            Console.WriteLine("        ╚════════════════════════╝");
            Console.WriteLine("");
            opcionString2 = pedirString("    👤  Nombre (max 10 characteres)", 10);
            
            // Crea una nueva lista dentro de Listas
            Usuarios.Add(new List<string>() {opcionString2});
            Console.WriteLine("");
            pedirString("    🔒  Contraseña", 10);

            // Añade a la creada anteriormente
            Usuarios[Usuarios.Count - 1].Add(opcionString);
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("¡Usuario Creado Correctamente!");
            usuarioActual = opcionString2;
            numUsuarioActual = Usuarios.Count - 1;
            hayUsuarioActual = true;
            Console.WriteLine("");
            Console.WriteLine("Presiona una tecla para volver al menú...");
            Console.ReadKey();
        }

        // Opción cambiar de usuario
        static void cambiarUsuario()
        {
            Console.Clear();
            if (!hayUsuarios())
            {
                // Si no hay usuarios
                Console.WriteLine("");
                Console.WriteLine("No hay usuarios creados, ve y crea uno...");
                Console.WriteLine("");
                Console.ReadKey();
            }
            else
            {
                while (!salir)
                {
                    Console.Clear();
                    Console.WriteLine("        ╔══════════════════════════════╗");
                    Console.WriteLine("        ║    [ Cambiar de Usuario ]    ║");
                    Console.WriteLine("        ╚══════════════════════════════╝");
                    Console.WriteLine("");
                    opcionString2 = pedirString("    👤  Nombre del usuario", 10);
                    pedirString("    🔒  Contraseña", 10);
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("");
                    if (opcionString2 == usuarioActual)
                    {
                        // Si intenta cambiar al actual.
                        Console.WriteLine("Ya estas iniciado en este usuario, prueba con otro...");
                        Console.ReadKey();
                    }
                    else
                    {
                        // Si funciona.
                        for (int i = 0; i < Usuarios.Count; i++)
                        {
                            if (opcionString2 == Usuarios[i][0] && opcionString == Usuarios[i][1])
                            {
                                usuarioActual = opcionString2;
                                hayUsuarioActual = true;
                                numUsuarioActual = i;
                                Console.WriteLine("¡Usuario cambiado correctamente!");
                                Console.WriteLine("");
                                Console.WriteLine("Presiona una tecla para volver al menú...");
                                Console.ReadKey();
                                salir = true;
                            }
                        }
                        if (!salir)
                        {
                            // Si no existiese
                            Console.WriteLine("El usuario que has introducido no existe. \n \nOh la contraseña no es correcta");
                            Console.WriteLine("");
                            pedirString("Escribe \"salir\" para volver al menú", 10);
                            if (opcionString == "salir")
                            {
                                salir = true;
                            }
                        }
                    }   
                }
                salir = false;
            }
        }

        // Opción eliminar usuario
        static void eliminarUsuario()
        {
            Console.Clear();
            if (!hayUsuarios())
            {
                Console.WriteLine("");
                Console.WriteLine("No hay usuarios creados, ve y crea uno...");
                Console.WriteLine("");
                Console.ReadKey();
            }
            else
            {
                while (!salir)
                {
                    Console.Clear();
                    Console.WriteLine("        ╔══════════════════════════════╗");
                    Console.WriteLine("        ║    [ Eliminar un Usuario ]   ║");
                    Console.WriteLine("        ╚══════════════════════════════╝");
                    Console.WriteLine("");
                    opcionString2 = pedirString("    👤  Nombre del usuario", 10);
                    pedirString("    🔒  Contraseña", 10);
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("");

                    // Si funcioa
                    for (int i = 0; i < Usuarios.Count; i++)
                    {
                        if (opcionString2 == Usuarios[i][0] && opcionString == Usuarios[i][1])
                        {
                            Usuarios.RemoveAt(i);
                            Console.WriteLine("¡Usuario borrado correctamente!");
                            if (opcionString2 == usuarioActual)
                            {
                                hayUsuarioActual = false;
                                numUsuarioActual = -1;
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Presiona una tecla para volver al menú...");
                            Console.ReadKey();
                            salir = true;
                        }
                    }
                        if (!salir)
                        {
                            // Si no funciona
                            Console.WriteLine("El usuario que has introducido no existe. \n \nOh la contraseña no es correcta");
                            Console.WriteLine("");
                            pedirString("Escribe \"salir\" para volver al menú", 10);
                            if (opcionString == "salir")
                            {
                                salir = true;
                            }
                        }
                }
                salir = false;
            }
        }

        // Te muestra cual es el usuario actual
        static void actualUsuario()
        {
            Console.Clear();
            if (hayUsuarioActual == false)
            {

                Console.WriteLine("");
                Console.WriteLine("No estás iniciado como un usario, por favor crea uno o cambia a uno");
                Console.WriteLine("");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Actualmente estas iniciado como {usuarioActual}");
                Console.WriteLine("");
                Console.WriteLine("Presiona una tecla para volver");
                Console.ReadKey();
            }
        }


        /// ÓPCION PRESTAMOS

        // Menú prestamos
        static void menuPrestamos()
        {
            do
            {
                Console.Clear();
                menu = new string[] { "Coger prestado un libro", "Devolver un libro", "Libros prestados" };
                menuBonito("OPCIONES LIBROS", menu, "Escribe el número de lo que quieres hacer", 0, 3, 37);
                switch (opcion)
                {
                    case 1:
                        cogerPrestadoLibro();
                        break;
                    case 2:
                        devolverLibro();
                        break;
                    case 3:
                        librosPrestados();
                        break;
                    case 0:
                        salir = true;
                        break;
                }
            } while (!salir);
            salir = false;
        }
        
        // Coger prestado un libro
        static void cogerPrestadoLibro()
        {
            Console.Clear();
            if (hayUsuarioActual == false)
            {
                Console.WriteLine("");
                Console.WriteLine("No estás iniciado como un usario, por favor crea uno o cambia a uno");
                Console.ReadKey();
            }
            else
            {
                while (!salir)
                {
                    Console.Clear();
                    if (hayLibros())
                    {
                        menuListaDeListas("LIBROS", Libros, 0, "Escribe el número del libro que quieres coger prestado", 0, Libros.Count, 50);
                        if (opcion != 0)
                        {
                            Console.Clear();
                            Console.WriteLine("");
                            Console.WriteLine("---------------------------------------");
                            Console.WriteLine("");
                            bool tieneElLibro = false;

                            // Si tiene el libro
                            for (int i = 2; i < Usuarios[numUsuarioActual].Count; i++)
                            {
                                if (Usuarios[numUsuarioActual][i] == Libros[opcion - 1][0])
                                {
                                    tieneElLibro = true;
                                }
                            }
                            if (tieneElLibro)
                            {
                                Console.Clear();
                                Console.WriteLine("Ya tienes este libro prestado...");
                                Console.ReadKey();
                            }

                            // Si tiene 3 libros ya prestados
                            else if (Usuarios[numUsuarioActual].Count == 5)
                            {
                                Console.Clear();
                                Console.WriteLine("Ya tienes 3 libros prestados, devuelve alguno anda...");
                                Console.ReadKey();
                            }

                            // Si lo tiene prestado otro usuario
                            else if (Libros[opcion - 1][4] == "No Disponible")
                            {
                                Console.Clear();
                                Console.WriteLine("Este libro lo tiene prestado otro usuario...");
                                Console.ReadKey();
                            }

                            // Si puede coger coger prestado el libro
                            else
                            {
                                Console.Clear();
                                Libros[opcion - 1][4] = "No Disponible";
                                Usuarios[numUsuarioActual].Add(Libros[opcion - 1][0]);
                                salir = true;
                                Console.WriteLine("¡Libro cogido prestado correctamente!");
                                Console.ReadKey();
                            }
                        }
                        salir = true;
                    }
                }
                salir = false;
            }

        }

        // Función para devolver un libro prestado
        static void devolverLibro()
        {
            Console.Clear();
            if (hayUsuarioActual == false)
            {
                Console.WriteLine("");
                Console.WriteLine("No estás iniciado como un usario, por favor crea uno o cambia a uno");
                Console.ReadKey();
            }
            else
            {
                while (!salir)
                {
                    Console.Clear();
                    if (hayLibros())
                    {
                        // Muestra los libros que puede devolver
                        if (Usuarios[numUsuarioActual].Count > 2)
                        {
                            Console.WriteLine("----------------------------------------------------");
                            for (int i = 2; i < Usuarios[numUsuarioActual].Count; i++)
                            {
                                Console.WriteLine("");
                                Console.WriteLine($"   {i - 1}. {Usuarios[numUsuarioActual][i]}");

                            }
                            Console.WriteLine("----------------------------------------------------");
                            Console.WriteLine("");
                            pedirNumero("Que libro quieres devolver", 1, Usuarios[numUsuarioActual].Count - 2, false);
                            Console.Clear();
                            Console.WriteLine("");
                            
                            // Si decide devolver un libro
                            for (int i = 0; i < Libros.Count; i++)
                            {
                                if (Libros[i][0] == Usuarios[numUsuarioActual][opcion])
                                {
                                    Libros[i][4] = "Disponible";
                                }
                            }
                            Usuarios[numUsuarioActual].RemoveAt(opcion);
                            Console.WriteLine("¡Muy bien, ya se ha devuelto el libro!");
                            salir = true;
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("No tienes Libros prestados, ve y toma uno prestado...");
                            salir = true;
                            Console.ReadKey();
                        }
                    }

                }
                salir = false;
            }
        }
        
        // Función para saber que libros prestados tiene el usuario actual
        static void librosPrestados()
        {
            Console.Clear();
            if (hayUsuarioActual == false)
            {
                Console.WriteLine("");
                Console.WriteLine("No estás iniciado como un usario, por favor crea uno o cambia a uno");
                Console.ReadKey();
            }
            else
            {
                while (!salir)
                {
                    Console.Clear();
                    if (hayLibros())
                    {
                        if (Usuarios[numUsuarioActual].Count > 2)
                        {
                            Console.WriteLine("----------------------------------------------------");
                            for (int i = 2; i < Usuarios[numUsuarioActual].Count; i++)
                            {
                                Console.WriteLine("");
                                Console.WriteLine($"   {i - 1}. {Usuarios[numUsuarioActual][i]}");

                            }
                            Console.WriteLine("----------------------------------------------------");
                            Console.WriteLine("");
                            Console.WriteLine("Presiona una tecla para volver");
                            salir = true;
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("No tienes Libros prestados, ve y toma uno prestado...");
                            salir = true;
                            Console.ReadKey();
                        }
                    }

                }
                salir = false;
            }
            
        }

        // Una simple función para explicar un poco del mágnifico creador
        static void autoria()
        {
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("");
            }

            Console.WriteLine("Programa hecho sin dormir por Ian Lasa.");
            Console.WriteLine("");
            Console.WriteLine("Finalizado el proyecto el 14/11/2025 a las 10:04");
            Console.WriteLine("");

            int nota = pedirNumero("¿Que nota le das a este fabuloso proyecto?", 10, 11, false);
            Console.Clear();

            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("");
            }
            Console.WriteLine($"¡Gracias por el merecido {nota}!");
            Console.ReadKey();
        }            
    }
} 
