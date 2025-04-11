using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            Assert.Equal(660u, s.Calories);
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
        [InlineData(true, true, false, 2, IceCreamSauce.HotFudge, 220 * 2 + 130 + 80 + 10)]
        [InlineData(true, true, false, 2, IceCreamSauce.None, 220 * 2 + 80 + 10)]
        [InlineData(true, true, true, 1, IceCreamSauce.HotFudge, 220 * 2 + 130 + 80 + 10 + 50)]
        [InlineData(false, true, true, 2, IceCreamSauce.None, 220 * 2 + 50 + 10)]
        [InlineData(true, false, true, 3, IceCreamSauce.None, 220 * 2 + 50 + 80)]
        [InlineData(false, false, true, 2, IceCreamSauce.HotFudge, 220 * 2 + 130 + 50)]
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
        [InlineData(true, true, true, 1, IceCreamSauce.HotFudge, new string[] { "Peanuts" })]
        [InlineData(false, true, true, 2, IceCreamSauce.None, new string[] { "Peanuts", "Hold Hot Fudge", "Hold Whipped Cream" })]
        [InlineData(true, false, true, 3, IceCreamSauce.None, new string[] { "Peanuts", "Hold Cherry", "Hold Hot Fudge" })]
        [InlineData(false, false, true, 2, IceCreamSauce.None, new string[] { "Add Peanuts", "Hold Hot Fudge", "Hold Whipped Cream", "Hold Cherry" })]
        public void PrepInfoCheckingForDifferentIngredientTest(bool whippedCream, bool cherry, bool peanuts, uint scoops, IceCreamSauce sauce, string[] expected) //if scoops is more than 1 do they get += another of the sauce cals?
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
        public void CheckBoundsOnScoopsTest(uint scoops, uint expected)
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
        public void CheckPeanutOptionsTest(bool peanut, bool expected)
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
        public void CheckWhippedCreamOptionsTest(bool whippedCream, bool expected)
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
        public void CheckCherryOptionsTest(bool cherry, bool expected)
        {
            BrownieSundae s = new() { Cherry = cherry };

            Assert.Equal(expected, s.Cherry);
        }

        /// <summary>
        /// Checks this sundae is part of IMenuItem and is a IceCream.
        /// </summary>
        [Fact]
        public void CheckIsAnIMenuItemTest()
        {
            BrownieSundae s = new();

            Assert.IsAssignableFrom<IMenuItem>(s);
            Assert.IsAssignableFrom<IceCream>(s);
            Assert.IsAssignableFrom<INotifyPropertyChanged>(s);
        }

        /// <summary>
        /// Tests to make sure that the right name is returned.
        /// </summary>
        [Fact]
        public void FindNameTest()
        {
            BrownieSundae s = new();

            Assert.Equal("Brownie Sundae", s.Name);
        }

        /// <summary>
        /// Tests if the sauce choice changes as the value changes.
        /// </summary>
        /// <param name="sauce">Type of sauce on </param>
        /// <param name="property">The name of the property we checking to see if it changes.</param>
        [Theory]
        [InlineData(IceCreamSauce.HotFudge, "SauceChoice")]
        [InlineData(IceCreamSauce.HotFudge, "Calories")]
        [InlineData(IceCreamSauce.HotFudge, "PreparationInformation")]
        [InlineData(IceCreamSauce.None, "SauceChoice")]
        [InlineData(IceCreamSauce.None, "Calories")]
        [InlineData(IceCreamSauce.None, "PreparationInformation")]
        public void ChangingSauceOptionsNotifyPropertyChanged(IceCreamSauce sauce, string property)
        {
            BrownieSundae s = new();
            Assert.PropertyChanged(s, property, () =>
            {
                s.SauceChoice = sauce;
            });
        }

        /// <summary>
        /// Tests if the Whipped cream property changes as the value changes.
        /// </summary>
        /// <param name="whippedCream">If the sundae has whipped cream.</param>
        /// <param name="property">the name of the property we are checking to see if it changes.</param>
        [Theory]
        [InlineData(true, "WhippedCream")]
        [InlineData(true, "Calories")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "WhippedCream")]
        [InlineData(false, "Calories")]
        [InlineData(false, "PreparationInformation")]
        public void ChangingWhippedCreamNotifyPropertyChanged(bool whippedCream, string property)
        {
            BrownieSundae s = new();
            Assert.PropertyChanged(s, property, () =>
            {
                s.WhippedCream = whippedCream;
            });
        }

        /// <summary>
        /// Tests if the cherry property changes as the value changes.
        /// </summary>
        /// <param name="cherry">If the sundae has a cherry.</param>
        /// <param name="property">The name of the property we are checking to see if it changes.</param>
        [Theory]
        [InlineData(true, "Cherry")]
        [InlineData(true, "Calories")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "Cherry")]
        [InlineData(false, "Calories")]
        [InlineData(false, "PreparationInformation")]
        public void ChangingCherryNotifyPropertyChanged(bool cherry, string property)
        {
            BrownieSundae s = new();
            Assert.PropertyChanged(s, property, () =>
            {
                s.Cherry = cherry;
            });
        }

        /// <summary>
        /// Tests if the peanuts property changes as the value changes.
        /// </summary>
        /// <param name="peanut">If the sundae has peanuts.</param>
        /// <param name="property">The name of the property we are checking to see if it changes.</param>
        [Theory]
        [InlineData(true, "Peanuts")]
        [InlineData(true, "Price")]
        [InlineData(true, "Calories")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "Peanuts")]
        [InlineData(false, "Price")]
        [InlineData(false, "Calories")]
        [InlineData(false, "PreparationInformation")]
        public void ChangingPeanutNotifyPropertyChanged(bool peanut, string property)
        {
            BrownieSundae s = new();
            Assert.PropertyChanged(s, property, () =>
            {
                s.Peanuts = peanut;
            });
        }
    }
}
