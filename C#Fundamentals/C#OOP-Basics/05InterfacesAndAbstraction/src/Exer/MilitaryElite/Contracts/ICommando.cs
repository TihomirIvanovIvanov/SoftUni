using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }
    }
}
