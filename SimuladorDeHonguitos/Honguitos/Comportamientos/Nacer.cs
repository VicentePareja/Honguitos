using System;
using System.Drawing;

namespace SimuladorDeHonguitos.Comportamientos
{
    public class NacerClasico : INacerBehavior
    {
        public bool DebeNacer(Point pos, bool[,] honguitos, int[,] esporas)
        {
            bool hayTresEsporas = esporas[pos.X, pos.Y] == 3;
            bool laCasillaEstaVacia = !honguitos[pos.X, pos.Y];
            return laCasillaEstaVacia && hayTresEsporas;
        }
    }

    public class NacerEstocastico : INacerBehavior
    {
        private Random random;

        public NacerEstocastico()
        {
            random = new Random();
        }

        public bool DebeNacer(Point pos, bool[,] honguitos, int[,] esporas)
        {
            double probabilidadDeNacer = esporas[pos.X, pos.Y] / 10.0;
            bool debeNacerSegunConteoDeEsporas = random.NextDouble() < probabilidadDeNacer; 
            bool laCasillaEstaVacia = !honguitos[pos.X, pos.Y];
            return laCasillaEstaVacia && debeNacerSegunConteoDeEsporas;
        }
    }
}