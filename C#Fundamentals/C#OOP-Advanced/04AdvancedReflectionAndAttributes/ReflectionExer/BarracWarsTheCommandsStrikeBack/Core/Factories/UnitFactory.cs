﻿namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            //TODO: implement for Problem 3
            var classType = Type.GetType("_03BarracksFactory.Models.Units." + unitType);
            var instance = (IUnit)Activator.CreateInstance(classType);

            return instance;
        }
    }
}
