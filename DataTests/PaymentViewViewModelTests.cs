using DairyBarn.PointOfSale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DairyBarn.Data.Burger;

namespace DairyBarn.DataTests
{
    /// <summary>
    /// The tests for the payment control functionality.
    /// </summary>
    public class PaymentViewViewModelTests
    {
        /// <summary>
        /// Tests if the GUI is acting correctly.
        /// </summary>
        [Fact]
        public void TestPaymentViewModelFunctionality()
        {
            Order order = new();
            Assert.Equal(1u, order.OrderNumber);

            PickTwo p2 = new();
            BBQBaconCheeseburger b1 = new();
            b1.Patties = 2;
            b1.AllToppings[BurgerTopping.Bacon].Included = false;
            IceCreamCone cone1 = new();
            cone1.Scoops = 2u;
            cone1.Dipped = true;
            cone1.TypeOfCone = Cone.ChocolateWaffle;

            BYOBurger b2 = new();
            b2.Veggie = true;
            b2.Patties = 3u;
            b2.CheeseChoice = Cheese.Cheddar;
            b2.AllToppings[BurgerTopping.Bacon].Included = true;
            b2.AllToppings[BurgerTopping.Lettuce].Included = true;
            b2.AllToppings[BurgerTopping.Tomato].Included = true;

            Coffee c1 = new();
            c1.SizeOfCup = CoffeeSize.Venti;
            c1.Iced = true;
            c1.Cream = true;

            p2.BurgerChoice = b1;
            p2.IceCreamChoice = cone1;
            order.Add(p2);
            order.Add(b2);
            order.Add(c1);

            Assert.Equal(26.99m, order.Subtotal, 2);
            Assert.Equal(2.47m, order.Tax, 2);
            Assert.Equal(29.46m, order.Total, 2);

            PaymentViewViewModel summary = new(order);
            summary.PaymentAmount = 40.00m;

            Order order2 = new();
            Assert.Equal(2u, order2.OrderNumber);

            Latte c2 = new();
            c2.SizeOfCup = CoffeeSize.Grande;
            c2.Vanilla = true;
            c2.Decaf = true;

            ClassicCheeseburger b3 = new();
            b3.CheeseChoice = Cheese.None;
            b3.AllToppings[BurgerTopping.Lettuce] = new BurgerIngredient(BurgerTopping.Lettuce, "Lettuce", true, false);

            BrownieSundae s1 = new();
            s1.Peanuts = true;
            s1.WhippedCream = false;

            order2.Add(b3);
            order2.Add(s1);
            order2.Add(c2);

            Assert.Equal(17.51m, order2.Subtotal, 2);
            Assert.Equal(1.60m, order2.Tax, 2);
            Assert.Equal(19.11m, order2.Total, 2);

            PaymentViewViewModel summary2 = new(order2);
            Assert.Throws<ArgumentException>( () =>
            {
                summary2.PaymentAmount = 15.00m;
            });
        }

       
    }
}
