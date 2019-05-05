using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        //Arrange
        var dummy = new Dummy(20, 10);

        //Act
        dummy.TakeAttack(5);

        //Arrange
        Assert.AreEqual(dummy.Health, 15);
    }

    [Test]
    public void AttackDeadDummyShouldThrow()
    {
        //Arrange
        var dummy = new Dummy(5, 10);

        //Act
        dummy.TakeAttack(5);

        //Arrange
        Assert.That(() => dummy.TakeAttack(5),
            Throws.InvalidOperationException
            .With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        //Arrange
        var hero = new Hero("Pesho");
        var dummy = new Dummy(5, 10);

        //Act
        hero.Attack(dummy);

        //Assert
        Assert.AreEqual(hero.Experience, 10);
    }
    
    [Test]
    public void AliveDummyCanNotGiveXP()
    {
        //Arrange
        var hero = new Hero("Pesho");
        var dummy = new Dummy(10, 0);

        //Act
        hero.Attack(dummy);

        //Assert
        Assert.AreEqual(hero.Experience, 0);
    }
}