using NUnit.Framework;

[TestFixture]
public class RefactorAxeTests
{
    private const int AxeAttack = 2;
    private const int AxeDurability = 2;
    private const int DummyHealth = 20;
    private const int DummyXP = 20;

    private Axe axe;
    private Dummy dummy;

    //Arrange
    [SetUp]
    public void TestInit()
    {
        this.axe = new Axe(AxeAttack, AxeDurability);
        this.dummy = new Dummy(DummyHealth, DummyXP);
    }

    [Test]
    public void AxeLosesDurabilityAfterAttack()
    {
        //Act
        this.axe.Attack(dummy);
        var actualResult = 1;
        //Assert
        Assert.AreEqual(axe.DurabilityPoints, actualResult,
            "Axe durability doesn`t change after attack.");
    }

    [Test]
    public void BrokenAxeCantAttack()
    {
        //Act
        this.axe.Attack(dummy);
        this.axe.Attack(dummy);
        var expectedMsg = "Axe is broken.";
        //Assert
        Assert.That(() => axe.Attack(dummy),
            Throws.InvalidOperationException
            .With.Message.EqualTo(expectedMsg));
    }
}