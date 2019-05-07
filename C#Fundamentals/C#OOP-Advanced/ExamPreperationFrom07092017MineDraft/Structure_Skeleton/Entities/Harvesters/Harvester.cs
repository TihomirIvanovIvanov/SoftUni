using System.Text;

public abstract class Harvester : IHarvester
{
    private const int InitialDurability = 1000;
    private const double DurabilityBrokenValue = 100;
    
    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = InitialDurability;
    }

    public int Id { get; }

    public double OreOutput { get; protected set; }

    public double EnergyRequirement { get; protected set; }

    public virtual double Durability { get; protected set; }

    public virtual void Broke()
    {
        this.Durability -= DurabilityBrokenValue;
        if (this.Durability < 0)
        {
            throw new System.ArgumentException();
        }
    }

    public double Produce()
    {
        return this.OreOutput;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.GetType().Name}")
            .AppendLine($"Durability: {this.Durability}");

        return sb.ToString().TrimEnd();
    }
}