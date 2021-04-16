using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketShips.Lib
{
    public class Range<T>
    {
        public readonly T Start;
        public readonly T End;

        public Range(T start, T end)
        {
            this.Start = start;
            this.End = end;
        }

        public override string ToString()
        {
            return $"{Start} to {End}";
        }
    }

    public static class Range
    {
        public static bool Overlap<T>(Range<T> left, Range<T> right) where T : IComparable<T>
        {
            if (left.Start.CompareTo(left.Start) == 0)
            {
                return true;
            }
            else if (left.Start.CompareTo(right.Start) > 0)
            {
                return left.Start.CompareTo(right.End) <= 0;
            }
            else
            {
                return right.Start.CompareTo(left.End) <= 0;
            }
        }
    }
}
