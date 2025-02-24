using System.ComponentModel;
using System.Xml.Serialization;

namespace DairyBarn.DataTests
{
    /// <summary>
    /// The unit tests for the BBQBaconCheeseburger class.
    /// </summary>
    public class BBQBaconCheeseburgerUnitTests
    {
        /// <summary>
        /// Tests to make sure the number of default patties is 1.
        /// </summary>
        [Fact]
        public void DefaultPattiesTest()
        {
            BBQBaconCheeseburger b = new();

            Assert.Equal(1u, b.Patties);
        }

        /// <summary>
        /// Test to make sure the number of default cheese slices is Cheddar.
        /// </summary>
        [Fact]
        public void DefaultCheeseTest()
        {
            BBQBaconCheeseburger b = new();

            Assert.Equal(Cheese.Cheddar, b.CheeseChoice);
        }

        /// <summary>
        /// Tests to make sure all the toppings allowed on the burger are in the dicitonary.
        /// </summary>
        [Fact]
        public void IncludedToppingsTest()
        {
            BBQBaconCheeseburger b = new();

            Assert.True(b.AllToppings[BurgerTopping.BBQSauce].Included);
            Assert.True(b.AllToppings[BurgerTopping.Bacon].Included);
            Assert.True(b.AllToppings[BurgerTopping.CrispyFriedOnions].Included);
        }

        /// <summary>
        /// Tests to make sure all the toppings is the same count as what is in the dictionary for that burger.
        /// </summary>
        [Fact]
        public void AllToppingsIs3Test()
        {
            BBQBaconCheeseburger b = new();

            Assert.Equal(3, b.AllToppings.Count);
        }

        /// <summary>
        /// Tests that the default for a veggie patty is false.
        /// </summary>
        [Fact]
        public void DefaultVeggieTest()
        {
            BBQBaconCheeseburger b = new();

            Assert.False(b.Veggie);
        }

        /// <summary>
        /// Tests that the default price is 7.29.
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            BBQBaconCheeseburger b = new();

            Assert.Equal(7.29m, b.Price);
        }

        /// <summary>
        /// Tests that the default calories is 775.
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            BBQBaconCheeseburger b = new();

