using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheTankGame.Entities.Miscellaneous;
using TheTankGame.Entities.Parts.Contracts;
using TheTankGame.Entities.Parts.Factories.Contracts;

namespace TheTankGame.Entities.Parts.Factories
{
    public class PartFactory : IPartFactory
    {
        public IPart CreatePart(string partTypeInput, string model, double weight, decimal price, int additionalParameter)
        {
            string format = partTypeInput + "Part";

            var partType = Assembly.GetCallingAssembly().GetTypes()
                .Where(t => typeof(IPart).IsAssignableFrom(t))
                .FirstOrDefault(t => t.Name == format);

            var part = (IPart)Activator.CreateInstance(partType, model, weight, price, additionalParameter);
            return part;
        }
    }
}
