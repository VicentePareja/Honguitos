using System.Drawing;

namespace SimuladorDeHonguitos.Honguitos;

public abstract class Honguito
{
    protected Point Posicion;

    protected Honguito(Point posicion)
        => Posicion = posicion;

    public abstract bool SeguiraVivoEnElSiguienteTurno(bool[,] hayHonguitoAqui);

    public abstract void LanzarEsporas(int[,] tablero);

    public void MarcarHonguitoEnTablero(bool[,] hayHonguitoAqui)
        => hayHonguitoAqui[Posicion.X, Posicion.Y] = true;
}