using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.DataTests
{
    /// <summary>
    /// The unit tests for the VeggieBurger class.
    /// </summary>
    public class VeggieBurgerUnitTests
    {
        /// <summary>
        /// Tests the defualt patties for this burger.
        /// </summary>
        [Fact]
        public void DefaultPattiesTest()
        {
            VeggieBurger b = new();

            Assert.Equal(1u, b.Patties);
        }

        /// <summary>
        /// Tests the defualt cheese for this burger.
        /// </summary>
        [Fact]
        public void DefaultCheeseTest()
        {
            VeggieBurger b = new();

            Assert.Equal(Cheese.PepperJack, b.CheeseChoice);
        }

        /// <summary>
        /// Tests the toppings that are included are included on this burger.
        /// </summary>
        [Fact]
        public void IncludedToppingsTest()
        {
            VeggieBurger b = new();

            Assert.True(b.AllToppings[BurgerTopping.ChipotleMayo].Included);
            Assert.True(b.AllToppings[BurgerTopping.Lettuce].Included);
            Assert.True(b.AllToppings[BurgerTopping.Tomato].Included);
        }

        /// <summary>
        /// Tests that the max number of toppings on this burger is 5.
        /// </summary>
        [Fact]
        public void AllToppingsIs5Test()
        {
            VeggieBurger b = new();

            Assert.Equal(5, b.AllToppings.Count);
        }

        /// <summary>
        /// Tests to make sure veggie is set to true.
        /// </summary>
        [Fact]
        public void DefaultVeggiesTest()
        {
            VeggieBurger b = new();

            Assert.True(b.Veggie);
        }

        /// <summary>
        /// Makes sure the default price is 6.99.
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            VeggieBurger b = new();

            Assert.Equal(6.99m, b.Price);
        }

        /// <summary>
        /// Makes sure the default calories are 585.
        /// </summary>
        [Fact]
        public void DefualtCaloriesTest()
        {
            VeggieBurger b = new();

            Assert.Equal(585u, b.Calories);
        }

        /// <summary>
        /// Tests different options to make sure the price is right.
        /// </summary>
        /// <param name="chipotleMayo">If chipotle mayo is on this burger.</param>
        /// <param name="lettuce">If lettuce is on this burger.</param>
        /// <param name="tomato">If tomato is on this burger.</param>
        /// <param name="pickles">If pickles are on this burger.</param>
        /// <param name="onions">If onions are on this burger.</param>
        /// <param name="veggie">If the patties are veggie.</param>
        /// <param name="patties">The number of patties.</param>
        /// <param name="cheese">The type of cheese.</param>
        /// <param name="expected">The expected price.</param>
        [Theory]
        [InlineData(true, true, true, false, false, true, 1, Cheese.PepperJack, 6.99)]
        [InlineData(true, true, true, false, false, true, 2 , Cheese.PepperJack, 6.99 + 2.00)]
        [InlineData(true, true, true, true, true, true, 1 , Cheese.None, 6.99)]
        [InlineData(true, true, true, true, true, true, 2, Cheese.PepperJack, 6.99 + 2.00)]
        [InlineData(false, false, false, true, true, true, 1, Cheese.PepperJack, 6.99)]
        [InlineData(false, false, false, true, true, true, 2, Cheese.PepperJack, 6.99 + 2.00)]
        [InlineData(true, true, true, false, false, false, 1, Cheese.None, 6.99)]
        [InlineData(false, false, false, true, true, false, 2, Cheese.PepperJack, 6.99 + 2.00)]
        public void PriceCheckingForDifferentIngredientTest(bool chipotleMayo, bool lettuce, bool tomato, bool pickles, bool onions, bool veggie, uint patties, Cheese cheese, decimal expected)
        {
            VeggieBurger b = new();

            b.AllToppings[BurgerTopping.ChipotleMayo].Included = chipotleMayo;
            b.AllToppings[BurgerTopping.Lettuce].Included = lettuce;
            b.AllToppings[BurgerTopping.Tomato].Included = tomato;
            b.AllToppings[BurgerTopping.Pickles].Included = pickles;
            b.AllToppings[BurgerTopping.Onions].Included = onions;
            b.Patties = patties;
            b.Veggie = veggie;
            b.CheeseChoice = cheese;

            Assert.Equal(expected, b.Price);
        }

        /// <summary>
        /// Tests different options to make sure the calories is right.
        /// </summary>
        /// <param name="chipotleMayo">If chipotle mayo is on this burger.</param>
        /// <param name="lettuce">If lettuce is on this burger.</param>
        /// <param name="tomato">If tomato is on this burger.</param>
        /// <param name="pickles">If pickles are on this burger.</param>
        /// <param name="onions">If onions are on this burger.</param>
        /// <param name="veggie">If the patties are veggie.</param>
        /// <param name="patties">The number of patties.</param>
        /// <param name="cheese">The type of cheese.</param>
        /// <param name="expected">The expected calories.</param>
        [Theory]
        [InlineData(true, true, true, false, false, true, 1, Cheese.PepperJack, 150 + 90 + 5 + 5 + 85 + 250)]
        [InlineData(true, true, true, false, false, true, 2, Cheese.PepperJack, 150 + 90 + 5 + 5 + (2*85) + (2*250))]
        [InlineData(true, true, true, true, true, true, 1, Cheese.None, 150 + 90 + 5 + 5 + 5 + 5 + 250)]
        [InlineData(true, true, true, true, true, true, 2, Cheese.PepperJack, 150 + 90 + 5 + 5 + 5 + 5 + (2*85) + (2*250))]
        [InlineData(false, false, false, true, true, true, 1, Cheese.PepperJack, 150 + 5 + 5 + 85 + 250)]
        [InlineData(false, false, false, true, true, true, 2, Cheese.PepperJack, 150 + 5 + 5 + (2*85) + (2*250))]
        [InlineData(true, true, true, false, false, false, 1, Cheese.None, 150 + 90 + 5 + 5 + 250)]
        [InlineData(false, false, false, true, true, false, 2, Cheese.PepperJack, 150 + 5 + 5 + (2*85) + (2*250))]
        public void CaloriesCheckingForDifferentIngredientTest(bool chipotleMayo, bool lettuce, bool tomato, bool pickles, bool onions, bool veggie, uint patties, Cheese cheese, uint expected)
        {
            VeggieBurger b = new();

            b.AllToppings[BurgerTopping.ChipotleMayo].Included = chipotleMayo;
            b.AllToppings[BurgerTopping.Lettuce].Included = lettuce;
            b.AllToppings[BurgerTopping.Tomato].Included = tomato;
            b.AllToppings[BurgerTopping.Pickles].Included = pickles;
            b.AllToppings[BurgerTopping.Onions].Included = onions;
            b.Patties = patties;
            b.Veggie = veggie;
            b.CheeseChoice = cheese;

            Assert.Equal(expected, b.Calories);
        }

        /// <summary>
        /// Tests different options to make sure the preparation information is right.
        /// </summary>
        /// <param name="chipotleMayo">If chipotle mayo is on this burger.</param>
        /// <param name="lettuce">If lettuce is on this burger.</param>
        /// <param name="tomato">If tomato is on this burger.</param>
        /// <param name="pickles">If pickles are on this burger.</param>
        /// <param name="onions">If onions are on this burger.</param>
        /// <param name="veggie">If the patties are veggie.</param>
        /// <param name="patties">The number of patties.</param>
        /// <param name="cheese">The type of cheese.</param>
        /// <param name="expected">The expected information.</param>
        [Theory]
        [InlineData(true, true, true, false, false, true, 1, Cheese.PepperJack, new string[] { })]
        [InlineData(true, true, true, false, false, true, 2, Cheese.PepperJack, new string[] { "Double"})]
        [InlineData(true, true, true, true, true, true, 1, Cheese.None, new string[] { "Add Pickles", "Add Onions", "Hold Pepper Jack Cheese"})]
        [InlineData(true, true, true, true, true, true, 2, Cheese.PepperJack, new string[] { "Add Pickles", "Add Onions", "Double"})]
        [InlineData(false, false, false, true, true, true, 1, Cheese.PepperJack, new string[] { "Hold Chipotle Mayo", "Hold Lettuce", "Hold Tomato", "Add Pickles", "Add Onions"})]
        [InlineData(false, false, false, true, true, true, 2, Cheese.PepperJack, new string[] { "Hold Chipotle Mayo", "Hold Lettuce", "Hold Tomato", "Add Pickles", "Add Onion", "Double"})]
        [InlineData(true, true, true, false, false, false, 1, Cheese.None, new string[] { "Hold Pepper Jack Cheese"})]
        [InlineData(false, false, false, true, true, false, 2, Cheese.PepperJack, new string[] { "Hold Chipotle Mayo", "Hold Lettuce", "Hold Tomato", "Add Pickles", "Add Onions", "Double"})]
        public void PrepInfoCheckingForDifferentIngredientTest(bool chipotleMayo, bool lettuce, bool tomato, bool pickles, bool onions, bool veggie, uint patties, Cheese cheese, string[] expected)
        {
            VeggieBurger b = new();

            b.AllToppings[BurgerTopping.ChipotleMayo].Included = chipotleMayo;
            b.AllToppings[BurgerTopping.Lettuce].Included = lettuce;
            b.AllToppings[BurgerTopping.Tomato].Included = tomato;
            b.AllToppings[BurgerTopping.Pickles].Included = pickles;
            b.AllToppings[BurgerTopping.Onions].Included = onions;
            b.Patties = patties;
            b.Veggie = veggie;
            b.CheeseChoice = cheese;

            foreach(string info in b.PreparationInformation)
            {
                Assert.Contains(info, b.PreparationInformation);
            }

            Assert.Equal(expected.Length, b.PreparationInformation.Count());
        }

        /// <summary>
        /// Checks the bounds on the number of patties.
        /// </summary>
        /// <param name="patties">The patties we are trying to add on this burger.</param>
        /// <param name="expected">What the actual number of patties should be.</param>
        [Theory]
        [InlineData(4, 1)]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 1)]
        [InlineData(50, 1)]
        public void CheckBoundsOnPatties(uint patties, uint expected)
        {
            VeggieBurger b = new() { Patties = patties };

            Assert.Equal(expected, b.Patties);
        }

        /// <summary>
        /// Checks the bounds for the type of cheese.
        /// </summary>
        /// <param name="cheese">The cheese we are trying to put on this burger.</param>
        /// <param name="expected">The expected value for the cheese.</param>
        [Theory]
        [InlineData(Cheese.PepperJack, Cheese.PepperJack)]
        [InlineData(Cheese.None, Cheese.None)]
        [InlineData(Cheese.Swiss, Cheese.PepperJack)]
        public void CheckBoundsOnCheese(Cheese cheese, Cheese expected)
        {
            VeggieBurger b = new();

            b.CheeseChoice = cheese;

            Assert.Equal(expected, b.CheeseChoice);
        }

        /// <summary>
        /// Tests to make sure this burger is part of IMenuItem and a Burger.
        /// </summary>
        [Fact]
        public void IsAnIMenuItem()
        {
            VeggieBurger b = new();

            Assert.IsAssignableFrom<IMenuItem>(b);
            Assert.IsAssignableFrom<Burger>(b);
        }
    }
}
