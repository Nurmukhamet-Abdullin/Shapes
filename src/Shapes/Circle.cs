using Shapes.Contracts;
using System;

namespace Shapes
{
    public class Circle : IShape, IEquatable<Circle>, ICloneable
    {
        public Circle(double radius)
        {
            Radius = radius > 0
                ? radius
                : throw new OverflowException(nameof(radius));
        }

        public double Radius { get; }

        /// <inheritdoc />
        public double Area => Math.PI * Radius * Radius;

        /// <inheritdoc />
        public bool Equals(Circle other) => Radius.Equals(other.Radius);

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is Circle other
                ? Equals(other)
                : throw new InvalidCastException(nameof(obj));
        }

        /// <inheritdoc />
        public override int GetHashCode() => Radius.GetHashCode();

        public static bool operator ==(Circle left, Circle right) =>
            Equals(left, right);

        public static bool operator !=(Circle left, Circle right) =>
            !Equals(left, right);

        /// <inheritdoc />
        public override string ToString() => $"Circle[{Radius}]";

        /// <inheritdoc />
        public object Clone() => new Circle(Radius);
    }
}
