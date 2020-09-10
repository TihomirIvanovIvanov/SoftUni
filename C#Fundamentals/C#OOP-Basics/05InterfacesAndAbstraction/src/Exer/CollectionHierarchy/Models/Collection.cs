using CollectionHierarchy.Contracts;
using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public abstract class Collection : IAdd
    {
        private readonly List<string> list;

        public Collection()
        {
            this.list = new List<string>();
        }

        protected IList<string> List => this.list;

        public abstract int Add(string element);
    }
}
