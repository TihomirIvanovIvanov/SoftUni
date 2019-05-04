namespace _03BarracksFactory.Core.Commands
{
    using CustumAttributes;
    using Contracts;
    
    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;

        [Inject]
        private IUnitFactory unitFactory;

        public AddCommand(string[] data)
            : base(data)
        {
        }

        public IRepository Repository { get => repository; private set => this.repository = value; }

        public IUnitFactory UnitFactory { get => unitFactory; private set => this.unitFactory = value; }

        public override string Execute()
        {
            var unitType = this.Data[1];
            var unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);

            var result = unitType + " added!";
            return result;
        }
    }
}
