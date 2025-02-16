using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of ClassicCheeseburger class
    /// </summary>
    public class ClassicCheeseburger : Burger
    {
        /// <summary>
        /// The name of the ClassicCheeseburger class
        /// </summary>
        public override string Name { get; } = "Classic Cheeseburger";

        /// <summary>
        /// The description of this burger
        /// </summary>
        public override string Description { get; } = "Traditional cheeseburger with American cheese, ketchup, mustard, onions, and pickles on a toasted bun";

        /// <summary>
        /// The constructor
        /// </summary>
        public ClassicCheeseburger()
        {
            _startingCals = 615;
            _startingPrice = 6.29m;
            _maxPatties = 3;
            _defaultCheese = Cheese.American;
            _cheeseChoice = Cheese.American;
            CheeseOptions.Add(_defaultCheese);
            CheeseOptions.Add(Cheese.None);
            AllToppings[BurgerTopping.Ketchup] = new BurgerIngredient(BurgerTopping.Ketchup, "Ketchup", true, true);
            AllToppings[BurgerTopping.Mustard] = new BurgerIngredient(BurgerTopping.Mustard, "Mustard", true, true);
            AllToppings[BurgerTopping.Onions] = new BurgerIngredient(BurgerTopping.Onions, "Onions", true, true);
            AllToppings[BurgerTopping.Pickles] = new BurgerIngredient(BurgerTopping.Pickles, "Pickles", true, true);
            AllToppings[BurgerTopping.Bacon] = new BurgerIngredient(BurgerTopping.Bacon, "Bacon", false, false);
            AllToppings[BurgerTopping.Lettuce] = new BurgerIngredient(BurgerTopping.Lettuce, "Lettuce", false, false);
            AllToppings[BurgerTopping.Tomato] = new BurgerIngredient(BurgerTopping.Tomato, "Tomato", false, false);
        }
    }
}
