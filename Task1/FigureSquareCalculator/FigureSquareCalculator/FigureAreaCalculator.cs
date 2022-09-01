using System;

namespace FigureSquareCalculator
{
    public class FigureAreaCalculator
    {
        private readonly IFigure figure;

        public FigureAreaCalculator(IFigure figure)
        {
            this.figure = figure ?? throw new ArgumentNullException(nameof(figure));
        }

        public double Calculate()
        {
            return figure.CalculateArea();
        }
    }
}
