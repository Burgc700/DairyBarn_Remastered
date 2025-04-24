using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
