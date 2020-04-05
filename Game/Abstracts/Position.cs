using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game.Abstracts
{
    public struct Position : IEquatable<Position>
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position && Equals(position);
        }

        public bool Equals(Position other)
        {
            return x == other.x &&
                   y == other.y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public static bool operator ==(Position left, Position right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }
    }
}
