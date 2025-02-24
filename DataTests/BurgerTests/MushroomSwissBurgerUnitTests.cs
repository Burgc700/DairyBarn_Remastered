using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.DataTests
{
    /// <summary>
    /// The unit tests for the MushroomSwissBurger class.
    /// </summary>
    public class MushroomSwissBurgerUnitTests
    {
        /// <summary>
        /// Tests the default patties on this burger.
        /// </summary>
        [Fact]
        public void DefaultPattiesTest()
        {
            MushroomSwissBurger b = new();

            Assert.Equal(1u, b.Patties);
        }

        /// <summary>
        /// Tests the default cheese on this burger.
        /// </summary>
        [Fact]
        public void DefaultCheeseTest()
        {
            MushroomSwissBurger b = new();

            Assert.Equal(Cheese.Swiss, b.CheeseChoice);
        }

        /// <summary>
        /// Tests that these are the included toppings for this burger.
        /// </summary>
        [Fact]
        public void IncludedToppingsTest()
        {
            MushroomSwissBurger b = new();

            Assert.True(b.AllToppings[BurgerTopping.GrilledOnions].Included);
            Assert.True(b.AllToppings[BurgerTopping.GrilledMushrooms].Included);
        }

        /// <summary>
        /// Tests the number of toppings allowed on this burger.
        /// </summary>
        [Fact]
        public void AllToppingsIs2Test()
        {
            MushroomSwissBurger b = new();

            Assert.Equal(2, b.AllToppings.Count);
        }

        /// <summary>
        /// Tests to make sure veggie is set to false.
        /// </summary>
        [Fact]
        public void DefaultVeggieTest()
        {
            MushroomSwissBurger b = new();

            Assert.False(b.Veggie);
        }

        /// <summary>
        /// Tests the default price is 6.99.
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            MushroomSwissBurger b = new();

            Assert.Equal(6.99m, b.Price);
        }

        /// <summary>
        /// Tests the default calories is 695.
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            MushroomSwissBurger b = new();

            Assert.Equal(695u, b.Calories);
        }

        /// <summary>
        /// Checks different ingredients allowed and makes sure the price is right.
        /// </summary>
        /// <param name="grilledOnions">If grilled onions are on this burger.</param>am>
        /// <param name="grilledMushrooms">If grilled mushrooms are on this burger.</param>
        /// <param name="veggie">If this burger has veggie patties.</param>
        /// <param name="patties">The number of patties on this burger.</param>
        /// <param name="cheese">The type of cheese on this burger.</param>
        /// <param name="expected">The expected price for this burger.</param>
        [Theory]
        [InlineData(true, true, false, 1, Cheese.Swiss, 6.99)]
        [InlineData(true, true, false, 2, Cheese.Swiss, 6.99 + 2.00)]
        [InlineData(true, false, false, 1, Cheese.Swiss, 6.99)]
        [InlineData(false, true, false, 1, Cheese.Swiss, 6.99)]
        [InlineData(false, false, false, 2, Cheese.None, 6.99 + 2.00)]
        [InlineData(true, true, true, 2, Cheese.None, 6.99 + 2.00)]
        [InlineData(true, true, true, 1, Cheese.Swiss, 6.99)]
        [InlineData(true, true, false, 1, Cheese.None, 6.99)]
        public void PriceCheckingForDifferentIngredientTest(bool grilledOnions, bool grilledMushrooms, bool veggie, uint patties, Cheese cheese, decimal expected)
        {
            MushroomSwissBurger b = new();

            b.AllToppings[BurgerTopping.GrilledMushrooms].Included = grilledMushrooms;
            b.AllToppings[BurgerTopping.GrilledOnions].Included = grilledOnions;
            b.Patties = patties;
            b.Veggie = veggie;
            b.CheeseChoice = cheese;

            Assert.Equal(expected, b.Price);
        }

        /// <summary>
        /// Checks different ingredients allowed and makes sure the calories is right.
        /// </summary>
        /// <param name="grilledOnions">If grilled onions are on this burger.</param>am>
        /// <param name="grilledMushrooms">If grilled mushrooms are on this burger.</param>
        /// <param name="veggie">If this burger has veggie patties.</param>
        /// <param name="patties">The number of patties on this burger.</param>
        /// <param name="cheese">The type of cheese on this burger.</param>
        /// <param name="expected">The expected calories for this burger.</param>
        [Theory]
        [InlineData(true, true, false, 1, Cheese.Swiss, 150 + 50 + 60 + 85 + 350)]
        [InlineData(true, true, false, 2, Cheese.Swiss, 150 + 50 + 60 + (2*85) + (2*350))]
        [InlineData(true, false, false, 1, Cheese.Swiss, 150 + 50 + 85 + 350)]
        [InlineData(false, true, false, 1, Cheese.Swiss, 150 + 60 + 85 + 350)]
        [InlineData(false, false, false, 2, Cheese.None, 150 + (2*350))]
        [InlineData(true, true, true, 2, Cheese.None, 150 + 50 + 60 + (2*250))]
        [InlineData(true, true, true, 1, Cheese.Swiss, 150 + 50 + 60 + 85 + 250)]
        [InlineData(true, true, false, 1, Cheese.None, 150 + 50 + 60 + 350)]
        public void CaloriesCheckingForDifferentIngredientTest(bool grilledOnions, bool grilledMushrooms, bool veggie, uint patties, Cheese cheese, uint expected)
        {
            MushroomSwissBurger b = new();

            b.AllToppings[BurgerTopping.GrilledMushrooms].Included = grilledMushrooms;
            b.AllToppings[BurgerTopping.GrilledOnions].Included = grilledOnions;
            b.Patties = patties;
            b.Veggie = veggie;
            b.CheeseChoice = cheese;

            Assert.Equal(expected, b.Calories);
        }

        /// <summary>
        /// Checks different ingredients allowed and makes sure the preparation information is right.
        /// </summary>
        /// <param name="grilledOnions">If grilled onions are on this burger.</param>am>
        /// <param name="grilledMushrooms">If grilled mushrooms are on this burger.</param>
        /// <param name="veggie">If this burger has veggie patties.</param>
        /// <param name="patties">The number of patties on this burger.</param>
        /// <param name="cheese">The type of cheese on this burger.</param>
        /// <param name="expected">The expected information for this burger.</param>
        [Theory]
        [InlineData(true, true, false, 1, Cheese.Swiss, new string[] { })]
        [InlineData(true, true, false, 2, Cheese.Swiss, new string[] { "Double"})]
        [InlineData(true, false, false, 1, Cheese.Swiss, new string[] { "Hold Grilled Mushrooms"})]
        [InlineData(false, true, false, 1, Cheese.Swiss, new string[] { "Hold Grilled Onions" })]
        [InlineData(false, false, false, 2, Cheese.None, new string[] { "Hold Grilled Onions", "Hold Grilled Mushrooms", "Double", "Hold Swiss Cheese"})]
        [InlineData(true, true, true, 2, Cheese.None, new string[] { "Double", "Add Veggie Patties", "Hold Swiss Cheese"})]
        [InlineData(false, false, true, 1, Cheese.Swiss, new string[] { "Hold Grilled Onions", "Hold Grilled Mushrooms", "Add Veggie Patties"})]
        [InlineData(true, true, false, 1, Cheese.None, new string[] { "Hold Swiss Cheese"})]
        public void PrepInfoCheckingForDifferentIngredientTest(bool grilledOnions, bool grilledMushrooms, bool veggie, uint patties, Cheese cheese, string[] expected)
        {
            MushroomSwissBurger b = new();

            b.AllToppings[BurgerTopping.GrilledMushrooms].Included = grilledMushrooms;
            b.AllToppings[BurgerTopping.GrilledOnions].Included = grilledOnions;
            b.Patties = patties;
            b.Veggie = veggie;
            b.CheeseChoice = cheese;

            foreach(string info in expected)
            {
                Assert.Contains(info, b.PreparationInformation);
            }

            Assert.Equal(expected.Length, b.PreparationInformation.Count());
        }

        /// <summary>
        /// Checks the bounds for patties allowed on this burger.
        /// </summary>
        /// <param name="patties">The number of patties we are trying to put on the burger.</param>
        /// <param name="expected">The actual number we expect.</param>
        [Theory]
        [InlineData(4, 1)]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 1)]
        [InlineData(50, 1)]
        public void CheckBoundsOnPatties(uint patties, uint expected)
        {
            MushroomSwissBurger b = new() { Patties = patties };

            Assert.Equal(expected, b.Patties);
        }

        /// <summary>
        /// Tests the bounds of cheese allowed on this burger.
        /// </summary>
        /// <param name="cheese">The type of cheese are trying to put on this burger.</param>
        /// <param name="expected">The cheese we expect to be on this burger.</param>
        [Theory]
        [InlineData(Cheese.Swiss, Cheese.Swiss)]
        [InlineData(Cheese.None, Cheese.None)]
        [InlineData(Cheese.Cheddar, Cheese.Swiss)]
        public void CheckBoundsOnCheese(Cheese cheese, Cheese expected)
        {
            MushroomSwissBurger b = new();

            b.CheeseChoice = cheese;

            Assert.Equal(expected, b.CheeseChoice);
        }

        /// <summary>
        /// Tests if this burger is an IMenuItem and a Burger
        /// </summary>
        [Fact]
        public void IsAnIMenuItem()
        {
            MushroomSwissBurger b = new();

            Assert.IsAssignableFrom<IMenuItem>(b);
            Assert.IsAssignableFrom<Burger>(b);
        }
    }
}
