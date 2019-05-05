using NUnit.Framework;

[TestFixture]
public class RefactorDummyTests
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
    public void DummyLosesHealthIfAttacked()
    {
        //Act
        var attackPoints = 5;
        this.dummy.TakeAttack(attackPoints);
        //Assert
        var actualResult = 15;
        Assert.AreEqual(this.dummy.Health, actualResult);
    }

    [Test]
    public void AttackDeadDummyShouldThrow()
    {
        //Act
        var attackPoints = 20;
        this.dummy.TakeAttack(attackPoints);
        //Assert
        var actualResult = "Dummy is dead.";
        Assert.That(() => dummy.TakeAttack(attackPoints),
            Throws.InvalidOperationException
            .With.Message.EqualTo(actualResult));
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        //Act
        this.dummy.TakeAttack(this.dummy.Health);
        //Assert
        Assert.AreEqual(this.dummy.GiveExperience(), DummyXP);
    }

    [Test]
    public void AliveDummyCannotGiveXP()
    {
        //Act
        this.dummy.TakeAttack(this.dummy.Health);
        //Assert
        Assert.AreEqual(this.dummy.GiveExperience(), DummyHealth);
    }
}