using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace DairyBarn.DataTests
{
    /// <summary>
    /// Tests the options of items in each list in the menu class.
    /// </summary>
    public class MenuTests
    {
        /// <summary>
        /// Tests 3 options available that are in the list, and 3 options that should not be in the list.
        /// </summary>
        [Fact]
        public void CheckValidAndInvalidOptionsForBurgersTest()
        {
            //classic: 2 cheese, 3 patties, 2 veggie, total: 12
            //BBq: 2 cheese, 2 patties, 2 veggie, total: 8
            //mushroom: 2 cheese, 2 patties, 2 veggie, total: 8
            //BYO: 5 cheese, 3 patties, 2 veggie, total: 30
            //veggie: 2 cheese, 2 patties, total: 4
            //total: 12 + 8 + 8 + 30 + 4 = 62

            Assert.Contains(Menu.Burgers, item => item is ClassicCheeseburger b && b.Patties == 3 && !b.Veggie && b.CheeseChoice == Cheese.American);
            Assert.Contains(Menu.Burgers, item => item is BBQBaconCheeseburger b && b.Patties == 1 && b.Veggie && b.CheeseChoice == Cheese.None);
            Assert.Contains(Menu.Burgers, item => item is BYOBurger b && b.Patties == 2 && !b.Veggie && b.CheeseChoice == Cheese.Swiss);

            Assert.DoesNotContain(Menu.Burgers, item => item is VeggieBurger b && !b.Veggie);
            Assert.DoesNotContain(Menu.Burgers, item => item is MushroomSwissBurger b && b.Patties == 3);
            Assert.DoesNotContain(Menu.Burgers, item => item is BBQBaconCheeseburger b && b.CheeseChoice == Cheese.PepperJack);
        }

        /// <summary>
        /// Tests 3 options available that are in the list, and 3 options that should not be in the list.
        /// </summary>
        [Fact]
        public void CheckValidAndInvalidOptionsForIceCreamTest()
        {
            //classic: 3 scoops, 6 sauce, 2 peanut, 2 cherry, 2 whipped cream, total: 144
            //winter: 6 sauce, 4 mix in, total: 24
            //brownie: 2 sauce, 2 peanut, 2 cherry, 2 whipped cream, total: 16
            //strawberry: 2 sauce, 2 peanut, 2 cherry, 2 whipped cream, total: 16
            //ice cream cone: 2 dipped, 4 cone, 2 scoops, total: 16
            //total: 144 + 24 + 16 + 16 + 16 =  216

            Assert.Contains(Menu.IceCream, item => item is ClassicSundae cs && cs.Scoops == 3 && !cs.Peanuts && cs.Cherry && cs.WhippedCream && cs.SauceChoice == IceCreamSauce.HotFudge);
            Assert.Contains(Menu.IceCream, item => item is IceCreamCone cone && cone.Scoops == 1 && cone.Dipped && cone.TypeOfCone == Cone.Waffle);
            Assert.Contains(Menu.IceCream, item => item is BrownieSundae b && b.SauceChoice == IceCreamSauce.None && b.Peanuts && !b.Cherry && b.WhippedCream);

            Assert.DoesNotContain(Menu.IceCream, item => item is WinterSwirl ws && ws.Scoops == 1);
            Assert.DoesNotContain(Menu.IceCream, item => item is StrawBerryShortcake sb && sb.SauceChoice == IceCreamSauce.Caramel);
            Assert.DoesNotContain(Menu.IceCream, item => item is BrownieSundae b && b.Scoops == 3);
        }

        /// <summary>
        /// Tests 3 options available that are in the list.
        /// </summary>
        [Fact]
        public void CheckValidOptionsForDrinks()
        {
            //coffee: 2 sugar, 2 cream, 2 iced, 2 decaf, 3 cup sizes, total: 48
            //latte: 2 iced, 2 decaf, 2 vanilla, 3 cup sizes, total: 24
            //mocha: 2 iced, 2 decaf, 3 cup sizes, total: 12
            //total: 48 + 24 + 12 = 84

            Assert.Contains(Menu.Drinks, item => item is Coffee c && c.Iced && c.Decaf && c.Cream && !c.Sugar && c.SizeOfCup == CoffeeSize.Tall);
            Assert.Contains(Menu.Drinks, item => item is Latte l && !l.Iced && !l.Decaf && l.Vanilla && l.SizeOfCup == CoffeeSize.Grande);
            Assert.Contains(Menu.Drinks, item => item is Mocha m && m.Iced && !m.Decaf && m.SizeOfCup == CoffeeSize.Venti);
        }

        /// <summary>
        /// Tests to make sure that nothing gets filtered out about price when min and max are null.
        /// </summary>
        [Fact]
        public void FilterWhenBothValuesNullForPriceTest()
        {
            IEnumerable<IMenuItem> result = Menu.FilterByPrice(Menu.FullMenu, null, null);
            Assert.All(result, item => Assert.Contains(item, Menu.FullMenu));
        }

        /// <summary>
        /// Tests to make sure that when min is null all items below the max are available.
        /// </summary>
        [Fact]
        public void FilterWhenMaxIsSetForPriceTest()
        {
            IEnumerable<IMenuItem> result = Menu.FilterByPrice(Menu.FullMenu, null, 5.00m);
            Assert.All(result, item => Assert.Contains(item, Menu.FullMenu.Where(m => m.Price <= 5.00m)));
        }

        /// <summary>
        /// Tests to make sure that when max is null all items avoce min are available.
        /// </summary>
        [Fact]
        public void FilterWhenMinIsSetForPriceTest()
        {
            IEnumerable<IMenuItem> result = Menu.FilterByPrice(Menu.FullMenu, 8.00m, null);
            Assert.All(result, item => Assert.Contains(item, Menu.FullMenu.Where(m => m.Price >= 8.00m)));
        }

        /// <summary>
        /// Tests to make sure that when min is 0 it still filters.
        /// </summary>
        [Fact]
        public void FilterWhenMinIsTheMinValuePriceTest()
        {
            IEnumerable<IMenuItem> result = Menu.FilterByPrice(Menu.FullMenu, 0.00m, 5.00m);
            Assert.All(result, item => Assert.Contains(item, Menu.FullMenu.Where(m => m.Price >= 0.00m && m.Price <= 5.00m)));
        }

        /// <summary>
        /// Tests to make sure that when max is 20.00 it still filters
        /// </summary>
        [Fact]
        public void FilterWhenMaxIsTheMaxValuePriceTest()
        {
            IEnumerable<IMenuItem> result = Menu.FilterByPrice(Menu.FullMenu, 8.00m, 20.00m);
            Assert.All(result, item => Assert.Contains(item, Menu.FullMenu.Where(m => m.Price >= 8.00m && m.Price <= 20.00m)));
        }

        /// <summary>
        /// Tests to make sure than when min and max are equal the only items are that price.
        /// </summary>
        [Fact]
        public void FilterWhenMinAndMaxAreEqualPriceTest()
        {
            IEnumerable<IMenuItem> result = Menu.FilterByPrice(Menu.FullMenu, 6.49m, 6.49m);
            Assert.All(result, item => Assert.Contains(item, Menu.FullMenu.Where(m => m.Price >= 6.49m && m.Price <= 6.49m)));
        }

        /// <summary>
        /// Tests that all items between min and max are available.
        /// </summary>
        [Fact]
        public void FilterWhenItemBetweenMinAndMaxPriceTest()
        {
            IEnumerable<IMenuItem> result = Menu.FilterByPrice(Menu.FullMenu, 2.00m, 7.00m);
            Assert.All(result, item => Assert.Contains(item, Menu.FullMenu.Where(m => m.Price >= 2.00m && m.Price <= 7.00m)));
        }

        /// <summary>
        /// Tests that when both values all null nothing by calories gets filtered.
        /// </summary>
        [Fact]
        public void FilterWhenBothAreNullCaloriesTest()
        {
            IEnumerable<IMenuItem> result = Menu.FilterByCalories(Menu.FullMenu, null, null);
            Assert.All(result, item => Assert.Contains(item, Menu.FullMenu));
        }

        /// <summary>
        /// Tests that when min is null items up to the max are filtered.
        /// </summary>
        [Fact]
        public void FilterWhenMaxIsSetForCaloriesTest()
        {
            IEnumerable<IMenuItem> result = Menu.FilterByCalories(Menu.FullMenu, null, 600);
            Assert.All(result, item => Assert.Contains(item, Menu.FullMenu.Where(m => m.Calories <= 600)));
        }

        /// <summary>
        /// Tests that when max is null items min and up are filtered.
        /// </summary>
        [Fact]
        public void FilterWhenMinIsSetForCaloriesTest()
        {
            IEnumerable<IMenuItem> result = Menu.FilterByCalories(Menu.FullMenu, 200, null);
            Assert.All(result, item => Assert.Contains(item, Menu.FullMenu.Where(m => m.Calories >= 200)));
        }

        /// <summary>
        /// Tests to make sure that when min value is a filter it still filters.
        /// </summary>
        [Fact]
        public void FilterWhenMinIsTheMinValueCaloriesTest()
        {
            IEnumerable<IMenuItem> result = Menu.FilterByCalories(Menu.FullMenu, 0, 500);
            Assert.All(result, item => Assert.Contains(item, Menu.FullMenu.Where(m => m.Calories >= 0 && m.Calories <= 500)));
        }

        /// <summary>
        /// Tests to make sure that when max value is a filter it still filters.
        /// </summary>
        [Fact]
        public void FilterWhenMaxIsTheMaxValueCaloriesTest()
        {
            IEnumerable<IMenuItem> result = Menu.FilterByCalories(Menu.FullMenu, 500, 1500);
            Assert.All(result, item => Assert.Contains(item, Menu.FullMenu.Where(m => m.Calories >= 200 && m.Calories <= 1500)));
        }

        /// <summary>
        /// Tests that when min and max are equal filters to only that number of calories.
        /// </summary>
        [Fact]
        public void FilterWhenMinAndMaxAreEqualCaloriesTest()
        {
            IEnumerable<IMenuItem> result = Menu.FilterByCalories(Menu.FullMenu, 675, 675);
            Assert.All(result, item => Assert.Contains(item, Menu.FullMenu.Where(m => m.Calories >= 675 && m.Calories <= 675)));
        }

        /// <summary>
        /// Tests that items between min and max are filtered.
        /// </summary>
        [Fact]
        public void FilterWhenItemBetweenMinAndMaxCaloriesTest()
        {
            IEnumerable<IMenuItem> result = Menu.FilterByCalories(Menu.FullMenu, 50, 150);
            Assert.All(result, item => Assert.Contains(item, Menu.FullMenu.Where(m => m.Calories >= 50 && m.Calories <= 150)));
        }

        /// <summary>
        /// Class that hard codes menu items to check search filter.
        /// </summary>
        internal class SmallMenu
        {
            /// <summary>
            /// List to add items too.
            /// </summary>
            private List<IMenuItem> _smallList;

            /// <summary>
            /// List that stores the items.
            /// </summary>
            public List<IMenuItem> SmallList => _smallList;

            /// <summary>
            /// The constructor.
            /// </summary>
            internal SmallMenu()
            {
                _smallList = new List<IMenuItem>();
                AddBurgers();
                AddIceCream();
                AddDrinks();
            }

            /// <summary>
            /// Adds the burgers to the list.
            /// </summary>
            private void AddBurgers()
            {
                BYOBurger byob1 = new();
                byob1.Patties = 3u;
                byob1.CheeseChoice = Cheese.PepperJack;
                byob1.Veggie = true;
                _smallList.Add(byob1);

                BYOBurger byob2 = new();
                byob2.Patties = 2u;
                byob2.CheeseChoice = Cheese.PepperJack;
                byob2.Veggie = true;
                _smallList.Add(byob2);

                VeggieBurger veggie1 = new();
                veggie1.Patties = 2u;
                veggie1.CheeseChoice = Cheese.PepperJack;
                _smallList.Add(veggie1);

                ClassicCheeseburger classic1 = new();
                classic1.Patties = 3u;
                classic1.CheeseChoice = Cheese.American;
                classic1.Veggie = true;
                _smallList.Add(classic1);
            }

            /// <summary>
            /// Adds the ice creams to the list.
            /// </summary>
            private void AddIceCream()
            {
                ClassicSundae cs1 = new();
                cs1.Scoops = 3u;
                cs1.SauceChoice = IceCreamSauce.HotFudge;
                cs1.Cherry = true;
                cs1.Peanuts = true;
                cs1.WhippedCream = false;
                _smallList.Add(cs1);

                ClassicSundae cs2 = new();
                cs2.Scoops = 3u;
                cs2.SauceChoice = IceCreamSauce.HotFudge;
                cs2.Cherry = false;
                cs2.Peanuts = true;
                cs2.WhippedCream = true;
                _smallList.Add(cs2);

                BrownieSundae brownie1 = new();
                brownie1.Scoops = 2u;
                brownie1.SauceChoice = IceCreamSauce.ChocolateSauce;
                brownie1.Cherry = false;
                brownie1.Peanuts = true;
                brownie1.WhippedCream = true;
                _smallList.Add(brownie1);

                IceCreamCone cone = new();
                cone.Scoops = 1u;
                cone.TypeOfCone = Cone.Waffle;
                cone.Dipped = true;
                _smallList.Add(cone);

                WinterSwirl ws1 = new();
                ws1.SauceChoice = IceCreamSauce.ChocolateSauce;
            }

            /// <summary>
            /// Adds the drinks to the list.
            /// </summary>
            public void AddDrinks()
            {
                Coffee c1 = new();
                c1.SizeOfCup = CoffeeSize.Grande;
                c1.Sugar = true;
                _smallList.Add(c1);

                Latte l1 = new();
                l1.SizeOfCup = CoffeeSize.Grande;
                l1.Vanilla = true;
                _smallList.Add(l1);

                Mocha m1 = new();
                m1.SizeOfCup = CoffeeSize.Venti;
                _smallList.Add(m1);
            }
        }

        /// <summary>
        /// Tests that all items containing the string are filtered using multiple words.
        /// </summary>
        [Fact]
        public void FilterSearchByThreePattiesAndVeggieBurgerTest()
        {
            SmallMenu small = new();
            IEnumerable<IMenuItem> result = Menu.Search(small.SmallList, "Veggie triple burger");
            Assert.Equal(2, result.Count());
        }

        /// <summary>
        /// Tests that all item containing the strings are filtered using capital letters.
        /// </summary>
        [Fact]
        public void FilterSearchByTwoPattiesAndVeggieBurgerTest()
        {
            SmallMenu small = new();
            IEnumerable<IMenuItem> result = Menu.Search(small.SmallList, "Double VEGGIE");
            Assert.Equal(2, result.Count());
        }

        /// <summary>
        /// Tests that all items containing the strings are filtered using 3 words.
        /// </summary>
        [Fact]
        public void FilterSearchByThreeScoopsAndPeanutsIceCreamTest()
        {
            SmallMenu small = new();
            IEnumerable<IMenuItem> result = Menu.Search(small.SmallList, "3 scoops peanuts");
            Assert.Equal(2, result.Count());
        }

        /// <summary>
        /// Tests that all items containing the string are filtered using 1 word.
        /// </summary>
        [Fact]
        public void FilterSearchByGrandeCoffeeSizeDrinkTest()
        {
            SmallMenu small = new();
            IEnumerable<IMenuItem> result = Menu.Search(small.SmallList, "Grande");
            Assert.Equal(2, result.Count());
        }

        /// <summary>
        /// Tests that all items in the string are filtered using mixed letters.
        /// </summary>
        [Fact]
        public void FilterSearchByGrandeAndCoffeeDrinkTest()
        {
            SmallMenu small = new();
            IEnumerable<IMenuItem> result = Menu.Search(small.SmallList, "Grande CoffEE");
            Assert.Equal(1, result.Count());
        }

        /// <summary>
        /// Tests that no items are filtered because of a string that is not in the name, description, or preparation information.
        /// </summary>
        [Fact]
        public void FilterSearchNothingShouldBeInListTest()
        {
            SmallMenu small = new();
            IEnumerable<IMenuItem> result = Menu.Search(small.SmallList, "venti abc");
            Assert.Equal(0, result.Count());
        }
    }
}
