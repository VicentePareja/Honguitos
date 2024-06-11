namespace SimuladorDeHonguitos.Simulador;

public static class GeneradorAleatorio
{
    private static Random generador = new Random();

    public static bool MuestrearEventoConProbabilidad(double prob)
        => generador.NextDouble() < prob;
    
    public static double MuestrearGaussiana(double media, double desviacionEstandar)
    {
        double u1 = 1.0-generador.NextDouble();
        double u2 = 1.0-generador.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                               Math.Sin(2.0 * Math.PI * u2);
        return media + desviacionEstandar * randStdNormal;
    }
}