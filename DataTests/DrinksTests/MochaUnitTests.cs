using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.DataTests
{
    /// <summary>
    /// The unit tests for the Mocha class.
    /// </summary>
    public class MochaUnitTests
    {
        /// <summary>
        /// The default cup size for this drink.
        /// </summary>
        [Fact]
        public void DefaultCupTest()
        {
            Mocha d = new();

            Assert.Equal(CoffeeSize.Tall, d.SizeOfCup);
        }

        /// <summary>
        /// Tests the defaults for the options for this coffee.
        /// </summary>
        [Fact]
        public void DefaultAddInOptionsTest()
        {
            Mocha d = new();

            Assert.False(d.Decaf);
            Assert.False(d.Iced);
            Assert.False(d.Vanilla);
            Assert.False(d.Cream);
            Assert.False(d.Sugar);
        }

        /// <summary>
        /// Makes sure the default price is 3.99.
        /// </summary>
        [Fact]
        public void DefaultCostTest()
        {
            Mocha d = new();

            Assert.Equal(3.99m, d.Price);
        }

        /// <summary>
        /// Makes sure the default calories is 200
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            Mocha d = new();

            Assert.Equal(200u, d.Calories);
        }

        /// <summary>
        /// Tests different ingredient options and finds the price.
        /// </summary>
        /// <param name="vanilla">If this drink has vanilla.</param>
        /// <param name="cream">If this drink has cream.</param>
        /// <param name="sugar">If this drink has sugar.</param>
        /// <param name="decaf">If the coffee is decaf.</param>
        /// <param name="iced">If the coffee is iced.</param>
        /// <param name="size">The size of the cup.</param>
        /// <param name="expected">The expected price.</param>
        [Theory]
        [InlineData(false, false, false, false, false, CoffeeSize.Tall, 3.99)] //fix cases
        [InlineData(false, true, true, false, false, CoffeeSize.Tall, 3.99)]
        [InlineData(false, true, false, true, true, CoffeeSize.Tall, 3.99)]
        [InlineData(false, false, true, false, true, CoffeeSize.Tall, 3.99)]
        [InlineData(true, false, false, true, false, CoffeeSize.Tall, 3.99)]
        [InlineData(false, true, true, false, false, CoffeeSize.Grande, 3.99 + .75)]
        [InlineData(false, false, false, true, true, CoffeeSize.Venti, 3.99 + 1.25)]
        public void PriceCheckForDifferentIngredientTest(bool vanilla, bool cream, bool sugar, bool decaf, bool iced, CoffeeSize size, decimal expected)
        {
            Mocha d = new();

            d.Vanilla = vanilla;
            d.Cream = cream;
            d.Sugar = sugar;
            d.SizeOfCup = size;
            d.Decaf = decaf;
            d.Iced = iced;

            Assert.Equal(expected, d.Price, 2);
        }

        /// <summary>
        /// Tests different ingredient options and finds the calories.
        /// </summary>
        /// <param name="vanilla">If this drink has vanilla.</param>
        /// <param name="cream">If this drink has cream.</param>
        /// <param name="sugar">If this drink has sugar.</param>
        /// <param name="decaf">If the coffee is decaf.</param>
        /// <param name="iced">If the coffee is iced.</param>
        /// <param name="size">The size of the cup.</param>
        /// <param name="expected">The expected calories.</param>
        [Theory]
        [InlineData(false, false, false, false, false, CoffeeSize.Tall, 200)]    
        [InlineData(false, true, true, false, false, CoffeeSize.Tall, 200)]
        [InlineData(false, true, false, true, true, CoffeeSize.Tall, 200 - 3)]
        [InlineData(false, false, true, false, true, CoffeeSize.Tall, 200)]
        [InlineData(true, false, false, true, false, CoffeeSize.Tall, 200 - 3)]
        [InlineData(false, true, true, false, false, CoffeeSize.Grande, (uint)(200 * (16.0/12.0)))]
        [InlineData(false, false, false, true, true, CoffeeSize.Venti, (uint)((200 - 3) * (20.0 / 12.0)))]
        public void CaloriesCheckForDifferentIngredientTest(bool vanilla, bool cream, bool sugar, bool decaf, bool iced, CoffeeSize size, uint expected)
        {
            Mocha d = new();

            d.Vanilla = vanilla;
            d.Cream = cream;
            d.Sugar = sugar;
            d.SizeOfCup = size;
            d.Decaf = decaf;
            d.Iced = iced;

            Assert.Equal(expected, d.Calories);
        }

        /// <summary>
        /// Tests different ingredient options and finds the preparation information.
        /// </summary>
        /// <param name="vanilla">If this drink has vanilla.</param>
        /// <param name="cream">If this drink has cream.</param>
        /// <param name="sugar">If this drink has sugar.</param>
        /// <param name="decaf">If the coffee is decaf.</param>
        /// <param name="iced">If the coffee is iced.</param>
        /// <param name="size">The size of the cup.</param>
        /// <param name="expected">The expected information.</param>
        [Theory]
        [InlineData(false, false, false, false, false, CoffeeSize.Tall, new string[] { })]                          
        [InlineData(false, true, true, false, false, CoffeeSize.Tall, new string[] { })]
        [InlineData(false, true, false, true, true, CoffeeSize.Tall, new string[] { "Decaf", "Iced" })]
        [InlineData(false, false, true, false, true, CoffeeSize.Tall, new string[] { "Iced" })]
        [InlineData(true, false, false, true, false, CoffeeSize.Tall, new string[] { "Decaf" })]
        [InlineData(false, true, true, false, false, CoffeeSize.Grande, new string[] { "Grande" })]
        [InlineData(false, false, false, true, true, CoffeeSize.Venti, new string[] { "Decaf", "Iced", "Venti" })]
        public void PrepInfoCheckForDifferentIngredientTest(bool vanilla, bool cream, bool sugar, bool decaf, bool iced, CoffeeSize size, string[] expected)
        {
            Mocha d = new();

            d.Vanilla = vanilla;
            d.Cream = cream;
            d.Sugar = sugar;
            d.SizeOfCup = size;
            d.Decaf = decaf;
            d.Iced = iced;

            foreach (string info in expected)
            {
                Assert.Contains(info, d.PreparationInformation);
            }

            Assert.Equal(expected.Length, d.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests the values for decaf.
        /// </summary>
        /// <param name="decaf">What we set decaf to.</param>
        /// <param name="expected">What we expect decaf to be.</param>
        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        public void CheckBoundsOnDecafTest(bool decaf, bool expected)
        {
            Mocha d = new() { Decaf = decaf };

            Assert.Equal(expected, d.Decaf);
        }

        /// <summary>
        /// Tests the values for iced.
        /// </summary>
        /// <param name="iced">What we set iced to.</param>
        /// <param name="expected">What we expect iced to be.</param>
        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        public void CheckBoundsOnIcedTest(bool iced, bool expected)
        {
            Mocha d = new() { Iced = iced };

            Assert.Equal(expected, d.Iced);
        }

        /// <summary>
        /// Tests the values for vanilla.
        /// </summary>
        /// <param name="vanilla">What we set vanilla to.</param>
        /// <param name="expected">What we expect vanilla to be.</param>
        [Theory]
        [InlineData(true, false)]
        [InlineData(false, false)]
        public void CheckBoundsOnVanillaTest(bool vanilla, bool expected)
        {
            Mocha d = new() { Vanilla = vanilla };

            Assert.Equal(expected, d.Vanilla);
        }

        /// <summary>
        /// Tests the values for cream.
        /// </summary>
        /// <param name="cream">What we set cream to be.</param>
        /// <param name="expected">What we expect cream to be.</param>
        [Theory]
        [InlineData(true, false)]
        [InlineData(false, false)]
        public void CheckBoundsOnCreamTest(bool cream, bool expected)
        {
            Mocha d = new() { Cream = cream };

            Assert.Equal(expected, d.Cream);
        }

        /// <summary>
        /// Tests the values for sugar.
        /// </summary>
        /// <param name="sugar">What we set sugar to be.</param>
        /// <param name="expected">What we expect sugar to be.</param>
        [Theory]
        [InlineData(true, false)]
        [InlineData(false, false)]
        public void CheckBoundsOnSugarTest(bool sugar, bool expected)
        {
            Mocha d = new() { Sugar = sugar };

            Assert.Equal(expected, d.Sugar);
        }

        /// <summary>
        /// Tests to make sure the drink is an IMenuItem and a drink.
        /// </summary>
        [Fact]
        public void IsAnIMenuItemTest()
        {
            Mocha d = new();

            Assert.IsAssignableFrom<IMenuItem>(d);
            Assert.IsAssignableFrom<Drink>(d);
        }

        /// <summary>
        /// Tests to make sure that the right name is returned.
        /// </summary>
        [Fact]
        public void FindNameTest()
        {
            Mocha d = new();

            Assert.Equal("Mocha", d.Name);
        }
    }
}
