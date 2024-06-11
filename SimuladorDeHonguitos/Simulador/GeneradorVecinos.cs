using System.Drawing;

namespace SimuladorDeHonguitos.Simulador;

public static class GeneradorVecinos
{
    private static Point posicion;
    private static List<Point> posicionVecinos;
    
    
    public static List<Point> Generar(Point posicion, Point dimensionTablero)
    {
        GeneradorVecinos.posicion = posicion;
        posicionVecinos = new List<Point>();
        for (int x = 0; x < dimensionTablero.X; x++)
        for (int y = 0; y < dimensionTablero.Y; y++)
            AgregarComoVecinoSiSeEncuentraCerca(x, y);

        return posicionVecinos;
    }

    private static void AgregarComoVecinoSiSeEncuentraCerca(int x, int y)
    {
        Point posibleVecino = new Point(x, y);
        double distancia = ObtenerDistanciaEuclidiana(posibleVecino);
        if (distancia > 0 && distancia < 2)
            posicionVecinos.Add(posibleVecino);
    }

    private static double ObtenerDistanciaEuclidiana(Point posibleVecino)
    {
        double dX = posibleVecino.X - posicion.X;
        double dY = posibleVecino.Y - posicion.Y;
        return Math.Sqrt(dX*dX + dY*dY);
    }

}