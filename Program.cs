using System;

class ChamanAzteca
{
    // Variables del chamán
    private static string nombre = string.Empty;
    private static int nivel = 1;
    private static int experiencia = 0;
    private static int energia = 100;
    private static int fuerza = 10;
    private static int destreza = 10;
    private static int fortaleza = 10;
    private static int inteligencia = 10;
    private static int carisma = 10;
    private static int sabiduria = 10;

    // Objeto Random para números aleatorios
    private static Random random = new Random();

    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido Chamán Azteca");
        Console.Write("Ingresa el nombre de tu chamán: ");
        nombre = Console.ReadLine() ?? "";

        bool continuar = true;

        do
        {
            MostrarMenu();
            int opcion;
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida. Introduce un número.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    VerEstado();
                    break;
                case 2:
                    EntrenarFuerza();
                    break;
                case 3:
                    EntrenarDestreza();
                    break;
                case 4:
                    EntrenarFortaleza();
                    break;
                case 5:
                    EntrenarInteligencia();
                    break;
                case 6:
                    EntrenarCarisma();
                    break;
                case 7:
                    EntrenarSabiduria();
                    break;
                case 8:
                    TomarPocion();
                    break;
                case 9:
                    Pelear();
                    break;
                case 10:
                    Descansar();
                    break;
                case 0:
                    continuar = false;
                    Console.WriteLine($"Hasta luego, {nombre}!");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intenta de nuevo.");
                    break;
            }

            // Verificar si el chamán está exhausto
            if (energia <= 0)
            {
                Console.WriteLine("¡Estás exhausto! Debes descansar.");
                energia = 0;
            }

