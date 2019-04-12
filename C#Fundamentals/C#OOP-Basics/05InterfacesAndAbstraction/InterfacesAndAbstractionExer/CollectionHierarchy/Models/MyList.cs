namespace CollectionHierarchy.Models
{
    using Contracts;

    public class MyList : AddRemoveCollection, IUsed
    {
        public MyList()
            : base()
        {
        }

        public override string Remove()
        {
            var element = this.List[0];
            this.List.RemoveAt(0);

            return element;
        }

        public int Used => this.List.Count;
    }
}