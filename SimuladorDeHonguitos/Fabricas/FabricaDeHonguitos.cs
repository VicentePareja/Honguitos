using System.Drawing;
using SimuladorDeHonguitos.Comportamientos;
using SimuladorDeHonguitos.Honguitos;

namespace SimuladorDeHonguitos.Fabricas
{
    public class FabricaDeHonguitos
    {
        private INacerBehavior nacerBehavior;
        private ILanzarEsporasBehavior lanzarEsporasBehavior;
        private IMorirBehavior morirBehavior;

        public FabricaDeHonguitos(INacerBehavior nacerBehavior, ILanzarEsporasBehavior lanzarEsporasBehavior, IMorirBehavior morirBehavior)
        {
            this.nacerBehavior = nacerBehavior;
            this.lanzarEsporasBehavior = lanzarEsporasBehavior;
            this.morirBehavior = morirBehavior;
        }

        public bool DebeNacer(Point pos, bool[,] honguitos, int[,] esporas)
        {
            return nacerBehavior.DebeNacer(pos, honguitos, esporas);
        }

        public Honguito Crear(Point pos, Point dimensionTablero)
        {
            return new Honguito(pos, nacerBehavior, lanzarEsporasBehavior, morirBehavior);
        }
    }
}