using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault valut;
        private Item item;
        [SetUp]
        public void Setup()
        {
            valut = new BankVault();
            item = new Item("A1", "4");
        }

        [Test]
        public void AddItem_ShouldThrowExceptionIfNotContainsKey()
        {

            Assert.Throws<ArgumentException>(() => valut.AddItem("D1",item));

        }

        [Test]
        public void AddItem_ShouldThrowExceptionIfValueIsNotNull()
        {
            valut.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => valut.AddItem("A1", new Item("Pesho", "123")));

        }

        [Test]
        public void AddItem_ShouldThrowExceptionIfCellExist()
        {
            valut.AddItem("A1",item);
            Assert.Throws<InvalidOperationException>(() => valut.AddItem("B1", item));

        }


        [Test]
        public void AddItem_ShouldRetturnMessageIfAddItemCorrectly()
        {

            string message = valut.AddItem("A1", item);
            Assert.AreEqual(message, $"Item:{item.ItemId} saved successfully!");

        }

        [Test]
        public void AddItem_ShouldSetItemToCellCorrectrly()
        {

            string message = valut.AddItem("A1", item);

            Assert.AreEqual(item, this.valut.VaultCells["A1"]);

        }

        [Test]
        public void Remove_ShouldReturn()
        {
           
            Assert.Throws<ArgumentException>(() => valut.RemoveItem("D1", new Item("Pesho", "de123")));

        }

        [Test]
        public void Remove_ShouldThrowExceptionIfItemInCellDoesNotExist()
        {

            Assert.Throws<ArgumentException>(() => valut.RemoveItem("A1", new Item("Pesho", "de123")));

        }

        [Test]
        public void Remove_ShouldRetturnMessageIfRemoveItemCorrectly()
        {

            valut.AddItem("A1",item);
            string message = valut.RemoveItem("A1", item);
            Assert.AreEqual(message, $"Remove item:{item.ItemId} successfully!");

        }

        [Test]
        public void Remove_WhenItemIsRemoved_ShouldMakeCellNull()
        {

            valut.AddItem("A1", item);
            string message = valut.RemoveItem("A1", item);
            Assert.AreEqual(null, this.valut.VaultCells["A1"]);

        }
    }
}