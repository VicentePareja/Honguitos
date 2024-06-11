using System.Drawing;
using SimuladorDeHonguitos;
using SimuladorDeHonguitos.Comportamientos;
using SimuladorDeHonguitos.Fabricas;
using SimuladorDeHonguitos.Honguitos;

int dimX = 25;
int dimY = 10;
var nacerBehavior = new NacerClasico();
var lanzarEsporasBehavior = new LanzarEsporasEstocastico();
var morirBehavior = new MorirEstocastico();
var fabrica = new FabricaDeHonguitos(nacerBehavior, lanzarEsporasBehavior, morirBehavior);
Point dimensionTablero = new Point(dimX, dimY);

Controlador controlador = new Controlador(fabrica, dimensionTablero);
controlador.Simular();