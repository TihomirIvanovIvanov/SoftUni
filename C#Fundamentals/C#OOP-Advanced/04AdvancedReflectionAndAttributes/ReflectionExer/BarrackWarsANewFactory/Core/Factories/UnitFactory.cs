namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            //TODO: implement for Problem 3

            //maybe i need the namespace _03BarracksFactory.Models.Units.
            var classType = Type.GetType("_03BarracksFactory.Models.Units." + unitType);
            var instance = (IUnit)Activator.CreateInstance(classType);

            return instance;
        }
    }
}
