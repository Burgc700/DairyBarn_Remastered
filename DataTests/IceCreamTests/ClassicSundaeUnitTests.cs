using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.DataTests
{
    /// <summary>
    /// The unit tests for the ClassicSundae class.
    /// </summary>
    public class ClassicSundaeUnitTests
    {
        /// <summary>
        /// Tests the default scoops is 1.
        /// </summary>
        [Fact]
        public void DefaultScoopsTest()
        {
            ClassicSundae s = new();

            Assert.Equal(1u, s.Scoops);
        }

        /// <summary>
        /// Tests the default sauce on this sundae.
        /// </summary>
        [Fact]
        public void DefaultSauceOptionTest()
        {
            ClassicSundae s = new();

            Assert.Equal(IceCreamSauce.HotFudge, s.SauceChoice);
        }

        /// <summary>
        /// Checks the other toppings default values.
        /// </summary>
        [Fact]
        public void ToppingsDefaultTest()
        {
            ClassicSundae s = new();

            Assert.False(s.WhippedCream);
            Assert.False(s.Cherry);
            Assert.False(s.Peanuts);
        }

        /// <summary>
        /// Makes sure the default price is 3.49.
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            ClassicSundae s = new();

            Assert.Equal(3.49m, s.Price);
        }

        /// <summary>
        /// Makes sure the default calories is 350.
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            ClassicSundae s = new();

            Assert.Equal(350u, s.Calories);
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
        [InlineData(false, false, false, 1, IceCreamSauce.HotFudge, 3.49)]
        [InlineData(false, false, false, 2, IceCreamSauce.HotFudge, 3.49 + 1.00)]
        [InlineData(false, false, false, 3, IceCreamSauce.HotFudge, 3.49 + 2.00)]
        [InlineData(false, false, true, 1, IceCreamSauce.ChocolateSauce, 3.49 + .50)]
        [InlineData(true, false, true, 2, IceCreamSauce.StrawberrySauce, 3.49 + 1.00 + 1.00)]
        [InlineData(false, true, false, 3, IceCreamSauce.Caramel, 3.49 + 2.00)]
        [InlineData(true, true, true, 2, IceCreamSauce.CrushedPineapple, 3.49 + 1.00 + 1.00)]
        public void PriceCheckingForDifferentIngredientTest(bool whippedCream, bool cherry, bool peanuts, uint scoops, IceCreamSauce sauce, decimal expected)
        {
            ClassicSundae s = new();

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
        [InlineData(false, false, false, 1, IceCreamSauce.HotFudge, 350)]
        [InlineData(false, false, false, 2, IceCreamSauce.HotFudge, 350 + 220)]
        [InlineData(false, false, false, 3, IceCreamSauce.HotFudge, 350 + 440)]
        [InlineData(false, false, true, 1, IceCreamSauce.ChocolateSauce, 350 - 130 + 50 + 80)]
        [InlineData(true, false, true, 2, IceCreamSauce.StrawberrySauce, 350 - 130 + 80 + 220 + 50 + 40)]
        [InlineData(false, true, false, 3, IceCreamSauce.Caramel, 350 + 10 + 440)]
        [InlineData(true, true, true, 2, IceCreamSauce.CrushedPineapple, 350 + 80 + 50 + 10 + 220 - 130 + 50)]
        [InlineData(true, true, false, 1, IceCreamSauce.None, 350 + 80 + 10 - 130)]
        public void CaloriesCheckingForDifferentIngredientTest(bool whippedCream, bool cherry, bool peanuts, uint scoops, IceCreamSauce sauce, uint expected)
        {
            ClassicSundae s = new();

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
        [InlineData(false, false, false, 1, IceCreamSauce.HotFudge, new string[] { "1 Scoop" })]
        [InlineData(false, false, false, 2, IceCreamSauce.HotFudge, new string[] { "2 Scoops" })]
        [InlineData(false, false, false, 3, IceCreamSauce.HotFudge, new string[] { "3 Scoops" })]
        [InlineData(false, false, true, 1, IceCreamSauce.ChocolateSauce, new string[] { "Add Peanuts", "Add Chocolate Sauce", "1 Scoop" })]
        [InlineData(true, false, true, 2, IceCreamSauce.StrawberrySauce, new string[] { "Add Whipped Cream", "Add Peanuts", "2 Scoops", "Add Strawberry Sauce" })]
        [InlineData(false, true, false, 3, IceCreamSauce.Caramel, new string[] { "Add Cherry", "3 Scoops", "Add Caramel" })]
        [InlineData(true, true, true, 2, IceCreamSauce.CrushedPineapple, new string[] { "Add Whipped Cream", "Add Cherry", "Add Peanuts", "2 Scoops", "Add Crushed Pineapple" })]
        [InlineData(true, true, false, 1, IceCreamSauce.None, new string[] { "Add Whipped Cream", "Add Cherry", "1 Scoop", "Hold Hot Fudge" })]
        public void PrepInfoCheckingForDifferentIngredientTest(bool whippedCream, bool cherry, bool peanuts, uint scoops, IceCreamSauce sauce, string[] expected)
        {
            ClassicSundae s = new();

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
        /// Checks the bounds on the number of scoops.
        /// </summary>
        /// <param name="scoops">The scoops we are trying to put in the sundae.</param>
        /// <param name="expected">The expected number of scoops.</param>
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(0, 1)]
        [InlineData(4, 1)]
        [InlineData(50, 1)]
        public void CheckBoundsOnScoops(uint scoops, uint expected)
        {
            ClassicSundae s = new() { Scoops = scoops };

            Assert.Equal(expected, s.Scoops);
        }

        /// <summary>
        /// Checks the types of sauces we can add to this sundae.
        /// </summary>
        /// <param name="sauce">The type of sauce we want to add.</param>
        /// <param name="expected">The sauce we expecting.</param>
        [Theory]
        [InlineData(IceCreamSauce.HotFudge, IceCreamSauce.HotFudge)]
        [InlineData(IceCreamSauce.None, IceCreamSauce.None)]
        [InlineData(IceCreamSauce.StrawberrySauce, IceCreamSauce.StrawberrySauce)]
        [InlineData(IceCreamSauce.Caramel, IceCreamSauce.Caramel)]
        [InlineData(IceCreamSauce.ChocolateSauce, IceCreamSauce.ChocolateSauce)]
        [InlineData(IceCreamSauce.CrushedPineapple, IceCreamSauce.CrushedPineapple)]
        public void CheckSauceOptionsTest(IceCreamSauce sauce, IceCreamSauce expected)
        {
            ClassicSundae s = new() { SauceChoice = sauce };

            Assert.Equal(expected, s.SauceChoice);
        }

        /// <summary>
        /// Tests the values for peanut.
        /// </summary>
        /// <param name="peanut">If we are trying to add peanuts.</param>
        /// <param name="expected">If we are actually adding peanuts.</param>
        [Theory]
        [InlineData(false, false)]
        [InlineData(true, true)]
        public void CheckPeanutOptions(bool peanut, bool expected)
        {
            ClassicSundae s = new() { Peanuts = peanut };

            Assert.Equal(expected, s.Peanuts);
        }

        /// <summary>
        /// Tests the values of whipped cream.
        /// </summary>
        /// <param name="whippedCream">If we are trying to add whipped cream.</param>
        /// <param name="expected">If we are actually adding whipped cream.</param>
        [Theory]
        [InlineData(false, false)]
        [InlineData(true, true)]
        public void CheckWhippedCreamOptions(bool whippedCream, bool expected)
        {
            ClassicSundae s = new() { WhippedCream = whippedCream };

            Assert.Equal(expected, s.WhippedCream);
        }

        /// <summary>
        /// Tests the values of cherry.
        /// </summary>
        /// <param name="cherry">If we are trying to add cherry.</param>
        /// <param name="expected">If we are actually adding cherry.</param>
        [Theory]
        [InlineData(false, false)]
        [InlineData(true, true)]
        public void CheckCherryOptions(bool cherry, bool expected)
        {
            ClassicSundae s = new() { Cherry = cherry };

            Assert.Equal(expected, s.Cherry);
        }

        /// <summary>
        /// If this sundae is part of IMenuItem and is a Icecream.
        /// </summary>
        [Fact]
        public void CheckIsAnIMenuItem()
        {
            ClassicSundae s = new();

            Assert.IsAssignableFrom<IMenuItem>(s);
            Assert.IsAssignableFrom<IceCream>(s);
        }
    }
}
