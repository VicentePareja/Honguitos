using System.Drawing;
using SimuladorDeHonguitos.Comportamientos;

namespace SimuladorDeHonguitos.Honguitos
{
    public class Honguito
    {
        private Point Posicion;
        private INacerBehavior nacerBehavior;
        private ILanzarEsporasBehavior lanzarEsporasBehavior;
        private IMorirBehavior morirBehavior;

        public Honguito(Point posicion, INacerBehavior nacerBehavior, ILanzarEsporasBehavior lanzarEsporasBehavior, IMorirBehavior morirBehavior)
        {
            Posicion = posicion;
            this.nacerBehavior = nacerBehavior;
            this.lanzarEsporasBehavior = lanzarEsporasBehavior;
            this.morirBehavior = morirBehavior;
        }

        public bool DebeNacer(bool[,] honguitos, int[,] esporas)
        {
            return nacerBehavior.DebeNacer(Posicion, honguitos, esporas);
        }

        public void LanzarEsporas(int[,] tablero)
        {
            lanzarEsporasBehavior.LanzarEsporas(Posicion, tablero);
        }

        public bool SeguiraVivoEnElSiguienteTurno(bool[,] hayHonguitoAqui)
        {
            return morirBehavior.SeguiraVivoEnElSiguienteTurno(Posicion, hayHonguitoAqui);
        }

        public void MarcarHonguitoEnTablero(bool[,] hayHonguitoAqui)
        {
            hayHonguitoAqui[Posicion.X, Posicion.Y] = true;
        }
    }
}