namespace Froggy
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : IEnumerable<int>
    {
        private int[] stones;

        public Lake(int[] stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Length; i += 2)
            {
                yield return this.stones[i];
            }

            int length = this.stones.Length;
            var backwardsStartIndex = length % 2 == 0 ? length - 1 : length - 2;

            for (int i = backwardsStartIndex; i > 0; i -= 2)
            {
                yield return this.stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
