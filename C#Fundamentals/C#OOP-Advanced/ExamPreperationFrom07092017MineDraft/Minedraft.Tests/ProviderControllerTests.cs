using NUnit.Framework;
using System.Linq;

[TestFixture]
public class ProviderControllerTests
{
    private IEnergyRepository energyRepository;
    private IProviderController providerController;

    [SetUp]
    public void SetUp()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(this.energyRepository);
    }

    [Test]
    public void ProviderController_RegisterProvider_Valid()
    {
        //Arrange 
        var args = "Pressure 40 100".Split().ToList();
        this.providerController.Register(args);

        //Act
        var countOfProviders = this.providerController.Entities.Count();

        //Assert
        Assert.AreEqual(1, countOfProviders, "Count of registered providers is not correct!");
    }

    [Test]
    public void ProviderController_ProduceMethod_Removes_Broken_Provider()
    {
        var args = "Pressure 40 100".Split().ToList();
        var args1 = "Solar 80 100".Split().ToList();

        this.providerController.Register(args);
        this.providerController.Register(args1);
        this.providerController.Produce();

        var actualResult = this.providerController.TotalEnergyProduced;

        Assert.AreEqual(300, actualResult, "Total energy produce is not correct!");
    }

    [Test]
    public void ProviderController_RepairProvider_Valid()
    {
        var args = "Pressure 40 100".Split().ToList();
        var args1 = "Solar 80 100".Split().ToList();
        var args2 = "Standart 10 100".Split().ToList();

        this.providerController.Register(args);
        this.providerController.Register(args1);
        this.providerController.Register(args2);

        for (int i = 0; i <= 10; i++)
        {
            this.providerController.Produce();
        }

        var actualAliveProvidersCount = this.providerController.Entities.Count;

        Assert.AreEqual(1, actualAliveProvidersCount, "Alive providers count is not correct!");
    }
}