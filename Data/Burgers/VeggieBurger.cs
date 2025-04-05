using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Definition of VeggieBurger class
    /// </summary>
    public class VeggieBurger : Burger
    {
        /// <summary>
        /// The name of the VeggieBurger instance
        /// </summary>
        public override string Name { get; } = "Veggie Burger";

        /// <summary>
        /// The description of this burger
        /// </summary>
        public override string Description { get; } = "A vegetarian patty with pepper jack cheese, Chipotle mayo, lettuce, and tomato on top of a toasted bun";

        /// <summary>
        /// Determines if the patty is a veggie patty
        /// </summary>
        public override bool Veggie 
        {
            get => _veggie;
            set
            {
                if(_veggie == true)
                {
                    _veggie = value;
                }
                if (_veggie == false)
                {
                    _veggie = true;
                }
                OnPropertyChanged(nameof(Veggie));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The constructor
        /// </summary>
        public VeggieBurger()
        {
            _startingCals = 150;
            _startingPrice = 6.99m;
            _maxPatties = 2;
            _patties = 1;
            _defaultVeggie = true;
            _veggie = true;
            _defaultCheese = Cheese.PepperJack;
            _cheeseChoice = Cheese.PepperJack;
            CheeseOptions.Add(_defaultCheese);
            CheeseOptions.Add(Cheese.None);
            AllToppings[BurgerTopping.ChipotleMayo] = new BurgerIngredient(BurgerTopping.ChipotleMayo, "Chipotle Mayo", true, true);
            AllToppings[BurgerTopping.Lettuce] = new BurgerIngredient(BurgerTopping.Lettuce, "Lettuce", true, true);
            AllToppings[BurgerTopping.Tomato] = new BurgerIngredient(BurgerTopping.Tomato, "Tomato", true, true);
            AllToppings[BurgerTopping.Onions] = new BurgerIngredient(BurgerTopping.Onions, "Onions", false, false);
            AllToppings[BurgerTopping.Pickles] = new BurgerIngredient(BurgerTopping.Pickles, "Pickles", false, false);
            foreach (BurgerIngredient ing in AllToppings.Values)
            {
                ing.PropertyChanged += HandleIngredientChanged!;
            }
        }
    }
}
