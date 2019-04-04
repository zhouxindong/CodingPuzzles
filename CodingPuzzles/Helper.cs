using System;
using System.Linq;

namespace CodingPuzzles
{
    public static class Helper
    {
        public static bool ArrayEquals<T>(this T[] left, T[] right)
            where T : IEquatable<T>
        {
            if(left == null || right == null)
                return false;

            if (left.Length != right.Length)
                return false;
            return !left.Where((t, i) => !t.Equals(right[i])).Any();
        }
    }
}