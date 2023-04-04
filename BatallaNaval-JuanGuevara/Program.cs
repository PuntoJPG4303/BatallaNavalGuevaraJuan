namespace BatallaNaval_JuanGuevara
{
    namespace Batalla_naval
    {
        namespace BatallaNaval
        {
            class Program
            {
                static void Main(string[] args)
                {
                    // Definir el tablero
                    int[,] tablero = new int[10, 10];

                    // Colocar los barcos del jugador 1
                    Console.WriteLine("Jugador 1, coloca tus barcos:");
                    ColocarBarcos(tablero);

                    // Limpiar la consola para el jugador 2
                    Console.Clear();

                    // Iniciar el contador de tiros del jugador 2
                    int contadorTiros = 0;

                    // Mientras haya barcos en el tablero del jugador 1
                    while (ContarBarcos(tablero) > 0)
                    {
                        // Mostrar el tablero del jugador 2
                        Console.WriteLine("Jugador 2, dispara:");
                        MostrarTablero(tablero);

                        // Pedir la posición del tiro
                        Console.Write("Ingresa la fila (1-10): ");
                        int fila = int.Parse(Console.ReadLine()) - 1;
                        Console.Write("Ingresa la columna (1-10): ");
                        int columna = int.Parse(Console.ReadLine()) - 1;

                        // Verificar si hay un barco en la posición
                        if (tablero[fila, columna] == 1)
                        {
                            // Si hay un barco, marcarlo como hundido
                            Console.WriteLine("¡Barco hundido!");
                            tablero[fila, columna] = 2;
                        }
                        else
                        {
                            // Si no hay un barco, marcar el tiro como fallido
                            Console.WriteLine("Agua...");
                        }

                        // Incrementar el contador de tiros
                        contadorTiros++;
                    }

                    // Mostrar el mensaje de victoria del jugador 2
                    Console.WriteLine("¡Ganaste en " + contadorTiros + " tiros!");
                }

                static void ColocarBarcos(int[,] tablero)
                {
                    // Colocar barcos de tamaño 4
                    ColocarBarco(tablero, 4);

                    // Colocar barcos de tamaño 3
                    ColocarBarco(tablero, 3);
                    ColocarBarco(tablero, 3);

                    // Colocar barcos de tamaño 2
                    ColocarBarco(tablero, 2);
                    ColocarBarco(tablero, 2);
                }

                static void ColocarBarco(int[,] tablero, int tamano)
                {
                    // Pedir la posición del barco
                    Console.Write("Ingresa la fila inicial del barco de tamaño " + tamano + " (1-10): ");
                    int fila = int.Parse(Console.ReadLine()) - 1;
                    Console.Write("Ingresa la columna inicial del barco de tamaño " + tamano + " (1-10): ");
                    int columna = int.Parse(Console.ReadLine()) - 1;

                    // Pedir la orientación del barco
                    Console.Write("Ingresa la orientación del barco (h o v): ");
                    string orientacion = Console.ReadLine();

                    // Verificar si la orientación es válida
                    while (orientacion != "h" && orientacion != "v")
                    {
                        Console.WriteLine("Orientación inválida, ingresa h o v.");
                        Console.Write("Ingresa la orientación del barco (h o v): ");
                        orientacion = Console.ReadLine();
                    }

                    // Colocar el barco en el tablero
                    if (orientacion == "h")
                    {
                        for (int i = columna; i < columna + tamano; i++)
                        {
                            tablero[fila, i] = 1;
                        }
                    }
                    else
                    {
                        for (int i = fila; i < fila + tamano; i++)
                        {
                            tablero[i, columna] = 1;
                        }
                    }
                }

                static int ContarBarcos(int[,] tablero)
                {
                    int contador = 0;

                    // Contar los barcos que quedan en el tablero
                    for (int i = 0; i < tablero.GetLength(0); i++)
                    {
                        for (int j = 0; j < tablero.GetLength(1); j++)
                        {
                            if (tablero[i, j] == 1)
                            {
                                contador++;
                            }
                        }
                    }

                    return contador;
                }

                static void MostrarTablero(int[,] tablero)
                {
                    Console.WriteLine("   1 2 3 4 5 6 7 8 9 10");
                    Console.WriteLine("  ---------------------");
                    for (int i = 0; i < tablero.GetLength(0); i++)
                    {
                        Console.Write((i + 1) + "| ");
                        for (int j = 0; j < tablero.GetLength(1); j++)
                        {
                            if (tablero[i, j] == 0 || tablero[i, j] == 1)
                            {
                                Console.Write("  ");
                            }
                            else if (tablero[i, j] == 2)
                            {
                                Console.Write("X ");
                            }
                            else if (tablero[i, j] == 3)
                            {
                                Console.Write("O ");
                            }
                        }
                        Console.WriteLine("|");
                    }
                    Console.WriteLine("  ---------------------");
                }
            }
        }
    }
}
