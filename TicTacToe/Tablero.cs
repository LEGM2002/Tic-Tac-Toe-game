using System;

namespace TicTacToe
{
    internal class Tablero
    {
        private char[,] tablero =
        {
            {'1', '2', '3' },
            {'4', '5', '6' },
            {'7', '8', '9' },
        };

        // metodo para crear el tablero de tic tac toe con su respectivo numero de casilla
        public void CrearTablero()
        {
            Console.Clear(); // limpiar pantalla para que se muestre el tablero actualizado
            Console.WriteLine("\t     |     |     ");
            Console.WriteLine("\t  {0}  |  {1}  |  {2}  ", tablero[0, 0], tablero[0, 1], tablero[0, 2]);
            Console.WriteLine("\t_____|_____|_____");
            Console.WriteLine("\t     |     |     ");
            Console.WriteLine("\t  {0}  |  {1}  |  {2}  ", tablero[1, 0], tablero[1, 1], tablero[1, 2]);
            Console.WriteLine("\t_____|_____|_____");
            Console.WriteLine("\t     |     |     ");
            Console.WriteLine("\t  {0}  |  {1}  |  {2}  ", tablero[2, 0], tablero[2, 1], tablero[2, 2]);
            Console.WriteLine("\t     |     |     ");
        }

        // metodo para verificar si esta disponible la casilla
        public bool CasillaDisponible(int casillaSeleccionada)
        {
            if ((casillaSeleccionada == 1 && tablero[0, 0] == '1') ||
                (casillaSeleccionada == 2 && tablero[0, 1] == '2') ||
                (casillaSeleccionada == 3 && tablero[0, 2] == '3') ||
                (casillaSeleccionada == 4 && tablero[1, 0] == '4') ||
                (casillaSeleccionada == 5 && tablero[1, 1] == '5') ||
                (casillaSeleccionada == 6 && tablero[1, 2] == '6') ||
                (casillaSeleccionada == 7 && tablero[2, 0] == '7') ||
                (casillaSeleccionada == 8 && tablero[2, 1] == '8') ||
                (casillaSeleccionada == 9 && tablero[2, 2] == '9'))
            {
                return true;
            }
            return false;
        }

        // metodo para identificar jugador
        public void ColocarXoO(int jugador, int casillaSeleccionada)
        {
            char signo = ' ';
            if (jugador == 1) { signo = 'X'; }
            else if (jugador == 2) { signo = 'O'; }

            switch (casillaSeleccionada)
            {
                case 1: tablero[0, 0] = signo; break;
                case 2: tablero[0, 1] = signo; break;
                case 3: tablero[0, 2] = signo; break;
                case 4: tablero[1, 0] = signo; break;
                case 5: tablero[1, 1] = signo; break;
                case 6: tablero[1, 2] = signo; break;
                case 7: tablero[2, 0] = signo; break;
                case 8: tablero[2, 1] = signo; break;
                case 9: tablero[2, 2] = signo; break;
            }
        }

        // metodo para verificar si hay un ganador
        public bool ExisteGanador()
        {
            char[] signos = { 'X', 'O' };
            foreach (char signo in signos)
            {
                // Verificar filas y columnas
                for (int i = 0; i < 3; i++)
                {
                    if ((tablero[i, 0] == signo && tablero[i, 1] == signo && tablero[i, 2] == signo) ||  // filas
                        (tablero[0, i] == signo && tablero[1, i] == signo && tablero[2, i] == signo))    // columnas
                    {
                        return true;
                    }
                }

                // Verificar diagonales
                if ((tablero[0, 0] == signo && tablero[1, 1] == signo && tablero[2, 2] == signo) ||  // diagonal principal
                    (tablero[0, 2] == signo && tablero[1, 1] == signo && tablero[2, 0] == signo))    // diagonal secundaria
                {
                    return true;
                }
            }
            return false;
        }
    }
}
