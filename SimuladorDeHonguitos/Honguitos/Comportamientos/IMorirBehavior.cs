using System.Drawing;

namespace SimuladorDeHonguitos.Comportamientos
{
    public interface IMorirBehavior
    {
        bool SeguiraVivoEnElSiguienteTurno(Point pos, bool[,] hayHonguitoAqui);
    }
}