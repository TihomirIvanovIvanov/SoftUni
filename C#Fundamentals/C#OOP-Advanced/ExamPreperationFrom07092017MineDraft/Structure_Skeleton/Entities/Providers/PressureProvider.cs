public class PressureProvider : Provider
{
    private const int EnergyIncrese = 2;
    private const int DurabilityDecrese = 300;

    public PressureProvider(int id, double energyOutput) 
        : base(id, energyOutput * EnergyIncrese)
    {
        this.Durability -= DurabilityDecrese;
    }
}