using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.DataTests
{
    /// <summary>
    /// The unit tests for the IceCreamCone class.
    /// </summary>
    public class IceCreamConeUnitTests
    {
        /// <summary>
        /// Tests that the default scoops is 1.
        /// </summary>
        [Fact]
        public void DefaultScoopsTest()
        {
            IceCreamCone s = new();

            Assert.Equal(1u, s.Scoops);
        }

        /// <summary>
        /// The default value for the dipped property.
        /// </summary>
        [Fact]
        public void DefaultDippedOption()
        {
            IceCreamCone s = new();

            Assert.False(s.Dipped);
        }

        /// <summary>
        /// What the default cone is.
        /// </summary>
        [Fact]
        public void DefaultConeOption()
        {
            IceCreamCone s = new();

            Assert.Equal(Cone.Cake, s.TypeOfCone);
        }

        /// <summary>
        /// Tests that the default price is 2.49.
        /// </summary>
        [Fact]
        public void DefaultPriceTest()
        {
            IceCreamCone s = new();

            Assert.Equal(2.49m, s.Price);
        }

        /// <summary>
        /// Tests that the default calories is 245.
        /// </summary>
        [Fact]
        public void DefaultCaloriesTest()
        {
            IceCreamCone s = new();

            Assert.Equal(245u, s.Calories);
        }

        /// <summary>
        /// Tests different ingredient to make sure the price is right.
        /// </summary>
        /// <param name="dipped">If the cone is dipped.</param>
        /// <param name="typeOfCone">The type of cone.</param>
        /// <param name="scoops">The number of scoops.</param>
        /// <param name="expected">The expected price.</param>
        [Theory]
        [InlineData(false, Cone.Cake, 1, 2.49)]
        [InlineData(false, Cone.Waffle, 1, 2.49 + 1.00)]
        [InlineData(false, Cone.ChocolateWaffle, 1, 2.49 + 1.50)]
        [InlineData(true, Cone.ChocolateWaffle, 1, 2.49 + 1.50 + .50)]
        [InlineData(true, Cone.Waffle, 1, 2.49 + 1.00 + .50)]
        [InlineData(true, Cone.Cake, 1, 2.49 + .50)]
        [InlineData(false, Cone.Cake, 2, 2.49 + 1.00)]
        [InlineData(false, Cone.Waffle, 2, 2.49 + 2.00)]
        [InlineData(false, Cone.ChocolateWaffle, 2, 2.49 + 2.50)]
        [InlineData(true, Cone.ChocolateWaffle, 2, 2.49 + 2.50 + .50)]
        [InlineData(true, Cone.Waffle, 2, 2.49 + 2.00 + .50)]
        [InlineData(true, Cone.Cake, 2, 2.49 + 1.50)]
        [InlineData(true, Cone.None, 1, 2.49 + .50)]
        public void PriceCheckingForDifferentIngredientTest(bool dipped, Cone typeOfCone, uint scoops, decimal expected)
        {
            IceCreamCone s = new();

            s.Dipped = dipped;
            s.TypeOfCone = typeOfCone;
            s.Scoops = scoops;

            Assert.Equal(expected, s.Price);
        }

        /// <summary>
        /// Tests different ingredient to make sure the calories is right.
        /// </summary>
        /// <param name="dipped">If the cone is dipped.</param>
        /// <param name="typeOfCone">The type of cone.</param>
        /// <param name="scoops">The number of scoops.</param>
        /// <param name="expected">The expected calories.</param>
        [Theory]
        [InlineData(false, Cone.Cake, 1, 245)]
        [InlineData(false, Cone.Waffle, 1, 245 - 25 + 130)]
        [InlineData(false, Cone.ChocolateWaffle, 1, 245 - 25 + 180)]
        [InlineData(true, Cone.ChocolateWaffle, 1, 245 - 25 + 180 + 100)]
        [InlineData(true, Cone.Waffle, 1, 245 - 25 + 130 + 100)]
        [InlineData(true, Cone.Cake, 1, 245 + 100)]
        [InlineData(false, Cone.Cake, 2, 245 + 220)]
        [InlineData(false, Cone.Waffle, 2, 245 - 25 + 130 + 220)]
        [InlineData(false, Cone.ChocolateWaffle, 2, 245 - 25 + 220 + 180)]
        [InlineData(true, Cone.ChocolateWaffle, 2, 245 - 25 + 220 + 180 + 100)]
        [InlineData(true, Cone.Waffle, 2, 245 - 25 + 220 + 130 + 100)]
        [InlineData(true, Cone.Cake, 2, 245 + 220 + 100)]
        [InlineData(true, Cone.None, 1, 245 - 25 + 100)]
        public void CaloriesCheckingForDifferentIngredientTest(bool dipped, Cone typeOfCone, uint scoops, uint expected)
        {
            IceCreamCone s = new();

            s.Dipped = dipped;
            s.TypeOfCone = typeOfCone;
            s.Scoops = scoops;

            Assert.Equal(expected, s.Calories);
        }

        /// <summary>
        /// Tests different ingredient to make sure the preparation information is right.
        /// </summary>
        /// <param name="dipped">If the cone is dipped.</param>
        /// <param name="typeOfCone">The type of cone.</param>
        /// <param name="scoops">The number of scoops.</param>
        /// <param name="expected">The expected information.</param>
        [Theory]
        [InlineData(false, Cone.Cake, 1, new string[] { })]
        [InlineData(false, Cone.Waffle, 1, new string[] { "Add Waffle Cone" })]
        [InlineData(false, Cone.ChocolateWaffle, 1, new string[] { "Add Chocolate Waffle Cone" })]
        [InlineData(true, Cone.ChocolateWaffle, 1, new string[] { "Add Chocolate Waffle Cone", "Dipped" })]
        [InlineData(true, Cone.Waffle, 1, new string[] { "Add Waffle Cone", "Dipped" })]
        [InlineData(true, Cone.Cake, 1, new string[] { "Dipped" })]
        [InlineData(false, Cone.Cake, 2, new string[] { "2 Scoops" })]
        [InlineData(false, Cone.Waffle, 2, new string[] { "Add Waffle Cone", "2 Scoops" })]
        [InlineData(false, Cone.ChocolateWaffle, 2, new string[] { "Add Chocolate Waffle Cone", "2 Scoops" })]
        [InlineData(true, Cone.ChocolateWaffle, 2, new string[] { "Add Chocolate Waffle Cone", "2 Scoops", "Dipped" })]
        [InlineData(true, Cone.Waffle, 2, new string[] { "Add Waffle Cone", "2 Scoops", "Dipped" })]
        [InlineData(true, Cone.Cake, 2, new string[] { "2 Scoops", "Dipped" })]
        [InlineData(true, Cone.None, 1, new string[] { "In a Cup", "Dipped" })]
        public void PrepInfoCheckingForDifferentIngredientTest(bool dipped, Cone typeOfCone, uint scoops, string[] expected)
        {
            IceCreamCone s = new();

            s.Dipped = dipped;
            s.TypeOfCone = typeOfCone;
            s.Scoops = scoops;

            foreach(string info in s.PreparationInformation)
            {
                Assert.Contains(info, s.PreparationInformation);
            }

            Assert.Equal(expected.Length, s.PreparationInformation.Count());
        }

        /// <summary>
        /// Tests the bounds for the dipped property.
        /// </summary>
        /// <param name="dipped">If we are dipping the ice cream.</param>
        /// <param name="expected">If we are actually dipping the ice cream.</param>
        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        public void BoundsDippedTest(bool dipped, bool expected)
        {
            IceCreamCone s = new() { Dipped = dipped };

            Assert.Equal(expected, s.Dipped);
        }

        /// <summary>
        /// Tests the bounds for scoops
        /// </summary>
        /// <param name="scoops">The number of scoops we are trying to add.</param>
        /// <param name="expected">The number of scoops actually being added.</param>
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 1)]
        [InlineData(50, 1)]
        public void BoundsScoopsTest(uint scoops, uint expected)
        {
            IceCreamCone s = new() { Scoops = scoops };

            Assert.Equal(expected, s.Scoops);
        }

        /// <summary>
        /// Tests the bounds for the types on cone.
        /// </summary>
        /// <param name="typeOfCone">The type of cone we are adding.</param>
        /// <param name="expected">The type of cone we are actually adding.</param>
        [Theory]
        [InlineData(Cone.Cake, Cone.Cake)]
        [InlineData(Cone.Waffle, Cone.Waffle)]
        [InlineData(Cone.ChocolateWaffle, Cone.ChocolateWaffle)]
        [InlineData(Cone.None, Cone.None)]
        public void BoundsOfConesTest(Cone typeOfCone, Cone expected)
        {
            IceCreamCone s = new() { TypeOfCone = typeOfCone };

            Assert.Equal(expected, s.TypeOfCone);
        }

        /// <summary>
        /// If the ice cream is part of IMenuItem and is an IceCream.
        /// </summary>
        [Fact]
        public void CheckIsAnIMenuItem()
        {
            IceCreamCone s = new();

            Assert.IsAssignableFrom<IMenuItem>(s);
            Assert.IsAssignableFrom<IceCream>(s);
        }
    }
}
