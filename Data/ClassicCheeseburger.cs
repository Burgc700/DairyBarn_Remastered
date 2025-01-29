using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Whether this burger contains American cheese
        /// </summary>
        public bool AmericanCheese { get; set; } = true;

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

                if(AmericanCheese == false)
                {
                    cals -= 80;
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

                if(AmericanCheese == false)
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

                return instructions;
            }
        }
    }
}
