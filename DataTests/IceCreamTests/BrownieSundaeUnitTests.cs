using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.DataTests
{
    /// <summary>
    /// The unit tests for the BrownieSundae class.
    /// </summary>
    public class BrownieSundaeUnitTests
    {
        /// <summary>
        /// The default number of scoops is 2.
        /// </summary>
        [Fact]
        public void DefaultScoopsTest()
        {
            BrownieSundae s = new();

            Assert.Equal(2u, s.Scoops);
        }

        /// <summary>
        /// Tests the default sauce is hot fudge.
        /// </summary>
        [Fact]
        public void DefaultSauceOptionTest()
        {
            BrownieSundae s = new();

            Assert.Equal(IceCreamSauce.HotFudge, s.SauceChoice);
        }

        /// <summary>
        /// Tests the defaults of the  the other things you can add.
        /// </summary>
        [Fact]
        public void ToppingsDefaultTest()
        {
            BrownieSundae s = new();

            Assert.True(s.WhippedCream);
            Assert.True(s.Cherry);
            Assert.False(s.Peanuts);
        }

        /// <summary>
        /// Tests that the default price is 5.99.
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            BrownieSundae s = new();

            Assert.Equal(5.99m, s.Price);
        }

        /// <summary>
        /// Tests that the default calories is 910.
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            BrownieSundae s = new();

            Assert.Equal(910u, s.Calories);
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
        [InlineData(true, true, false, 2, IceCreamSauce.HotFudge, 5.99)]
        [InlineData(true, true, false, 2, IceCreamSauce.None, 5.99)]
        [InlineData(true, true, true, 1, IceCreamSauce.HotFudge, 5.99 + .50)]
        [InlineData(false, true, true, 2, IceCreamSauce.None, 5.99 + .50)]
        [InlineData(true, false, true, 3, IceCreamSauce.None, 5.99 + .50)]
        [InlineData(false, false, true, 2, IceCreamSauce.HotFudge, 5.99 + .50)]
        public void PriceCheckingForDifferentIngredientTest(bool whippedCream, bool cherry, bool peanuts, uint scoops, IceCreamSauce sauce, decimal expected) //if scoops is more than 1 do they get += another of the sauce cals?
        {
            BrownieSundae s = new();

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
        [InlineData(true, true, false, 2, IceCreamSauce.HotFudge, 910)]
        [InlineData(true, true, false, 2, IceCreamSauce.None, 910 - 130)]
        [InlineData(true, true, true, 1, IceCreamSauce.HotFudge, 910 + 50)]
        [InlineData(false, true, true, 2, IceCreamSauce.None, 910 - 80 - 130 + 50)]
        [InlineData(true, false, true, 3, IceCreamSauce.None, 910 - 130 - 10 + 50)]
        [InlineData(false, false, true, 2, IceCreamSauce.HotFudge, 910 - 80 - 10 + 50)]
        public void CaloriesCheckingForDifferentIngredientTest(bool whippedCream, bool cherry, bool peanuts, uint scoops, IceCreamSauce sauce, uint expected) //if scoops is more than 1 do they get += another of the sauce cals?
        {
            BrownieSundae s = new();

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
        [InlineData(true, true, false, 2, IceCreamSauce.HotFudge, new string[] { })]
        [InlineData(true, true, false, 2, IceCreamSauce.None, new string[] { "Hold Hot Fudge" })]
        [InlineData(true, true, true, 1, IceCreamSauce.HotFudge, new string[] { "Add Peanuts" })]
        [InlineData(false, true, true, 2, IceCreamSauce.None, new string[] { "Hold Whipped Cream", "Add Peanuts", "Hold Hot Fudge" })]
        [InlineData(true, false, true, 3, IceCreamSauce.None, new string[] { "Hold Cherry", "Add Peanuts", "Hold Hot Fudge" })]
        [InlineData(false, false, true, 2, IceCreamSauce.None, new string[] { "Hold whipped Cream", "Hold Cherry", "Add Peanuts", "Hold Hot Fudge" })]
        public void PrepInfoCheckingForDifferentIngrediantTest(bool whippedCream, bool cherry, bool peanuts, uint scoops, IceCreamSauce sauce, string[] expected) //if scoops is more than 1 do they get += another of the sauce cals?
        {
            BrownieSundae s = new();

            s.WhippedCream = whippedCream;
            s.Cherry = cherry;
            s.Peanuts = peanuts;
            s.Scoops = scoops;
            s.SauceChoice = sauce;

            foreach (string info in s.PreparationInformation)
            {
                Assert.Contains(info, s.PreparationInformation);
            }

            Assert.Equal(expected.Length, s.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests the bounds for the scoops.
        /// </summary>
        /// <param name="scoops">The number of scoops we want to put on this ice cream.</param>
        /// <param name="expected">The number that should actually be on on the sundae.</param>
        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 2)]
        [InlineData(3, 2)]
        [InlineData(0, 2)]
        [InlineData(50, 2)]
        public void CheckBoundsOnScoops(uint scoops, uint expected)
        {
            BrownieSundae s = new() { Scoops = scoops };

            Assert.Equal(expected, s.Scoops);
        }

        /// <summary>
        /// Tests the types of sauce options.
        /// </summary>
        /// <param name="sauce">The type of sauce we are trying to put on this sundae.</param>
        /// <param name="expected">What sauce should actually be on the sundae.</param>
        [Theory]
        [InlineData(IceCreamSauce.HotFudge, IceCreamSauce.HotFudge)]
        [InlineData(IceCreamSauce.None, IceCreamSauce.None)]
        [InlineData(IceCreamSauce.StrawberrySauce, IceCreamSauce.HotFudge)]
        public void CheckSauceOptionsTest(IceCreamSauce sauce, IceCreamSauce expected)
        {
            BrownieSundae s = new() { SauceChoice = sauce };

            Assert.Equal(expected, s.SauceChoice);
        }

        /// <summary>
        /// Checks the values for peanuts.
        /// </summary>
        /// <param name="peanut">If we are adding peanuts.</param>
        /// <param name="expected">If we are actually adding peanuts.</param>
        [Theory]
        [InlineData(false, false)]
        [InlineData(true, true)]
        public void CheckPeanutOptions(bool peanut, bool expected)
        {
            BrownieSundae s = new() { Peanuts = peanut };

            Assert.Equal(expected, s.Peanuts);
        }

        /// <summary>
        /// Checks the values for whipped cream.
        /// </summary>
        /// <param name="whippedCream">If we are adding whipped cream.</param>
        /// <param name="expected">If we are actually adding whipped cream.</param>
        [Theory]
        [InlineData(false, false)]
        [InlineData(true, true)]
        public void CheckWhippedCreamOptions(bool whippedCream, bool expected)
        {
            BrownieSundae s = new() { WhippedCream = whippedCream };

            Assert.Equal(expected, s.WhippedCream);
        }

        /// <summary>
        /// Checks the values for cherry.
        /// </summary>
        /// <param name="cherry">If we are adding cherry.</param>
        /// <param name="expected">If we are actually adding cherry.</param>
        [Theory]
        [InlineData(false, false)]
        [InlineData(true, true)]
        public void CheckCherryOptions(bool cherry, bool expected)
        {
            BrownieSundae s = new() { Cherry = cherry };

            Assert.Equal(expected, s.Cherry);
        }

        /// <summary>
        /// Checks this sundae is part of IMenuItem and is a IceCream.
        /// </summary>
        [Fact]
        public void CheckIsAnIMenuItem()
        {
            BrownieSundae s = new();

            Assert.IsAssignableFrom<IMenuItem>(s);
            Assert.IsAssignableFrom<IceCream>(s);
        }
    }
}
