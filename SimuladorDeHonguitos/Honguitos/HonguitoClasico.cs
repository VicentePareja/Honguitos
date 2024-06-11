using System.Drawing;
using SimuladorDeHonguitos.Simulador;

namespace SimuladorDeHonguitos.Honguitos;

public class HonguitoClasico : Honguito
{
    private List<Point> posicionVecinos;

    public HonguitoClasico(Point posicion, Point dimensionTablero) 
        : base(posicion)
    {
        posicionVecinos = new List<Point>();
        posicionVecinos = GeneradorVecinos.Generar(posicion, dimensionTablero);
    }
    
    public override bool SeguiraVivoEnElSiguienteTurno(bool[,] hayHonguitoAqui)
    {
        int vecinos = ContarVecinos(hayHonguitoAqui);
        return vecinos == 2 || vecinos == 3;
    }

    private int ContarVecinos(bool[,] hayHonguitoAqui)
    {
        int total = 0;
        foreach (var vecino in posicionVecinos)
            if (hayHonguitoAqui[vecino.X, vecino.Y])
                total++;
        return total;
    }
    
    public override void LanzarEsporas(int[,] tablero)
    {
        foreach (var vecino in posicionVecinos)
            tablero[vecino.X, vecino.Y] += 1;
    }
}