using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.DataTests
{
    /// <summary>
    /// Tests specific test.
    /// </summary>
    public class SpecificRequiredTests
    {
        /// <summary>
        /// Test the case of a classic cheeseburger with 3 patties, bacon, and no mustard.
        /// </summary>
        [Fact]
        public void TestClassicBurgerWithBaconNoMustardPriceTest()
        {
            ClassicCheeseburger b = new();

            b.Patties = 3;
            b.AllToppings[BurgerTopping.Bacon].Included = true;
            b.AllToppings[BurgerTopping.Mustard].Included = false;
            string[] prep = new string[] { "Triple", "Add Bacon", "Hold Mustard" };

            Assert.Equal(1545u, b.Calories);
            Assert.Equal(11.29m, b.Price);
            foreach(string info in b.PreparationInformation)
            {
                Assert.Contains(info, b.PreparationInformation);
            }

            Assert.Equal(prep.Length, b.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests the base of a BYOBurger with one veggie patty cheddar cheese, bbq sauce, crispy fried onions, and lettuce.
        /// </summary>
        [Fact]
        public void TestBYOBurgerWithOneVeggiePattieCheddarCheeseBBQSauceCrispyFriedOnionsAndLettuce()
        {
            BYOBurger b = new();

            b.Veggie = true;
            b.Patties = 1;
            b.CheeseChoice = Cheese.Cheddar;
            b.AllToppings[BurgerTopping.BBQSauce].Included = true;
            b.AllToppings[BurgerTopping.CrispyFriedOnions].Included = true;
            b.AllToppings[BurgerTopping.Lettuce].Included = true;
            string[] prep = new string[] { "Add Veggie Patties ", "Add Cheddar Cheese", "Add BBQ Sauce", "Add Crispy Fried Onions", "Add Lettuce" };

            Assert.Equal(605u, b.Calories);
            Assert.Equal(7.29m, b.Price);
            foreach(string info in b.PreparationInformation)
            {
                Assert.Contains(info, b.PreparationInformation);
            }

            Assert.Equal(prep.Length, b.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests a Grande decaf iced coffee with cream and sugar.
        /// </summary>
        [Fact]
        public void TestGrandeIcedCoffeeWithCreamAndSugar()
        {
            Coffee d = new();

            d.SizeOfCup = CoffeeSize.Grande;
            d.Decaf = true;
            d.Iced = true;
            d.Cream = true;
            d.Sugar = true;
            string[] prep = new string[] { "Decaf", "Iced", "Grade", "Add Sugar", "Add Cream" };

            Assert.Equal(89u, d.Calories);
            Assert.Equal(3.24m, d.Price);
            foreach(string info in d.PreparationInformation)
            {
                Assert.Contains(info, d.PreparationInformation);
            }

            Assert.Equal(prep.Length, d.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests a classic sundae case with strawberry sauce, 3 scoops of ice cream, whipped cream, and a cherry.
        /// </summary>
        [Fact]
        public void TestClassicSundaeWithStrawberrySauce3ScoopsWhippedCreamCherry()
        {
            ClassicSundae s = new();

            s.SauceChoice = IceCreamSauce.StrawberrySauce;
            s.Scoops = 3;
            s.WhippedCream = true;
            s.Cherry = true;
            string[] prep = new string[] { "3 Scoops", "Add Strawberry Sauce", "Add Whipped Cream", "Add Cherry" };

            Assert.Equal(790u, s.Calories);
            Assert.Equal(5.99m, s.Price);
            foreach(string info in s.PreparationInformation)
            {
                Assert.Contains(info, s.PreparationInformation);
            }
            Assert.Equal(prep.Length, s.PreparationInformation.Count());
        }

        /// <summary>
        /// Case of Ice cream cone with 1 scoop in a waffle cone and dipped.
        /// </summary>
        [Fact]
        public void IceCreamCone1ScoopDippedWaffleCone()
        {
            IceCreamCone c = new();

            c.Scoops = 1;
            c.Dipped = true;
            c.TypeOfCone = Cone.Waffle;
            string[] prep = new string[] { "Dipped", "Waffle Cone" };

            Assert.Equal(450u, c.Calories);
            Assert.Equal(3.99m, c.Price);
            foreach(string info in c.PreparationInformation)
            {
                Assert.Contains(info, c.PreparationInformation);
            }

            Assert.Equal(2, c.PreparationInformation.Count());
        }

        /// <summary>
        /// Case of a pick two with a BBQ Bacon CheeseBurger, and winter swirl.
        /// </summary>
        [Fact]
        public void PickTwoWithBBQBaconCheeseBurgerAndWinterSwirl()
        {
            PickTwo two = new();

            two.BurgerChoice = new BBQBaconCheeseburger() { CheeseChoice = Cheese.None };
            two.IceCreamChoice = new WinterSwirl() { SauceChoice = IceCreamSauce.Caramel, MixInChoice = IceCreamMixIn.CookieDough };
            string[] prep = new string[] { "Burger: BBQ Bacon Cheeseburger", "\tHold Cheddar Cheese", "Ice Cream: Winter Swirl", "\tCaramel", "\tCookie Dough" };

            Assert.Equal(1345u, two.Calories);
            Assert.Equal(9.21m, two.Price);
            
            foreach(string info in two.PreparationInformation)
            {
                Assert.Contains(info, two.PreparationInformation);
            }
            
            Assert.Equal(5, two.PreparationInformation.Count());
            
        }
    }
}
