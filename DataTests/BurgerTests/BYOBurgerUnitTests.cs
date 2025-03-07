using DairyBarn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.DataTests
{
    /// <summary>
    /// The unit tests for the BYOBurger class.
    /// </summary>
    public class BYOBurgerUnitTests
    {
        /// <summary>
        /// Tests to make sure the number of default patties is 1.
        /// </summary>
        [Fact]
        public void DefaultPattiesTest()
        {
            BYOBurger b = new();

            Assert.Equal(1u, b.Patties);
        }

        /// <summary>
        /// Test to make sure the number of default cheese slices is American.
        /// </summary>
        [Fact]
        public void DefaultCheeseTest()
        {
            BYOBurger b = new();

            Assert.Equal(Cheese.American, b.CheeseChoice);
        }

        /// <summary>
        /// Tests to make sure all the toppings is the same count as what is in the dictionary for that burger.
        /// </summary>
        [Fact]
        public void AllToppingsIs12Test()
        {
            BYOBurger b = new();

            Assert.Equal(12, b.AllToppings.Count);
        }

        /// <summary>
        /// Tests that the default for a veggie patty is false.
        /// </summary>
        [Fact]
        public void DefaultVeggieTest()
        {
            BYOBurger b = new();

            Assert.False(b.Veggie);
        }

        /// <summary>
        /// Tests the default price is 6.29.
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            BYOBurger b = new();

            Assert.Equal(6.29m, b.Price);
        }

        /// <summary>
        /// Test the default calories is 580.
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            BYOBurger b = new();

            Assert.Equal(150u + 350u + 80u, b.Calories);
        }

        /// <summary>
        /// Tests to make sure different options of ingredients have the right price.
        /// </summary>
        /// <param name="ketchup">If the burger has ketchup.</param>
        /// <param name="mustard">If the burger has mustard.</param>
        /// <param name="onion">If the burger has onion.</param>
        /// <param name="pickles">If the burger has pickles.</param>
        /// <param name="lettuce">If the burger has lettuce.</param>
        /// <param name="bacon">If the burger has bacon.</param>
        /// <param name="tomato">If the burger has tomato.</param>
        /// <param name="grilledOnions">If the burger has grilled onions.</param>
        /// <param name="grilledMushrooms">If the burger has grilled mushrooms.</param>
        /// <param name="bbqSauce">If the burger has bbq sauce.</param>
        /// <param name="crispyFriedOnions">If the burger has crispy fried onions.</param>
        /// <param name="chipotleMayo">If the burger has chipotle mayo.</param>
        /// <param name="veggie">If the burger has veggie patties.</param>
        /// <param name="patties">The number of patties the burger has.</param>
        /// <param name="cheese">The type of cheese on the burger.</param>
        /// <param name="expected">The expected price of the burger.</param>
        [Theory]
        [InlineData(false, false, false, false, false, false, false, false, false, false, false, false, false, 1, Cheese.American, 6.29)]
        [InlineData(false, false, false, false, false, false, false, false, false, false, false, false, false, 2, Cheese.PepperJack, 6.29 + 2.00)]
        [InlineData(false, false, false, false, false, false, false, false, false, false, false, false, false, 3, Cheese.Cheddar, 6.29 + 4.00)]
        [InlineData(true, true, true, true, true, true, true, true, true, true, true, true, false, 1, Cheese.PepperJack, 6.29 + 1.50 + 3.00)]
        [InlineData(true, true, true, true, true, true, false, false, false, false,true, true, true, 2, Cheese.None, 6.29 + 1.25 + .75 + 2.00)]
        [InlineData(false, false, false, false, false, false, true, true, true, true, false, false, false, 3, Cheese.Swiss, 6.29 + 2.50 + 4.00)]
        [InlineData(true, false, true, false, true, false, true, false, true, false, true, false, true, 1, Cheese.American, 6.29 + 2.00)]
        [InlineData(false, true, false, true, false, true, false, true, false, true, false, true, false, 2, Cheese.Cheddar, 6.29 + 2.50 + 2.00)]
        public void PriceCheckingForDifferentIngredientTest(bool ketchup, bool mustard, bool onion, bool pickles, bool lettuce, bool bacon, bool tomato, bool grilledOnions, bool grilledMushrooms, bool bbqSauce, bool crispyFriedOnions, bool chipotleMayo, bool veggie, uint patties, Cheese cheese, decimal expected)
        {
            BYOBurger b = new();

            b.AllToppings[BurgerTopping.Ketchup].Included = ketchup;
            b.AllToppings[BurgerTopping.Mustard].Included = mustard;
            b.AllToppings[BurgerTopping.Onions].Included = onion;
            b.AllToppings[BurgerTopping.Pickles].Included = pickles;
            b.AllToppings[BurgerTopping.Bacon].Included = bacon;
            b.AllToppings[BurgerTopping.Lettuce].Included = lettuce;
            b.AllToppings[BurgerTopping.Tomato].Included = tomato;
            b.AllToppings[BurgerTopping.GrilledOnions].Included = grilledOnions;
            b.AllToppings[BurgerTopping.GrilledMushrooms].Included = grilledMushrooms;
            b.AllToppings[BurgerTopping.BBQSauce].Included = bbqSauce;
            b.AllToppings[BurgerTopping.CrispyFriedOnions].Included = crispyFriedOnions;
            b.AllToppings[BurgerTopping.ChipotleMayo].Included = chipotleMayo;
            b.Patties = patties;
            b.Veggie = veggie;
            b.CheeseChoice = cheese;


            Assert.Equal(expected, b.Price, 2);
        }

        /// <summary>
        /// Tests to make sure different options of ingredients have the right number of calories.
        /// </summary>
        /// <param name="ketchup">If the burger has ketchup.</param>
        /// <param name="mustard">If the burger has mustard.</param>
        /// <param name="onion">If the burger has onion.</param>
        /// <param name="pickles">If the burger has pickles.</param>
        /// <param name="lettuce">If the burger has lettuce.</param>
        /// <param name="bacon">If the burger has bacon.</param>
        /// <param name="tomato">If the burger has tomato.</param>
        /// <param name="grilledOnions">If the burger has grilled onions.</param>
        /// <param name="grilledMushrooms">If the burger has grilled mushrooms.</param>
        /// <param name="bbqSauce">If the burger has bbq sauce.</param>
        /// <param name="crispyFriedOnions">If the burger has crispy fried onions.</param>
        /// <param name="chipotleMayo">If the burger has chipotle mayo.</param>
        /// <param name="veggie">If the burger has veggie patties.</param>
        /// <param name="patties">The number of patties the burger has.</param>
        /// <param name="cheese">The type of cheese on the burger.</param>
        /// <param name="expected">The expected calories of the burger.</param>
        [Theory]
        [InlineData(false, false, false, false, false, false, false, false, false, false, false, false, false, 1, Cheese.American, 150 + 350 + 80)]
        [InlineData(false, false, false, false, false, false, false, false, false, false, false, false, false, 2, Cheese.PepperJack, 150 + (2*350) + (2*85))]
        [InlineData(false, false, false, false, false, false, false, false, false, false, false, false, false, 3, Cheese.Cheddar, 150 + (3*350) + (3*90))]
        [InlineData(true, true, true, true, true, true, true, true, true, true, true, true, false, 1, Cheese.PepperJack, 150 + 85 + 20 + 5 + 5 + 5 + 5 + 75 + 5 + 50 + 60 + 40 + 70 + 90 + 350)]
        [InlineData(true, true, true, true, true, true, false, false, false, false, true, true, true, 2, Cheese.None, 150+ 20 + 5 + 5 + 5 + 5 + 75 + 70 + 90 + (2*250))]
        [InlineData(false, false, false, false, false, false, true, true, true, true, false, false, false, 3, Cheese.Swiss, 150 + 5 + 50 + 60 + 40 + (3*350) + (3* 85))]
        [InlineData(true, false, true, false, true, false, true, false, true, false, true, false, false, 1, Cheese.American, 150 + 350 + 80 + 20 + 5 + 5 + 5 + 60 + 70)]
        [InlineData(false, true, false, true, false, true, false, true, false, true, false, true, true, 2, Cheese.Cheddar, 150 + (2*250) + (2*90) + 5 + 5 + 75 + 50 + 40 + 90)]
        public void CaloriesCheckingForDifferentIngredientTest(bool ketchup, bool mustard, bool onion, bool pickles, bool lettuce, bool bacon, bool tomato, bool grilledOnions, bool grilledMushrooms, bool bbqSauce, bool crispyFriedOnions, bool chipotleMayo, bool veggie, uint patties, Cheese cheese, uint expected)
        {
            BYOBurger b = new();

            b.AllToppings[BurgerTopping.Ketchup].Included = ketchup;
            b.AllToppings[BurgerTopping.Mustard].Included = mustard;
            b.AllToppings[BurgerTopping.Onions].Included = onion;
            b.AllToppings[BurgerTopping.Pickles].Included = pickles;
            b.AllToppings[BurgerTopping.Bacon].Included = bacon;
            b.AllToppings[BurgerTopping.Lettuce].Included = lettuce;
            b.AllToppings[BurgerTopping.Tomato].Included = tomato;
            b.AllToppings[BurgerTopping.GrilledOnions].Included = grilledOnions;
            b.AllToppings[BurgerTopping.GrilledMushrooms].Included = grilledMushrooms;
            b.AllToppings[BurgerTopping.BBQSauce].Included = bbqSauce;
            b.AllToppings[BurgerTopping.CrispyFriedOnions].Included = crispyFriedOnions;
            b.AllToppings[BurgerTopping.ChipotleMayo].Included = chipotleMayo;
            b.Patties = patties;
            b.Veggie = veggie;
            b.CheeseChoice = cheese;


            Assert.Equal(expected, b.Calories);
        }

        /// <summary>
        /// Tests to make sure different options of ingredients have the right preparation information.
        /// </summary>
        /// <param name="ketchup">If the burger has ketchup.</param>
        /// <param name="mustard">If the burger has mustard.</param>
        /// <param name="onion">If the burger has onion.</param>
        /// <param name="pickles">If the burger has pickles.</param>
        /// <param name="lettuce">If the burger has lettuce.</param>
        /// <param name="bacon">If the burger has bacon.</param>
        /// <param name="tomato">If the burger has tomato.</param>
        /// <param name="grilledOnions">If the burger has grilled onions.</param>
        /// <param name="grilledMushrooms">If the burger has grilled mushrooms.</param>
        /// <param name="bbqSauce">If the burger has bbq sauce.</param>
        /// <param name="crispyFriedOnions">If the burger has crispy fried onions.</param>
        /// <param name="chipotleMayo">If the burger has chipotle mayo.</param>
        /// <param name="veggie">If the burger has veggie patties.</param>
        /// <param name="patties">The number of patties the burger has.</param>
        /// <param name="cheese">The type of cheese on the burger.</param>
        /// <param name="expected">The expected information of the burger.</param>
        [Theory]
        [InlineData(false, false, false, false, false, false, false, false, false, false, false, false, false, 1, Cheese.American, new string[] { })]
        [InlineData(false, false, false, false, false, false, false, false, false, false, false, false, false, 2, Cheese.PepperJack, new string[] { "Add PepperJack Cheese", "Double"})]
        [InlineData(false, false, false, false, false, false, false, false, false, false, false, false, false, 3, Cheese.Cheddar, new string[] { "Add Cheddar Cheese", "Triple" })]
        [InlineData(true, true, true, true, true, true, true, true, true, true, true, true, false, 1, Cheese.PepperJack, new string[] { "Add Ketchup", "Add Mustard", "Add Onions", "Add Pickles", "Add Lettuce", "Add Bacon", "Add Tomato", "Add Grilled Onions", "Add Grilled Mushrooms", "Add BBQ Sauce", "Add Crispy Fried Onions", "Add Chipotle Mayo", "Add PepperJack Cheese" })]
        [InlineData(true, true, true, true, true, true, false, false, false, false, true, true, true, 2, Cheese.None, new string[] { "Add Ketchup", "Add Mustard", "Add Onions", "Add Pickles", "Add Lettuce", "Add Bacon", "Add Crispy Fried Onions", "Add Chipotle Mayo", "Add Veggie Patties", "Double", "Hold American Cheese" })]
        [InlineData(false, false, false, false, false, false, true, true, true, true, false, false, false, 3, Cheese.Swiss, new string[] { "Add Swiss Cheese", "Triple", "Add Tomato", "Add Grilled Onions", "Add Grilled Mushrooms", "Add BBQ Sauce" })]
        [InlineData(true, false, true, false, true, false, true, false, true, false, true, false, false, 1, Cheese.American, new string[] { "Add Ketchup", "Add Onions", "Add Lettuce", "Add Tomato", "Add Grilled Mushrooms", "Add Crispy Fried Onions" })]
        [InlineData(false, true, false, true, false, true, false, true, false, true, false, true, true, 2, Cheese.Cheddar, new string[] { "Add Mustard", "Add Pickles", "Add Bacon", "Add Grilled Onions", "Add BBQ Sauce", "Add Chipotle Mayo", "Add Veggie Patties", "Add Cheddar Cheese", "Double" })]
        public void PrepInfoCheckingForDifferentIngredientTest(bool ketchup, bool mustard, bool onion, bool pickles, bool lettuce, bool bacon, bool tomato, bool grilledOnions, bool grilledMushrooms, bool bbqSauce, bool crispyFriedOnions, bool chipotleMayo, bool veggie, uint patties, Cheese cheese, string[] expected)
        {
            BYOBurger b = new();

            b.AllToppings[BurgerTopping.Ketchup].Included = ketchup;
            b.AllToppings[BurgerTopping.Mustard].Included = mustard;
            b.AllToppings[BurgerTopping.Onions].Included = onion;
            b.AllToppings[BurgerTopping.Pickles].Included = pickles;
            b.AllToppings[BurgerTopping.Bacon].Included = bacon;
            b.AllToppings[BurgerTopping.Lettuce].Included = lettuce;
            b.AllToppings[BurgerTopping.Tomato].Included = tomato;
            b.AllToppings[BurgerTopping.GrilledOnions].Included = grilledOnions;
            b.AllToppings[BurgerTopping.GrilledMushrooms].Included = grilledMushrooms;
            b.AllToppings[BurgerTopping.BBQSauce].Included = bbqSauce;
            b.AllToppings[BurgerTopping.CrispyFriedOnions].Included = crispyFriedOnions;
            b.AllToppings[BurgerTopping.ChipotleMayo].Included = chipotleMayo;
            b.Patties = patties;
            b.Veggie = veggie;
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
        [InlineData(3, 3)]
        [InlineData(50, 1)]
        public void CheckBoundsOnPattiesTest(uint patties, uint expected)
        {
            BYOBurger b = new() { Patties = patties };

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
        [InlineData(Cheese.American, Cheese.American)]
        [InlineData(Cheese.PepperJack, Cheese.PepperJack)]
        [InlineData(Cheese.Swiss, Cheese.Swiss)]
        public void CheckBoundsOnCheeseTest(Cheese cheese, Cheese expected)
        {
            BYOBurger b = new();

            b.CheeseChoice = cheese;

            Assert.Equal(expected, b.CheeseChoice);
        }

        /// <summary>
        /// Tests to make sure this burger is part of IMenuItem.
        /// </summary>
        [Fact]
        public void IsAnIMenuItemTest()
        {
            BYOBurger b = new();

            Assert.IsAssignableFrom<IMenuItem>(b);
            Assert.IsAssignableFrom<Burger>(b);
        }

        /// <summary>
        /// Tests to make sure that the right name is returned.
        /// </summary>
        [Fact]
        public void FindsNameTest()
        {
            BYOBurger b = new();

            Assert.Equal("Build-Your-Own Burger", b.Name);
        }
    }
}
