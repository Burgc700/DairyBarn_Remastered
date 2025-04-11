using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.DataTests
{
    /// <summary>
    /// The unit tests for the WinterSwirl class.
    /// </summary>
    public class WinterSwirlUnitTests
    {
        /// <summary>
        /// The default number of scoops is 2.
        /// </summary>
        [Fact]
        public void DefaultScoopsTest()
        {
            WinterSwirl s = new();

            Assert.Equal(2u, s.Scoops);
        }

        /// <summary>
        /// The default sauce option is chocolate sauce.
        /// </summary>
        [Fact]
        public void DefaultSauceOptionTest()
        {
            WinterSwirl s = new();

            Assert.Equal(IceCreamSauce.ChocolateSauce, s.SauceChoice);
        }

        /// <summary>
        /// The default mix in is oreos.
        /// </summary>
        [Fact]
        public void DefaultMixInOptionTest()
        {
            WinterSwirl s = new();

            Assert.Equal(IceCreamMixIn.Oreos, s.MixInChoice);
        }

        /// <summary>
        /// The default price is 4.99.
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            WinterSwirl s = new();

            Assert.Equal(4.99m, s.Price);
        }

        /// <summary>
        /// The default calories is 440.
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            WinterSwirl s = new();

            Assert.Equal(680u, s.Calories);
        }

        /// <summary>
        /// Tests different ingredients to make sure the price is right.
        /// </summary>
        /// <param name="sauce">The sauce we are adding.</param>
        /// <param name="mixIn">The mix in we are adding.</param>
        /// <param name="expected">The expected price.</param>
        [Theory]
        [InlineData(IceCreamSauce.ChocolateSauce, IceCreamMixIn.Oreos, 4.99)]
        [InlineData(IceCreamSauce.ChocolateSauce, IceCreamMixIn.Reeses, 4.99)]
        [InlineData(IceCreamSauce.ChocolateSauce, IceCreamMixIn.CookieDough, 4.99)]
        [InlineData(IceCreamSauce.ChocolateSauce, IceCreamMixIn.MandMs, 4.99)]
        [InlineData(IceCreamSauce.Caramel, IceCreamMixIn.MandMs, 4.99)]
        [InlineData(IceCreamSauce.StrawberrySauce, IceCreamMixIn.CookieDough, 4.99)]
        [InlineData(IceCreamSauce.HotFudge, IceCreamMixIn.Reeses, 4.99)]
        [InlineData(IceCreamSauce.CrushedPineapple, IceCreamMixIn.MandMs, 4.99)]
        [InlineData(IceCreamSauce.None, IceCreamMixIn.Oreos, 4.99)]
        public void PriceCheckingForDifferentIngredientTest(IceCreamSauce sauce, IceCreamMixIn mixIn, decimal expected)
        {
            WinterSwirl s = new();

            s.SauceChoice = sauce;
            s.MixInChoice = mixIn;

            Assert.Equal(expected, s.Price);
        }

        /// <summary>
        /// Tests different ingredients to make sure the calories is right.
        /// </summary>
        /// <param name="sauce">The sauce we are adding.</param>
        /// <param name="mixIn">The mix in we are adding.</param>
        /// <param name="expected">The expected calories.</param>
        [Theory]
        [InlineData(IceCreamSauce.ChocolateSauce, IceCreamMixIn.Oreos, 680)]
        [InlineData(IceCreamSauce.ChocolateSauce, IceCreamMixIn.Reeses, 220 * 2 + 90 + 80)]
        [InlineData(IceCreamSauce.ChocolateSauce, IceCreamMixIn.CookieDough, 220 * 2 + 90 + 80)]
        [InlineData(IceCreamSauce.ChocolateSauce, IceCreamMixIn.MandMs, 220 * 2 + 120 + 80)]
        [InlineData(IceCreamSauce.Caramel, IceCreamMixIn.MandMs, 220 * 2 + 130 + 120)]
        [InlineData(IceCreamSauce.StrawberrySauce, IceCreamMixIn.CookieDough, 220 * 2 + 40 + 90)]
        [InlineData(IceCreamSauce.HotFudge, IceCreamMixIn.Reeses, 220 * 2 + 130 + 90)]
        [InlineData(IceCreamSauce.CrushedPineapple, IceCreamMixIn.MandMs, 220 * 2 + 50 + 120)]
        [InlineData(IceCreamSauce.None, IceCreamMixIn.Oreos, 220 * 2 + 160)]
        [InlineData(IceCreamSauce.Caramel, IceCreamMixIn.CookieDough, 220*2+90+130)]
        public void CaloriesCheckingForDifferentIngredientTest(IceCreamSauce sauce, IceCreamMixIn mixIn, uint expected)
        {
            WinterSwirl s = new();

            s.SauceChoice = sauce;
            s.MixInChoice = mixIn;

            Assert.Equal(expected, s.Calories);
        }

        /// <summary>
        /// Tests different ingredients to make sure the preparation information is right.
        /// </summary>
        /// <param name="sauce">The sauce we are adding.</param>
        /// <param name="mixIn">The mix in we are adding.</param>
        /// <param name="expected">The expected information.</param>
        [Theory]
        [InlineData(IceCreamSauce.ChocolateSauce, IceCreamMixIn.Oreos, new string[] { })]
        [InlineData(IceCreamSauce.ChocolateSauce, IceCreamMixIn.Reeses, new string[] { "Reeses" })]
        [InlineData(IceCreamSauce.ChocolateSauce, IceCreamMixIn.CookieDough, new string[] { "Cookie Dough" })]
        [InlineData(IceCreamSauce.ChocolateSauce, IceCreamMixIn.MandMs, new string[] { "M&M's"})]
        [InlineData(IceCreamSauce.Caramel, IceCreamMixIn.MandMs, new string[] { "Caramel", "M&M's" })]
        [InlineData(IceCreamSauce.StrawberrySauce, IceCreamMixIn.CookieDough, new string[] { "Strawberry Sauce", "Cookie Dough" })]
        [InlineData(IceCreamSauce.HotFudge, IceCreamMixIn.Reeses, new string[] { "Hot Fudge", "Reeses" })]
        [InlineData(IceCreamSauce.CrushedPineapple, IceCreamMixIn.MandMs, new string[] { "Crushed Pineapple", "M&M's" })]
        [InlineData(IceCreamSauce.None, IceCreamMixIn.Oreos, new string[] { "Hold Chocolate Sauce" })]
        public void PrepInfoCheckingForDifferentIngredientTest(IceCreamSauce sauce, IceCreamMixIn mixIn, string[] expected)
        {
            WinterSwirl s = new();

            s.SauceChoice = sauce;
            s.MixInChoice = mixIn;

            foreach(string info in expected)
            {
                Assert.Contains(info, s.PreparationInformation);
            }

            Assert.Equal(expected.Length, s.PreparationInformation.Count());
        }

        /// <summary>
        /// Checks the bounds for scoops.
        /// </summary>
        /// <param name="scoops">The number of scoops we want.</param>
        /// <param name="expected">The number on scoops we are getting.</param>
        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 2)]
        [InlineData(3, 2)]
        [InlineData(0, 2)]
        [InlineData(50, 2)]
        public void CheckBoundsOnScoopsTest(uint scoops, uint expected)
        {
            WinterSwirl s = new() { Scoops = scoops };

            Assert.Equal(expected, s.Scoops);
        }

        /// <summary>
        /// Tests the different types of sauce.
        /// </summary>
        /// <param name="sauce">The type of sauce we want.</param>
        /// <param name="expected">The type of sauce we are getting.</param>
        [Theory]
        [InlineData(IceCreamSauce.HotFudge, IceCreamSauce.HotFudge)]
        [InlineData(IceCreamSauce.None, IceCreamSauce.None)]
        [InlineData(IceCreamSauce.StrawberrySauce, IceCreamSauce.StrawberrySauce)]
        [InlineData(IceCreamSauce.Caramel, IceCreamSauce.Caramel)]
        [InlineData(IceCreamSauce.ChocolateSauce, IceCreamSauce.ChocolateSauce)]
        [InlineData(IceCreamSauce.CrushedPineapple, IceCreamSauce.CrushedPineapple)]
        public void CheckSauceOptionsTest(IceCreamSauce sauce, IceCreamSauce expected)
        {
            WinterSwirl s = new() { SauceChoice = sauce };

            Assert.Equal(expected, s.SauceChoice);
        }

        /// <summary>
        /// Tests the different mix in options.
        /// </summary>
        /// <param name="mixIn">The mix in option we want.</param>
        /// <param name="expected">The mix in options we get.</param>
        [Theory]
        [InlineData(IceCreamMixIn.Oreos, IceCreamMixIn.Oreos)]
        [InlineData(IceCreamMixIn.MandMs, IceCreamMixIn.MandMs)]
        [InlineData(IceCreamMixIn.CookieDough, IceCreamMixIn.CookieDough)]
        [InlineData(IceCreamMixIn.Reeses, IceCreamMixIn.Reeses)]
        public void CheckMixInOptionsTest(IceCreamMixIn mixIn, IceCreamMixIn expected)
        {
            WinterSwirl s = new() { MixInChoice = mixIn };

            Assert.Equal(expected, s.MixInChoice);
        }

        /// <summary>
        /// Makes sure this sundae is part of IMenuItem and ice cream.
        /// </summary>
        [Fact]
        public void CheckIsAnIMenuItemTest()
        {
            WinterSwirl s = new();

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
            WinterSwirl s = new();

            Assert.Equal("Winter Swirl", s.Name);
        }

        /// <summary>
        /// Tests if the mix in choice changes as the value changes.
        /// </summary>
        /// <param name="mixIn">The type of mix in in the ice cream.</param>
        /// <param name="property">The property name we are checking to see if it changed.</param>
        [Theory]
        [InlineData(IceCreamMixIn.Oreos, "MixInChoice")]
        [InlineData(IceCreamMixIn.Reeses, "Calories")]
        [InlineData(IceCreamMixIn.MandMs, "PreparationInformation")]
        [InlineData(IceCreamMixIn.CookieDough, "MixInChoice")]
        [InlineData(IceCreamMixIn.Oreos, "Calories")]
        [InlineData(IceCreamMixIn.Reeses, "PreparationInformation")]
        [InlineData(IceCreamMixIn.MandMs, "MixInChoice")]
        [InlineData(IceCreamMixIn.CookieDough, "Calories")]
        public void ChangingMixInChoiceNotifyPropertyChanged(IceCreamMixIn mixIn, string property)
        {
            WinterSwirl s = new();
            Assert.PropertyChanged(s, property, () =>
            {
                s.MixInChoice = mixIn;
            });
        }

        /// <summary>
        /// Tests if the sauce choice changes as the value changes.
        /// </summary>
        /// <param name="sauce">The sauce on the ice cream.</param>
        /// <param name="property">The property name we are checking to see if it changed.</param>
        [Theory]
        [InlineData(IceCreamSauce.Caramel, "SauceChoice")]
        [InlineData(IceCreamSauce.CrushedPineapple, "Calories")]
        [InlineData(IceCreamSauce.ChocolateSauce, "PreparationInformation")]
        [InlineData(IceCreamSauce.HotFudge, "SauceChoice")]
        [InlineData(IceCreamSauce.StrawberrySauce, "Calories")]
        [InlineData(IceCreamSauce.Caramel, "PreparationInformation")]
        [InlineData(IceCreamSauce.None, "SauceChoice")]
        [InlineData(IceCreamSauce.ChocolateSauce, "Calories")]
        public void ChangingSauceChoiceNotifyPropertyChanged(IceCreamSauce sauce, string property)
        {
            WinterSwirl s = new();
            Assert.PropertyChanged(s, property, () =>
            {
                s.SauceChoice = sauce;
            });
        }
    }
}
