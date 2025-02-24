using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of BBQBaconCheeseburger class
    /// </summary>
    public class BBQBaconCheeseburger : Burger
    {
        /// <summary>
        /// The name of the BBQBaconCheeseBurger instance
        /// </summary>
        public override string Name { get; } = "BBQ Bacon Cheeseburger";

        /// <summary>
        /// The description of this burger
        /// </summary>
        public override string Description { get; } = "A burger with smoky barbecue sauce, cheddar cheese, bacon, and crispy fried onions on top of a toasted bun";

        /// <summary>
        /// If the patties are veggie patties.
        /// </summary>
        public override bool Veggie
        {
            get => _veggie;
            set
            {
                _veggie = value;

            }
        }

        /// <summary>
        /// The constructor
        /// </summary>
        public BBQBaconCheeseburger()
        {
            _startingCals = 150;
            _startingPrice = 7.29m;
            _maxPatties = 2;
            _patties = 1;
            _veggie = false;
            _defaultCheese = Cheese.Cheddar;
            _cheeseChoice = Cheese.Cheddar;
            CheeseOptions.Add(_defaultCheese);
            CheeseOptions.Add(Cheese.None);
            AllToppings[BurgerTopping.Bacon] = new BurgerIngredient(BurgerTopping.Bacon, "Bacon", true, true);
            AllToppings[BurgerTopping.BBQSauce] = new BurgerIngredient(BurgerTopping.BBQSauce, "BBQ Sauce", true, true);
            AllToppings[BurgerTopping.CrispyFriedOnions] = new BurgerIngredient(BurgerTopping.CrispyFriedOnions, "Crispy Fried Onions", true, true);
        }
    }
}
