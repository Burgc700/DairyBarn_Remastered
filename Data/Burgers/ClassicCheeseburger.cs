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
        /// If the patties are veggie patties.
        /// </summary>
        public override bool Veggie
        {
            get => _veggie;
            set
            {
                _veggie = value;
                OnPropertyChanged(nameof(Veggie));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The constructor
        /// </summary>
        public ClassicCheeseburger()
        {
            _startingCals = 150;
            _startingPrice = 6.29m;
            _maxPatties = 3;
            _patties = 1;
            _veggie = false;
            _defaultCheese = Cheese.American;
            _cheeseChoice = Cheese.American;
            CheeseOptions.Add(_defaultCheese);
            CheeseOptions.Add(Cheese.None);
            AllToppings[BurgerTopping.Ketchup] = new BurgerIngredient(BurgerTopping.Ketchup, "Ketchup", true, true, 0.00m, 20);
            AllToppings[BurgerTopping.Mustard] = new BurgerIngredient(BurgerTopping.Mustard, "Mustard", true, true, 0.00m, 5);
            AllToppings[BurgerTopping.Onions] = new BurgerIngredient(BurgerTopping.Onions, "Onions", true, true, 0.00m, 5);
            AllToppings[BurgerTopping.Pickles] = new BurgerIngredient(BurgerTopping.Pickles, "Pickles", true, true, 0.00m, 5);
            AllToppings[BurgerTopping.Bacon] = new BurgerIngredient(BurgerTopping.Bacon, "Bacon", false, false, 1.00m, 75);
            AllToppings[BurgerTopping.Lettuce] = new BurgerIngredient(BurgerTopping.Lettuce, "Lettuce", false, false, .25m, 5);
            AllToppings[BurgerTopping.Tomato] = new BurgerIngredient(BurgerTopping.Tomato, "Tomato", false, false, .25m, 5);
            foreach (BurgerIngredient ing in AllToppings.Values)
            {
                ing.PropertyChanged += HandleIngredientChanged!;
            }
        }
    }
}
