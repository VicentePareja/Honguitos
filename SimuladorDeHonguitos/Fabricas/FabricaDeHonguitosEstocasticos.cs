using System.Drawing;
using SimuladorDeHonguitos.Honguitos;
using SimuladorDeHonguitos.Simulador;

namespace SimuladorDeHonguitos.Fabricas;

public class FabricaDeHonguitosEstocasticos : FabricaDeHonguitos
{
    public bool DebeNacer(Point pos, bool[,] honguitos, int[,] esporas)
    {
        double probabilidadDeNacer = esporas[pos.X, pos.Y] / 10.0;
        bool debeNacerSegunConteoDeEsporas = GeneradorAleatorio.MuestrearEventoConProbabilidad(probabilidadDeNacer); 
        bool laCasillaEstaVacia = !honguitos[pos.X, pos.Y];
        return laCasillaEstaVacia && debeNacerSegunConteoDeEsporas;
    }

    public Honguito Crear(Point pos, Point dimTab)
    {
        return new HonguitoEstocastico(pos, dimTab);
    }
}