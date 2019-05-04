namespace _03BarracksFactory.Core.Commands
{
    using Contracts;
    using System;
    using CustumAttributes;

    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data)
            : base(data)
        {
        }

        public IRepository Repository { get => this.repository; private set => this.repository = value; }

        public override string Execute()
        {
            var typeOfUnit = this.Data[1];

            try
            {
                this.Repository.RemoveUnit(typeOfUnit);
                return $"{typeOfUnit} retired!";
            }
            catch (ArgumentException ae)
            {
                return ae.Message;
            }
        }
    }
}