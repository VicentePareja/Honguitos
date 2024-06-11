using System.Drawing;
using SimuladorDeHonguitos.Fabricas;
using SimuladorDeHonguitos.Honguitos;
using SimuladorDeHonguitos.Simulador;

namespace SimuladorDeHonguitos;

public class Controlador
{
    private Tablero tablero;
    
    public Controlador(FabricaDeHonguitos fabrica, Point dimensionTablero)
        => tablero = new Tablero(fabrica, dimensionTablero);

    public void Simular()
    {
        while (true)
        {
            tablero.SimularUnPaso();
            Vista.MostrarTablero(tablero);
        }
    }
    
}