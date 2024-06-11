using SimuladorDeHonguitos.Simulador;

namespace SimuladorDeHonguitos;

public static class Vista
{
    public static void MostrarTablero(Tablero tablero)
    {
        bool[,] hayHonguitoAqui = tablero.ObtenerPosicionesConHonguitos();
        for (int y = 0; y < hayHonguitoAqui.GetLength(1); y++)
        {
            for (int x = 0; x < hayHonguitoAqui.GetLength(0); x++)
            {
                if(hayHonguitoAqui[x,y])
                    Console.Write("O");
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }

        Console.ReadLine();
    }


}