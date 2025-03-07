using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace DairyBarn.DataTests
{
    /// <summary>
    /// The unit tests for the StrawberryShortcake class.
    /// </summary>
    public class StrawberryShortcakeUnitTests
    {
        /// <summary>
        /// Tests the default scoops is 2.
        /// </summary>
        [Fact]
        public void DefaultScoopsTest()
        {
            StrawBerryShortcake s = new();

            Assert.Equal(2u, s.Scoops);
        }

        /// <summary>
        /// Tests the default sauce options.
        /// </summary>
        [Fact]
        public void DefaultSauceOptionTest()
        {
            StrawBerryShortcake s = new();

            Assert.Equal(IceCreamSauce.StrawberrySauce, s.SauceChoice);
        }

        /// <summary>
        /// Tests the default values for other toppings.
        /// </summary>
        [Fact]
        public void ToppingsDefaultTest()
        {
            StrawBerryShortcake s = new();

            Assert.True(s.WhippedCream);
            Assert.True(s.Cherry);
            Assert.False(s.Peanuts);
        }

        /// <summary>
        /// Tests the default price is 5.99.
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            StrawBerryShortcake s = new();

            Assert.Equal(5.99m, s.Price);
        }

        /// <summary>
        /// Tests the default calories is 770.
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            StrawBerryShortcake s = new();

            Assert.Equal(770u, s.Calories);
        }

        /// <summary>
        /// Tests the price for different options for this ice cream.
        /// </summary>
        /// <param name="whippedCream">If the sundae has whipped cream.</param>
        /// <param name="cherry">If he sundae has cherry.</param>
        /// <param name="peanuts">If the sundae had peanuts.</param>
        /// <param name="scoops">How many scoops the sundae has.</param>
        /// <param name="sauce">The type of sauce on this sundae.</param>
        /// <param name="expected">The expected price.</param>
        [Theory]
        [InlineData(true, true, false, 2, IceCreamSauce.StrawberrySauce, 5.99)]
        [InlineData(true, false, false, 1, IceCreamSauce.StrawberrySauce, 5.99)]
        [InlineData(false, true, false, 3, IceCreamSauce.StrawberrySauce, 5.99)]
        [InlineData(true, true, true, 2, IceCreamSauce.None, 5.99 +.50)]
        [InlineData(true, false, true, 2, IceCreamSauce.None, 5.99 + .50)]
        [InlineData(false, true, true, 2, IceCreamSauce.StrawberrySauce, 5.99 + .50)]
        public void PriceCheckingForDifferentIngredientTest(bool whippedCream, bool cherry, bool peanuts, uint scoops, IceCreamSauce sauce, decimal expected)
        {
            StrawBerryShortcake s = new();

            s.WhippedCream = whippedCream;
            s.Cherry = cherry;
            s.Peanuts = peanuts;
            s.Scoops = scoops;
            s.SauceChoice = sauce;

            Assert.Equal(expected, s.Price);
        }

        /// <summary>
        /// Tests the calories for different options for this ice cream.
        /// </summary>
        /// <param name="whippedCream">If the sundae has whipped cream.</param>
        /// <param name="cherry">If he sundae has cherry.</param>
        /// <param name="peanuts">If the sundae had peanuts.</param>
        /// <param name="scoops">How many scoops the sundae has.</param>
        /// <param name="sauce">The type of sauce on this sundae.</param>
        /// <param name="expected">The expected calories.</param>
        [Theory]
        [InlineData(true, true, false, 2, IceCreamSauce.StrawberrySauce, 770)]
        [InlineData(true, false, false, 1, IceCreamSauce.StrawberrySauce, 770 - 10)]
        [InlineData(false, true, false, 3, IceCreamSauce.StrawberrySauce, 770 - 80)]
        [InlineData(true, true, true, 2, IceCreamSauce.None, 770 + 50 - 40)]
        [InlineData(true, false, true, 2, IceCreamSauce.None, 770 - 40 - 10 + 50)]
        [InlineData(false, true, true, 2, IceCreamSauce.StrawberrySauce, 770 - 80 + 50)]
        public void CaloriesCheckingForDifferentIngredientTest(bool whippedCream, bool cherry, bool peanuts, uint scoops, IceCreamSauce sauce, uint expected)
        {
            StrawBerryShortcake s = new();

            s.WhippedCream = whippedCream;
            s.Cherry = cherry;
            s.Peanuts = peanuts;
            s.Scoops = scoops;
            s.SauceChoice = sauce;

            Assert.Equal(expected, s.Calories);
        }

        /// <summary>
        /// Tests the preparation information for different options for this ice cream.
        /// </summary>
        /// <param name="whippedCream">If the sundae has whipped cream.</param>
        /// <param name="cherry">If he sundae has cherry.</param>
        /// <param name="peanuts">If the sundae had peanuts.</param>
        /// <param name="scoops">How many scoops the sundae has.</param>
        /// <param name="sauce">The type of sauce on this sundae.</param>
        /// <param name="expected">The expected information.</param>
        [Theory]
        [InlineData(true, true, false, 2, IceCreamSauce.StrawberrySauce, new string[] { })]
        [InlineData(true, false, false, 1, IceCreamSauce.StrawberrySauce, new string[] { "Hold Cherry" })]
        [InlineData(false, true, false, 3, IceCreamSauce.StrawberrySauce, new string[] { "Hold Whipped Cream" })]
        [InlineData(true, true, true, 2, IceCreamSauce.None, new string[] { "Add Peanuts", "Hold Strawberry Sauce" })]
        [InlineData(true, false, true, 2, IceCreamSauce.None, new string[] { "Hold Cherry", "Add Peanuts", "Hold Strawberry Sauce"})]
        [InlineData(false, true, true, 2, IceCreamSauce.StrawberrySauce, new string[] { "Hold Whipped Cream", "Add Peanuts" })]
        [InlineData(false, false, true, 2, IceCreamSauce.None, new string[] { "Hold Whipped Cream", "Hold Cherry", "Add Peanuts", "Hold Strawberry Sauce"})]
        public void PrepInfoCheckingForDifferentIngredientTest(bool whippedCream, bool cherry, bool peanuts, uint scoops, IceCreamSauce sauce, string[] expected)
        {
            StrawBerryShortcake s = new();

            s.WhippedCream = whippedCream;
            s.Cherry = cherry;
            s.Peanuts = peanuts;
            s.Scoops = scoops;
            s.SauceChoice = sauce;

            foreach(string info in s.PreparationInformation)
            {
                Assert.Contains(info, s.PreparationInformation);
            }

            Assert.Equal(expected.Length, s.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests the bounds for scoops of ice cream.
        /// </summary>
        /// <param name="scoops">The number of scoops we want to add.</param>
        /// <param name="expected">The number of scoops we can actually add.</param>
        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 2)]
        [InlineData(3, 2)]
        [InlineData(0, 2)]
        [InlineData(50, 2)]
        public void CheckBoundsOnScoopsTest(uint scoops, uint expected)
        {
            StrawBerryShortcake s = new() { Scoops = scoops };

            Assert.Equal(expected, s.Scoops);
        }

        /// <summary>
        /// Checks the different sauce options.
        /// </summary>
        /// <param name="sauce">The sauce we are trying to add.</param>
        /// <param name="expected">The sauce we are actually adding.</param>
        [Theory]
        [InlineData(IceCreamSauce.StrawberrySauce, IceCreamSauce.StrawberrySauce)]
        [InlineData(IceCreamSauce.None, IceCreamSauce.None)]
        [InlineData(IceCreamSauce.CrushedPineapple, IceCreamSauce.StrawberrySauce)]
        public void CheckSauceOptionsTest(IceCreamSauce sauce, IceCreamSauce expected)
        {
            StrawBerryShortcake s = new() { SauceChoice = sauce };

            Assert.Equal(expected, s.SauceChoice);
        }

        /// <summary>
        /// Checks the values for peanut.
        /// </summary>
        /// <param name="peanut">The value for peanut we want.</param>
        /// <param name="expected">The value we are actually getting.</param>
        [Theory]
        [InlineData(false, false)]
        [InlineData(true, true)]
        public void CheckPeanutOptionsTest(bool peanut, bool expected)
        {
            BrownieSundae s = new() { Peanuts = peanut };

            Assert.Equal(expected, s.Peanuts);
        }

        /// <summary>
        /// Checks the values for whipped cream.
        /// </summary>
        /// <param name="whippedCream">The value for whipped cream we want.</param>
        /// <param name="expected">The value we are getting.</param>
        [Theory]
        [InlineData(false, false)]
        [InlineData(true, true)]
        public void CheckWhippedCreamOptionsTest(bool whippedCream, bool expected)
        {
            StrawBerryShortcake s = new() { WhippedCream = whippedCream };

            Assert.Equal(expected, s.WhippedCream);
        }

        /// <summary>
        /// Checks the values for cherry.
        /// </summary>
        /// <param name="cherry">The value for cherry we want.</param>
        /// <param name="expected">The value we are getting.</param>
        [Theory]
        [InlineData(false, false)]
        [InlineData(true, true)]
        public void CheckCherryOptionsTest(bool cherry, bool expected)
        {
            StrawBerryShortcake s = new() { Cherry = cherry };

            Assert.Equal(expected, s.Cherry);
        }

        /// <summary>
        /// If the sundae is part of IMenuItem and is a ice cream.
        /// </summary>
        [Fact]
        public void CheckIsAnIMenuItemTest()
        {
            StrawBerryShortcake s = new();

            Assert.IsAssignableFrom<IMenuItem>(s);
            Assert.IsAssignableFrom<IceCream>(s);
        }

        /// <summary>
        /// Tests to make sure that the right name is returned.
        /// </summary>
        [Fact]
        public void FindNameTest()
        {
            StrawBerryShortcake s = new();

            Assert.Equal("Strawberry Shortcake", s.Name);
        }
    }
}
