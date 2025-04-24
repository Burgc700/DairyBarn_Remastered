using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Class definition to build your own burger.
    /// </summary>
    public class BYOBurger : Burger
    {
        /// <summary>
        /// The name of this burger.
        /// </summary>
        public override string Name => "Build-Your-Own Burger";

        /// <summary>
        /// The description of this burger.
        /// </summary>
        public override string Description => "Your choice of burger patty, cheese, and toppings.";

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
        public BYOBurger()
        {
            _startingCals = 150;
            _startingPrice = 6.29m;
            _maxPatties = 3;
            _patties = 1;
            _veggie = false;
            _defaultCheese = Cheese.American;
            _cheeseChoice = Cheese.American;
            CheeseOptions.Add(_defaultCheese);
            CheeseOptions.Add(Cheese.Swiss);
            CheeseOptions.Add(Cheese.PepperJack);
            CheeseOptions.Add(Cheese.Cheddar);
            CheeseOptions.Add(Cheese.None);
            AllToppings[BurgerTopping.Ketchup] = new BurgerIngredient(BurgerTopping.Ketchup, "Ketchup", false, false, 0.00m, 20);
            AllToppings[BurgerTopping.Mustard] = new BurgerIngredient(BurgerTopping.Mustard, "Mustard", false, false, 0.00m, 5);
            AllToppings[BurgerTopping.Onions] = new BurgerIngredient(BurgerTopping.Onions, "Onions", false, false, 0.00m, 5);
            AllToppings[BurgerTopping.Pickles] = new BurgerIngredient(BurgerTopping.Pickles, "Pickles", false, false, 0.00m, 5);
            AllToppings[BurgerTopping.Bacon] = new BurgerIngredient(BurgerTopping.Bacon, "Bacon", false, false, 1.00m, 75);
            AllToppings[BurgerTopping.Lettuce] = new BurgerIngredient(BurgerTopping.Lettuce, "Lettuce", false, false, .25m, 5);
            AllToppings[BurgerTopping.Tomato] = new BurgerIngredient(BurgerTopping.Tomato, "Tomato", false, false, .25m, 5);
            AllToppings[BurgerTopping.CrispyFriedOnions] = new BurgerIngredient(BurgerTopping.CrispyFriedOnions, "Crispy Fried Onions", false, false, .50m, 70);
            AllToppings[BurgerTopping.BBQSauce] = new BurgerIngredient(BurgerTopping.BBQSauce, "BBQ Sauce", false, false, .25m, 40);
            AllToppings[BurgerTopping.GrilledMushrooms] = new BurgerIngredient(BurgerTopping.GrilledMushrooms, "Grilled Mushrooms", false, false, 1.00m, 60);
            AllToppings[BurgerTopping.GrilledOnions] = new BurgerIngredient(BurgerTopping.GrilledOnions, "Grilled Onions", false, false, 1.00m, 50);
            AllToppings[BurgerTopping.ChipotleMayo] = new BurgerIngredient(BurgerTopping.ChipotleMayo, "Chipotle Mayo", false, false, .25m, 90);
            foreach (BurgerIngredient ing in AllToppings.Values)
            {
                ing.PropertyChanged += HandleIngredientChanged!;
            }
        }
    }
}
