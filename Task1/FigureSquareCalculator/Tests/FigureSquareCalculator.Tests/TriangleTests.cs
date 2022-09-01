using System;
using System.Collections.Generic;
using Xunit;

namespace FigureSquareCalculator.Tests
{
    public class TriangleTests
    {
        [Theory]
        [MemberData(nameof(TriangleUncorrectSidesTestData))]
        public void Triangle_WithUncorrectSidesValues_ThrowsArgumentException(double side1, double side2, double side3)
        {
            Assert.Throws<ArgumentException>(() => { new Triangle(side1, side2, side3); });
        }

        public static IEnumerable<object[]> TriangleUncorrectSidesTestData()
        {
            yield return new object[] { 1, 2, 1 };
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { 3, 6, 3 };
            yield return new object[] { 4, 8, 4 };
        }

        [Theory]
        [MemberData(nameof(TriangleNegativeSideTestData))]
        public void Triangle_WithNegativeSideValue_ThrowsArgumentOutOfRangeException(double side1, double side2, double side3)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { new Triangle(side1, side2, side3); });
        }

        public static IEnumerable<object[]> TriangleNegativeSideTestData()
        {
            yield return new object[] { 0, 0, 0 };
            yield return new object[] { 3, 0, 3 };
            yield return new object[] { -1, -8, -4 };
            yield return new object[] { -5, 3, 6 };
            yield return new object[] { 5, -3, 6 };
            yield return new object[] { 5, 3, -6 };
        }

        [Theory]
        [MemberData(nameof(RightTriangleSideTestData))]
        public void IsRightTriangle_WithCorrectSideValues_ReturnTrue(double side1, double side2, double side3)
        {
            var triangle = new Triangle(side1, side2, side3);

            var actual = triangle.IsRightTriangle();

            Assert.True(actual);
        }

        public static IEnumerable<object[]> RightTriangleSideTestData()
        {
            yield return new object[] { 3, 4, 5 };
            yield return new object[] { 3, 5, Math.Sqrt(3 * 3 + 5 * 5) };
            yield return new object[] { 4, 5, Math.Sqrt(4 * 4 + 5 * 5) };
            yield return new object[] { 21, 22, Math.Sqrt(21 * 21 + 22 * 22) };
        }

        [Theory]
        [MemberData(nameof(TriangleSideTestData))]
        public void CalculateArea_WithCorrectSideValues_ReturnCorrectArea(double side1, double side2, double side3, double expected)
        {
            var triangle = new Triangle(side1, side2, side3);

            var actual = triangle.CalculateArea();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TriangleSideTestData()
        {
            yield return new object[] { 3, 4, 5, 6 };
            yield return new object[] { 2, 4, 5, 3.799671038392666 };
            yield return new object[] { 2.5, 3.5, 4.5, 4.353070037341462 };
            yield return new object[] { 245.5, 134.6, 156.7, 9584.37152481058 };
            yield return new object[] { 2455.5, 1345.6, 1565.7, 956253.618570697};
        }
    }
}