            Assert.Equal(775u, b.Calories);
        }

        /// <summary>
        /// Tests the price for different options avaliable for the burger.
        /// </summary>
        /// <param name="bbqSauce">If bbq sauce is on the burger.</param>
        /// <param name="bacon">If bacon is on the the burger.</param>
        /// <param name="crispyFriedOnions">If crispy fried onions is on the burger</param>
        /// <param name="veggie">If the burger has veggie patties.</param>
        /// <param name="patties">How many patties are on the burger.</param>
        /// <param name="cheese">How many cheese slices are on the burger.</param>
        /// <param name="expected">The expected value for the price.</param>
        [Theory]
        [InlineData(true, true, true, false, 1, Cheese.Cheddar, 7.29)]
        [InlineData(false, false, false, false, 1, Cheese.Cheddar, 7.29)] //Check to make sure it is default
        [InlineData(true, true, true, false, 2, Cheese.None, 7.29 + 2.00)]
        [InlineData(true, true, true, true, 1, Cheese.Cheddar, 7.29)]
        [InlineData(true, true, true, true, 2, Cheese.Cheddar, 7.29 + 2.00)]
        [InlineData(false, false, false, true, 1, Cheese.Cheddar, 7.29)]
        [InlineData(false, false, false, true, 2, Cheese.None, 7.29 + 2.00)]
        [InlineData(true, false, true, true, 1, Cheese.Cheddar, 7.29)]
        public void PriceCheckingForDifferentIngredientTest(bool bbqSauce, bool bacon, bool crispyFriedOnions, bool veggie, uint patties, Cheese cheese, decimal expected)
        {
            BBQBaconCheeseburger b = new();

            b.AllToppings[BurgerTopping.BBQSauce].Included = bbqSauce;
            b.AllToppings[BurgerTopping.Bacon].Included = bacon;
            b.AllToppings[BurgerTopping.CrispyFriedOnions].Included = crispyFriedOnions;
            b.Veggie = veggie;
            b.Patties = patties;
            b.CheeseChoice = cheese;

            Assert.Equal(expected, b.Price, 2);
        }

        /// <summary>
        /// Tests the calories for different options for this burger.
        /// </summary>
        /// <param name="bbqSauce">If bbq is on this burger.</param>
        /// <param name="bacon">If bacon is on this burger.</param>
        /// <param name="crispyFriedOnions">If crispy fried onions are on this burger.</param>
        /// <param name="veggie">If this burger has veggie patties.</param>
        /// <param name="patties">How many patties are on this burger.</param>
        /// <param name="cheese">The type cheese slices are on this burger.</param>
        /// <param name="expected">The expected value for calories.</param>
        [Theory]
        [InlineData(true, true, true, false, 1, Cheese.Cheddar, 150 + 40 + 75 + 70 + 90 + 350 )]
        [InlineData(false, false, false, false, 1, Cheese.Cheddar, 150 + 90 + 350)] 
        [InlineData(true, true, true, false, 2, Cheese.None, 150 + 40 + 75 + 70 + (2 * 350))]
        [InlineData(true, true, true, true, 1, Cheese.Cheddar, 150 + 40 + 75 + 70 + 90 + 250)]
        [InlineData(true, true, true, true, 2, Cheese.Cheddar, 150 + 40 + 75 + 70 + (2 * 90) + (2 * 250))]
        [InlineData(false, false, false, true, 1, Cheese.Cheddar, 150 + 250 + 90)]
        [InlineData(false, false, false, true, 2, Cheese.None, 150 + (2 * 250))]
        [InlineData(true, false, true, true, 1, Cheese.Cheddar, 150 + 40 + 70 + 250 + 90)]
        [InlineData(true, true, true, false, 1, Cheese.None, 150+40+75+70+350)] //picktwo test case
        public void CaloriesCheckingForDifferentIngredientTest(bool bbqSauce, bool bacon, bool crispyFriedOnions, bool veggie, uint patties, Cheese cheese, uint expected)
        {
            BBQBaconCheeseburger b = new();

            b.AllToppings[BurgerTopping.BBQSauce].Included = bbqSauce;
            b.AllToppings[BurgerTopping.Bacon].Included = bacon;
            b.AllToppings[BurgerTopping.CrispyFriedOnions].Included = crispyFriedOnions;
            b.Veggie = veggie;
            b.Patties = patties;
            b.CheeseChoice = cheese;

            Assert.Equal(expected, b.Calories);
        }

        /// <summary>
        /// Tests if the preparation information is correct for different options of this burger.
        /// </summary>
        /// <param name="bbqSauce">If bbq sauce is on this burger.</param>
        /// <param name="bacon">If bacon is on this burger.</param>
        /// <param name="crispyFriedOnions">If crispy fried onions is on this burger.</param>
        /// <param name="veggie">If the burger has veggie patties.</param>
        /// <param name="patties">How many patties are on this burger.</param>
        /// <param name="cheese">How many cheese slices are on this burger.</param>
        /// <param name="expected">The expected preparation information.</param>
        [Theory]
        [InlineData(true, true, true, false, 1, Cheese.Cheddar, new string[] { })]
        [InlineData(false, false, false, false, 1, Cheese.Cheddar, new string[] {"Hold BBQ Sauce", "Hold Bacon", "Hold Crispy Fried Onions"})]
        [InlineData(true, true, true, false, 2, Cheese.None, new string[] { "Double", "Hold Cheddar Cheese"})]
        [InlineData(true, true, true, true, 1, Cheese.Cheddar, new string[] { "Add Veggie Patties"})]
        [InlineData(true, true, true, true, 2, Cheese.Cheddar, new string[] { "Add Veggie Patties", "Double"})]
        [InlineData(false, false, false, true, 1, Cheese.Cheddar, new string[] { "Hold BBQ Sauce", "Hold Bacon", "Hold Crispy Fried Onions", "Add Veggie Patties"})]
        [InlineData(false, false, false, true, 2, Cheese.None, new string[] {"Hold BBQ Sauce", "Hold Bacon", "Hold Crispy Fried Onions", "Add Veggie Patties", "Double", "Hold Cheddar Cheese"})]
        [InlineData(true, false, true, true, 1, Cheese.Cheddar, new string[] { "Hold Bacon", "Add Veggie Patties"})]
        public void PrepInfoCheckDifferentOptionsTest(bool bbqSauce, bool bacon, bool crispyFriedOnions, bool veggie, uint patties, Cheese cheese, string[] expected)
        {
            BBQBaconCheeseburger b = new();

            b.AllToppings[BurgerTopping.BBQSauce].Included = bbqSauce;
            b.AllToppings[BurgerTopping.Bacon].Included = bacon;
            b.AllToppings[BurgerTopping.CrispyFriedOnions].Included = crispyFriedOnions;
            b.Veggie = veggie;
            b.Patties = patties;
            b.CheeseChoice = cheese;

            foreach (string info in expected)
            {
                Assert.Contains(info, b.PreparationInformation);
            }

            Assert.Equal(expected.Length, b.PreparationInformation.Count());
        }

        /// <summary>
        /// Checks the bound cases for the number of patties on a burger.
        /// </summary>
        /// <param name="patties">The number of patties.</param>
        /// <param name="expected">The expected number of patties.</param>
        [Theory]
        [InlineData(4, 1)]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 1)]
        [InlineData(50, 1)]
        public void CheckBoundsOnPatties(uint patties, uint expected)
        {
            BBQBaconCheeseburger b = new() { Patties = patties };

            Assert.Equal(expected, b.Patties);
        }

        /// <summary>
        /// Checks the bounds for numbers of cheese slices on the burger.
        /// </summary>
        /// <param name="cheese">The number of cheese slices.</param>
        /// <param name="expected">The expected number of cheese slices.</param>
        [Theory]
        [InlineData(Cheese.Cheddar, Cheese.Cheddar)]
        [InlineData(Cheese.None, Cheese.None)]
        [InlineData(Cheese.American, Cheese.Cheddar)]
        public void CheckBoundsOnCheese(Cheese cheese, Cheese expected)
        {
            BBQBaconCheeseburger b = new();

            b.CheeseChoice = cheese;

            Assert.Equal(expected, b.CheeseChoice);
        }

        /// <summary>
        /// Tests to make sure this burger is part of IMenuItem.
        /// </summary>
        [Fact]
        public void IsAnIMenuItem()
        {
            BBQBaconCheeseburger b = new();

            Assert.IsAssignableFrom<IMenuItem>(b);
            Assert.IsAssignableFrom<Burger>(b);
        }
    }
}