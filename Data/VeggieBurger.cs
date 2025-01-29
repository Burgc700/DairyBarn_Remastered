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
        /// Whether this burger contains pepper jack cheese
        /// </summary>
        public bool PepperJackCheese { get; set; } = true;

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
        /// The price of this burger
        /// </summary>
        public decimal Price
        {
            get
            {
                decimal cost = 6.99m;
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

                if(PepperJackCheese == false)
                {
                    cals -= 85;
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

                if(PepperJackCheese == false)
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

                return instructions;
            }
        }
    }
}
