using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private int attack = 10;
    private int durability = 2;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(attack, durability);
        dummy = new Dummy(40, 5);
    }

    [Test]
    public void When_AxeAttackAndDurabilityProvided_ShoudBeSetCorrectly()
    {

        Assert.AreEqual(axe.AttackPoints, attack);
        Assert.AreEqual(axe.DurabilityPoints, durability);
    }

    [Test]
    public void When_AxeAttacks_ShoudLooseDurabilityPoints()
    {
        axe.Attack(dummy);
        Assert.AreEqual( durability-1, axe.DurabilityPoints);
    }

    [Test]

    public void When_AttackWitBrokenAxe_ShouldThrowExeption()
    {
        axe.Attack(dummy);
        axe.Attack(dummy);

        Assert.That(() => axe.Attack(dummy),
            Throws.InvalidOperationException.With
            .Message.EqualTo("Axe is broken."));
    }
}