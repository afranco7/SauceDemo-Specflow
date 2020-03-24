using NUnit.Framework;
using SauceDemo_Specflow.DriverProvider;
using SauceDemo_Specflow.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SauceDemo_Specflow.Steps
{
    [Binding]
    class AddAndRemoveItemsFromCartSteps
    {
       
        static InventoryPage inventoryPage;
        static string itemName;

        [BeforeScenario]
        public static void TestInitialize()
        {            
            inventoryPage = new InventoryPage(DriverSetup.Driver);            
        }

        [When(@"I press add to cart button for (.*)")]
        public void WhenIPressAddToCartButtonFor(string item)
        {
            itemName = item;
            inventoryPage.ClickAddToCartButton(item);
        }

        [Then(@"the item is correctly added")]
        public void ThenTheItemIsCorrectlyAdded()
        {
            string expectedText = "REMOVE";
            Assert.AreEqual(expectedText, inventoryPage.CartButtonText(itemName));
        }

        [When(@"I press remove button for item added")]
        public void WhenIPressRemoveButtonForItemAdded()
        {
            inventoryPage.ClickAddToCartButton(itemName);
        }

        [Then(@"the items is correctly removed")]
        public void ThenTheItemsIsCorrectlyRemoved()
        {
            string expectedText = "ADD TO CART";
            Assert.AreEqual(expectedText, inventoryPage.CartButtonText(itemName));
        }

    }
}
