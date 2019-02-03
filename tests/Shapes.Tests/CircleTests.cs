using System;
using Xunit;

namespace Shapes.Tests
{
    public class CircleTests
    {
        [Theory]
        [InlineData(-2)]
        [InlineData(-1)]
        [InlineData(-1.5)]
        [InlineData(-0.5)]
        [InlineData(0)]
        public void Circle_ShouldNotBeConstructed_WithInvalidSides(
            double radius)
        {
            Assert.Throws<OverflowException>(() =>
                new Circle(radius));
        }

        [Theory]
        [InlineData(1, Math.PI)]
        [InlineData(2, Math.PI * 4)]
        [InlineData(3, Math.PI * 9)]
        [InlineData(4, Math.PI * 16)]
        public void CircleArea_ShouldBeCorrect_WithAnyCorrectInput(
            double radius, double expectedArea)
        {
            var circle = new Circle(radius);

            Assert.Equal(circle.Area, expectedArea);
        }

        [Fact]
        public void CircleClone_ShouldReturnEqualButNotSameInstance()
        {
            var tr1 = new Circle(1);
            var tr2 = (Circle)tr1.Clone();

            Assert.Equal(tr1, tr2);
            Assert.False(ReferenceEquals(tr1, tr2));
        }
    }
}
