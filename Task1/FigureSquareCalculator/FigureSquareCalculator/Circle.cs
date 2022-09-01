using System;

namespace FigureSquareCalculator
{
    public class Circle : IFigure
    {
        public double Radius { get; }

        public Circle (double radius)
        {
            if (radius < 0)
                throw new ArgumentOutOfRangeException("Radius couldn`t be negative");

            Radius = radius;
        }

        public double CalculateArea() => Math.Pow(Radius, 2) * Math.PI;

    }
}
