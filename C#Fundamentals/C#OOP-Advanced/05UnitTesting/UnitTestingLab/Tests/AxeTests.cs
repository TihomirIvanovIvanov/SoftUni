using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    [Test]
    public void AxeLosesDurabilityAfterAttack()
    {
        //Arrange
        var axe = new Axe(10, 10);
        var dummy = new Dummy(10, 10);

        //Act
        axe.Attack(dummy);

        //Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn`t change after attack.");
    }

    [Test]
    public void AttackWithBrokenAxeShouldThrow()
    {
        //Arrange
        var axe = new Axe(1, 1);
        var dummy = new Dummy(10, 10);

        //Act
        axe.Attack(dummy);

        //Arrange
        Assert.That(() => axe.Attack(dummy),
            Throws.InvalidOperationException
            .With.Message.EqualTo("Axe is broken."));
    }
}