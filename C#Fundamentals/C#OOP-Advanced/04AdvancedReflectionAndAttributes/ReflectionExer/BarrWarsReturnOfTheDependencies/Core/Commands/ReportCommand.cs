namespace _03BarracksFactory.Core.Commands
{
    using Contracts;
    using CustumAttributes;

    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        public ReportCommand(string[] data)
            : base(data)
        {
        }

        public IRepository Repository { get => this.repository; private set => this.repository = value; }

        public override string Execute()
        {
            var result = this.Repository.Statistics;
            return result;
        }
    }
}
