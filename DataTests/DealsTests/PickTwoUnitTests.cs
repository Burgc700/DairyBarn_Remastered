using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.DataTests
{
    /// <summary>
    /// The unit tests for the PickTwo class.
    /// </summary>
    public class PickTwoUnitTests
    {
        /// <summary>
        /// Makes sure pick two is part of IMenuItem.
        /// </summary>
        [Fact]
        public void CastPickTwoToIMenuItem()
        {
            PickTwo two = new();

            Assert.IsAssignableFrom<IMenuItem>(two);
            Assert.IsAssignableFrom<INotifyPropertyChanged>(two);
        }

        /// <summary>
        /// Checks the default cheeseburger.
        /// </summary>
        [Fact]
        public void DefaultBurgerTest()
        {
            PickTwo two = new();

            Assert.IsType<ClassicCheeseburger>(two.BurgerChoice);
        }

        /// <summary>
        /// Checks the default ice cream.
        /// </summary>
        [Fact]
        public void DefaultIceCreamTest()
        {
            PickTwo two = new();

            Assert.IsType<ClassicSundae>(two.IceCreamChoice);
        }

        /// <summary>
        /// Tests the total calories of the burger and ice cream.
        /// </summary>
        [Fact]
        public void TestCaloriesTest()
        {
            PickTwo two = new();

            Assert.Equal((uint)(615 + 350), two.Calories);
        }
        
        /// <summary>
        /// Tests the combined price of the burger and ice cream with 75% off.
        /// </summary>
        [Fact]
        public void TestPriceWith25PercentOffTest()
        {
            PickTwo two = new();

            Assert.Equal((3.49m + 6.29m) * .75m, two.Price);
        }

        /// <summary>
        /// Tests to make sure that the right name is returned.
        /// </summary>
        [Fact]
        public void FindNameTest()
        {
            PickTwo two = new();

            Assert.Equal("Pick Two", two.Name);
        }

        /// <summary>
        /// Tests to make sure the property changes when the value changes for the BurgerChoice.
        /// </summary>
        /// <param name="property">The property we are checking see changed.</param>
        [Theory]
        [InlineData("BurgerChoice")]
        [InlineData("BurgerOptions")]
        [InlineData("Price")]
        [InlineData("Calories")]
        [InlineData("PreparationInformation")]
        public void ChangingBurgerChoiceInvokesPropertyChanged(string property)
        {
            PickTwo two = new();
            Assert.PropertyChanged(two, property, () =>
            {
                two.BurgerChoice = new BBQBaconCheeseburger();
            });
        }

        /// <summary>
        /// Tests to make sure the property changes when the value changes for IceCreamChoice.
        /// </summary>
        /// <param name="property">The property we are checking see changed.</param>
        [Theory]
        [InlineData("IceCreamChoice")]
        [InlineData("IceCreamOptions")]
        [InlineData("Price")]
        [InlineData("Calories")]
        [InlineData("PreparationInformation")]
        public void ChangingIceCreamChoiceChoiceInvokesPropertyChanged(string property)
        {
            PickTwo two = new();
            Assert.PropertyChanged(two, property, () =>
            {
                two.IceCreamChoice = new StrawBerryShortcake();
            });
        }
    }
}
