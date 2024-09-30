using System;
using System.Collections;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Clear(); // mantener el color en toda la consola
            Menu();
        }

        // menu principal
        public static void Menu()
        {
            int opcion = 0;
            bool opcionValida = true;
            do
            {
                Console.WriteLine("- - - - TIC TAC TOE - - - -" +
                    "\n[1]. Jugar." +
                    "\n[2]. Salir.");
                Console.Write("Ingrese la opción elegida: ");
                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Formato erróneo, ingrese un número...\n");
                }

                if (opcion == 1)
                {
                    bool jugarDeNuevo = true;
                    while (jugarDeNuevo)
                    {
                        Juego();
                        jugarDeNuevo = Validacion();
                        if (!jugarDeNuevo)
                        {
                            break;
                        }
                    }
                }
                else if (opcion == 2)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Valor incorrecto, inténtelo de nuevo...\n");
                    opcionValida = false;
                }
            }
            while (!opcionValida);

            return;
        }

        // metodo encargado de la logica del juego
        public static void Juego()
        {
            Tablero tablero = new Tablero();    // instanciar un tablero cada que inicie un juego
            int jugador = 2;
            int contadorDeTurnos = 0;
            int casillaSeleccionada = 0;
            bool casillaValida = true;
            do
            {
                tablero.CrearTablero();

                // verificar ganador antes de cambiar turno
                if (tablero.ExisteGanador())
                {
                    Console.WriteLine("\nFelicidades jugador {0}, haz ganado :)", jugador);
                    break;
                }

                // verificar empate
                if (contadorDeTurnos == 9)
                {
                    Console.WriteLine("\n\tJuego empatado :|");
                    break;
                }

                //cambio de turno
                if (jugador == 2) { jugador = 1; }
                else if (jugador == 1) { jugador = 2; }

                do
                {
                    Console.Write("\nJugador {0}, elija una casilla: ", jugador);
                    try
                    {
                        casillaSeleccionada = Convert.ToInt32(Console.ReadLine());  // casteo
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        tablero.CrearTablero();
                        Console.WriteLine("\nFormato erróneo, ingrese un número...");
                    }

                    casillaValida = tablero.CasillaDisponible(casillaSeleccionada);   // verificar que este disponible la casilla
                    
                    if (casillaValida)
                    {
                        tablero.ColocarXoO(jugador, casillaSeleccionada);
                        contadorDeTurnos++;
                    }
                    else
                    {
                        Console.Clear();
                        tablero.CrearTablero();
                        Console.WriteLine("\nValor incorrecto, inténtelo de nuevo...");
                    }
                }
                while (!casillaValida);
            }
            while (true);
        }

        // metodo para verificar si quiere volver a jugar
        public static bool Validacion()
        {
            int opcion = 0;
            bool opcionValida = true;
            bool formatoValido = true;
            Console.WriteLine("\nPresione cualquier tecla para continuar....");
            Console.ReadKey();
            do
            {
                Console.Clear();
                if (!formatoValido || !opcionValida)
                {
                    Console.WriteLine("Valor incorrecto, inténtelo de nuevo...\n");
                }
                Console.WriteLine("¿Desea jugar de nuevo?" +
                "\n[1]. Si." +
                "\n[2]. No.");
                Console.Write("Ingrese la opción elegida: ");
                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());
                    formatoValido = true;
                }
                catch (Exception)
                {
                    Console.Clear();
                    formatoValido = false;
                }

                if (opcion == 1)
                {
                    return true;
                }
                else if (opcion == 2)
                {
                    break;
                }
                else
                {
                    opcionValida = false;
                }
            }
            while (!opcionValida);

            return false;
        }
    }
}
