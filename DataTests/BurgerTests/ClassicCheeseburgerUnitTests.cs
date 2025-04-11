using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.DataTests
{
    /// <summary>
    /// The unit tests for the ClassicCheeseburger class.
    /// </summary>
    public class ClassicCheeseburgerUnitTests
    {
        /// <summary>
        /// Tests the default number of patties on this burger.
        /// </summary>
        [Fact]
        public void DefaultPattiesTest()
        {
            ClassicCheeseburger b = new();

            Assert.Equal(1u, b.Patties);
        }

        /// <summary>
        /// Test the default cheese for this burger.
        /// </summary>
        [Fact]
        public void DefaultCheeseTest()
        {
            ClassicCheeseburger b = new();

            Assert.Equal(Cheese.American, b.CheeseChoice);
        }

        /// <summary>
        /// Tests the included toppings are set to true for this burger.
        /// </summary>
        [Fact]
        public void IncludedToppingsTest()
        {
            ClassicCheeseburger b = new();

            Assert.True(b.AllToppings[BurgerTopping.Ketchup].Included);
            Assert.True(b.AllToppings[BurgerTopping.Mustard].Included);
            Assert.True(b.AllToppings[BurgerTopping.Onions].Included);
            Assert.True(b.AllToppings[BurgerTopping.Pickles].Included);
        }

        /// <summary>
        /// Tests to make sure there are only 7 toppings allowed on this burger.
        /// </summary>
        [Fact]
        public void AllToppingsIs7Test()
        {
            ClassicCheeseburger b = new();

            Assert.Equal(7, b.AllToppings.Count);
        }

        /// <summary>
        /// Tests to make sure veggie is set to false.
        /// </summary>
        [Fact]
        public void DefaultVeggieTest()
        {
            ClassicCheeseburger b = new();

            Assert.False(b.Veggie);
        }

        /// <summary>
        /// Tests to make sure the default price is 6.29.
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            ClassicCheeseburger b = new();

            Assert.Equal(6.29m, b.Price);
        }

        /// <summary>
        /// Tests to make sure the default calories is 615.
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            ClassicCheeseburger b = new();

            Assert.Equal(615u, b.Calories);
        }

        /// <summary>
        /// Tests different ingredient options and makes sure the price is right.
        /// </summary>
        /// <param name="ketchup">If ketchup is on this burger.</param>
        /// <param name="mustard">If mustard is on this burger.</param>
        /// <param name="onions">If onions is on this burger.</param>
        /// <param name="pickles">If pickles is on this burger.</param>
        /// <param name="bacon">If bacon is on this burger.</param>
        /// <param name="lettuce">If lettuce is on this burger.</param>
        /// <param name="tomato">If tomato is on this burger.</param>
        /// <param name="veggie">If this burger has veggie patties.</param>
        /// <param name="patties">The number of patties on this burger.</param>
        /// <param name="cheese">The type of cheese on this burger.</param>
        /// <param name="expected">The expected price of this burger./param>
        [Theory]
        [InlineData(true, true, true, true, false, false, false, false, 1, Cheese.American, 6.29)]
        [InlineData(true, true, true, true, true, true, true, false, 1, Cheese.American, 6.29 + 1.00 + .25 + .25)]
        [InlineData(true, true, true, true, true, true, true, false, 2, Cheese.American, 6.29 + 1.00 + .25 + .25 + 2.00)]
        [InlineData(true, true, true, true, true, true, true, false, 3, Cheese.American, 6.29 + 1.00 + .25 + .25 + 4.00)]
        [InlineData(false, false, false, false, true, true, false, true, 1, Cheese.None, 6.29 + 1.00 + .25)]
        [InlineData(true, true, true, true, true, false, false, true, 2, Cheese.None, 6.29 + 1.00 + 2.00)]
        [InlineData(false, false, false, false, false, false, false, false, 1, Cheese.None, 6.29)]
        [InlineData(true, true, true, true, true, true, true, true, 3, Cheese.American, 6.29 + 1.00 + .25 + .25 + 4.00 )]
        public void PriceCheckingForDifferentIngredientTest(bool ketchup, bool mustard, bool onions, bool pickles, bool bacon, bool lettuce, bool tomato, bool veggie, uint patties, Cheese cheese, decimal expected)
        {
            ClassicCheeseburger b = new();

            b.AllToppings[BurgerTopping.Ketchup].Included = ketchup;
            b.AllToppings[BurgerTopping.Mustard].Included = mustard;
            b.AllToppings[BurgerTopping.Onions].Included = onions;
            b.AllToppings[BurgerTopping.Pickles].Included = pickles;
            b.AllToppings[BurgerTopping.Bacon].Included = bacon;
            b.AllToppings[BurgerTopping.Lettuce].Included = lettuce;
            b.AllToppings[BurgerTopping.Tomato].Included = tomato;
            b.Veggie = veggie;
            b.Patties = patties;
            b.CheeseChoice = cheese;

            Assert.Equal(expected, b.Price, 2);
        }

        /// <summary>
        /// Tests different ingredient options and makes sure the calories is right.
        /// </summary>
        /// <param name="ketchup">If ketchup is on this burger.</param>
        /// <param name="mustard">If mustard is on this burger.</param>
        /// <param name="onions">If onions is on this burger.</param>
        /// <param name="pickles">If pickles is on this burger.</param>
        /// <param name="bacon">If bacon is on this burger.</param>
        /// <param name="lettuce">If lettuce is on this burger.</param>
        /// <param name="tomato">If tomato is on this burger.</param>
        /// <param name="veggie">If this burger has veggie patties.</param>
        /// <param name="patties">The number of patties on this burger.</param>
        /// <param name="cheese">The type of cheese on this burger.</param>
        /// <param name="expected">The expected calories of this burger./param>
        [Theory]
        [InlineData(true, true, true, true, false, false, false, false, 1, Cheese.American, 150 + 20 + 5 + 5 + 5 + 80 + 350)]
        [InlineData(true, true, true, true, true, true, true, false, 1, Cheese.American, 150 + 20 + 5 + 5 + 5 + 75 + 5 + 5 + 80 + 350)]
        [InlineData(true, true, true, true, true, true, true, false, 2, Cheese.American, 150+20+5+5+5+75+5+5+(80 * 2)+(350*2))]
        [InlineData(true, true, true, true, true, true, true, false, 3, Cheese.American, 150 + 20 + 5 + 5 + 5 + 75 + 5 + 5 + (80 * 3) + (350 * 3))]
        [InlineData(false, false, false, false, true, true, false, true, 1, Cheese.None, 150 + 75 + 5 + 250)]
        [InlineData(true, true, true, true, true, false, false, true, 2, Cheese.None, 150+20+5+5+5+75+(2*250))]
        [InlineData(false, false, false, false, false, false, false, false, 1, Cheese.None, 150 + 350)]
        [InlineData(true, true, true, true, true, true, true, true, 3, Cheese.American, 150+20+5+5+5+75+5+5+(3*250)+(3*80))]
        public void CalororiesCheckingForDifferentIngredientTest(bool ketchup, bool mustard, bool onions, bool pickles, bool bacon, bool lettuce, bool tomato, bool veggie, uint patties, Cheese cheese, uint expected)
        {
            ClassicCheeseburger b = new();

            b.AllToppings[BurgerTopping.Ketchup].Included = ketchup;
            b.AllToppings[BurgerTopping.Mustard].Included = mustard;
            b.AllToppings[BurgerTopping.Onions].Included = onions;
            b.AllToppings[BurgerTopping.Pickles].Included = pickles;
            b.AllToppings[BurgerTopping.Bacon].Included = bacon;
            b.AllToppings[BurgerTopping.Lettuce].Included = lettuce;
            b.AllToppings[BurgerTopping.Tomato].Included = tomato;
            b.Veggie = veggie;
            b.Patties = patties;
            b.CheeseChoice = cheese;

            Assert.Equal(expected, b.Calories);
        }

        /// <summary>
        /// Tests different ingredient options and makes sure the preparation information is right.
        /// </summary>
        /// <param name="ketchup">If ketchup is on this burger.</param>
        /// <param name="mustard">If mustard is on this burger.</param>
        /// <param name="onions">If onions is on this burger.</param>
        /// <param name="pickles">If pickles is on this burger.</param>
        /// <param name="bacon">If bacon is on this burger.</param>
        /// <param name="lettuce">If lettuce is on this burger.</param>
        /// <param name="tomato">If tomato is on this burger.</param>
        /// <param name="veggie">If this burger has veggie patties.</param>
        /// <param name="patties">The number of patties on this burger.</param>
        /// <param name="cheese">The type of cheese on this burger.</param>
        /// <param name="expected">The expected information of this burger./param>
        [Theory]
        [InlineData(true, true, true, true, false, false, false, false, 1, Cheese.American, new string[] { })]
        [InlineData(true, true, true, true, true, true, true, false, 1, Cheese.American, new string[] { "Add Bacon", "Add Lettuce", "Add Tomato"})]
        [InlineData(true, true, true, true, true, true, true, false, 2, Cheese.American, new string[] { "Add Bacon", "Add Lettuce", "Add Tomato", "Double" })]
        [InlineData(true, true, true, true, true, true, true, false, 3, Cheese.American, new string[] { "Add Bacon", "Add Lettuce", "Add Tomato", "Triple" })]
        [InlineData(false, false, false, false, true, true, false, true, 1, Cheese.None, new string[] {"Hold Ketchup", "Hold Mustard", "Hold Onions", "Hold Pickles", "Add Bacon", "Add Lettuce", "Add Veggie Patties", "Hold American Cheese"})]
        [InlineData(true, true, true, true, true, false, false, true, 2, Cheese.None, new string[] { "Add Bacon", "Add Veggie Patties", "Double", "Hold American Cheese"})]
        [InlineData(false, false, false, false, false, false, false, false, 1, Cheese.None, new string[] { "Hold Ketchup", "Hold Mustard", "Hold Onions", "Hold Pickles", "Hold American Cheese"})]
        [InlineData(true, true, true, true, true, true, true, true, 3, Cheese.None, new string[] { "Add bacon", "Add Lettuce", "Add Tomato", "Veggie", "Triple", "Hold American Cheese"})]
        public void PrepInfoCheckDifferentOptionsTest(bool ketchup, bool mustard, bool onions, bool pickles, bool bacon, bool lettuce, bool tomato, bool veggie, uint patties, Cheese cheese, string[] expected)
        {
            ClassicCheeseburger b = new();

            b.AllToppings[BurgerTopping.Ketchup].Included = ketchup;
            b.AllToppings[BurgerTopping.Mustard].Included = mustard;
            b.AllToppings[BurgerTopping.Onions].Included = onions;
            b.AllToppings[BurgerTopping.Pickles].Included = pickles;
            b.AllToppings[BurgerTopping.Bacon].Included = bacon;
            b.AllToppings[BurgerTopping.Lettuce].Included = lettuce;
            b.AllToppings[BurgerTopping.Tomato].Included = tomato;
            b.Veggie = veggie;
            b.Patties = patties;
            b.CheeseChoice = cheese;
            
            foreach(string info in b.PreparationInformation)
            {
                Assert.Contains(info, b.PreparationInformation);
            }

            Assert.Equal(expected.Length, b.PreparationInformation.Count());
            
            
        }

        /// <summary>
        /// Checks the bounds for the number of patties.
        /// </summary>
        /// <param name="patties">The number of patties we are trying to put on the burger.</param>
        /// <param name="expected">What the number should actually be.</param>
        [Theory]
        [InlineData(4, 1)]
        [InlineData(0 , 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(50, 1)]
        public void CheckBoundsOnPattiesTest(uint patties, uint expected)
        {
            ClassicCheeseburger b = new() { Patties = patties };

            Assert.Equal(expected, b.Patties);
        }

        /// <summary>
        /// Tested the cheese bounds.
        /// </summary>
        /// <param name="cheese">The type of cheese we are trying to put on the burger.</param>
        /// <param name="expected">The type of cheese that should actually be on the burger.</param>
        [Theory]
        [InlineData(Cheese.American, Cheese.American)]
        [InlineData(Cheese.None, Cheese.None)]
        [InlineData(Cheese.Swiss, Cheese.American)]
        public void CheckBoundsOnCheeseTest(Cheese cheese, Cheese expected)
        {
            ClassicCheeseburger b = new();

            b.CheeseChoice = cheese;

            Assert.Equal(expected, b.CheeseChoice);
        }

        /// <summary>
        /// Tests to make sure the burger is part of IMenuItem and burger.
        /// </summary>
        [Fact]
        public void IsAnIMenuItemTest()
        {
            ClassicCheeseburger b = new();

            Assert.IsAssignableFrom<IMenuItem>(b);
            Assert.IsAssignableFrom<Burger>(b);
            Assert.IsAssignableFrom<INotifyPropertyChanged>(b);
        }

        /// <summary>
        /// Tests to make sure that the right name is returned.
        /// </summary>
        [Fact]
        public void FindsNameTest()
        {
            ClassicCheeseburger b = new();

            Assert.Equal("Classic Cheeseburger", b.Name);
        }

        /// <summary>
        /// Tests that when veggies value changes the other properties values also change.
        /// </summary>
        /// <param name="veggie">If this burger has veggie patties.</param>
        /// <param name="property">The name of the property value that should also change.</param>
        [Theory]
        [InlineData(true, "Veggie")]
        [InlineData(true, "Price")]
        [InlineData(true, "Calories")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "Veggie")]
        [InlineData(false, "Price")]
        [InlineData(false, "Calories")]
        [InlineData(false, "PreparationInformation")]
        public void ChangingVeggieNotifyPropertyChanged(bool veggie, string property)
        {
            ClassicCheeseburger b = new();
            Assert.PropertyChanged(b, property, () =>
            {
                b.Veggie = veggie;
            });
        }

        /// <summary>
        /// Tests that cheese choice value changes the other properties values also change.
        /// </summary>
        /// <param name="cheese">The type of cheese on this burger.</param>
        /// <param name="property">The name of the property value that should also change.</param>
        [Theory]
        [InlineData(Cheese.American, "CheeseChoice")]
        [InlineData(Cheese.American, "Calories")]
        [InlineData(Cheese.American, "PreparationInformation")]
        [InlineData(Cheese.None, "CheeseChoice")]
        [InlineData(Cheese.None, "Calories")]
        [InlineData(Cheese.None, "PreparationInformation")]
        public void ChangingCheeseChoiceNotifyPropertyChanged(Cheese cheese, string property)
        {
            ClassicCheeseburger b = new();
            Assert.PropertyChanged(b, property, () =>
            {
                b.CheeseChoice = cheese;
            });
        }

        /// <summary>
        /// Tests that patties value changes the other properties values also change.
        /// </summary>
        /// <param name="patty">The number of patties on the burger.</param>
        /// <param name="property">The name of the property value that should also change.</param>
        [Theory]
        [InlineData(1, "Patties")]
        [InlineData(2, "Calories")]
        [InlineData(3, "Price")]
        [InlineData(1, "PreparationInformation")]
        [InlineData(2, "Patties")]
        [InlineData(3, "Calories")]
        [InlineData(1, "Price")]
        [InlineData(2, "PreparationInformation")]
        public void ChangingPattiesNotifyPropertyChanged(uint patty, string property)
        {
            ClassicCheeseburger b = new();
            Assert.PropertyChanged(b, property, () =>
            {
                b.Patties = patty;
            });
        }
    }
}
