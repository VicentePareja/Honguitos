using System.Drawing;

namespace SimuladorDeHonguitos.Comportamientos
{
    public interface INacerBehavior
    {
        bool DebeNacer(Point pos, bool[,] honguitos, int[,] esporas);
    }
}