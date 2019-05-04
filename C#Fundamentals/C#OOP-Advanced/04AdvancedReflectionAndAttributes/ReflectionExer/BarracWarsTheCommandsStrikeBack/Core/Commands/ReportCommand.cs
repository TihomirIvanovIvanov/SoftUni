namespace _03BarracksFactory.Core.Commands
{
    using Contracts;

    public class ReportCommand : Command
    {
        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            var unitToReport = this.Repository.Statistics;
            return unitToReport;
        }
    }
}
