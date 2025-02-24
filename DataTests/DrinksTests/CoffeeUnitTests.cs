using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.DataTests
{
    /// <summary>
    /// The unit tests for the Coffee class.
    /// </summary>
    public class CoffeeUnitTests
    {
        /// <summary>
        /// Tests the defualt cup size.
        /// </summary>
        [Fact]
        public void DefaultCupTest()
        {
            Coffee d = new();

            Assert.Equal(CoffeeSize.Tall, d.SizeOfCup);
        }

        /// <summary>
        /// Checks the values of the options to this drink.
        /// </summary>
        [Fact]
        public void DefaultAddInOptionsTest()
        {
            Coffee d = new();

            Assert.False(d.Decaf);
            Assert.False(d.Iced);
            Assert.False(d.Vanilla);
            Assert.False(d.Cream);
            Assert.False(d.Sugar);
        }

        /// <summary>
        /// Makes sure the defualt price is 2.49.
        /// </summary>
        [Fact]
        public void DefaultCostTest()
        {
            Coffee d = new();

            Assert.Equal(2.49m, d.Price);
        }

        /// <summary>
        /// Makes sure the default calories is 5.
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            Coffee d = new();

            Assert.Equal(5u, d.Calories);
        }

        /// <summary>
        /// Tests different options to make sure the price is right.
        /// </summary>
        /// <param name="vanilla">If vanilla is in this drink.</param>
        /// <param name="cream">If cream is in this drink.</param>
        /// <param name="sugar">If sugar is in this drink.</param>
        /// <param name="decaf">If this drink is decaf.</param>
        /// <param name="iced">If this drink is iced.</param>
        /// <param name="size">The size of cup for this drink.</param>
        /// <param name="expected">The expected price for this drink.</param>
        [Theory]
        [InlineData(false, false, false, false, false, CoffeeSize.Tall, 2.49)]
        [InlineData(false, true, true, false, false, CoffeeSize.Tall, 2.49)]
        [InlineData(false, true, false, true, true, CoffeeSize.Tall, 2.49)]
        [InlineData(false, false, true, false, true, CoffeeSize.Tall, 2.49)]
        [InlineData(true, false, false, true, false, CoffeeSize.Tall, 2.49)]
        [InlineData(false, true, true, false, false, CoffeeSize.Grande, 2.49 + .75)]
        [InlineData(false, false, false, true, true, CoffeeSize.Venti, 2.49 + 1.25)]
        public void PriceCheckForDifferentIngredientTest(bool vanilla, bool cream, bool sugar, bool decaf, bool iced, CoffeeSize size, decimal expected)
        {
            Coffee d = new();

            d.Vanilla = vanilla;
            d.Cream = cream;
            d.Sugar = sugar;
            d.SizeOfCup = size;
            d.Decaf = decaf;
            d.Iced = iced;

            Assert.Equal(expected, d.Price, 2);
        }

        /// <summary>
        /// Tests different options to make sure the calories is right.
        /// </summary>
        /// <param name="vanilla">If vanilla is in this drink.</param>
        /// <param name="cream">If cream is in this drink.</param>
        /// <param name="sugar">If sugar is in this drink.</param>
        /// <param name="decaf">If this drink is decaf.</param>
        /// <param name="iced">If this drink is iced.</param>
        /// <param name="size">The size of cup for this drink.</param>
        /// <param name="expected">The expected calories for this drink.</param>
        [Theory]
        [InlineData(false, false, false, false, false, CoffeeSize.Tall, 5)]
        [InlineData(false, true, true, false, false, CoffeeSize.Tall, 5 + 40 + 25)]
        [InlineData(false, true, false, true, true, CoffeeSize.Tall, 5 + 40 - 3)]
        [InlineData(false, false, true, false, true, CoffeeSize.Tall, 5 + 25)]
        [InlineData(true, false, false, true, false, CoffeeSize.Tall, 5 - 3)]
        [InlineData(false, true, true, false, false, CoffeeSize.Grande, (uint)((5 + 40 + 25 ) * (16.0/12.0)))]
        [InlineData(false, false, false, true, true, CoffeeSize.Venti, (uint)((5 - 3) * (20.0 / 12.0)))]
        public void CaloriesCheckForDifferentIngredientTest(bool vanilla, bool cream, bool sugar, bool decaf, bool iced, CoffeeSize size, uint expected)
        {
            Coffee d = new();

            d.Vanilla = vanilla;
            d.Cream = cream;
            d.Sugar = sugar;
            d.SizeOfCup = size;
            d.Decaf = decaf;
            d.Iced = iced;

            Assert.Equal(expected, d.Calories);
        }

        /// <summary>
        /// Tests different options to make sure the preparation information is right.
        /// </summary>
        /// <param name="vanilla">If vanilla is in this drink.</param>
        /// <param name="cream">If cream is in this drink.</param>
        /// <param name="sugar">If sugar is in this drink.</param>
        /// <param name="decaf">If this drink is decaf.</param>
        /// <param name="iced">If this drink is iced.</param>
        /// <param name="size">The size of cup for this drink.</param>
        /// <param name="expected">The expected information for this drink.</param>
        [Theory]
        [InlineData(false, false, false, false, false, CoffeeSize.Tall, new string[] { })]
        [InlineData(false, true, true, false, false, CoffeeSize.Tall, new string[] { "Add Cream", "Add Sugar"})]
        [InlineData(false, true, false, true, true, CoffeeSize.Tall, new string[] { "Add Cream", "Decaf", "Iced"})]
        [InlineData(false, false, true, false, true, CoffeeSize.Tall, new string[] {"Add Sugar", "Iced"})]
        [InlineData(true, false, false, true, false, CoffeeSize.Tall, new string[] { "Decaf"})]
        [InlineData(false, true, true, false, false, CoffeeSize.Grande, new string[] { "Add Cream", "Add Sugar", "Grande"})]
        [InlineData(false, false, false, true, true, CoffeeSize.Venti, new string[] { "Decaf", "Iced", "Venti"})]
        public void PrepInfoCheckForDifferentIngredientTest(bool vanilla, bool cream, bool sugar, bool decaf, bool iced, CoffeeSize size, string[] expected)
        {
            Coffee d = new();

            d.Vanilla = vanilla;
            d.Cream = cream;
            d.Sugar = sugar;
            d.SizeOfCup = size;
            d.Decaf = decaf;
            d.Iced = iced;

            foreach(string info in expected)
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
        public void CheckBoundsOnDecaf(bool decaf, bool expected)
        {
            Coffee d = new() { Decaf = decaf };

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
        public void CheckBoundsOnIced(bool iced, bool expected)
        {
            Coffee d = new() { Iced = iced };

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
        public void CheckBoundsOnVanilla(bool vanilla, bool expected)
        {
            Coffee d = new() { Vanilla = vanilla };

            Assert.Equal(expected, d.Vanilla);
        }

        /// <summary>
        /// Tests the values for cream.
        /// </summary>
        /// <param name="cream">What we set cream to be.</param>
        /// <param name="expected">What we expect cream to be.</param>
        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        public void CheckBoundsOnCream(bool cream, bool expected)
        {
            Coffee d = new() { Cream = cream };

            Assert.Equal(expected, d.Cream);
        }

        /// <summary>
        /// Tests the values for sugar.
        /// </summary>
        /// <param name="sugar">What we set sugar to be.</param>
        /// <param name="expected">What we expect sugar to be.</param>
        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        public void CheckBoundsOnSugar(bool sugar, bool expected)
        {
            Coffee d = new() { Sugar = sugar };

            Assert.Equal(expected, d.Sugar);
        }

        /// <summary>
        /// Tests to make sure the drink is an IMenuItem and a drink.
        /// </summary>
        [Fact]
        public void IsAnIMenuItem()
        {
            Coffee d = new();

            Assert.IsAssignableFrom<IMenuItem>(d);
            Assert.IsAssignableFrom<Drink>(d);
        }
    }
}
