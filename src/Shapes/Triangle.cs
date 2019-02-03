using Shapes.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shapes
{
    public class Triangle : IShape, IEquatable<Triangle>, ICloneable
    {
        private const double Epsilon = double.Epsilon * 10;

        /// <summary>Semiperimeter.</summary>
        private readonly double _sp;

        /// <summary>Sorted sides.</summary>
        private readonly IReadOnlyList<double> _sorted;

        /// <summary>
        /// Equilateral triangle.
        /// </summary>
        /// <param name="side">The length of the triangle's side.</param>
        public Triangle(double side)
            : this(side, side, side)
        {
        }

        /// <summary>
        /// Isosceles triangle.
        /// </summary>
        /// <param name="theBase">Length of the thiangle's base.</param>
        /// <param name="hip">Length of the triangle's hips.</param>
        public Triangle(double theBase, double hip)
            : this(theBase, hip, hip)
        {
        }

        public Triangle(double side1, double side2, double side3)
        {
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
                throw new OverflowException(
                    "One of sides is not positive.");

            if (side1 + side2 < side3 ||
                side1 + side3 < side2 ||
                side2 + side3 < side1)
                throw new OverflowException(
                    "One of the sides is longer than other two.");

            Side1 = side1;
            Side2 = side2;
            Side3 = side3;

            _sp = (side1 + side2 + side3) / 2;

            _sorted = new [] { side1, side2, side3 }.OrderBy(x => x).ToList();
        }

        public double Side1 { get; }
        public double Side2 { get; }
        public double Side3 { get; }

        // https://en.wikipedia.org/wiki/Heron%27s_formula
        /// <inheritdoc />
        public double Area =>
            Math.Sqrt(_sp * (_sp - Side1) * (_sp - Side2) * (_sp - Side3));

        // https://en.wikipedia.org/wiki/Pythagorean_theorem
        // https://randomascii.wordpress.com/2012/02/25/comparing-floating-point-numbers-2012-edition/
        public bool IsRectangular =>
            Math.Abs(_sorted[0] * _sorted[0] + _sorted[1] * _sorted[1]
                     - _sorted[2] * _sorted[2]) < Epsilon;

        /// <inheritdoc />
        public bool Equals(Triangle other)
        {
            return _sorted[0].Equals(other._sorted[0])
                && _sorted[1].Equals(other._sorted[1])
                && _sorted[2].Equals(other._sorted[2]);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is Triangle other
                ? Equals(other)
                : throw new InvalidCastException(nameof(obj));
        }

        /// <inheritdoc />
        public override int GetHashCode() => _sorted.GetHashCode();

        public static bool operator ==(Triangle left, Triangle right) =>
            Equals(left, right);

        public static bool operator !=(Triangle left, Triangle right) =>
            !Equals(left, right);

        /// <inheritdoc />
        public override string ToString() =>
            $"Triangle[{_sorted[0]} {_sorted[1]}, {_sorted[2]}]";

        /// <inheritdoc />
        public object Clone() => new Triangle(Side1, Side2, Side3);
    }
}
