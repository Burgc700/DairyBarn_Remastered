using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyBarn.Data
{
    /// <summary>
    /// Implements common code in all the burger menu items.
    /// </summary>
    public abstract class Burger : IMenuItem
    {
        /// <summary>
        /// Finds the listens and tells it that the property has changed.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gets the information for the burger ingredients.
        /// </summary>
        public class BurgerIngredient
        {
            /// <summary>
            /// Listens to Included to see if a topping is included or not included.
            /// </summary>
            public event PropertyChangedEventHandler? PropertyChanged;

            /// <summary>
            /// Gets the different types of burger toppings.
            /// </summary>
            public BurgerTopping Toppings { get; }

            /// <summary>
            /// Gets the names of the burger toppings.
            /// </summary>
            public string Name { get; }

            /// <summary>
            /// Sets the default value for if an topping is included.
            /// </summary>
            private bool _included = true;

            /// <summary>
            /// If the topping is being included on this burger.
            /// </summary>
            public bool Included
            {
                get => _included;
                set
                {
                    _included = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Included)));
                }
            }

            /// <summary>
            /// If the topping is default on this burger.
            /// </summary>
            public bool Default { get; set; }

            /// <summary>
            /// The constructor.
            /// </summary>
            /// <param name="topp"></param>
            /// <param name="name">The name of the topping.</param>
            /// <param name="included">If the topping is included on the burger.</param>
            /// <param name="def">If the topping is a default item on the burger.</param>
            public BurgerIngredient(BurgerTopping topp, string name, bool included, bool def)
            {
                Toppings = topp;
                Name = name;
                Included = included;
                Default = def;
            }
        }

        /// <summary>
        /// Stores the toppings on the current burger.
        /// </summary>
        public Dictionary<BurgerTopping, BurgerIngredient> AllToppings { get; } = new();

        /// <summary>
        /// The default value for if it is part of pick two.
        /// </summary>
        private bool _partOfPickTwo = false;

        /// <summary>
        /// Determines if this burger is part of pick two already.
        /// </summary>
        public bool PartOfPickTwo
        {
            get => _partOfPickTwo;
            set
            {
                _partOfPickTwo = value;
                OnPropertyChanged(nameof(PartOfPickTwo));
            }

            
        }

        /// <summary>
        /// Gets the name of the burger.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the description of the burger.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// The starting price for the burger.
        /// </summary>
        protected decimal _startingPrice;

        /// <summary>
        /// Calculates the price for the burger.
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal price = _startingPrice;
                if (Patties > 1)
                {
                    price += (2.00m) * (Patties - 1);
                }
                foreach (BurgerTopping topping in AllToppings.Keys)
                {
                    if (AllToppings[topping].Included && !AllToppings[topping].Default)
                    {
                        price += IngredientDatabase.GetBurgerToppingPrice(AllToppings[topping].Toppings);
                    }
                }
                return price;
            }
        }

        /// <summary>
        /// The starting calories for the burger.
        /// </summary>
        protected uint _startingCals;

        /// <summary>
        /// Calculates the calories for the burger.
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = _startingCals;

                cals += (IngredientDatabase.GetCheeseCalories(CheeseChoice) * Patties);

                if (Veggie == false)
                {
                    cals += (350 * Patties);
                }
                if (Veggie == true)
                {
                    cals += (250 * Patties);
                }
                foreach (BurgerTopping topping in AllToppings.Keys)
                {
                    if (AllToppings[topping].Included)
                    {
                        cals += IngredientDatabase.GetBurgerToppingCalories(AllToppings[topping].Toppings);
                    }
                }
                return cals;
            }
        }

        /// <summary>
        /// Adds the preparation information for this burger.
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if (Veggie == true && _defaultVeggie == false)
                {
                    instructions.Add("Add Veggie Patties");
                }
                if (Patties == 2)
                {
                    instructions.Add("Double");
                }
                if (Patties == 3)
                {
                    instructions.Add("Triple");
                }   
                if(CheeseChoice != _defaultCheese && CheeseChoice != Cheese.None)
                {
                    instructions.Add($"Add {CheeseChoice} Cheese");
                }
                if(CheeseChoice != Cheese.None && _defaultCheese == Cheese.None)
                {
                    instructions.Add($"Add {CheeseChoice} Cheese");
                }
                if(CheeseChoice == Cheese.None)
                {
                    instructions.Add($"Hold {_defaultCheese} Cheese");
                }
                
                foreach (BurgerTopping topping in AllToppings.Keys)
                {
                    if (AllToppings[topping].Included && !AllToppings[topping].Default)
                    {
                        instructions.Add($"Add {AllToppings[topping].Name}");
                    }
                    if (!AllToppings[topping].Included && AllToppings[topping].Default)
                    {
                        instructions.Add($"Hold {AllToppings[topping].Name}");
                    }
                }
                return instructions;
            }
        }


        /// <summary>
        /// The cheese options for a burger.
        /// </summary>
        public List<Cheese> CheeseOptions { get; } = new();

        /// <summary>
        /// The choice of cheese for this burger.
        /// </summary>
        protected Cheese _cheeseChoice = Cheese.None;

        /// <summary>
        /// The default cheese option for the burger.
        /// </summary>
        protected Cheese _defaultCheese = Cheese.None;

        /// <summary>
        /// The choice of cheese for the burger.
        /// </summary>
        public Cheese CheeseChoice //like sauce choice
        {
            get => _cheeseChoice;
            set
            {
                if (CheeseOptions.Contains(value))
                {
                    _cheeseChoice = value;
                }
                OnPropertyChanged(nameof(CheeseChoice));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The minimum number of patties allowed on burgers.
        /// </summary>
        protected uint _minPatties = 1;

        /// <summary>
        /// The default number of patties on the burger.
        /// </summary>
        protected uint _defaultPatties = 1;

        /// <summary>
        /// The maximum number of patties on the burger.
        /// </summary>
        protected uint _maxPatties;

        /// <summary>
        /// The number of patties on the burger.
        /// </summary>
        protected uint _patties;

        /// <summary>
        /// The number of patties for the burger.
        /// </summary>
        public uint Patties
        {
            get => _patties;
            set
            {
                if (value >= _minPatties && value <= _maxPatties)
                {
                    _patties = value;
                }
                OnPropertyChanged(nameof(Patties));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
            }
        }

        /// <summary>
        /// The default veggie value for the burgers
        /// </summary>
        protected bool _defaultVeggie;

        /// <summary>
        /// Whether the burger has veggie patties.
        /// </summary>
        protected bool _veggie;

        /// <summary>
        /// If the patties are veggie patties.
        /// </summary>
        public abstract bool Veggie { get; set; }

        /// <summary>
        /// Gets the name of the burger.
        /// </summary>
        /// <returns>The name of the burger.</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Helper method to invoke the properties that are changing when customizing the control.
        /// </summary>
        /// <param name="propertyName">The property we are invoking the change on.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Changes price, calories, and preparation information for different toppings.
        /// </summary>
        /// <param name="sender">Any of the check boxs to customize the burger toppings.</param>
        /// <param name="e">Changes the properties and reflects them on the GUI.</param>
        protected void HandleIngredientChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PreparationInformation)));
        }
    }
}
