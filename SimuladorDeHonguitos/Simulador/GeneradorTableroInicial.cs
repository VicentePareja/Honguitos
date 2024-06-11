using System.Drawing;
using SimuladorDeHonguitos.Fabricas;
using SimuladorDeHonguitos.Honguitos;

namespace SimuladorDeHonguitos.Simulador;

public static class GeneradorTableroInicial
{
    private const double ProbDeQueHayaUnHonguito = 0.3;
    private static List<Honguito> honguitos;
    private static FabricaDeHonguitos fabrica;
    private static Point dimensionTablero;
    
    public static List<Honguito> Generar(FabricaDeHonguitos fabrica, Point dimensionTablero)
    {
        GeneradorTableroInicial.fabrica = fabrica;
        GeneradorTableroInicial.dimensionTablero = dimensionTablero;
        honguitos = new List<Honguito>();
        for (int x = 0; x < dimensionTablero.X; x++)
            for (int y = 0; y < dimensionTablero.Y; y++)
                AgregarHonguitoAleatoriamente(new Point(x, y));
        return honguitos;
    }

    private static void AgregarHonguitoAleatoriamente(Point posicion)
    {
        if (GeneradorAleatorio.MuestrearEventoConProbabilidad(ProbDeQueHayaUnHonguito))
            AgregarHonguitoSegunTipo(posicion);
    }

    private static void AgregarHonguitoSegunTipo(Point posicion)
    {
        Honguito honguito = fabrica.Crear(posicion, dimensionTablero);
        honguitos.Add(honguito);
    }
}