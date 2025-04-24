using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of MushroomSwissBurger class
    /// </summary>
    public class MushroomSwissBurger : Burger
    {
        /// <summary>
        /// The name of the MushroomSwissBurger instance
        /// </summary>
        public override string Name { get; } = "Mushroom Swiss Burger";

        /// <summary>
        /// The description of this burger
        /// </summary>
        public override string Description { get; } = "A burger with grilled onions, mushroom, and Swiss cheese on top of a toasted bun";

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


        public MushroomSwissBurger()
        {
            _startingCals = 150;
            _startingPrice = 6.99m;
            _maxPatties = 2;
            _patties = 1;
            _veggie = false;
            _defaultCheese = Cheese.Swiss;
            _cheeseChoice = Cheese.Swiss;
            CheeseOptions.Add(_defaultCheese);
            CheeseOptions.Add(Cheese.None);
            AllToppings[BurgerTopping.GrilledOnions] = new BurgerIngredient(BurgerTopping.GrilledOnions, "Grilled Onions", true, true, 1.00m, 50);
            AllToppings[BurgerTopping.GrilledMushrooms] = new BurgerIngredient(BurgerTopping.GrilledMushrooms, "Grilled Mushrooms", true, true, 1.00m, 60);
            foreach (BurgerIngredient ing in AllToppings.Values)
            {
                ing.PropertyChanged += HandleIngredientChanged!;
            }
        }
    }
}
