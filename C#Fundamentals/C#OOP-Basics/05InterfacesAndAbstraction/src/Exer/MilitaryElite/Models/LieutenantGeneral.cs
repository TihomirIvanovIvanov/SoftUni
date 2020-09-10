namespace MilitaryElite.Models
{
    using Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<Private> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<Private>();
        }

        public IReadOnlyCollection<IPrivate> Privates
        {
            get { return this.privates; }
        }

        public void AddPrivate(Private @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (var current in this.Privates)
            {
                sb.AppendLine("  " + current.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}