using System.Drawing;
using SimuladorDeHonguitos.Fabricas;
using SimuladorDeHonguitos.Honguitos;

namespace SimuladorDeHonguitos.Simulador;

public class Tablero
{
    private FabricaDeHonguitos fabrica;
    private Point dimensionTablero;
    private List<Honguito> honguitos;
    private bool[,] hayHonguitoAqui;
    private int[,] conteoEsporas;
    
    public Tablero(FabricaDeHonguitos fabrica, Point dimensionTablero)
    {
        this.fabrica = fabrica;
        this.dimensionTablero = dimensionTablero;
        honguitos = GeneradorTableroInicial.Generar(fabrica, dimensionTablero);
    }

    public bool[,] ObtenerPosicionesConHonguitos()
    {
        ComputarPosicionesHonguitos();
        return hayHonguitoAqui;
    }

    public void SimularUnPaso()
    {
        ComputarPosicionesHonguitos();
        LanzarEsporas();
        QuitarHonguitosQueMueren();
        AgregarHonguitosQueNacen();
    }

    private void ComputarPosicionesHonguitos()
    {
        hayHonguitoAqui = new bool[dimensionTablero.X, dimensionTablero.Y];
        foreach (var honguito in honguitos)
            honguito.MarcarHonguitoEnTablero(hayHonguitoAqui);
    }

    private void LanzarEsporas()
    {
        conteoEsporas = new int[dimensionTablero.X, dimensionTablero.Y];
        foreach (var honguito in honguitos)
            honguito.LanzarEsporas(conteoEsporas);
    }

    private void QuitarHonguitosQueMueren()
    {
        List<Honguito> honguitosQueViven = new List<Honguito>();
        foreach (var honguito in honguitos)
            if(honguito.SeguiraVivoEnElSiguienteTurno(hayHonguitoAqui))
                honguitosQueViven.Add(honguito);
        honguitos = honguitosQueViven;
    }
    
    private void AgregarHonguitosQueNacen()
    {
        for (int x = 0; x < dimensionTablero.X; x++)
        for (int y = 0; y < dimensionTablero.Y; y++)
            AgregarHonguitoSiCorresponde(x, y);
    }

    private void AgregarHonguitoSiCorresponde(int x, int y)
    {
        Point pos = new Point(x, y);
        if (fabrica.DebeNacer(pos, hayHonguitoAqui, conteoEsporas))
            honguitos.Add(fabrica.Crear(pos, dimensionTablero));
    }
}