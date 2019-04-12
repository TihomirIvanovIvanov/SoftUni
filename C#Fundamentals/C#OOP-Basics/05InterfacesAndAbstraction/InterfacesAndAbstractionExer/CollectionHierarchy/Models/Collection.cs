namespace CollectionHierarchy.Models
{
    using Contracts;
    using System.Collections.Generic;

    public abstract class Collection : IAdd
    {
        private List<string> list;

        public Collection()
        {
            this.list = new List<string>();
        }

        protected IList<string> List => this.list;

        public abstract int Add(string element);
    }
}