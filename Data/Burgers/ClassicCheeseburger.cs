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
    public class ClassicCheeseburger
    {
        /// <summary>
        /// The name of the ClassicCheeseburger class
        /// </summary>
        public string Name { get; } = "Classic Cheeseburger";

        /// <summary>
        /// The description of this burger
        /// </summary>
        public string Description { get; } = "Traditional cheeseburger with American cheese, ketchup, mustard, onions, and pickles on a toasted bun";

        /// <summary>
        /// Whether this burger contains ketchup
        /// </summary>
        public bool Ketchup { get; set; } = true;

        /// <summary>
        /// Whether this burger contains Mustard
        /// </summary>
        public bool Mustard { get; set; } = true;

        /// <summary>
        /// Whether this burger contains onions
        /// </summary>
        public bool Onions { get; set; } = true;

        /// <summary>
        /// Whether this burger contains pickles
        /// </summary>
        public bool Pickles { get; set; } = true;

        /// <summary>
        /// Whether this burger contains bacon
        /// </summary>
        public bool Bacon { get; set; } = false;

        /// <summary>
        /// Whether this burger contains lettuce
        /// </summary>
        public bool Lettuce { get; set; } = false;

        /// <summary>
        /// Whether this burger contains tomato
        /// </summary>
        public bool Tomato { get; set; } = false;

        /// <summary>
        /// The default cheese for this burger.
        /// </summary>
        private Cheese _defaultCheese = Cheese.American;

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
                if(value == _defaultPattie || value == 2 || value == 3)
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
                decimal cost = 6.29m;

                if(Bacon == true)
                {
                    cost += 1.00m;
                }
                else if(Lettuce == true)
                {
                    cost += .25m;
                }
                else if(Tomato == true)
                {
                    cost += .25m;
                }
                else if(Patties == 2)
                {
                    cost += 2.00m;
                }
                else if(Patties == 3)
                {
                    cost += 2.00m;
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
                uint cals = 615;

                if(TypeOfCheese != Cheese.American)
                {
                    cals -= 80;
                }
                else if(TypeOfCheese != Cheese.American && Patties == 2)
                {
                    cals += 350;
                }
                else if (TypeOfCheese != Cheese.American && Patties == 3)
                {
                    cals += 350;
                    cals += 350;
                }
                else if (TypeOfCheese == Cheese.American && Patties == 2)
                {
                    cals += 350;
                    cals += 80;
                }
                else if (TypeOfCheese == Cheese.American && Patties == 3)
                {
                    cals += 350;
                    cals += 350;
                    cals += 80;
                    cals += 80;
                }
                else if(Ketchup == false)
                {
                    cals -= 20;
                }
                else if(Mustard == false)
                {
                    cals -= 5;
                }
                else if(Onions == false)
                {
                    cals -= 5;
                }
                else if(Pickles == false)
                {
                    cals -= 5;
                }
                else if(Bacon == true)
                {
                    cals += 75;
                }
                else if(Lettuce == true)
                {
                    cals += 5;
                }
                else if(Tomato == true)
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

                if(TypeOfCheese != Cheese.American)
                {
                    instructions.Add("Hold American Cheese");
                }
                else if(Ketchup == false)
                {
                    instructions.Add("Hold Ketchup");
                }
                else if(Mustard == false)
                {
                    instructions.Add("Hold Mustard");
                }
                else if(Onions == false)
                {
                    instructions.Add("Hold Onions");
                }
                else if(Pickles == false)
                {
                    instructions.Add("Hold Pickles");
                }
                else if(Bacon == true)
                {
                    instructions.Add("Add Bacon");
                }
                else if(Lettuce == true)
                {
                    instructions.Add("Add Lettuce");
                }
                else if(Tomato == true)
                {
                    instructions.Add("Add Tomato");
                }
                else if(Patties == 2)
                {
                    instructions.Add("Double.");
                }
                else if(Patties == 3)
                {
                    instructions.Add("Triple.");
                }

                return instructions;
            }
        }
    }
}
