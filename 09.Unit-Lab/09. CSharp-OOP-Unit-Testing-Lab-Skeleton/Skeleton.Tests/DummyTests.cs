using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private int health = 20;
    private int experience = 5;
    private int attack = 10;
    private int durability = 10;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void StarUp()
    {
        axe = new Axe(attack, durability);
        dummy = new Dummy(health, experience);
    }

    [Test]
    public void When_DummyAttacked_ShouldLosesHeath()
    {
        //dummy.TakeAttack(10);
        //Assert.AreEqual(health - 10, dummy.Health);

        axe.Attack(dummy);
        Assert.That(dummy.Health, Is.EqualTo(10));
    }

    [Test]
    public void When_DummyIsDead_ShouldThrowsExceptionIfAttacked()
    {
        axe.Attack(dummy);
        axe.Attack(dummy);

        Assert.That(() => axe.Attack(dummy), 
            Throws.InvalidOperationException
            .With.Message
            .EqualTo ("Dummy is dead."));
    }

    [Test]

    public void When_DummyIsDead_ShouldCanGiveXP()
    {
        axe.Attack(dummy);
        axe.Attack(dummy);

        Assert.That(dummy.GiveExperience(), Is.EqualTo(5));
    }

    [Test]

    public void When_DummyIsAlive_ShouldCanNotGiveXP()
    {
        Assert.That(() => dummy.GiveExperience(),
        Throws.InvalidOperationException
        .With.Message
        .EqualTo("Target is not dead."));
    }
}
