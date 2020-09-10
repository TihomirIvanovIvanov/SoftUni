using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class MyList : AddRemoveCollection, IUsed
    {
        public MyList()
            : base()
        {
        }

        public int Used => this.List.Count;

        public override string Remove()
        {
            var element = this.List[0];
            this.List.RemoveAt(0);
            return element;
        }
    }
}
