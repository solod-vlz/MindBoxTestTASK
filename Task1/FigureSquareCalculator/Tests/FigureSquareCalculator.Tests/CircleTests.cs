using System;
using System.Collections.Generic;
using Xunit;

namespace FigureSquareCalculator.Tests
{
    public class CircleTests
    {
        [Fact]
        public void Radius_WithNegativeValue_ThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { new Circle(-1); });
        }

        [Theory]
        [MemberData(nameof(CircleAreaTestData))]
        public void CalculateArea_WithCorrectRadius_ReturnCorrectArea(double radius, double expected)
        {
            var circle = new Circle(radius);

            var actual = circle.CalculateArea();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> CircleAreaTestData()
        {
            yield return new object[] { 0, 0 };
            yield return new object[] { 1, Math.PI};
            yield return new object[] { 1.2, Math.PI * 1.2 * 1.2 };
            yield return new object[] { 32.1, Math.PI * 32.1 * 32.1};
        }
    }
}
