using System.Drawing;
using SimuladorDeHonguitos.Simulador;

namespace SimuladorDeHonguitos.Comportamientos
{
    public class MorirClasico : IMorirBehavior
    {
        private List<Point> posicionVecinos;

        public MorirClasico(Point posicion, Point dimensionTablero)
        {
            posicionVecinos = GeneradorVecinos.Generar(posicion, dimensionTablero);
        }

        public bool SeguiraVivoEnElSiguienteTurno(Point pos, bool[,] hayHonguitoAqui)
        {
            int vecinos = ContarVecinos(pos, hayHonguitoAqui);
            return vecinos == 2 || vecinos == 3;
        }

        private int ContarVecinos(Point pos, bool[,] hayHonguitoAqui)
        {
            int total = 0;
            foreach (var vecino in posicionVecinos)
                if (hayHonguitoAqui[vecino.X, vecino.Y])
                    total++;
            return total;
        }
    }

    public class MorirEstocastico : IMorirBehavior
    {
        private const double ProbabilidadDeSobrevivir = 0.2;

        public bool SeguiraVivoEnElSiguienteTurno(Point pos, bool[,] hayHonguitoAqui)
            => GeneradorAleatorio.MuestrearEventoConProbabilidad(ProbabilidadDeSobrevivir);
    }
}