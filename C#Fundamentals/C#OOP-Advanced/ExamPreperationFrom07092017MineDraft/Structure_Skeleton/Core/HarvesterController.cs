using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private const string FullMode = "Full";
    private const string HalfMode = "Half";
    private const string EnergyMode = "Energy";
    private const double FullRatio = 1.0;
    private const double HalfRatio = 0.5;
    private const double EnergyRatio = 0.2;

    private IHarvesterFactory harvesterFactory;
    private IEnergyRepository energyRepository;
    private List<IHarvester> allHarvesters;
    private double oreProduced;
    private string currentMode;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.harvesterFactory = new HarvesterFactory();
        this.energyRepository = energyRepository;
        this.allHarvesters = new List<IHarvester>();
        this.oreProduced = 0;
        this.currentMode = FullMode;
    }

    public IReadOnlyCollection<IEntity> Entities => this.allHarvesters.AsReadOnly();

    public double OreProduced => this.oreProduced;

    public string ChangeMode(string mode)
    {
        this.currentMode = mode;

        var brokenHarvester = new List<IHarvester>();
        foreach (var harvester in this.allHarvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch
            {
                brokenHarvester.Add(harvester);
            }
        }

        foreach (var harvester in brokenHarvester)
        {
            this.allHarvesters.Remove(harvester);
        }

        return $"Mode changed to {mode}!";
    }

    public string Produce()
    {
        var neededEnergy = this.CalculateNeededEnergy();

        if (this.energyRepository.EnergyStored < neededEnergy)
        {
            return $"Produced 0 ore today!";
        }

        this.energyRepository.TakeEnergy(neededEnergy);

        var oreOutput = this.CalculateOreOutput();
        this.oreProduced += oreOutput;

        return $"Produced {oreOutput} ore today!";
    }

    private double CalculateOreOutput()
    {
        var oreOutput = this.allHarvesters.Sum(h => h.OreOutput);

        switch (this.currentMode)
        {
            case HalfMode:
                oreOutput *= HalfRatio;
                break;
            case EnergyMode:
                oreOutput *= EnergyRatio;
                break;
            case FullMode:
                oreOutput *= FullRatio;
                break;
            default:
                break;
        }

        return oreOutput;
    }

    private double CalculateNeededEnergy()
    {
        var neededEnergy = this.allHarvesters.Sum(h => h.EnergyRequirement);

        switch (this.currentMode)
        {
            case HalfMode:
                neededEnergy *= HalfRatio;
                break;
            case EnergyMode:
                neededEnergy *= EnergyRatio;
                break;
            case FullMode:
                neededEnergy *= FullRatio;
                break;
            default:
                break;
        }

        return neededEnergy;
    }

    public string Register(IList<string> args)
    {
        var harvester = this.harvesterFactory.GenerateHarvester(args);

        if (harvester != null)
        {
            this.allHarvesters.Add(harvester);
            return $"Successfully registered {harvester.GetType().Name}";
        }
        return null;
    }

    public override string ToString()
    {
        return $"Total Mined Plumbus Ore: {this.OreProduced}";
    }
}