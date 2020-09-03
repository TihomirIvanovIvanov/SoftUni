using System;
using System.Collections.Generic;

namespace RandomList
{
    public class RandomList : List<string>
    {
        private readonly Random random;

        public RandomList()
        {
            this.random = new Random();
        }

        public string RandomString()
        {
            var index = random.Next(0, base.Count - 1);
            var element = base[index];
            base.RemoveAt(index);

            return element;
        }
    }
}
