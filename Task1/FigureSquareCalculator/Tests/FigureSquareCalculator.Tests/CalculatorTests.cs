using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FigureSquareCalculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculator_WithNullArgument_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => { new FigureAreaCalculator(null); });
        }

        [Theory]
        [MemberData(nameof(TriangleCalculatorTestData))]
        [MemberData(nameof(CircleCalculatorTestData))]
        public void Calculate_WithCorrectParams_ReturnCorrectArea(IFigure figure, double expected)
        {
            var calculator = new FigureAreaCalculator(figure);

            var actual = calculator.Calculate();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TriangleCalculatorTestData()
        {
            return TriangleTests.TriangleSideTestData()
                               .Select(t =>
                               {
                                   var param = t.Select(i => Convert.ToDouble(i)).ToArray();
                                   return new object[] { new Triangle(param[0], param[1], param[2]), param[3] };
                               });                     
        }

        public static IEnumerable<object[]> CircleCalculatorTestData()
        {
            return CircleTests.CircleAreaTestData()
                               .Select(t =>
                               {
                                   var param = t.Select(i => Convert.ToDouble(i)).ToArray();
                                   return new object[] { new Circle(param[0]), param[1] };
                               });
        }
    }
}
