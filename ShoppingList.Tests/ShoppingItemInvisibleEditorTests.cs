using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ShoppingList.Tests
{
    [TestClass]
    public class ShoppingItemInvisibleEditorTests
    {
        [TestMethod]
        public void Selected_Shopping_Item_Returns_Visible()
        {
            ShoppingItem item = new ShoppingItem();

            var converter = new ShoppingItemInvisibleConverter();
            string visibility = (string)converter.Convert(item);

            Assert.AreEqual<string>("Visible", visibility);
        }

        [TestMethod]
        public void Convert_Null_Hidden()
        {
            ShoppingItem item = null;

            var converter = new ShoppingItemInvisibleConverter();
            string? visibility = (string)converter.Convert(item);

            Assert.AreEqual<string>("Hidden", visibility);
        }

     
    }
}