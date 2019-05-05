using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

[TestFixture]
public class HeroTests
{
    private const int FakeAxeAttackPoints = 2;
    private const int FakeAxeDurabilityPoints = 2;
    private const int FakeTargetHealth = 10;
    private const int FakeTargetXP = 10;
    private const string FakeHeroName = "Pesho";

    private class FakeTarget : ITarget
    {
        public FakeTarget()
        {
            this.Health = FakeTargetHealth;
        }

        public int Health { get; private set; }

        public int GiveExperience()
        {
            return FakeTargetXP;
        }

        public bool IsDead()
        {
            return this.Health <= 0;
        }

        public void TakeAttack(int attackPoints)
        {
            this.Health -= attackPoints;
        }
    }

    private class FakeWeapon : IWeapon
    {
        public FakeWeapon()
        {
            this.AttackPoints = FakeAxeAttackPoints;
            this.DurabilityPoints = FakeAxeDurabilityPoints;
        }

        public int AttackPoints { get; private set; }

        public int DurabilityPoints { get; private set; }

        public void Attack(ITarget target)
        {
            target.TakeAttack(this.AttackPoints);
        }
    }

    [Test]
    public void HeroGainsXPAfterAttackIfTargetDies()
    {
        //Arrange
        IWeapon fakeWeapon = new FakeWeapon();
        ITarget fakeTarget = new FakeTarget();

        Hero hero = new Hero(FakeHeroName, fakeWeapon);
        //Act
        hero.Attack(fakeTarget);
        //Assert
        Assert.AreEqual(hero.Experience, 10, "The hero does not gain XP after killing a target.");
    }

    [Test]
    public void HereGainsXPAfterAttackIfTargetDiesMocking()
    {
        //Arrange
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        fakeTarget.Setup(t => t.Health).Returns(0);
        fakeTarget.Setup(t => t.GiveExperience()).Returns(10);
        fakeTarget.Setup(t => t.IsDead()).Returns(true);

        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        Hero hero = new Hero(FakeHeroName, fakeWeapon.Object);

        //Act
        hero.Attack(fakeTarget.Object);

        //Assert
        Assert.AreEqual(hero.Experience, 10);
    }
}