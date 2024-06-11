using System.Drawing;
using SimuladorDeHonguitos;
using SimuladorDeHonguitos.Fabricas;
using SimuladorDeHonguitos.Honguitos;

int dimX = 25;
int dimY = 10;
FabricaDeHonguitos fabrica = new FabricaDeHonguitosEstocasticos();
Point dimensionTablero = new Point(dimX, dimY);

Controlador controlador = new Controlador(fabrica, dimensionTablero);
controlador.Simular();