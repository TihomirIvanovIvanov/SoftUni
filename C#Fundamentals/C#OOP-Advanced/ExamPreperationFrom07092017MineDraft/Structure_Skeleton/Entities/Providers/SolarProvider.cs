public class SolarProvider : Provider
{
    private const int DurabilityIncrese = 500;

    public SolarProvider(int id, double energyOutput)
        : base(id, energyOutput)
    {
        this.Durability += DurabilityIncrese;
    }
}