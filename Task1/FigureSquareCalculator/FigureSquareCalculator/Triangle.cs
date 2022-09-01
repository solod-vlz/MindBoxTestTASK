using System;

namespace FigureSquareCalculator
{
    public class Triangle : IFigure
    {
        public double Side1 { get; }

        public double Side2 { get; }

        public double Side3 { get; }

        public double CalculateArea()
        {
            var halfPerimeter = (Side1 + Side2 + Side3) / 2 ;

            return Math.Sqrt(halfPerimeter * (halfPerimeter - Side1) * (halfPerimeter - Side2) * (halfPerimeter - Side3));
        }

        public Triangle(double side1, double side2, double side3)
        {
            if (side1 <= 0)
                throw new ArgumentOutOfRangeException(nameof(side1));
            Side1 = side1;

            if (side2 <= 0)
                throw new ArgumentOutOfRangeException(nameof(side2));
            Side2 = side2;

            if (side3 <= 0)
                throw new ArgumentOutOfRangeException(nameof(side3));
            Side3 = side3;

            if (!IsCorrectTriangle(side1, side2, side3))
                throw new ArgumentException("Sides values are inconsistent");
        }

        private bool IsCorrectSides(double a, double b, double c) => a + b > c;

        private bool IsCorrectTriangle(double a, double b, double c)
        {
            return IsCorrectSides(a, b, c) & IsCorrectSides(a, c, b) & IsCorrectSides(b, c, a);
        }

        public bool IsRightTriangle()
        {
            var sides = new double[] { Side1, Side2, Side3 };
            Array.Sort(sides);

            return (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2)).CompareTo(Math.Pow(sides[2], 2)) == 0;
        }
    }
}
