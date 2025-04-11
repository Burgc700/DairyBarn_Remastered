using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.DataTests
{
    /// <summary>
    /// The unit tests for the Latte class.
    /// </summary>
    public class LatteUnitTests
    {
        /// <summary>
        /// The default cup size for this drink.
        /// </summary>
        [Fact]
        public void DefaultCupTest()
        {
            Latte d = new();

            Assert.Equal(CoffeeSize.Tall, d.SizeOfCup);
        }

        /// <summary>
        /// Tests the defaults for the things you can add to this drink.
        /// </summary>
        [Fact]
        public void DefaultAddInOptionsTest()
        {
            Latte d = new();

            Assert.False(d.Decaf);
            Assert.False(d.Iced);
            Assert.False(d.Vanilla);
            Assert.False(d.Cream);
            Assert.False(d.Sugar);
        }

        /// <summary>
        /// Makes sure the default price is 3.49.
        /// </summary>
        [Fact]
        public void DefaultCostTest()
        {
            Latte d = new();

            Assert.Equal(3.49m, d.Price);
        }
        
        /// <summary>
        /// Makes sure the default calories is 150
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            Latte d = new();

            Assert.Equal(150u, d.Calories);
        }

        /// <summary>
        /// Tests different options for ingredients to check the price is right.
        /// </summary>
        /// <param name="vanilla">If this drink has vanilla.</param>
        /// <param name="cream">If this drink has cream.</param>
        /// <param name="sugar">If this drink has sugar.</param>
        /// <param name="decaf">If the drink is decaf.</param>
        /// <param name="iced">If the drink is iced.</param>
        /// <param name="size">The size of cup for this drink.</param>
        /// <param name="expected">The expected price.</param>
        [Theory]
        [InlineData(false, false, false, false, false, CoffeeSize.Tall, 3.49)]
        [InlineData(false, true, true, false, false, CoffeeSize.Tall, 3.49)]
        [InlineData(false, true, false, true, true, CoffeeSize.Tall, 3.49)]
        [InlineData(true, false, true, false, true, CoffeeSize.Tall, 3.49 + .24)]
        [InlineData(true, false, false, true, false, CoffeeSize.Tall, 3.49 + .24)]
        [InlineData(false, true, true, false, false, CoffeeSize.Grande, 3.49 + .75)]
        [InlineData(false, false, false, true, true, CoffeeSize.Venti, 3.49 + 1.25)]
        [InlineData(true, true, false, false ,false, CoffeeSize.Grande, 3.49 + .75 + .24)]
        [InlineData(true, false, true, true, false, CoffeeSize.Venti, 3.49 + 1.25 + .24)]
        public void PriceCheckForDifferentIngredientTest(bool vanilla, bool cream, bool sugar, bool decaf, bool iced, CoffeeSize size, decimal expected)
        {
            Latte d = new();

            d.Vanilla = vanilla;
            d.Cream = cream;
            d.Sugar = sugar;
            d.SizeOfCup = size;
            d.Decaf = decaf;
            d.Iced = iced;

            Assert.Equal(expected, d.Price, 2);
        }

        /// <summary>
        /// Tests different options for ingredients to check the calories is right.
        /// </summary>
        /// <param name="vanilla">If this drink has vanilla.</param>
        /// <param name="cream">If this drink has cream.</param>
        /// <param name="sugar">If this drink has sugar.</param>
        /// <param name="decaf">If the drink is decaf.</param>
        /// <param name="iced">If the drink is iced.</param>
        /// <param name="size">The size of cup for this drink.</param>
        /// <param name="expected">The expected calories.</param>
        [Theory]
        [InlineData(false, false, false, false, false, CoffeeSize.Tall, 150)]
        [InlineData(false, true, true, false, false, CoffeeSize.Tall, 150)]
        [InlineData(false, true, false, true, true, CoffeeSize.Tall, 150 - 3)]
        [InlineData(true, false, true, false, true, CoffeeSize.Tall, 150 + 80)]
        [InlineData(true, false, false, true, false, CoffeeSize.Tall, 150 + 80 - 3)]
        [InlineData(false, true, true, false, false, CoffeeSize.Grande, (uint)(150 * (16.0/12.0)))]
        [InlineData(false, false, false, true, true, CoffeeSize.Venti, (uint)((150 - 3) * (20.0/12.0)))]
        [InlineData(true, true, false, false, false, CoffeeSize.Grande, (uint)((150 + 80) * (16.0/12.0)))]
        [InlineData(true, false, true, true, false, CoffeeSize.Venti, (uint)((150 + 80 - 3) * (20.0/12.0)))]
        public void CaloriesCheckForDifferentIngredientTest(bool vanilla, bool cream, bool sugar, bool decaf, bool iced, CoffeeSize size, uint expected)
        {
            Latte d = new();

            d.Vanilla = vanilla;
            d.Cream = cream;
            d.Sugar = sugar;
            d.SizeOfCup = size;
            d.Decaf = decaf;
            d.Iced = iced;

            Assert.Equal(expected, d.Calories);
        }

        /// <summary>
        /// Tests different options for ingredients to check the preparation information is right.
        /// </summary>
        /// <param name="vanilla">If this drink has vanilla.</param>
        /// <param name="cream">If this drink has cream.</param>
        /// <param name="sugar">If this drink has sugar.</param>
        /// <param name="decaf">If the drink is decaf.</param>
        /// <param name="iced">If the drink is iced.</param>
        /// <param name="size">The size of cup for this drink.</param>
        /// <param name="expected">The expected information.</param>
        [Theory]
        [InlineData(false, false, false, false, false, CoffeeSize.Tall, new string[] { })]
        [InlineData(false, true, true, false, false, CoffeeSize.Tall, new string[] { })]
        [InlineData(false, true, false, true, true, CoffeeSize.Tall, new string[] { "Decaf", "Iced"})]
        [InlineData(true, false, true, false, true, CoffeeSize.Tall, new string[] { "Add Vanilla", "Iced"})]
        [InlineData(true, false, false, true, false, CoffeeSize.Tall, new string[] { "Add Vanilla", "Decaf"})]
        [InlineData(false, true, true, false, false, CoffeeSize.Grande, new string[] { "Grande"})]
        [InlineData(false, false, false, true, true, CoffeeSize.Venti, new string[] { "Decaf", "Iced", "Venti"})]
        [InlineData(true, true, false, false, false, CoffeeSize.Grande, new string[] { "Add Vanilla", "Grande"})]
        [InlineData(true, false, true, true, true, CoffeeSize.Venti, new string[] { "Add Vanilla", "Decaf", "Iced", "Venti"})]
        public void PrepInfoCheckForDifferentIngredientTest(bool vanilla, bool cream, bool sugar, bool decaf, bool iced, CoffeeSize size, string[] expected)
        {
            Latte d = new();

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
            Latte d = new() { Decaf = decaf };

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
            Latte d = new() { Iced = iced };

            Assert.Equal(expected, d.Iced);
        }

        /// <summary>
        /// Tests the values for vanilla.
        /// </summary>
        /// <param name="vanilla">What we set vanilla to.</param>
        /// <param name="expected">What we expect vanilla to be.</param>
        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        public void CheckBoundsOnVanillaTest(bool vanilla, bool expected)
        {
            Latte d = new() { Vanilla = vanilla };

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
            Latte d = new() { Cream = cream };

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
            Latte d = new() { Sugar = sugar };

            Assert.Equal(expected, d.Sugar);
        }

        /// <summary>
        /// Tests to make sure the drink is an IMenuItem and a drink.
        /// </summary>
        [Fact]
        public void IsAnIMenuItemTest()
        {
            Latte d = new();

            Assert.IsAssignableFrom<IMenuItem>(d);
            Assert.IsAssignableFrom<Drink>(d);
            Assert.IsAssignableFrom<INotifyPropertyChanged>(d);
        }

        /// <summary>
        /// Tests to make sure that the right name is returned.
        /// </summary>
        [Fact]
        public void FindNameTest()
        {
            Latte d = new();

            Assert.Equal("Latte", d.Name);
        }

        /// <summary>
        /// Test if the property changed for iced when the value changes.
        /// </summary>
        /// <param name="iced">If the drink is iced.</param>
        /// <param name="property">The name of the property that is changing.</param>
        [Theory]
        [InlineData(true, "Iced")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "Iced")]
        [InlineData(false, "PreparationInformation")]
        public void ChangingIceShouldNotifyPropertyChanged(bool iced, string property)
        {
            Latte d = new();
            Assert.PropertyChanged(d, property, () =>
            {
                d.Iced = iced;
            });
        }

        /// <summary>
        /// Tests if the property changed for decaf when the value changes.
        /// </summary>
        /// <param name="decaf">If the drink is decaf.</param>
        /// <param name="property">The name of the property that is changing.</param>
        [Theory]
        [InlineData(true, "Decaf")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "Decaf")]
        [InlineData(false, "PreparationInformation")]
        public void ChangingDecafShouldNotifyPropertyChanged(bool decaf, string property)
        {
            Latte d = new();
            Assert.PropertyChanged(d, property, () =>
            {
                d.Decaf = decaf;
            });
        }

        /// <summary>
        /// Tests if the property changed for vanilla when the value changes.
        /// </summary>
        /// <param name="vanilla">If the drink has vanilla.</param>
        /// <param name="property">The name of the property that is changing.</param>
        [Theory]
        [InlineData(true, "Vanilla")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(true, "Calories")]
        [InlineData(false, "Vanilla")]
        [InlineData(false, "PreparationInformation")]
        [InlineData(false, "Calories")]
        public void ChangingVanillaShouldNotifyPropertyChanged(bool vanilla, string property)
        {
            Latte d = new();
            Assert.PropertyChanged(d, property, () =>
            {
                d.Vanilla = vanilla;
            });
        }

        /// <summary>
        /// Tests if the property changed for size of cup when the value changes.
        /// </summary>
        /// <param name="size">The size of the drink.</param>
        /// <param name="property">The name of the property that is changing.</param>
        [Theory]
        [InlineData(CoffeeSize.Venti, "Calories")]
        [InlineData(CoffeeSize.Tall, "Price")]
        [InlineData(CoffeeSize.Grande, "PreparationInformation")]
        [InlineData(CoffeeSize.Tall, "SizeOfCup")]
        [InlineData(CoffeeSize.Venti, "Price")]
        [InlineData(CoffeeSize.Tall, "PreparationInformation")]
        [InlineData(CoffeeSize.Grande, "Price")]
        [InlineData(CoffeeSize.Venti, "SizeOfCup")]
        public void ChangingSizeShouldNotifyOfPropertyChanged(CoffeeSize size, string property)
        {
            Latte d = new();
            Assert.PropertyChanged(d, property, () =>
            {
                d.SizeOfCup = size;
            });
        }
    }
}