            Console.WriteLine(); // Espacio entre iteraciones

        } while (continuar);
    }

    static void MostrarMenu()
    {
        Console.WriteLine("=== MENÚ PRINCIPAL ===");
        Console.WriteLine("1. Ver estado");
        Console.WriteLine("2. Entrenar fuerza (combate)");
        Console.WriteLine("3. Entrenar destreza (agilidad)");
        Console.WriteLine("4. Entrenar fortaleza (resistencia)");
        Console.WriteLine("5. Entrenar inteligencia (estudio)");
        Console.WriteLine("6. Entrenar carisma (magia)");
        Console.WriteLine("7. Entrenar sabiduría (meditación)");
        Console.WriteLine("8. Tomar poción");
        Console.WriteLine("9. Pelear");
        Console.WriteLine("10. Descansar");
        Console.WriteLine("0. Salir");
        Console.WriteLine("=====================");
        Console.Write("Elige una opción: ");
    }

    static void VerEstado()
    {
        Console.WriteLine($"=== ESTADO DE {nombre} ===");
        Console.WriteLine($"Nivel: {nivel}");
        Console.WriteLine($"Experiencia: {experiencia}/{nivel * 100}");
        Console.WriteLine($"Energía: {energia}/100");
        Console.WriteLine($"Fuerza: {fuerza}");
        Console.WriteLine($"Destreza: {destreza}");
        Console.WriteLine($"Fortaleza: {fortaleza}");
        Console.WriteLine($"Inteligencia: {inteligencia}");
        Console.WriteLine($"Carisma: {carisma}");
        Console.WriteLine($"Sabiduría: {sabiduria}");
        Console.WriteLine("=========================");
    }

    static void EntrenarFuerza()
    {
        Console.Write("¿Cuántas horas de combate quieres practicar? (1-6): ");
        if (!int.TryParse(Console.ReadLine(), out int horas) || horas < 1 || horas > 6)
        {
            Console.WriteLine("Horas inválidas. Debe ser entre 1 y 6.");
            return;
        }

        if (energia < horas * 10)
        {
            Console.WriteLine($"No tienes suficiente energía para entrenar {horas} horas.");
            return;
        }

        energia -= horas * 10;
        fuerza += horas;
        experiencia += horas * 5;

        Console.WriteLine($"Has entrenado combate por {horas} horas!");
        Console.WriteLine($"+{horas} Fuerza");
        Console.WriteLine($"-{horas * 10} Energía");

        VerificarSubidaNivel();
    }

    static void EntrenarDestreza()
    {
        Console.Write("¿Cuántas horas de agilidad quieres practicar? (1-6): ");
        if (!int.TryParse(Console.ReadLine(), out int horas) || horas < 1 || horas > 6)
        {
            Console.WriteLine("Horas inválidas. Debe ser entre 1 y 6.");
            return;
        }

        if (energia < horas * 8)
        {
            Console.WriteLine($"No tienes suficiente energía para entrenar {horas} horas.");
            return;
        }

        energia -= horas * 8;
        destreza += horas;
        experiencia += horas * 4;

        Console.WriteLine($"Has entrenado agilidad por {horas} horas!");
        Console.WriteLine($"+{horas} Destreza");
        Console.WriteLine($"-{horas * 8} Energía");

        VerificarSubidaNivel();
    }

    static void EntrenarFortaleza()
    {
        Console.Write("¿Cuántas horas de resistencia quieres practicar? (1-6): ");
        if (!int.TryParse(Console.ReadLine(), out int horas) || horas < 1 || horas > 6)
        {
            Console.WriteLine("Horas inválidas. Debe ser entre 1 y 6.");
            return;
        }

        if (energia < horas * 12)
        {
            Console.WriteLine($"No tienes suficiente energía para entrenar {horas} horas.");
            return;
        }

        energia -= horas * 12;
        fortaleza += horas * 2;
        experiencia += horas * 6;

        Console.WriteLine($"Has entrenado resistencia por {horas} horas!");
        Console.WriteLine($"+{horas * 2} Fortaleza");
        Console.WriteLine($"-{horas * 12} Energía");

        VerificarSubidaNivel();
    }

    static void EntrenarInteligencia()
    {
        Console.Write("¿Cuántas horas de estudio quieres practicar? (1-6): ");
        if (!int.TryParse(Console.ReadLine(), out int horas) || horas < 1 || horas > 6)
        {
            Console.WriteLine("Horas inválidas. Debe ser entre 1 y 6.");
            return;
        }

        if (energia < horas * 6)
        {
            Console.WriteLine($"No tienes suficiente energía para estudiar {horas} horas.");
            return;
        }

        energia -= horas * 6;
        inteligencia += horas * 5;
        experiencia += horas * 7;

        Console.WriteLine($"Has estudiado por {horas} horas!");
        Console.WriteLine($"+{horas * 5} Inteligencia");
        Console.WriteLine($"-{horas * 6} Energía");

        VerificarSubidaNivel();
    }

    static void EntrenarCarisma()
    {
        Console.Write("¿Cuántas horas de magia quieres practicar? (1-6): ");
        if (!int.TryParse(Console.ReadLine(), out int horas) || horas < 1 || horas > 6)
        {
            Console.WriteLine("Horas inválidas. Debe ser entre 1 y 6.");
            return;
        }

        if (energia < horas * 9)
        {
            Console.WriteLine($"No tienes suficiente energía para practicar magia {horas} horas.");
            return;
        }

        energia -= horas * 9;
        carisma += horas * 3;
        experiencia += horas * 5;

        Console.WriteLine($"Has practicado magia por {horas} horas!");
        Console.WriteLine($"+{horas * 3} Carisma");
        Console.WriteLine($"-{horas * 9} Energía");

        VerificarSubidaNivel();
    }

    static void EntrenarSabiduria()
    {
        Console.Write("¿Cuántas horas de meditación quieres practicar? (1-6): ");
        if (!int.TryParse(Console.ReadLine(), out int horas) || horas < 1 || horas > 6)
        {
            Console.WriteLine("Horas inválidas. Debe ser entre 1 y 6.");
            return;
        }

        if (energia < horas * 5)
        {
            Console.WriteLine($"No tienes suficiente energía para meditar {horas} horas.");
            return;
        }

        energia -= horas * 5;
        sabiduria += horas * 4;
        experiencia += horas * 8;

        Console.WriteLine($"Has meditado por {horas} horas!");
        Console.WriteLine($"+{horas * 4} Sabiduría");
        Console.WriteLine($"-{horas * 5} Energía");

        VerificarSubidaNivel();
    }

    static void Descansar()
    {
        energia = 100;
        Console.WriteLine("Has descansado y recuperado toda tu energía!");
    }

    static void TomarPocion()
    {
        Console.WriteLine("Elige una poción:");
        Console.WriteLine("1. Poción Roja (+2 Fuerza, -1 Sabiduría)");
        Console.WriteLine("2. Poción Azul (+2 Fortaleza, -2 Inteligencia)");
        Console.WriteLine("3. Poción Verde (+2 Inteligencia, -2 Destreza)");
        Console.WriteLine("4. Cancelar");
        Console.Write("Opción: ");

        if (!int.TryParse(Console.ReadLine(), out int opcion))
        {
            Console.WriteLine("Opción inválida.");
            return;
        }

        switch (opcion)
        {
            case 1:
                fuerza += 2;
                sabiduria -= 1;
                Console.WriteLine("Has tomado la poción roja!");
                Console.WriteLine("+2 Fuerza, -1 Sabiduría");
                break;
            case 2:
                fortaleza += 2;
                inteligencia -= 2;
                Console.WriteLine("Has tomado la poción azul!");
                Console.WriteLine("+2 Fortaleza, -2 Inteligencia");
                break;
            case 3:
                inteligencia += 2;
                destreza -= 2;
                Console.WriteLine("Has tomado la poción verde!");
                Console.WriteLine("+2 Inteligencia, -2 Destreza");
                break;
            case 4:
                Console.WriteLine("Has decidido no tomar ninguna poción.");
                break;
            default:
                Console.WriteLine("Opción inválida.");
                break;
        }

        // Validar que no haya stats negativos
        if (sabiduria < 0) sabiduria = 0;
        if (inteligencia < 0) inteligencia = 0;
        if (destreza < 0) destreza = 0;
    }

    static void Pelear()
    {
        if (energia < 30)
        {
            Console.WriteLine("No tienes suficiente energía para pelear (necesitas al menos 30).");
            return;
        }

        energia -= 30;

        // Calcular probabilidad de ganar basada en stats
        int probabilidad = (fuerza + destreza + fortaleza) / 3;

        if (random.Next(1, 101) <= probabilidad)
        {
            int recompensa = nivel * 20;
            experiencia += recompensa;
            Console.WriteLine($"¡Has ganado la batalla! +{recompensa} experiencia");
            VerificarSubidaNivel();
        }
        else
        {
            Console.WriteLine("Has perdido la batalla. Necesitas entrenar más.");
        }
    }

    static void VerificarSubidaNivel()
    {
        if (experiencia >= nivel * 100)
        {
            nivel++;
            experiencia -= (nivel - 1) * 100;
            Console.WriteLine($"¡Felicidades! Has subido al nivel {nivel}!");
        }
    }
}