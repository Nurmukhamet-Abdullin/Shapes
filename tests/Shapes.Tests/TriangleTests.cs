using System;
using Xunit;

namespace Shapes.Tests
{
    public class TriangleTests
    {
        [Theory]
        [InlineData(1, 2, 5)]
        [InlineData(1, 5, 2)]
        [InlineData(0, 4, 5)]
        [InlineData(3, 0, 5)]
        [InlineData(3, 4, 0)]
        [InlineData(-1, 4, 5)]
        [InlineData(3, -1, 5)]
        [InlineData(3, 4, -1)]
        public void Triangle_ShouldNotBeConstructed_WithInvalidSides(
            double side1, double side2, double side3)
        {
            Assert.Throws<OverflowException>(() =>
                new Triangle(side1, side2, side3));
        }

        [Theory]
        [InlineData(3, 4, 5)]
        [InlineData(3, 5, 4)]
        [InlineData(4, 3, 5)]
        [InlineData(4, 5, 3)]
        [InlineData(5, 3, 4)]
        [InlineData(5, 4, 3)]
        public void Triangle_ShouldBeRectangular_WithPythagoreanSides(
            double side1, double side2, double side3)
        {
            var triangle = new Triangle(side1, side2, side3);

            Assert.True(triangle.IsRectangular);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 3, 4)]
        [InlineData(4, 5, 6)]
        public void Triangle_ShouldNotBeRectangular_WithPythagoreanSides(
            double side1, double side2, double side3)
        {
            var triangle = new Triangle(side1, side2, side3);

            Assert.False(triangle.IsRectangular);
        }

        [Fact]
        public void TriangleClone_ShouldReturnEqualButNotSameInstance()
        {
            var tr1 = new Triangle(1, 2, 3);
            var tr2 = (Triangle)tr1.Clone();

            Assert.Equal(tr1, tr2);
            Assert.False(ReferenceEquals(tr1, tr2));
        }
    }
}
