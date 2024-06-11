using System.Drawing;

namespace SimuladorDeHonguitos.Comportamientos
{
    public interface ILanzarEsporasBehavior
    {
        void LanzarEsporas(Point pos, int[,] tablero);
    }
}