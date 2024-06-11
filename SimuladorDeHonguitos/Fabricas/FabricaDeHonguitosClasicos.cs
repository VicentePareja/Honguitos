using System.Drawing;
using SimuladorDeHonguitos.Honguitos;

namespace SimuladorDeHonguitos.Fabricas;

public class FabricaDeHonguitosClasicos : FabricaDeHonguitos
{
    public bool DebeNacer(Point pos, bool[,] honguitos, int[,] esporas)
    {
        bool hayTresEsporas = esporas[pos.X, pos.Y] == 0;
        bool laCasillaEstaVacia = !honguitos[pos.X, pos.Y];
        return laCasillaEstaVacia && hayTresEsporas;
    }

    public Honguito Crear(Point pos, Point dimTab)
    {
        return new HonguitoClasico(pos, dimTab);
    }
}