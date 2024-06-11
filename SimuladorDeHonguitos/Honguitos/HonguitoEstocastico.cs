using System.Drawing;
using SimuladorDeHonguitos.Simulador;

namespace SimuladorDeHonguitos.Honguitos;

public class HonguitoEstocastico : Honguito
{
    private const double ProbabilidadDeSobrevivir = 0.2;
    private const double NumeroEsporasALanzar = 15;
    private const double DesviacionEstandarEsporas = 1.5;
    
    public HonguitoEstocastico(Point posicion, Point dimensionTablero) 
        : base(posicion)
    { }

    public override bool SeguiraVivoEnElSiguienteTurno(bool[,] hayHonguitoAqui)
        => GeneradorAleatorio.MuestrearEventoConProbabilidad(ProbabilidadDeSobrevivir);

    public override void LanzarEsporas(int[,] tablero)
    {
        HashSet<(int, int)> posicionesDondeCaenEsporas = MuestrearPosicionesDondeCaenEsporas();
        AgregarEsporasTablero(posicionesDondeCaenEsporas, tablero);
    }

    private HashSet<(int, int)> MuestrearPosicionesDondeCaenEsporas()
    {
        HashSet<(int, int)> posicionesDondeCaenEsporas = new HashSet<(int, int)>();
        for (int i = 0; i < NumeroEsporasALanzar; i++)
        {
            int x = (int)Math.Round(GeneradorAleatorio.MuestrearGaussiana(Posicion.X, DesviacionEstandarEsporas));
            int y = (int)Math.Round(GeneradorAleatorio.MuestrearGaussiana(Posicion.Y, DesviacionEstandarEsporas));
            posicionesDondeCaenEsporas.Add((x, y));
        }

        return posicionesDondeCaenEsporas;
    }

    private void AgregarEsporasTablero(HashSet<(int, int)> posicionesDondeCaenEsporas, int[,] tablero)
    {
        foreach (var pos in posicionesDondeCaenEsporas)
        {
            if (EsPosicionValida(pos.Item1, tablero.GetLength(0)) &&
                EsPosicionValida(pos.Item2, tablero.GetLength(1)))
                tablero[pos.Item1,pos.Item2] += 1;
        }
    }

    private bool EsPosicionValida(int value, int maxValue)
        => value >= 0 && value < maxValue;
}