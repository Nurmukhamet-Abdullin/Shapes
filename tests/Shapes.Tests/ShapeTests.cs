using Shapes.Contracts;
using System.Collections.Generic;
using System.Globalization;
using Xunit;
using Xunit.Abstractions;

namespace Shapes.Tests
{
    public class ShapeTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public ShapeTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void ShapeArea_ShouldNotThrow()
        {
            var shapes = new List<IShape>
            {
                new Circle(1),
                new Triangle(1, 2, 3),
                new Triangle(2, 3, 4),
                new Circle(1)
            };

            shapes.ForEach(s =>
                _testOutputHelper.WriteLine(s.Area.ToString(CultureInfo.InvariantCulture)));
        }
    }
}
