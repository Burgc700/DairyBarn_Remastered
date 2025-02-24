using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.DataTests
{
    /// <summary>
    /// The unit tests for the Order Collection class.
    /// </summary>
    public class OrderUnitTests
    {
        /// <summary>
        /// A mock menu item for testing
        /// </summary>
        internal class MockMenuItem : IMenuItem
        {
            /// <summary>
            /// The name of the mock menu item.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// The description of the mock menu item.
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// The price of the mock menu item.
            /// </summary>
            public decimal Price { get; set; }

            /// <summary>
            /// The calories of the mock menu item.
            /// </summary>
            public uint Calories { get; set; }

            /// <summary>
            /// The preparation information for the mock menu item.
            /// </summary>
            public IEnumerable<string> PreparationInformation { get; set; }
        }

        /// <summary>
        /// Tests the subtotal adds the prices of all items.
        /// </summary>
        [Fact]
        public void SubtotalShouldReflectItemPricesTest()
        {
            Order o = new Order();

            o.Add(new MockMenuItem() { Price = 1.00m });
            o.Add(new MockMenuItem() { Price = 2.50m });
            o.Add(new MockMenuItem() { Price = 3.00m });

            Assert.Equal(6.50m, o.Subtotal, 2);
        }

        /// <summary>
        /// Tests the default tax rate is 0.0915.
        /// </summary>
        [Fact]
        public void DefaultTaxRate()
        {
            Order o = new();

            Assert.Equal(0.0915m, o.TaxRate, 4);
        }

        /// <summary>
        /// Tests that the tax is the tax rate times the subtotal
        /// </summary>
        [Fact]
        public void TaxShouldReflectItemsTest()
        {
            Order o = new();

            o.Add(new MockMenuItem() { Price = 2.00m });
            o.Add(new MockMenuItem() { Price = 3.50m });
            o.Add(new MockMenuItem() { Price = 5.50m });

            Assert.Equal((decimal)(2.00 + 3.50 + 5.50) * o.TaxRate, o.Tax, 4);
        }

        /// <summary>
        /// Tests that the total price is correct.
        /// </summary>
        [Fact]
        public void TotalShouldReflectItemsTest()
        {
            Order o = new();

            o.Add(new MockMenuItem() { Price = 2.50m });
            o.Add(new MockMenuItem() { Price = 6.50m });
            o.Add(new MockMenuItem() { Price = 2.00m });

            decimal sub = 11.00m;
            decimal tax = sub * o.TaxRate;

            Assert.Equal(sub + tax, o.Total, 2);
        }

        /// <summary>
        /// Makes sure the count property keeps track of the items in the order.
        /// </summary>
        [Fact]
        public void TestCountTest()
        {
            Order o = new();

            o.Add(new MockMenuItem());
            o.Add(new MockMenuItem());
            o.Add(new MockMenuItem());

            Assert.Equal(3, o.Count);
        }

        /// <summary>
        /// Tests the readonly property is false.
        /// </summary>
        [Fact]
        public void DefaultReadOnlyTest()
        {
            Order o = new();

            Assert.False(o.IsReadOnly);
        }

        /// <summary>
        /// Makes sure the default subtotal is 0.
        /// </summary>
        [Fact]
        public void DefaultSubtotalTest()
        {
            Order o = new();

            Assert.Equal(0, o.Subtotal);
        }

        /// <summary>
        /// Makes sure the default total is 0.
        /// </summary>
        [Fact]
        public void DefaultTotalTest()
        {
            Order o = new();

            Assert.Equal(0, o.Total);
        }

        /// <summary>
        /// Makes sure the default tax is 0.
        /// </summary>
        [Fact]
        public void DefaultTaxTest()
        {
            Order o = new();

            Assert.Equal(0, o.Tax);
        }
    }
}
