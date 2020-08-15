using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CustomComparator
{
    internal class EvenOddComparer : IComparer<int>
    {
        public int Compare([AllowNull] int x, [AllowNull] int y)
        {
            if (this.IsEven(x) && !this.IsEven(y))
            {
                return -1;
            }

            if (!this.IsEven(x) && this.IsEven(y))
            {
                return 1;
            }

            if (x >= y)
            {
                return 1;
            }

            return -1;
        }

        private bool IsEven(int x) => x % 2 == 0;
    }
}