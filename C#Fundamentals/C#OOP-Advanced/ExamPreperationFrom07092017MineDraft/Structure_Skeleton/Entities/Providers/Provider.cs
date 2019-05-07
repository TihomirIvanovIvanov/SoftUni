using System.Text;

public abstract class Provider : IProvider
{
    private const int InitialDurability = 1000;
    private const double DurabilityBrokenValue = 100;

    protected Provider(int id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public double EnergyOutput { get; protected set; }

    public int Id { get; protected set; }

    public double Durability { get; protected set; }

    public void Broke()
    {
        this.Durability -= DurabilityBrokenValue;
        if (this.Durability < 0)
        {
            throw new System.ArgumentException();
        }
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.GetType().Name}")
            .AppendLine($"Durability: {this.Durability}");

        return sb.ToString().TrimEnd();
    }
}