using System.Drawing;
using SimuladorDeHonguitos.Simulador;

namespace SimuladorDeHonguitos.Comportamientos
{
    public class LanzarEsporasClasico : ILanzarEsporasBehavior
    {
        private List<Point> posicionVecinos;

        public LanzarEsporasClasico(Point posicion, Point dimensionTablero)
        {
            posicionVecinos = GeneradorVecinos.Generar(posicion, dimensionTablero);
        }

        public void LanzarEsporas(Point pos, int[,] tablero)
        {
            foreach (var vecino in posicionVecinos)
                tablero[vecino.X, vecino.Y] += 1;
        }
    }

    public class LanzarEsporasEstocastico : ILanzarEsporasBehavior
    {
        private const double NumeroEsporasALanzar = 15;
        private const double DesviacionEstandarEsporas = 1.5;

        public void LanzarEsporas(Point pos, int[,] tablero)
        {
            HashSet<(int, int)> posicionesDondeCaenEsporas = MuestrearPosicionesDondeCaenEsporas(pos);
            AgregarEsporasTablero(posicionesDondeCaenEsporas, tablero);
        }

        private HashSet<(int, int)> MuestrearPosicionesDondeCaenEsporas(Point pos)
        {
            HashSet<(int, int)> posicionesDondeCaenEsporas = new HashSet<(int, int)>();
            for (int i = 0; i < NumeroEsporasALanzar; i++)
            {
                int x = (int)Math.Round(GeneradorAleatorio.MuestrearGaussiana(pos.X, DesviacionEstandarEsporas));
                int y = (int)Math.Round(GeneradorAleatorio.MuestrearGaussiana(pos.Y, DesviacionEstandarEsporas));
                posicionesDondeCaenEsporas.Add((x, y));
            }

            return posicionesDondeCaenEsporas;
        }

        private void AgregarEsporasTablero(HashSet<(int, int)> posicionesDondeCaenEsporas, int[,] tablero)
        {
            foreach (var pos in posicionesDondeCaenEsporas)
            {
                if (EsPosicionValida(pos.Item1, tablero.GetLength(0)) &&
                    EsPosicionValida(pos.Item2, tablero.GetLength(1)))
                    tablero[pos.Item1, pos.Item2] += 1;
            }
        }

        private bool EsPosicionValida(int value, int maxValue)
            => value >= 0 && value < maxValue;
    }
}
