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
    public class VeggieBurger
    {
        /// <summary>
        /// The name of the VeggieBurger instance
        /// </summary>
        public string Name { get; } = "Veggie Burger";

        /// <summary>
        /// The description of this burger
        /// </summary>
        public string Description { get; } = "A vegetarian patty with pepper jack cheese, Chipotle mayo, lettuce, and tomato on top of a toasted bun";

        /// <summary>
        /// Whether this burger contains chipotle mayo
        /// </summary>
        public bool ChipotleMayo { get; set; } = true;

        /// <summary>
        /// Whether this burger contains lettuce
        /// </summary>
        public bool Lettuce { get; set; } = true;

        /// <summary>
        /// Whether this burger contains tomato
        /// </summary>
        public bool Tomato { get; set; } = true;

        /// <summary>
        /// Whether this burger contains onions
        /// </summary>
        public bool Onions { get; set; } = false;

        /// <summary>
        /// Whether this burger contains pickles
        /// </summary>
        public bool Pickles { get; set; } = false;

        /// <summary>
        /// The default cheese for this burger.
        /// </summary>
        private Cheese _defaultCheese = Cheese.PepperJack;

        /// <summary>
        /// The type of cheese on this burger.
        /// </summary>
        public Cheese TypeOfCheese
        {
            get => _defaultCheese;
            set
            {
                if(value == _defaultCheese || value == Cheese.None)
                {
                    _defaultCheese = value;
                }
            }
        }

        /// <summary>
        /// The default number of patties on this burger.
        /// </summary>
        private int _defaultPattie = 1;

        /// <summary>
        /// The number of patties on this burger.
        /// </summary>
        public int Patties
        {
            get => _defaultPattie;
            set
            {
                if(value == _defaultPattie || value == 2)
                {
                    _defaultPattie = value;
                }
            }
        }

        /// <summary>
        /// The price of this burger
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 6.99m;
                if(Patties == 2)
                {
                    cost += 2.00m;
                }
                return cost;
            }
        }

        /// <summary>
        /// The total number of calories in this burger
        /// </summary>
        public uint Calories
        {
            get
            {
                uint cals = 585;

                if(TypeOfCheese != Cheese.PepperJack)
                {
                    cals -= 85;
                }
                else if(TypeOfCheese != Cheese.PepperJack && Patties == 2)
                {
                    cals += 250;
                }
                else if (TypeOfCheese == Cheese.PepperJack && Patties == 2)
                {
                    cals += 250;
                    cals += 85;
                }
                else if(ChipotleMayo == false)
                {
                    cals -= 90;
                }
                else if(Lettuce == false)
                {
                    cals -= 5;
                }
                else if(Tomato == false)
                {
                    cals -= 5;
                }
                else if(Onions == true)
                {
                    cals += 5;
                }
                else if(Pickles == true)
                {
                    cals += 5;
                }

                return cals;
            }
        }

        /// <summary>
        /// Information for the preparation of this burger
        /// </summary>
        public IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if(TypeOfCheese != Cheese.PepperJack)
                {
                    instructions.Add("Hold Pepper Jack Cheese");
                }
                else if(ChipotleMayo == false)
                {
                    instructions.Add("Hold Chipotle Mayo");
                }
                else if(Lettuce == false)
                {
                    instructions.Add("Hold Lettuce");
                }
                else if(Tomato == false)
                {
                    instructions.Add("Hold Tomato");
                }
                else if(Onions == true)
                {
                    instructions.Add("Add Onions");
                }
                else if(Pickles == true)
                {
                    instructions.Add("Add Pickles");
                }
                else if(Patties == 2)
                {
                    instructions.Add("Double.");
                }

                return instructions;
            }
        }
    }
}
