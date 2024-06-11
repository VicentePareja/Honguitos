using System.Drawing;
using SimuladorDeHonguitos.Honguitos;

namespace SimuladorDeHonguitos.Fabricas;

public interface FabricaDeHonguitos
{
    bool DebeNacer(Point pos, bool[,] honguitos, int[,] esporas);
    Honguito Crear(Point pos, Point dimTab);
}