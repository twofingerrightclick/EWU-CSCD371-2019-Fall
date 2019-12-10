using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass]
    public class ShoppingListMainWindowViewModelTests
    {

        [TestMethod]
        public void AddItemCommand_Executes_Adding_New_Shopping_Item()
        {
            
            List<string> itemsToAdd = new List<string>() { "apple", "orange", "ananas" };
           
            var viewModel = new ShoppingListMainWindowViewModel();


            for (int i=0; i<itemsToAdd.Count; i++)
            {
                viewModel.NewEntryText = itemsToAdd[i];
             

                viewModel.AddItemCommand.Execute(null);
            }



            for (int i = 0; i < itemsToAdd.Count; i++)
            {
                Assert.AreEqual<string>(viewModel.ShoppingListItems[i].Name, itemsToAdd[i]);
            }
           
        }





        [TestMethod]
        public void DeleteItemCommand_Executes_Deleting_SelectedItem_From_ShoppingListItems_And_Sets_SelectedItem_To_Null()
        {
            var shoppingItemtoDelete = new ShoppingItem() { Name = "Apple" };

            

            var viewModel = new ShoppingListMainWindowViewModel();

            viewModel.ShoppingListItems.Add(shoppingItemtoDelete);

            viewModel.SelectedShoppingItem = viewModel.ShoppingListItems[0];

            viewModel.DeleteItemCommand.Execute(null);



           CollectionAssert.DoesNotContain(viewModel.ShoppingListItems, shoppingItemtoDelete);
            Assert.IsTrue(viewModel.SelectedShoppingItem == null);
            

        }



    }
}
